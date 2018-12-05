using Newtonsoft.Json;
using RevenueMonsterOpenAPI.Constant;
using RevenueMonsterOpenAPI.Model;
using RevenueMonsterOpenAPI.Util;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RevenueMonsterOpenAPI
{
    public class Payment
    {

        public async Task<QuickPay> QuickPay(Object data, string accessToken, string privateKey, string environment)
        {
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string encode = Encode.Base64Encode(compactJson);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/quickpay");
            }
            else if (environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/quickpay");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            string textParameters = String.Format("data={0}&method={1}&nonceStr={2}&requestURl={3}&signType={4}&timestamp=", encode, method, requestUrl, signType, timestamp);
            Signature signature = new Signature();
            GenerateSignatureResult signatureResult = new GenerateSignatureResult();
            signatureResult = await signature.GenerateSignature(data, method, nonceStr, privateKey, requestUrl, signType, timestamp, environment);
            QuickPay result = new QuickPay();
            try
            {
                var content = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult.signature);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.PostAsync(requestUrl, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<QuickPay>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<QuickPay>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<Refund> Refund(Object data, string accessToken, string privateKey, string environment)
        {
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string encode = Encode.Base64Encode(compactJson);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/refund");
            }
            else if (environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/refund");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            string textParameters = String.Format("data={0}&method={1}&nonceStr={2}&requestURl={3}&signType={4}&timestamp=", encode, method, requestUrl, signType, timestamp);
            Signature signature = new Signature();
            GenerateSignatureResult signatureResult = new GenerateSignatureResult();
            signatureResult = await signature.GenerateSignature(data, method, nonceStr, privateKey, requestUrl, signType, timestamp, environment);
            Refund result = new Refund();
            try
            {
                var content = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult.signature);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.PostAsync(requestUrl, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Refund>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<Refund>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<Reverse> Reverse(Object data, string accessToken, string privateKey, string environment)
        {
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string encode = Encode.Base64Encode(compactJson);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/reverse");
            }
            else if (environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/reverse");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            string textParameters = String.Format("data={0}&method={1}&nonceStr={2}&requestURl={3}&signType={4}&timestamp=", encode, method, requestUrl, signType, timestamp);
            Signature signature = new Signature();
            GenerateSignatureResult signatureResult = new GenerateSignatureResult();
            signatureResult = await signature.GenerateSignature(data, method, nonceStr, privateKey, requestUrl, signType, timestamp, environment);
            Reverse result = new Reverse();
            try
            {
                var content = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult.signature);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.PostAsync(requestUrl, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Reverse>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<Reverse>(response.Content.ReadAsStringAsync().Result);
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
