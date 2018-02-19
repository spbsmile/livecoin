using System.Security.Cryptography;
using System.Text;

namespace Livecoin
{
    public partial class LivecoinClient
    {
        private static string HashHMAC(string key, string message)
        {
            var encoding = new UTF8Encoding();
            var keyByte = encoding.GetBytes(key);

            var hmacsha256 = new HMACSHA256(keyByte);

            var messageBytes = encoding.GetBytes(message);
            var hashmessage = hmacsha256.ComputeHash(messageBytes);
            return ByteArrayToString(hashmessage);
        }

        private static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private static string HttpBuildQuery(string formdata)
        {
            var str = formdata.Replace("/", "%2F");
            str = str.Replace("@", "%40");
            str = str.Replace(";", "%3B");
            str = str.Replace(",", "%2C");
            return str;
        }
    }
}