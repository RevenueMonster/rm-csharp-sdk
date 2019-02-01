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
    public class Authorization
    {
        public async Task<ClientCredentials> GetClientCredentials()
        {
            ClientCredentials result = new ClientCredentials();
            try
            {
                string parameter = String.Concat(ProjectEnvironment.clientId, ":", ProjectEnvironment.clientSecret);
                string encodeParameter = Encode.Base64Encode(parameter);
                string url = "";
                if (ProjectEnvironment.environment == "sandbox")
                {
                    url = String.Concat(Url.SandBoxOAuth, "/v1/token");
                }
                else if (ProjectEnvironment.environment == "production")
                {
                    url = String.Concat(Url.ProductionOAuth, "/v1/token");
                }

                var values = new
                {
                    grantType = "client_credentials"
                };

                var content = JsonConvert.SerializeObject(values);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodeParameter);
                var response = await client.PostAsync(url, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ClientCredentials>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<ClientCredentials>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<ClientCredentials> GetClientCredentials(string clientId, string clientSecret, string environment)
        {
            ClientCredentials result = new ClientCredentials();
            try
            {
                string parameter = String.Concat(clientId, ":", clientSecret);
                string encodeParameter = Encode.Base64Encode(parameter);
                string url = "";
                if (environment == "sandbox")
                {
                    url = String.Concat(Url.SandBoxOAuth, "/v1/token");
                }
                else if (environment == "production")
                {
                    url = String.Concat(Url.ProductionOAuth, "/v1/token");
                }

                var values = new
                {
                    grantType = "client_credentials"
                };

                var content = JsonConvert.SerializeObject(values);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodeParameter);
                var response = await client.PostAsync(url, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ClientCredentials>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<ClientCredentials>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<ClientCredentials> RefreshToken()
        {
            ClientCredentials result = new ClientCredentials();
            try
            {
                string parameter = String.Concat(ProjectEnvironment.clientId, ":", ProjectEnvironment.clientSecret);
                string encodeParameter = Encode.Base64Encode(parameter);
                string url = "";
                if (ProjectEnvironment.environment == "sandbox")
                {
                    url = String.Concat(Url.SandBoxOAuth, "/v1/token");
                } 
                else if (ProjectEnvironment.environment == "production")
                {
                    url = String.Concat(Url.ProductionOAuth, "/v1/token");
                }

                var values = new
                {
                    grantType = "refresh_token",
                    refreshToken = ProjectEnvironment.refreshToken
                };

                var content = JsonConvert.SerializeObject(values);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodeParameter);
                var response = await client.PostAsync(url, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ClientCredentials>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<ClientCredentials>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
            return result;
        }

        public async Task<ClientCredentials> RefreshToken(string clientId, string clientSecret, string refreshToken, string environment)
        {
            ClientCredentials result = new ClientCredentials();
            try
            {
                string parameter = String.Concat(clientId, ":", clientSecret);
                string encodeParameter = Encode.Base64Encode(parameter);
                string url = "";
                if (environment == "sandbox")
                {
                    url = String.Concat(Url.SandBoxOAuth, "/v1/token");
                }
                else if (environment == "production")
                {
                    url = String.Concat(Url.ProductionOAuth, "/v1/token");
                }

                var values = new
                {
                    grantType = "refresh_token",
                    refreshToken = refreshToken
                };

                var content = JsonConvert.SerializeObject(values);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodeParameter);
                var response = await client.PostAsync(url, byteContent);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jsonAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ClientCredentials>(jsonAsString);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<ClientCredentials>(response.Content.ReadAsStringAsync().Result);
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
