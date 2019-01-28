using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using SystemExtend;
using SystemExtend.ExceptionExt;
 
using WEB.DataAccessBase;
using WEB.Module.LoginManage;
namespace WEB.DataAccess.UsersTBL
{
    /// <summary>
    /// OperateData 的摘要说明
    /// </summary>
    public class OperateData : OperateDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        /********   可修改区域 Start  ********/
        DBControl.Base.BLLOpt<Model.Users_Model> bll = new DBControl.Base.BLLOpt<Model.Users_Model>();
        /********   可修改区域 End  ********/

        public void ProcessRequest(HttpContext context)
        {
            /********  初始化 可修改区域 Start  ********/
            _tableName = "Users";

            /********  初始化 可修改区域 End  ********/

            context.Response.ContentType = "text/plain";
            Initial(context);
            if (UrlHelper.ReqStr("m").Equals("DeleteByID"))
            {
                DeleteByID();
            }
            else if (UrlHelper.ReqStr("m").Equals("UpdatePass"))
            {
                UpdatePass();
            }
            else
            {
                OptData();
            }

        }


        private void OptData()
        {
            /********   可修改区域 Start  ********/
            Model.Users_Model model = GetNewDataModel(CurrentContext);
            /********   可修改区域 End  ********/



            bool issuccess = false;
            string msg = string.Empty;

            try
            {
                if (IsAdd)
                {
                    if (HasLoginID(model.LoginID.Trim()))
                    {
                        msg = "该用户名已经存在，请添加其他用户名。";
                    }
                    else
                    {
                        issuccess = bll.AddModel(model);
                        msg = issuccess ? "添加成功。" : "添加失败！";
                    }
                }
                else
                {
                    issuccess = bll.UpdateModel(model);
                    msg = issuccess ? "修改成功。" : "修改失败！";
                }
            }
            catch (Exception ex)
            {
                issuccess = false;
                msg = string.Format("{0} {1}", msg, ex.Message);
            }

            ReturnMsg(issuccess, enumReturnTitle.OptData, msg);

        }

        private void DeleteByID()
        {
            if (bll.Delete(_pKeyValue))
            {
                ReturnMsg(true, enumReturnTitle.OptData, "删除成功!");
            }
            else
            {
                ReturnMsg(false, enumReturnTitle.OptData, "删除失败!");
            }


        }


        /********  获取数据  可修改区域 Start  ********/
        private Model.Users_Model GetNewDataModel(HttpContext context)
        {

            Model.Users_Model model = new Model.Users_Model();
            if (IsEdit)
            {

                model = bll.GetModelByKeyValue(_pKeyValue);
                if (null == model)
                {
                    throw new HasNotRecordException(_pKeyValue);
                }
            }

            model.UserID = string.IsNullOrWhiteSpace(_pKeyValue) ? 0 : int.Parse(_pKeyValue);
            model.LoginID = UrlHelper.ReqStrByGetOrPost(context, "LoginID");
            model.RealName = UrlHelper.ReqStrByGetOrPost(context, "RealName");
            model.DepartmentID = UrlHelper.ReqIntByGetOrPost(context, "DepartmentID");
            
            model.Mobile = UrlHelper.ReqStrByGetOrPost(context, "Mobile");
            model.Email = UrlHelper.ReqStrByGetOrPost(context, "Email");
            model.QQ = UrlHelper.ReqStrByGetOrPost(context, "QQ");
            model.IsEnabled = UrlHelper.ReqBoolByGetOrPost(context, "IsEnabled");
            model.IsLocked = UrlHelper.ReqBoolByGetOrPost(context, "IsLocked");
            model.Remark = UrlHelper.ReqStrByGetOrPost(context, "Remark");

            return model;

        }
        /********  获取数据  可修改区域 End  ********/


        #region 其他

        public void UpdatePass()
        { 
            string OldPass = UrlHelper.ReqStrByGetOrPost("OldPass");
            OldPass =  Common.Encrypt.ToPassString(OldPass);
            string NewPass = UrlHelper.ReqStrByGetOrPost("NewPass");
            NewPass = Common.Encrypt.ToPassString(NewPass);

            if (string.IsNullOrWhiteSpace(_pKeyValue))
            {
                WEB.Module.LoginManage.IUser user = CurrentUser;
                _pKeyValue = user.BaseInfo.UserID.ToString();
            }

            long count = bll.Count(string.Format("UserID={0} and UserPwd='{1}'", _pKeyValue, OldPass));
            if (count > 0)
            {
                Model.Users_Model model = bll.GetModelByKeyValue(_pKeyValue);
                model.UserPwd = NewPass;
                bll.UpdateModel(model);
                ReturnMsg(true, enumReturnTitle.OptData, "修改成功");
            }
            else {
                ReturnMsg(false, enumReturnTitle.OptData, "原密码不正确,修改失败！");
            
            }

        }

        public bool HasLoginID(string LoginID)
        {
            return bll.Count(string.Format("LoginID='{0}'  ", LoginID.Trim() )) > 0;
        }

        #endregion







        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}