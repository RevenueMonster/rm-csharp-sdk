using Newtonsoft.Json;
using RevenueMonsterOpenAPI.Constant;
using RevenueMonsterOpenAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RevenueMonsterOpenAPI
{
    class Signature
    {
        public async Task<GenerateSignatureResult> GenerateSignature(Object data, string method, string nonceStr, string privateKey, string requestUrl, string signType, string timestamp, string environment)
        {
            GenerateSignatureResult result = new GenerateSignatureResult();
            try
            {
                string url = "";
                if (environment == "sandbox")
                {
                    url = String.Concat(Url.SandBoxOpen, "/tool/signature/generate");
                }
                else if (environment == "production")
                {
                    url = String.Concat(Url.ProductionOpen, "/tool/signature/generate");
                }

                GenerateSignatureRequestData generateSignatureData = new GenerateSignatureRequestData();
                if (data != null)
                {
                    generateSignatureData.data = data;
                }
                generateSignatureData.method = method;
                generateSignatureData.nonceStr = nonceStr;
                generateSignatureData.privateKey = privateKey;
                generateSignatureData.requestUrl = requestUrl;
                generateSignatureData.signType = signType;
                generateSignatureData.timestamp = timestamp;

                var content = JsonConvert.SerializeObject(generateSignatureData); 
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GenerateSignatureResult>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<GenerateSignatureResult>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
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
