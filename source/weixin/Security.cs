using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace weixin
{
    public class Security
    {
        /// <summary>
        /// 是否有效的请求
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsValidReq(string signature, string timestamp, string nonce, string token)
        {
            bool yes = false;
            
            List<string> list = new List<string>();
            list.Add(token);
            list.Add(timestamp);
            list.Add(nonce);
            list.Sort();

            string tempstr = string.Join("",list.ToArray());

            if (SHA1(tempstr).ToLower() == signature.ToLower())
            {
                yes = true;
                     
            }


            return yes;
        }


        private static string SHA1(string text)
        {
            byte[] cleanBytes = Encoding.Default.GetBytes(text);
            byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
    }
}
