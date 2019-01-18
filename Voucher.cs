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
    public class Voucher
    {
        public async Task<IssueVoucherResult> IssueVoucher(string batchKey, string accessToken, string privateKey, string environment)
        {
            Object data = new { };
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string encode = Encode.Base64Encode(compactJson);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/voucher-batch/" + batchKey + "/issue");
            }
            else if (environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/voucher-batch/" + batchKey + "/issue");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature(null, method, nonceStr, privateKey, requestUrl, signType, timestamp, environment);
            signatureResult = "sha256 " + signatureResult;
            IssueVoucherResult result = new IssueVoucherResult();
            try
            {
                var content = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.PostAsync(requestUrl, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<IssueVoucherResult>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<IssueVoucherResult>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<VoidVoucherResult> VoidVoucher(string code, string accessToken, string privateKey, string environment)
        {
            Object data = new { };
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string encode = Encode.Base64Encode(compactJson);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/voucher/" + code + "/void");
            }
            else if (environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/voucher/" + code + "/void");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature(null, method, nonceStr, privateKey, requestUrl, signType, timestamp, environment);
            signatureResult = "sha256 " + signatureResult;
            VoidVoucherResult result = new VoidVoucherResult();
            try
            {
                var content = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.PostAsync(requestUrl, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<VoidVoucherResult>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<VoidVoucherResult>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<GetVoucherByCodeResult> GetVoucherByCode(string code, string accessToken, string privateKey, string environment)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/voucher/" + code);
            }
            else if (environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/voucher/" + code);
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, privateKey, requestUrl, signType, timestamp, environment);
            signatureResult = "sha256 " + signatureResult;
            GetVoucherByCodeResult result = new GetVoucherByCodeResult();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.GetAsync(requestUrl);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetVoucherByCodeResult>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<GetVoucherByCodeResult>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<GetVoucherBatchesResult> GetVoucherBatches(string accessToken, string privateKey, string environment)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/voucher-batches");
            }
            else if (environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/voucher-batches");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, privateKey, requestUrl, signType, timestamp, environment);
            signatureResult = "sha256 " + signatureResult;
            GetVoucherBatchesResult result = new GetVoucherBatchesResult();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.GetAsync(requestUrl);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetVoucherBatchesResult>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<GetVoucherBatchesResult>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }


        public async Task<GetVoucherBatchByKeyResult> GetVoucherBatchByKey(string batchKey, string accessToken, string privateKey, string environment)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/voucher-batch/" + batchKey);
            }
            else if (environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/voucher-batch/" + batchKey);
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, privateKey, requestUrl, signType, timestamp, environment);
            signatureResult = "sha256 " + signatureResult;
            GetVoucherBatchByKeyResult result = new GetVoucherBatchByKeyResult();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.GetAsync(requestUrl);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetVoucherBatchByKeyResult>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<GetVoucherBatchByKeyResult>(response.Content.ReadAsStringAsync().Result);
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
