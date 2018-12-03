using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevenueMonsterOpenAPI.Model;

namespace RevenueMonsterOpenAPI.Model
{
    public class ClientCredentials
    {
        public string accessToken { get; set; }
        public string tokenType { get; set; }
        public int expiresIn { get; set; }
        public string refreshToken { get; set; }
        public Error error { get; set; }
    }
    
}
