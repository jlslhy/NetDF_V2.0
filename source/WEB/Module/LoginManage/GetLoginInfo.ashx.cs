using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.DataAccessBase;
using Common;
using NetServ.Net.Json;

namespace WEB.Module.LoginManage
{
    /// <summary>
    /// GetLoginInfo 的摘要说明
    /// </summary>
    public class GetLoginInfo : GetDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Initial(context);
            if (UrlHelper.ReqStr("m").Equals("GetUserInfo"))
            {
                GetUserInfo();
            }
            else if (UrlHelper.ReqStr("m").Equals("CheckUpLoginState"))
            {
                CheckUpLoginState();
            }
        }

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        private void GetUserInfo() {
            IUser ICurrentUser = LoginHelper.CurrentUser;
            if (null == ICurrentUser)
            {
                ReturnMsg(false, enumReturnTitle.Login, "会话无效，请登录。");
            }
            else if (ICurrentUser.IsOnline())
            {
                UserBaseInfo userBaseInfo = ICurrentUser.BaseInfo;
                JsonObject jObj = new JsonObject();
                jObj.Add("IsSuccess", true);
                jObj.Add("UserID", userBaseInfo.UserID);
                jObj.Add("LoginID", userBaseInfo.LoginID);
                jObj.Add("RealName", userBaseInfo.RealName);

                JsonWriter jwriter = new JsonWriter();
                jObj.Write(jwriter);
                CurrentContext.Response.Write(jwriter.ToString());

            }
            else {
                ReturnMsg(false, enumReturnTitle.Login, "会话过期，请登录。");
            }
        }

        public void CheckUpLoginState() {
            if (!LoginHelper.CurrentUser.IsOnline()) {
                ReturnMsg(false, enumReturnTitle.Login, "会话过期，请登录。");
            }
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