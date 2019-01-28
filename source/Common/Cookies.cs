using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common
{
    public class Cookies
    {
        /// <summary>
        /// 设置COOKIE
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="name"></param>
        /// <param name="time">过期时间(单位:分钟)</param>
        /// <returns></returns>
        public static bool setCookie(string strName, string name, double time)
        {
            try
            {
                string strname = HttpUtility.UrlEncode(name);
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = DateTime.Now.AddMinutes(time);
                Cookie.Values.Add("Value", HttpContext.Current.Server.UrlEncode(strname));
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool updateCookies(string strName, string name, double time)
        {
            try
            {
                System.Web.HttpContext.Current.Response.Cookies[strName]["Value"] = name;
                return setCookie(strName, name, time);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public static string getCookie(string strName, string strValue)
        {
            HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies[strName];

            try
            {
                if (Cookie != null)
                {
                    return HttpUtility.UrlDecode(Cookie.Values[strValue].ToString());
                }
                else
                {
                    return null;
                }
            }
            catch { return null; }
        }
    }
}

