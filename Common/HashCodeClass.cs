using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WX_TennisAssociation.Common
{
    #region 获得hash码
    /// <summary>
    /// 获得hash码
    /// </summary>
    public class HashCodeClass
    {
        #region MD5加密
        /// <summary>
        /// 用md5加密
        /// </summary>
        /// <param name="Sourcein">输入的未加密之前的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5_DesEncrypt(string strLogin_PWD)
        {
            MD5CryptoServiceProvider MD5CSP = new MD5CryptoServiceProvider();
            byte[] MD5Source = Encoding.UTF8.GetBytes(strLogin_PWD);
            byte[] MD5Out = MD5CSP.ComputeHash(MD5Source);
            return Convert.ToBase64String(MD5Out);
        }
        #endregion

        #region SHA1加密
        /// <summary>
        /// 用SHA1加密
        /// </summary>
        /// <param name="Sourcein">输入的未加密之前的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA1_DesEncrypt(string strLogin_PWD)
        {
            SHA1 SHA1CSP = SHA1.Create();
            byte[] SHA1Source = Encoding.UTF8.GetBytes(strLogin_PWD);
            byte[] SHA1Out = SHA1CSP.ComputeHash(SHA1Source);
            return Convert.ToBase64String(SHA1Out);
        }
        #endregion

        #region 加密和解密
        #region 密钥
        const string myKey = "AkfHY3iZbGBVQHKc3+K9KTJtSNZTFiVgMJQnXaMe5j0=";
        const string myIV = "wVmTdz2/r4prjZMsRywbYg==";
         
        /// <summary>
        /// 获得key
        /// </summary>
        /// <returns></returns>
        private static byte[] GetKey()
        {
            byte[] key = Convert.FromBase64String(myKey);
            return key;
        }

        private static byte[] GetIV()
        {
            byte[] iv = Convert.FromBase64String(myIV);
            return iv;
        }
        #endregion

        #region 加密算法
        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="plainText">原字符串</param>
        /// <param name="Key">key</param>
        /// <param name="IV">iv</param>
        /// <returns>返回加密后的字节数组</returns>
        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted = null;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
        #endregion

        #region 加密
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">字符串</param>
        /// <returns></returns>
        public static string EncryptStringToBytesAes(string plainText)
        {
            byte[] encrypted = EncryptStringToBytes_Aes(plainText, GetKey(), GetIV());

            return BitConverter.ToString(encrypted);
        }
        #endregion

        #region 解密算法
        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="cipherText">加密后的字节数组</param>
        /// <param name="Key">key</param>
        /// <param name="IV">iv</param>
        /// <returns>返回原字符串</returns>
        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = string.Empty;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            return plaintext;
        }
        #endregion

        #region 解密
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText">需要解密的数据</param>
        /// <returns>返回解密结果</returns>
        public static string DecryptStringFromBytesAes(string hashcode)
        {
            byte[] encrypted = HexStringToBytes(hashcode);

            return DecryptStringFromBytes_Aes(encrypted, GetKey(), GetIV());
        }
        #endregion

        #region 十六进制字符串转化成字节数组
        /// <summary>
        /// 十六进制字符串转化成字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static byte[] HexStringToBytes(string str)
        {
            const string HEX_CHARS = "0123456789ABCDEF";

            if (str.Length == 0)
                return new byte[0];

            if ((str.Length + 1) % 3 != 0)
                throw new FormatException();

            byte[] bytes = new byte[(str.Length + 1) / 3];

            int state = 0; // 0 = expect first digit, 1 = expect second digit, 2 = expect hyphen
            int currentByte = 0;
            int x;
            int value = 0;

            foreach (char c in str)
            {
                switch (state)
                {
                    case 0:
                        x = HEX_CHARS.IndexOf(Char.ToUpperInvariant(c));
                        if (x == -1)
                            throw new FormatException();
                        value = x << 4;
                        state = 1;
                        break;
                    case 1:
                        x = HEX_CHARS.IndexOf(Char.ToUpperInvariant(c));
                        if (x == -1)
                            throw new FormatException();
                        bytes[currentByte++] = (byte)(value + x);
                        state = 2;
                        break;
                    case 2:
                        if (c != '-')
                            throw new FormatException();
                        state = 0;
                        break;
                }
            }
            System.Diagnostics.Debug.WriteLine(bytes);
            return bytes;
        }
        #endregion
        #endregion
    }
    #endregion
}
