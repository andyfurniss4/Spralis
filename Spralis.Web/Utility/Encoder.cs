using System;
using System.Text;

namespace Spralis.Web.Utility
{
    public static class Encoder
    {
        public static string Base64Encode(string plainText)
        {
            if (plainText == null)
            {
                return null;
            }

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string encodedText)
        {
            if (encodedText == null)
            {
                return null;
            }

            var base64StringBytes = Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(base64StringBytes);
        }
    }
}