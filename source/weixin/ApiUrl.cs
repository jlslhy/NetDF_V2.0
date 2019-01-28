using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace weixin
{
    public class ApiUrl
    {
        #region 发送客服消息


        /// <summary>
        /// 发送客服消息地址
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static string Message_Custom_SendUrl(string access_token)
        {
            return string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}",access_token);
        }

        #endregion

    }
}
