using Newtonsoft.Json;
using RevenueMonsterOpenAPI.Constant;
using RevenueMonsterOpenAPI.Model;
using RevenueMonsterOpenAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RevenueMonsterOpenAPI
{
    public class Loyalty
    {
        public async Task<LoyaltyPoint> GiveLoyaltyPoint(Object data)
        {
            string compactJson = SignatureUtil.GenerateCompactJson(data);
            string method = "post";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/loyalty/reward");
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/loyalty/reward");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature(compactJson, method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            LoyaltyPoint result = new LoyaltyPoint();
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
                    result = JsonConvert.DeserializeObject<LoyaltyPoint>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<LoyaltyPoint>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<GetLoyaltyMembersResult> GetLoyaltyMembers()
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/loyalty/members");
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/loyalty/members");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            GetLoyaltyMembersResult result = new GetLoyaltyMembersResult();
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
                    result = JsonConvert.DeserializeObject<GetLoyaltyMembersResult>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<GetLoyaltyMembersResult>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<GetLoyaltyMemberResult> GetLoyaltyMember(string memberId)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/loyalty/member/"+memberId);
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/loyalty/member/"+memberId);
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            GetLoyaltyMemberResult result = new GetLoyaltyMemberResult();
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
                    result = JsonConvert.DeserializeObject<GetLoyaltyMemberResult>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<GetLoyaltyMemberResult>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<LoyaltyMemberPointHistories> GetLoyaltyMemberPointHistory(string memberId)
        {
            string method = "get";
            string nonceStr = RandomString.GenerateRandomString(32);
            string requestUrl = "";
            if (ProjectEnvironment.environment == "sandbox")
            {
                requestUrl = String.Concat(Url.SandBoxOpen, "/v3/loyalty/member/"+memberId+"/history");
            }
            else if (ProjectEnvironment.environment == "production")
            {
                requestUrl = String.Concat(Url.ProductionOpen, "/v3/loyalty/member/" + memberId + "/history");
            }
            string signType = "sha256";
            string timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            Signature signature = new Signature();
            string signatureResult = "";
            signatureResult = signature.GenerateSignature("", method, nonceStr, ProjectEnvironment.privateKey, requestUrl, signType, timestamp, ProjectEnvironment.environment);
            signatureResult = "sha256 " + signatureResult;
            LoyaltyMemberPointHistories result = new LoyaltyMemberPointHistories();
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
                    result = JsonConvert.DeserializeObject<LoyaltyMemberPointHistories>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<LoyaltyMemberPointHistories>(response.Content.ReadAsStringAsync().Result);
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
