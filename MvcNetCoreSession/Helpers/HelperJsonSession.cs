using Newtonsoft.Json;

namespace MvcNetCoreSession.Helpers
{
    public class HelperJsonSession
    {
        public static string SerializeObject<T>(T data)
        {
            string json = JsonConvert.SerializeObject(data);
            return json;
        }
        public static T DeserializableObject<T>(string data)
        {
            T objeto = JsonConvert.DeserializeObject<T>(data);
            return objeto;
        }
    }
}
