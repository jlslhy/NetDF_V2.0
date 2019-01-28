using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSJ.Web.UI.Register
{
    public class Reg
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperateResult RegUser(Model.CSJ_UsersInfo model )
        {
            OperateResult result = new OperateResult();
            BLL.CSJ_UsersInfo bllCSJ_UsersInfo = new BLL.CSJ_UsersInfo();
            if (bllCSJ_UsersInfo.HasUserID(model.UserID))
            {
                result.Success = false;
                result.Messges = "已经存在此用户，请尝试别的用户名。";
                return result;
            }
            if (bllCSJ_UsersInfo.Add(model) > 0)
            {
                result.Success = true;
                result.Messges = "注册成功！";
            }
            return result;
        }


    }
}
