using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WEB.Module.LoginManage
{
    public interface IUser
    {
        /// <summary>
        /// 是否在线 (是否已登录)
        /// </summary>
        /// <returns></returns>
        bool IsOnline();
        /// <summary>
        /// 登录用户的基本信息
        /// </summary>
        UserBaseInfo BaseInfo
        {
            get;
            set;
        }
        /// <summary>
        /// 注销
        /// </summary>
        void LogOut();

        /// <summary>
        /// 登录状态信息
        /// </summary>
        string LoginStateInfo
        {
            get;
        }
         

    }
}
