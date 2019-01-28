using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Common;
using WEB.Config;

namespace WEB.Module.LoginManage
{
    public class UserCookie : IUser
    {
        /// <summary>
        /// 是否在线 (是否已登录)
        /// </summary>
        /// <returns></returns>
        public bool IsOnline()
        {
            bool online = false;
            if (HttpContext.Current.Request.Cookies["UserBaseInfo"] != null)
            {
                online = true;
            }
            return online;
        }

        public UserBaseInfo BaseInfo
        {
            get {
               // HttpContext.Current.Response.Write("输出Cookies");
                if (HttpContext.Current.Request.Cookies["UserBaseInfo"] == null)
                {
                    return null;
                }
                else
                {
                    UserBaseInfo UBInfo = new UserBaseInfo();
                    try
                    {
                         
                        HttpCookie cookie = HttpContext.Current.Request.Cookies["UserBaseInfo"];
                         
                        UBInfo.UserID = int.Parse(cookie.Values["UserID"].ToString());
                        UBInfo.LoginID = cookie.Values["LoginID"].ToString();
                        UBInfo.RealName = cookie.Values["RealName"].ToString();
                        
                        UBInfo.DepartmentID = Int32.Parse(cookie.Values["DepartmentID"].ToString());

                    }
                    catch { }

                    return UBInfo;

                }
            }

            set
            {
              //  HttpContext.Current.Response.Write("插入cookie");
                UserBaseInfo info = (UserBaseInfo)value;
                HttpCookie cookie = new HttpCookie("UserBaseInfo");
                cookie.Expires = DateTime.Now.AddMinutes(ConfigHelper.GetXmlSystemConfigInt("CookieExpires"));
               
                cookie.Values.Add("UserID", info.UserID.ToString());
                cookie.Values.Add("LoginID", info.LoginID);
                cookie.Values.Add("RealName", info.RealName);
                cookie.Values.Add("DepartmentID", info.DepartmentID.ToString());
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);


            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        public void LogOut()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UserBaseInfo"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 登录状态信息
        /// </summary>
        public string LoginStateInfo {
            get { return "目前是用cookie保存状态"; }
        }


        

    }
}
