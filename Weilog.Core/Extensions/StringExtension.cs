using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Weilog.Core.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 将字符串转换成 MD5 加密字符串。
        /// </summary>
        /// <param name="str">需要转换的字符串。</param>
        /// <returns>MD5 加密字符串。</returns>
        public static string ToMD5(this string str)
        {
            MD5 md5 = MD5.Create();

            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(str));

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
