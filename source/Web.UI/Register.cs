using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBControl;
namespace App.Web.UI
{
    public class Register
    {
        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        //public static OperateResult RegisterNewUser(Model.Sys.UsersInfo_Model model)
        //{
        //    OperateResult result = new OperateResult();
        //    DBControl.BLL.BLLOpt<Model.Sys.UsersInfo_Model> bll = new DBControl.BLL.BLLOpt<Model.Sys.UsersInfo_Model>();

            //if (!bll.HasUserID(model.UserID))
            //{
            //    if (bll.Add(model) > 0)
            //    {
            //        result.Success = true;
            //        result.Messges = "注册成功！";
            //    }
            //}
            //else
            //{
            //    result.Success = false;
            //    result.Messges = "已经有此用户，注册失败！";
            //}
        //    return result;
        //}

    }
}
