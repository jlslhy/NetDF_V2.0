using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WEB.Module.LoginManage
{
    public class UserSession:IUser
    {
        
        /// <summary>
        /// 是否在线 (是否已登录)
        /// </summary>
        /// <returns></returns>
        public bool IsOnline()
        {
            bool online = false;
            if (HttpContext.Current.Session["UserBaseInfo"]!=null)
            {
                online = true;
            }
            return online;
        }



        /// <summary>
        /// 登录用户的基本信息
        /// </summary>
        public UserBaseInfo BaseInfo {
            get {
                if (HttpContext.Current.Session["UserBaseInfo"] == null)
                {
                    return null;
                }
                else {
                   // HttpContext.Current.Response.Write("输出session");
                    return (UserBaseInfo)HttpContext.Current.Session["UserBaseInfo"];

                }
            }
            set
            {
                HttpContext.Current.Session["UserBaseInfo"] = value;
               // HttpContext.Current.Response.Write("插入session");
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        public void LogOut()
        {
            if (null != HttpContext.Current.Session["UserBaseInfo"])
            {
                HttpContext.Current.Session.Abandon();
            }
        }

        /// <summary>
        /// 登录状态信息
        /// </summary>
        public string LoginStateInfo
        {
            get { return "目前是用session保存状态"; }
        }




    }
}
