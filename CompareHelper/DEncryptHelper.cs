using System;
using System.Security.Cryptography;
using System.Text;

namespace CompareHelper
{
    /// <summary>
    /// 
    /// </summary>
    public class DEncryptHelper
    {

    }

    public static class HashHelper
    {
        private static MD5 md5Hasher;
        private static MD5 GetMD5Hasher()
        {
            if (md5Hasher == null)
            {
                md5Hasher = MD5.Create();
            }
            return md5Hasher;
        }
        /// <summary>
        /// 对字符串进行MD5加密,返回的字符串长度为32
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            
            return MD5Encrypt(EncodingHelper.EncodingStringToBytes(s));
        }
        /// <summary>
        /// 对字符串进行MD5加密,返回的字符串长度为32
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MD5Encrypt(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            byte[] hashBytes = GetMD5Hasher().ComputeHash(bytes);
            string result = BitConverter.ToString(hashBytes);

            return result.Replace("-", "").ToUpper();
        }
    }

    /// <summary>
    /// 本类为了这个项目做指定的统一编码
    /// </summary>
    public static class EncodingHelper
    {
        /// <summary>
        /// 将字符串序列化成字节数组, UTF8编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] EncodingStringToBytes(string s)
        {
            byte[] result = UTF8Encoding.UTF8.GetBytes(s);
            return result;
        }

        /// <summary>
        /// 将字节数组解码成字符串, UTF8解码
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStringFromBytes(byte[] bytes)
        {
            string s = UTF8Encoding.UTF8.GetString(bytes);
            return s;
        }

        public static string GetHex16FromBytes(byte[] bytes)
        {
            int int32 = BitConverter.ToInt32(bytes, 0);
            string hexStr = Convert.ToString(int32, 16);
            return hexStr;
        }
    }
}
