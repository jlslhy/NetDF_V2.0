using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.IO;
using  NetServ.Net.Json;

namespace Connect.QQ.PC
{
    public class API
    {
        static string OpenIDReqUrl = "https://graph.qq.com/oauth2.0/me";

        public static string GetOpenID(string access_token)
        {
            WebClient wc = new WebClient();
            string returnVal = wc.GetHtml(string.Format("{0}?access_token={1}", OpenIDReqUrl, access_token));
            int start = returnVal.IndexOf("(")+1;
            int count = returnVal.IndexOf(")")-start;
            string str = returnVal.Substring(start,count);
            StringReader rdr = new StringReader(str);
            JsonParser parser = new JsonParser(rdr, true);
            JsonObject obj = (JsonObject)parser.ParseObject();
            JsonString openid = (JsonString)obj["openid"];
            return openid.ToString();
        }
             
    }
}
