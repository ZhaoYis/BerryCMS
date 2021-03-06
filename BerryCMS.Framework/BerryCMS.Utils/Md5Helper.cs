﻿using System.Security.Cryptography;
using System.Text;

namespace BerryCMS.Utils
{
    /// <summary>
    /// MD5加密帮助类
    /// </summary>
    public class Md5Helper
    {
        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source">加密字符</param>
        /// <param name="len">加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位</param>
        /// <returns></returns>
        public static string Md5(string source, string len = "x2")
        {
            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);

            StringBuilder builder = new StringBuilder();
            foreach (byte s in result)
            {
                builder.Append(s.ToString(len));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
            }
            return builder.ToString();
        }
        #endregion
    }
}