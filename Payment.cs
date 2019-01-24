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

        public async Task<QuickPay> QuickPay(Object data)
        {
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/quickpay");
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/quickpay");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature(compactJson, method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            QuickPay result = new QuickPay();
            try
            {
                var content = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ProjectEnvironment.accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
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

        public async Task<Refund> Refund(Object data)
        {
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/refund");
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/refund");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature(compactJson, method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            Refund result = new Refund();
            try
            {
                var buffer = System.Text.Encoding.UTF8.GetBytes(compactJson);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ProjectEnvironment.accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
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

        public async Task<Reverse> Reverse(Object data)
        {
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/reverse");
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/reverse");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature(compactJson, method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            Reverse result = new Reverse();
            try
            {
                var content = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ProjectEnvironment.accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
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

        public async Task<PaymentTransactionByID> GetPaymentTransactionByID(string transactionId)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/transaction/", transactionId);
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/transaction/", transactionId);
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            PaymentTransactionByID result = new PaymentTransactionByID();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ProjectEnvironment.accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.GetAsync(requestUrl);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<PaymentTransactionByID>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<PaymentTransactionByID>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<PaymentTransactionByOrderID> GetPaymentTransactionByOrderID(string orderId)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/transaction/order/", orderId);
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/transaction/order/", orderId);
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            PaymentTransactionByOrderID result = new PaymentTransactionByOrderID();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ProjectEnvironment.accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.GetAsync(requestUrl);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<PaymentTransactionByOrderID>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<PaymentTransactionByOrderID>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<CreateTransactionQrCodeUrl> CreateTransactionQRCodeUrl(Object data)
        {
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/transaction/qrcode");
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/transaction/qrcode");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature(compactJson, method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            CreateTransactionQrCodeUrl result = new CreateTransactionQrCodeUrl();
            try
            {
                var content = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ProjectEnvironment.accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.PostAsync(requestUrl, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<CreateTransactionQrCodeUrl>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<CreateTransactionQrCodeUrl>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }


        public async Task<GetTransactionQrCodeUrl> GetTransactionQrCodeUrl(string limit, string type, string expiryType)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrlEncode = "";
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/transaction/qrcodes?order[]=-createdAt&limit="+limit+"&filter={\"type\":\""+type+"\", \"expiry.type\": \""+ expiryType + "\"}");
                requestUrlEncode = String.Concat(Url.SandBoxOpen, "/v3/payment/transaction/qrcodes?order[]=-createdAt&limit="+limit+"&filter=%7B%22type%22:%22"+type+"%22,%20%22expiry.type%22:%20%22"+expiryType+"%22%7D");
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/transaction/qrcodes?order[]=-createdAt&limit=" + limit + "&filter={\"type\":\"" + type + "\", \"expiry.type\": \"" + expiryType + "\"}");
                requestUrlEncode = String.Concat(Url.ProductionOpen, "/v3/payment/transaction/qrcodes%3Forder%5B%5D%3D-createdAt%26limit%3D"+limit+"%26filter%3D%7B%22type%22%3A%22"+type+"%22%2C%20%22expiry.type%22%3A%20%22"+expiryType+"%22%7D");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, ProjectEnvironment.privateKey, requestUrlEncode, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            GetTransactionQrCodeUrl result = new GetTransactionQrCodeUrl();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ProjectEnvironment.accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.GetAsync(requestUrl);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetTransactionQrCodeUrl>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<GetTransactionQrCodeUrl>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<GetTransactionQrCodeUrlByCode> GetTransactionQrCodeUrlByCode(string qrCode)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/transaction/qrcode/", qrCode);
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/transaction/qrcode/", qrCode);
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            GetTransactionQrCodeUrlByCode result = new GetTransactionQrCodeUrlByCode();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ProjectEnvironment.accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.GetAsync(requestUrl);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetTransactionQrCodeUrlByCode>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<GetTransactionQrCodeUrlByCode>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<GetTransactionsByCode> GetTransactionsByCode(string qrCode)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/payment/transaction/qrcode/", qrCode, "/transactions");
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/payment/transaction/qrcode/", qrCode, "/transactions");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            GetTransactionsByCode result = new GetTransactionsByCode();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ProjectEnvironment.accessToken);
                client.DefaultRequestHeaders.Add("X-Nonce-Str", nonceStr);
                client.DefaultRequestHeaders.Add("X-Signature", signatureResult);
                client.DefaultRequestHeaders.Add("X-Timestamp", timestamp);
                var response = await client.GetAsync(requestUrl);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<GetTransactionsByCode>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<GetTransactionsByCode>(response.Content.ReadAsStringAsync().Result);
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
