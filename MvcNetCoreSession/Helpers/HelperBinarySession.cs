using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MvcNetCoreSession.Helpers
{
    public class HelperBinarySession
    {
        public static byte[] ObjectToByte(Object objeto)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objeto);
                return stream.ToArray();
            }
        }

        public static Object ByteToObject(byte[] data) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);
                Object objeto = formatter.Deserialize(stream);
                return objeto;
            }
        }
    }
}
