using System;
using System.Security.Cryptography;
using System.Text;
using Wolfife.Common.Config;

namespace Wolfife.Common
{
    public class Utils
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public static ConfigurationManager Configuration => new ConfigurationManager();

        /// <summary>
        /// get string md5 value
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string str)
        {
            using var hashAlgorithm = MD5.Create();

            var buffer = Encoding.UTF8.GetBytes(str);
            var output = hashAlgorithm.ComputeHash(buffer);
            var md5 = BitConverter.ToString(output);

            return md5.Replace("-", string.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetMD5HashByEncoding(string content, Encoding encoding)
        {
            using var md5 = MD5.Create();
            var result = md5.ComputeHash(encoding.GetBytes(content));

            return BitConverter.ToString(result).Replace("-", "");
        }
    }
}
