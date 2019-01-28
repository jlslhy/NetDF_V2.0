using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Common;
using WEB.Config;

namespace WEB.Module.LoginManage
{
    public class UserBasePage : System.Web.UI.Page
    {

        protected IUser _user;

        protected IUser CurrentUser {
            get {
                if (_user == null)
                {
                    string LoginState = ConfigHelper.GetXmlSystemConfig("LoginState");

                     _user = new UserCookie();
                    if (LoginState.Equals("Session"))
                    {
                        _user = new UserSession();
                    }

                    if (LoginState.Equals("Cookie_Session"))
                    {
                        if (Request.Cookies["testcookie"] == null || !Request.Cookies["testcookie"].Value.Equals("ok"))
                        {
                            _user = new UserSession();
                        }

                    }
                    

                }
                return _user;
            }
 
        }

        

    }
}
