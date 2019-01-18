using Newtonsoft.Json;
using RevenueMonsterOpenAPI.Constant;
using RevenueMonsterOpenAPI.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RevenueMonsterOpenAPI.Util;

namespace RevenueMonsterOpenAPI
{
    class Signature
    {
        public string GenerateSignature(string compactJson, string method, string nonceStr, string privateKey, string requestUrl, string signType, string timestamp, string environment)
        {
            string signedData = "";
            try
            {
                //GenerateSignatureResult result = new GenerateSignatureResult();
                string plainText = "";
                if (compactJson != "")
                {
                    string encodedData = Encode.Base64Encode(compactJson);
                    plainText = String.Format("data={0}&method={1}&nonceStr={2}&requestUrl={3}&signType={4}&timestamp={5}", encodedData, method, nonceStr, requestUrl, signType, timestamp);
                }
                else
                {
                    plainText = String.Format("method={0}&nonceStr={1}&requestUrl={2}&signType={3}&timestamp={4}", method, nonceStr, requestUrl, signType, timestamp);
                }
                byte[] plainTextByte = Encoding.UTF8.GetBytes(plainText);
                RSACryptoServiceProvider provider = PemKeyUtils.GetRSAProviderFromPemFile(privateKey);
                string prikey = provider.ToXmlString(true);
                byte[] signedBytes = provider.SignData(plainTextByte, CryptoConfig.MapNameToOID("SHA256"));
                signedData = Convert.ToBase64String(signedBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return signedData;
        }

        public static byte[] RSAEncrypt(byte[] plaintext, string destKey)
        {
            byte[] encryptedData;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(destKey);
            encryptedData = rsa.Encrypt(plaintext, true);
            rsa.Dispose();
            return encryptedData;
        }


        public async Task<VerifySignatureResult> VerifySignature(Object data, string method, string nonceStr, string publicKey, string requestUrl, string signType, string timestamp, string signature, string environment)
        {
            VerifySignatureResult result = new VerifySignatureResult();
            try
            {
                string url = "";
                if (environment == "sandbox")
                {
                    url = String.Concat(Url.SandBoxOpen, "/tool/signature/verify");
                }
                else if (environment == "production")
                {
                    url = String.Concat(Url.ProductionOpen, "/tool/signature/verify");
                }

                VerifySignatureRequestData verifySignatureData = new VerifySignatureRequestData();
                verifySignatureData.data = data;
                verifySignatureData.method = method;
                verifySignatureData.nonceStr = nonceStr;
                verifySignatureData.publicKey = publicKey;
                verifySignatureData.requestUrl = requestUrl;
                verifySignatureData.signType = signType;
                verifySignatureData.timestamp = timestamp;
                verifySignatureData.signature = signature;

                var content = JsonConvert.SerializeObject(verifySignatureData); 
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<VerifySignatureResult>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<VerifySignatureResult>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }
    }
}
