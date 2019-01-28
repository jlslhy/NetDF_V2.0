using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBControl;
using WEB.Config;



namespace WEB.Module.LoginManage
{
    public class LoginHelper
    {
        public static UserBaseInfo CheckLogin(string loginID, string uPass, out LoginResult result)
        {
            result = new LoginResult();
             
            UserBaseInfo Info = new UserBaseInfo();
            DBControl.Base.BLLOpt<Model.Users_Model> usersBll = new DBControl.Base.BLLOpt<Model.Users_Model>();
            IList<Model.Users_Model> models = usersBll.GetList(string.Format("loginID='{0}'",loginID));

            if (null == models || models.Count < 1)
            {
                result.Messges = "没有此用户！";
            }
            else
            {
                if (!Common.Encrypt.ToPassString(uPass).Equals(models[0].UserPwd))
                {
                    result.Messges = "密码错误!";
                }
                else
                {
                   
                    Info.UserID = models[0].UserID;
                    Info.LoginID = models[0].LoginID;
                    Info.RealName = models[0].RealName;
                    
                    Info.DepartmentID = models[0].DepartmentID ?? 0;
                    result.Success = true;
                }

            }
            return Info;
        }


        /// <summary>
        /// 为测试用的用户登录方法
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static UserBaseInfo LoginForTest(string userID, out LoginResult result)
        {
            result = new LoginResult();
            UserBaseInfo Info = new UserBaseInfo();
            //BLL.SSSE_UsersInfo bll = new BLL.SSSE_UsersInfo();
            //IList<Model.SSSE_UsersInfo> models = bll.GetModels("1", "UserID='" + userID + "'", "", false, "ID", "UserID", "RealName", "upass", "RoleID");

            //if (null == models || models.Count < 1)
            //{
            //    result.Messges = "没有此用户！";
            //    result.Success = false;
            //}
            //else {
            //    Info.ID = models[0].ID.Value;
            //    Info.UserID = models[0].UserID;
            //    Info.RealName = models[0].RealName;
            //    Info.RoleID = models[0].RoleID.Value;
            //    result.Success = true;
            //}
            return Info;
        }

        public static LoginManage.IUser CurrentUser
        {
            get
            {

                LoginManage.IUser _user;
                string LoginState = ConfigHelper.GetXmlSystemConfig("LoginState");

                _user = new UserCookie();
                if (LoginState.Equals("Session"))
                {
                    _user = new UserSession();
                }

                if (LoginState.Equals("Cookie_Session"))
                {

                    if (System.Web.HttpContext.Current.Request.Cookies["testcookie"] == null || !System.Web.HttpContext.Current.Request.Cookies["testcookie"].Value.Equals("ok"))
                    {
                        _user = new UserSession();
                    }

                }

                return _user;

            }
        }


    }
    public struct LoginResult
    {
        public bool Success;
        public string Messges;
    }
}
