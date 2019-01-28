using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;
using System.Xml;

namespace weixin
{
    public class ApiWebBase :System.Web.UI.Page
    {
        public string access_token = string.Empty;
        Common.WebClient webClient = new Common.WebClient();
        protected bool IsReqValid = false;

        protected string PostString = string.Empty;
        protected XmlDocument PostXmlDoc = null;

        public void reqBegin(string WeiXinToken)
        {

           


            if (Request.QueryString["signature"] != null
               && Request.QueryString["timestamp"] != null
               && Request.QueryString["nonce"] != null
                )
            {
                string signature = Request.QueryString["signature"].ToString();
                string timestamp = Request.QueryString["timestamp"].ToString();
                string nonce = Request.QueryString["nonce"].ToString();

                long Ltimestamp = long.Parse(timestamp);
                
                DateTime aa = new DateTime(1970, 1, 1);
                long LtimestampNow = (DateTime.Now.Ticks - aa.Ticks) / 10000000 - 8 * 60 * 60;


                if (LtimestampNow - Ltimestamp >= 10
                    || LtimestampNow - Ltimestamp <= -10)
                {
                    reqLog(string.Format("无效的时间截 Ltimestamp:{0},LtimestampNow{1}", Ltimestamp, LtimestampNow));
                    Response.Clear();
                    Response.Write("");
                    Response.End();
                    return;
                }


                if (!weixin.Security.IsValidReq(signature, timestamp, nonce,  WeiXinToken ))
                {
                    reqLog("无效的请求参数。");
                    Response.Clear();
                    Response.Write("");
                    Response.End();
                    return;
                }

                if (Request.QueryString["echostr"] != null)
                {
                    Response.Clear();
                    Response.Write(Request.QueryString["echostr"].ToString());
                    Response.End();
                    return;
                }
                IsReqValid = true;
                //reqLog(string.Format("有效 Ltimestamp:{0},LtimestampNow{1}", Ltimestamp, LtimestampNow));

            }
            else {
                reqLog("缺少必要的请求参数。");
                Response.Clear();
                Response.Write("");
                Response.End();
            }
        }

        /// <summary>
        /// 获取微信Post过来的信息内容 字符串格式
        /// </summary>
        /// <returns></returns>
        public string GetPostString()
        {
            if (string.IsNullOrWhiteSpace(PostString))
            {
                if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
                {
                    using (Stream stream = HttpContext.Current.Request.InputStream)
                    {
                        Byte[] postBytes = new Byte[stream.Length];
                        stream.Read(postBytes, 0, (Int32)stream.Length);
                        PostString = Encoding.UTF8.GetString(postBytes);

                    }
                }
            }
            return PostString;
        }

        /// <summary>
        /// 获取微信Post过来的信息内容 Xml格式
        /// </summary>
        /// <returns></returns>
        public XmlDocument GetPostXmlDoc()
        {
            if (PostXmlDoc == null)
            {
                string xmlStr = GetPostString();
                if (!string.IsNullOrWhiteSpace(xmlStr))
                {
                    PostXmlDoc = new XmlDocument();
                    PostXmlDoc.LoadXml(xmlStr); 
                }   
            }

            return PostXmlDoc;
        }

        #region 接收普通消息


        /// <summary>
        /// 获取接收普通消息中ToUserName值
        /// </summary>
        /// <param name="postXmlDoc"></param>
        /// <returns></returns>
        public string GetPost_ToUserName(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "ToUserName");
        }

        public string GetPost_FromUserName(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "FromUserName");
        }

        public string GetPost_CreateTime(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "CreateTime");
        }

        public string GetPost_MsgType(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "MsgType");
        }

        public string GetPost_Content(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Content");
        }

        public string GetPost_MsgId(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "MsgId");
        }

        public string GetPost_PicUrl(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "PicUrl");
        }

        public string GetPost_MediaId(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "MediaId");
        }

        public string GetPost_ThumbMediaId(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "ThumbMediaId");
        }

        public string GetPost_Format(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Format");
        }

        public string GetPost_Location_X(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Location_X");
        }

        public string GetPost_Location_Y(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Location_Y");
        }

        public string GetPost_Scale(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Scale");
        }

        public string GetPost_Label(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Label");
        }

        public string GetPost_Title(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Title");
        }

        public string GetPost_Description(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Description");
        }

        public string GetPost_Url(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Url");
        }

        #endregion

        #region 菜单事件推送

        public string GetPost_Event(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "Event");
        }

        public string GetPost_EventKey(XmlDocument postXmlDoc)
        {
            return GetPost_Val(postXmlDoc, "EventKey");
        }




        #endregion



        public string GetPost_Val(XmlDocument postXmlDoc,string nodeName)
        {
            XmlNode xmlNode = postXmlDoc.SelectSingleNode(string.Format("/xml/{0}",nodeName));
            if (null != xmlNode)
            {
                return xmlNode.InnerText;
            }
            else
            {
                return string.Empty;
            }
        }

        










        public void reqLog(string msg)
        {
            StreamWriter sw = File.CreateText(Server.MapPath("~/WebLog/reqLog.txt"));
            sw.Write(Request.Url + " " + DateTime.Now.ToString()+" "+msg);
            sw.Close();
        }


        #region 发送客服消息

        public void SendText(string openid, string content)
        {
            string url = weixin.ApiUrl.Message_Custom_SendUrl(access_token);
            string str = JsonString.GetSendTextJsonStr(openid,content);
            //webClient.PostString(url,str);
            webClient.Post(url, str);
        }
        #endregion







    }
}
