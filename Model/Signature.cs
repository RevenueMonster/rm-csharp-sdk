using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueMonsterOpenAPI.Model
{
    public class GenerateSignatureResult
    {
        public string data { get; set; }
        public string sequenceData { get; set; }
        public string signature { get; set; }
        public Error error { get; set; }
    }

    public class VerifySignatureResult
    {
        public Boolean isValid { get; set; }
        public Error error { get; set; }
    }

    public class GenerateSignatureRequestData
    {
        public Object data { get; set; }
        public string method { get; set; }
        public string nonceStr { get; set; }
        public string privateKey { get; set; }
        public string requestUrl { get; set; }
        public string signType { get; set; }
        public string timestamp { get; set; }
    }

    public class VerifySignatureRequestData
    {
        public Object data { get; set; }
        public string method { get; set; }
        public string nonceStr { get; set; }
        public string publicKey { get; set; }
        public string requestUrl { get; set; }
        public string signType { get; set; }
        public string timestamp { get; set; }
        public string signature { get; set; }
    }
}
