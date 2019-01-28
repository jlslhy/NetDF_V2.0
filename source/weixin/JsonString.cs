using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace weixin
{
    public class JsonString
    {
        #region 发送客服消息

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="openid">普通用户openid</param>
        /// <param name="content">文本消息内容</param>
        /// <returns></returns>
        public static string GetSendTextJsonStr(string openid,string content)
        {
            string tempStr =
                @"{{
                        ""touser"":""{0}"",
                        ""msgtype"":""text"",
                        ""text"":
                        {{
                             ""content"":""{1}""
                        }}
                    }}";
            tempStr = string.Format(tempStr,openid,content);
            return tempStr;
        }






        #endregion



    }
}
