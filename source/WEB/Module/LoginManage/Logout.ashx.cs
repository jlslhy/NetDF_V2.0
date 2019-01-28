using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.DataAccessBase;
using Common;

namespace WEB.Module.LoginManage
{
    /// <summary>
    /// Logout 的摘要说明
    /// </summary>
    public class Logout : GetDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Initial(context);
            if (UrlHelper.ReqStr("m").Equals("UserLogout"))
            {
                UserLogout();
            }
        }

        /// <summary>
        /// 用户注销
        /// </summary>
        private void UserLogout() {
            LoginHelper.CurrentUser.LogOut();
            ReturnMsg(true,enumReturnTitle.Login,"注销成功。");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}