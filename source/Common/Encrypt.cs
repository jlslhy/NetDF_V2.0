using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Encrypt
    {
        public static string ToPassString(string oldStr)
        {
            StringBuilder newstrSB = new StringBuilder();
            string temp = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldStr,"MD5");
            newstrSB.Append(temp.Substring(2, 3));
            newstrSB.Append(temp.Substring(5, 6));
            newstrSB.Append(temp.Substring(8, 5));
            newstrSB.Append(temp.Substring(7, 3));
            newstrSB.Append(temp.Substring(2, 3));
            newstrSB.Append(temp.Substring(5, 3));
            newstrSB.Append(temp.Substring(8, 5));
            newstrSB.Append(temp.Substring(3, 1));
            newstrSB.Append(temp.Substring(0, 3));
           
            return newstrSB.ToString();
        }
    }
}
