using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using SystemExtend;
using SystemExtend.ExceptionExt;
using WEB.DataAccessBase;
using System.Data;
using NetServ.Net.Json;

namespace WEB.DataAccess.SystemRoleTBL
{
    /// <summary>
    /// OperateData 的摘要说明
    /// </summary>
    public class OperateData : OperateDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        /********   可修改区域 Start  ********/
        DBControl.Base.BLLOpt<Model.SystemRole_Model> bll = new DBControl.Base.BLLOpt<Model.SystemRole_Model>();
        // DBControl.BLL.SystemRoleBLL bllExt = new DBControl.BLL.SystemRoleBLL();

        /********   可修改区域 End  ********/

        public void ProcessRequest(HttpContext context)
        {
            /********  初始化 可修改区域 Start  ********/
            _tableName = "SystemRole";
            _idField = "SystemRoleID";
            /********  初始化 可修改区域 End  ********/

            context.Response.ContentType = "text/plain";
            Initial(context);
            if (UrlHelper.ReqStr("m").Equals("DeleteByID"))
            {
                DeleteByID();
            }
            else if (UrlHelper.ReqStr("m").Equals("GetJsonDataByID"))
            {
                GetJsonDataByID();
            }
            else
            {
                OptData();
            }
        }
        public void GetJsonDataByID()
        {
            string id = UrlHelper.ReqStr("id");
            if (!string.IsNullOrWhiteSpace(id))
            {
                /*******************  字段 可修改区域 Start  **********************/
                string[] fieldArr = new string[]{
				  	  
				"[SystemRoleName]"
				  	  
				,"[RoleDesc]"
				  	  
				,"[IsSystem]"
				      
                };
                /*******************  字段 可修改区域 End  **********************/
                try
                {
                    IDataReader idr = DBControl.Base.DBAccess.GetDataIDR(fieldArr, _tableName, string.Format(" {0}={1}", _idField, id), string.Empty);

                    JsonObject jsonData = JsonResult(false,enumReturnTitle.GetData, "数据获取失败。");
                    JsonObject tempdata = OneDataRecordToJson(idr);
                    if (tempdata.Keys.Count > 0)
                    {
                        jsonData = JsonResult(true,enumReturnTitle.GetData, "数据获取成功。");
                        jsonData.Add("Data", tempdata);
                    }

                    JsonWriter jWriter = new JsonWriter();
                    jsonData.Write(jWriter);
                    CurrentContext.Response.Write(jWriter.ToString());
                }
                catch (Exception ex)
                {
                    ReturnMsg(false,enumReturnTitle.GetData, ex.Message);
                }

            }
            else
            {
                ReturnMsg(false, enumReturnTitle.GetData, "获取数据失败，请传递一个有效的ID值。");
            }

        }

        private void OptData()
        {
            /********   可修改区域 Start  ********/
            Model.SystemRole_Model model = GetNewDataModel(CurrentContext);
            /********   可修改区域 End  ********/

            bool issuccess = false;
            string msg = string.Empty;

            try
            {
                if (IsAdd)
                {
                    issuccess = bll.AddModel(model);
                    msg = issuccess ? "添加成功。" : "添加失败！";
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
            ReturnMsg(issuccess,enumReturnTitle.OptData, msg);
        }

        private void DeleteByID()
        {
            if (bll.Delete(_pKeyValue))
            {
                ReturnMsg(true,enumReturnTitle.OptData, "删除成功!");
            }
            else
            {
                ReturnMsg(false,enumReturnTitle.OptData, "删除失败!");
            }
        }


        /********  获取数据  可修改区域 Start  ********/
        private Model.SystemRole_Model GetNewDataModel(HttpContext context)
        {
            Model.SystemRole_Model model = new Model.SystemRole_Model();
            if (IsEdit)
            {
                model = bll.GetModelByKeyValue(_pKeyValue);

                if (null == model)
                {
                    throw new HasNotRecordException(_pKeyValue);
                }
            }

            model.SystemRoleID = string.IsNullOrWhiteSpace(_pKeyValue) ? 0 : int.Parse(_pKeyValue);

            model.SystemRoleName = UrlHelper.ReqStrByGetOrPost(context, "SystemRoleName");

            model.RoleDesc = UrlHelper.ReqStrByGetOrPost(context, "RoleDesc");

            model.IsSystem = UrlHelper.ReqBoolByGetOrPost(context, "IsSystem");

            return model;

        }
        /********  获取数据  可修改区域 End  ********/


        #region 其他


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