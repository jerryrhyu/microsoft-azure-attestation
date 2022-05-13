using Newtonsoft.Json.Linq;

namespace validatequotes
{
    public class JoseHelper
    {
        public static JObject ExtractJosePart(string jwt, int partIndex)
        {
            string[] joseParts = jwt.Split('.');
            var decodedPart = Base64Url.DecodeString(joseParts[partIndex]);
            JObject jsonPart = JObject.Parse(decodedPart);

            //Logger.WriteLine($"jwtParts.Length             : {joseParts.Length}");
            //Logger.WriteLine($"decoded to string:          : {decodedPart}");

            return jsonPart;
        }
        public static JToken ExtractJosePartField(string jwt, int partIndex, string fieldName)
        {
            var part = ExtractJosePart(jwt, partIndex);
            return part[fieldName];
        }
    }
}
