using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web ;

namespace Common
{
    public class JsHelper
    {
        

        private static string ScriptTag {  get { return "<script type='text/javascript'>alert('{0}');{1}{2}{3}</script>"; } }
        private static string WindowCloseStr {
            get { return "window.close();"; }
        }
        private static string WindowCloseParentStr {
            get { return "window.opener.close();window.opener.opener = null; "; }
        }
        private static string GoToStr {
            get { return "window.history.go({0});"; }
        }
        private static string GoToTargetUrl {
            get { return "window.location.href='{0}';"; }
        }



        #region 显示消息
        /// <summary>
        /// 显示消息，但先出现空白页
        /// </summary>
        /// <param name="msg"></param>
        public static void wShowMessage(string msg,System.Web.UI.Page page)
        {
            ShowMessage(msg,page,true);
        }
        public static void ShowMessage(string msg, System.Web.UI.Page page)
        {
            ShowMessage(msg, page, false);
        }

        public static void ShowMessage(string msg, System.Web.UI.Page page, bool isWhiteBackground)
        {
            string scriptStr= string.Format(ScriptTag, msg, string.Empty, string.Empty, string.Empty);
             
            ResponseWriteScript(isWhiteBackground,page,scriptStr);

        }

        #endregion




        #region 显示消息并且控制是否关闭窗口

        public static void wShowMessage(string msg, bool isClose,System.Web.UI.Page page)
        {
            ShowMessage(msg,isClose,page,true);
        }

        public static void ShowMessage(string msg, bool isClose, System.Web.UI.Page page) {
            ShowMessage(msg,isClose,page,false);
        }
        public static void ShowMessage(string msg, bool isClose, System.Web.UI.Page page, bool isWhiteBackground)
        {
            string scriptStr = string.Format(ScriptTag, msg, isClose ? WindowCloseStr : "", string.Empty, string.Empty);

            ResponseWriteScript(isWhiteBackground, page, scriptStr);
        }
        #endregion


        #region 显示消息并且控制是否关闭窗口或父窗口

        public static void wShowMessage(string msg, bool isClose, bool isCloseParent,System.Web.UI.Page page)
        {
            ShowMessage(msg,isClose,isCloseParent,page,true);
        }
        public static void ShowMessage(string msg, bool isClose, bool isCloseParent, System.Web.UI.Page page)
        {
            ShowMessage(msg, isClose, isCloseParent, page, false);
        }

        public static void ShowMessage(string msg, bool isClose, bool isCloseParent, System.Web.UI.Page page, bool isWhiteBackground)
        {
            string scriptStr = string.Format(ScriptTag, msg, isClose ? WindowCloseStr : string.Empty, isCloseParent ? WindowCloseParentStr : string.Empty, string.Empty);

            ResponseWriteScript(isWhiteBackground, page, scriptStr);
        }
        #endregion






        #region 显示消息并且跳转到指定的步骤 

        public static void wShowMessage(string msg, int goTo, System.Web.UI.Page page)
        {
            ShowMessage(msg,goTo,page,true);
        }
        public static void ShowMessage(string msg, int goTo, System.Web.UI.Page page)
        {
            ShowMessage(msg, goTo, page, false);
        }

        public static void ShowMessage(string msg, int goTo, System.Web.UI.Page page, bool isWhiteBackground)
        {
            string scriptStr = string.Format(ScriptTag, msg, string.Format(GoToStr, goTo.ToString()), string.Empty, string.Empty);
            ResponseWriteScript(isWhiteBackground, page, scriptStr);
        }

        #endregion




        #region 显示消息并且跳转到指定的Url
        public static void wShowMessage(string msg, string targetUrl, System.Web.UI.Page page)
        {
            ShowMessage(msg,targetUrl,page,true);
        }

        public static void ShowMessage(string msg, string targetUrl, System.Web.UI.Page page)
        {
            ShowMessage(msg, targetUrl, page, false);
        }
        public static void ShowMessage(string msg, string targetUrl, System.Web.UI.Page page, bool isWhiteBackground)
        {
            string scriptStr = string.Format(ScriptTag, msg, string.Format(GoToTargetUrl, targetUrl), string.Empty, string.Empty);

            ResponseWriteScript(isWhiteBackground, page, scriptStr);
        }
        #endregion





        #region 显示消息并且并且指定是否在新窗口打开指定的Url

        public static void wShowMessage(string msg, string targetUrl, bool isNewWindow, System.Web.UI.Page page)
        {
            
            ShowMessage(msg,targetUrl,isNewWindow,page,true);

        }

        public static void ShowMessage(string msg, string targetUrl, bool isNewWindow, System.Web.UI.Page page)
        {
            ShowMessage(msg, targetUrl, isNewWindow, page, false);
        }

       
        public static void ShowMessage(string msg, string targetUrl, bool isNewWindow, System.Web.UI.Page page, bool isWhiteBackground)
        {
            string scriptStr = string.Format(ScriptTag, msg, "window.open('" + targetUrl + "');", string.Empty, string.Empty);
 
                if (isNewWindow)
                {
                    ResponseWriteScript(isWhiteBackground, page, scriptStr);
                }
                else
                {
                    if (isWhiteBackground) {
                        wShowMessage(msg, targetUrl, page);
                    }
                    else
                    {
                        ShowMessage(msg, targetUrl, page);
                    }
                }
             

        }
        #endregion




        public static void ResponseWriteScript(bool isWhiteBackground,System.Web.UI.Page page,string scriptStr)
        
        {
            if (isWhiteBackground)
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "showmessage", scriptStr);
            }
            else
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "showmessage", scriptStr);
            }
        }







    }
}
