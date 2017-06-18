using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SpGatewayHelper.Helper
{
    public class CryptoHelper
    {
        private string Key { get; }
        private string Iv { get; }

        public CryptoHelper(string key, string iv)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(iv))
            {
                throw new NullReferenceException("Key or Iv is required");
            }
            Key = key;
            Iv = iv;
        }
        /// <summary>
        /// 將資料使用 AES 128 雜湊後傳回
        /// </summary>
        /// <param name="dataDictionary">The data dictionary.</param>
        /// <returns></returns>
        public string GetAesString(Dictionary<string, object> dataDictionary)
        {
            var aesCryptoServiceProvider = new AesCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(Key),
                IV = Encoding.ASCII.GetBytes(Iv)
            };
            var source = string.Join("&", dataDictionary.Select(d => d.Key + "=" + d.Value));
            var dataByteArray = Encoding.UTF8.GetBytes(source);

            string encrypt;
            var sb = new StringBuilder();
            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, aesCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(dataByteArray, 0, dataByteArray.Length);
                cryptoStream.FlushFinalBlock();
                foreach (var d in ms.ToArray())
                {
                    sb.AppendFormat("{0:x2}", d);
                }
                encrypt = sb.ToString();
            }
            return encrypt;
        }

        /// <summary>
        /// Decrypts the aes string.
        /// </summary>
        /// <param name="aesString">The aes string.</param>
        /// <returns></returns>
        public string DecryptAesString(string aesString)
        {
            var dataByteArray = Enumerable.Range(0, aesString.Length / 2)
                 .Select(d => Convert.ToByte(aesString.Substring(d * 2, 2), 16))
                 .ToArray();

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = Encoding.UTF8.GetBytes(Iv);
                aesAlg.FeedbackSize = 128;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.None;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (var msDecrypt = new MemoryStream(dataByteArray))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt, Encoding.ASCII))
                {
                    return Regex.Replace(srDecrypt.ReadToEnd(), "[^\x0d\x0a\x20-\x7e\t]", "");
                }
            }
        }

        /// <summary>
        /// 取得 Sha256 字串
        /// </summary>
        /// <param name="aesString">The aes string.</param>
        /// <returns></returns>
        public string GetSha256String(string aesString)
        {
            var source = $"HashKey={Key}&{aesString}&HashIV={Iv}";
            var bytes = Encoding.UTF8.GetBytes(source);
            var hashstring = new SHA256Managed();
            var hash = hashstring.ComputeHash(bytes);
            var sb = new StringBuilder();
            foreach (var d in hash)
            {
                sb.AppendFormat("{0:X2}", d);
            }
            return sb.ToString();
        }
    }
}