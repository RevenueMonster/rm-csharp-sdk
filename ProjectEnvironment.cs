using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueMonsterOpenAPI
{
    public class ProjectEnvironment
    {
        public static String clientId { get; set; }
        public static String clientSecret { get; set; }
        public static String environment { get; set; }
        public static String accessToken { get; set; }
        public static String refreshToken { get; set; }
        public static String privateKey { get; set; }

        public void setEnvironment(string ClientId,string ClientSecret,string Environment)
        {
            clientId = ClientId;
            clientSecret = ClientSecret;
            environment = Environment;
        }
    }
}
