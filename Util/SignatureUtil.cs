using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RevenueMonsterOpenAPI.Util
{
    class SignatureUtil
    {
        public static string GenerateCompactJson(Object data)
        {
            string dataStr = JsonConvert.SerializeObject(data);
            //sorting purpose
            JObject obj = JObject.Parse(dataStr);
            var sortedObj = new JObject(
                obj.Properties().OrderByDescending(prop => prop.Type)
            );
            string output = sortedObj.ToString(Formatting.None);
            return output;
        }

    }
}
