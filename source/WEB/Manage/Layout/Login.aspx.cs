using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
 
using WEB.Config;
using WEB.Module.LoginManage;

namespace WEB.Manage.Layout
{
    public partial class Login : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (Common.UrlOper.ReqStr("action").Equals("relogin"))
            {
                Response.Write("<script>window.parent.location='" + Request.Path + "'</script>");

            }
 
            if (!Page.IsPostBack)
            {
                // 向客户端写一个cookie 值，用来判断客户端是否支持cookie
                string LoginState = ConfigHelper.GetXmlSystemConfig("LoginState");
                if (LoginState.Equals("Cookie_Session"))
                {
                    HttpCookie testcookie = new HttpCookie("testcookie");
                    testcookie.Expires = DateTime.Now.AddDays(1);
                    testcookie.Value = "ok";
                    Response.Cookies.Add(testcookie);
                }
 
            }
 
        }

       

        protected void OKIBtn_Click(object sender, ImageClickEventArgs e)
        {
            LoginResult result;
            UserBaseInfo uinfo = LoginHelper.CheckLogin(UserIDTB.Text.Trim(), PassTB.Text, out result);
            if (result.Success)
            {
                IUser user = CurrentUser;
                user.BaseInfo = uinfo;

                Response.Redirect(ConfigHelper.BackgroundFirstPage);

            }
            else
            {
                JsHelper.wShowMessage("登录失败！", this);
            }
        }

        protected void btn22_Click(object sender, EventArgs e)
        {
            Response.Write("ddd");
        }
    }
}