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

namespace WEB.DataAccess.WF_WorkFlowTBL
{
    /// <summary>
    /// OperateData 的摘要说明
    /// </summary>
    public class OperateData : OperateDataBase, IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        /********   可修改区域 Start  ********/
        DBControl.Base.BLLOpt<Model.WF_WorkFlow_Model> bll = new DBControl.Base.BLLOpt<Model.WF_WorkFlow_Model>();
        DBControl.BLL.WF_WorkFlowBLL bllAddition = new DBControl.BLL.WF_WorkFlowBLL();
	    
	   // DBControl.BLL.WF_WorkFlowBLL bllExt = new DBControl.BLL.WF_WorkFlowBLL();

        /********   可修改区域 End  ********/

        public void ProcessRequest(HttpContext context)
        {
            /********  初始化 可修改区域 Start  ********/
            _tableName = "WF_WorkFlow";
			_idField = "ID";
            /********  初始化 可修改区域 End  ********/

            context.Response.ContentType = "text/plain";
            Initial(context);
            if (UrlHelper.ReqStr("m").Equals("DeleteByID"))
            {
                DeleteByID();
            }
			else if (UrlHelper.ReqStr("m").Equals("DeleteByIDs"))
            {
                DeleteByIDs();
            }
            else if (UrlHelper.ReqStr("m").Equals("GetJsonDataByID"))
            {
                GetJsonDataByID();
            }
			else if (UrlHelper.ReqStr("m").Equals("IsExist"))
            {
                IsExist();
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
				  	  
				"[WorkFlowID]"
				  	  
				,"[WorkFlowName]"
				  	  
				,"[Remark]"
				  	  
				,"[CreateTime]"
				  	  
				,"[WFAdministrator]"
				  	  
				,"[Enabled]"
				      
                };
                /*******************  字段 可修改区域 End  **********************/
                try
                {
                    IDataReader idr = DBControl.Base.DBAccess.GetDataIDR(fieldArr, _tableName, string.Format(" {0}={1}", _idField, id), string.Empty);

                    JsonObject jsonData = JsonResult(false, enumReturnTitle.GetData, "数据获取失败。");
                    JsonObject tempdata = OneDataRecordToJson(idr);
                    if (tempdata.Keys.Count > 0)
                    {
                        jsonData = JsonResult(true, enumReturnTitle.GetData, "数据获取成功。");
                        jsonData.Add("Data", tempdata);
                    }

                    JsonWriter jWriter = new JsonWriter();
                    jsonData.Write(jWriter);
                    CurrentContext.Response.Write(jWriter.ToString());
                }
                catch (Exception ex)
                {
                    ReturnMsg(false, enumReturnTitle.GetData, ex.Message);
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
            Model.WF_WorkFlow_Model model = GetNewDataModel(CurrentContext);
            /********   可修改区域 End  ********/

            bool issuccess = false;
            string msg = string.Empty;

            try
            {
                if (IsAdd)
                {
                    issuccess = bll.AddModel(model);
                    msg = issuccess ? "添加成功。" : "添加失败！";                }
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
		private void DeleteByIDs()
        {
            string ids = UrlHelper.ReqStr("ids");
			
            List<string> idlist = ids.Split(',').ToList();
            if (bll.Delete(idlist))
            {
                ReturnMsg(true, enumReturnTitle.OptData, "删除成功!");
            }
            else
            {
                ReturnMsg(false, enumReturnTitle.OptData, "删除失败!");
            }
        }

		private void IsExist()
        {
            string ColName = UrlHelper.ReqStr("ColName");
            string Val = UrlHelper.ReqStr("Val");
            bool isExist = false;
            if (IsAdd)
            {
                isExist = DBUtility.DbHelperSQL.Exists(_tableName, ColName, Val);
            }
            else
            {
                isExist = DBUtility.DbHelperSQL.Exists(_tableName, ColName, Val, _idField + "<>" + _pKeyValue);
            }

            if (isExist)
            {
                ReturnMsg(true, enumReturnTitle.GetData, "存在此值。");
            }
            else
            {
                ReturnMsg(false, enumReturnTitle.GetData, "不存在此值。");
            }
        }


        /********  获取数据  可修改区域 Start  ********/
        private Model.WF_WorkFlow_Model GetNewDataModel(HttpContext context)
        {
            Model.WF_WorkFlow_Model model = new Model.WF_WorkFlow_Model();
            if (IsEdit)
            {
                model = bll.GetModelByKeyValue(_pKeyValue);
                
                if (null == model)
                {
                    throw new HasNotRecordException(_pKeyValue);
                }
            }
			 
            model.ID = string.IsNullOrWhiteSpace(_pKeyValue) ? 0 : int.Parse(_pKeyValue);
			
            model.WorkFlowID = UrlHelper.ReqIntByGetOrPost(context, "WorkFlowID");
            
            model.WorkFlowName = UrlHelper.ReqStrByGetOrPost(context, "WorkFlowName");
			
            model.Remark = UrlHelper.ReqStrByGetOrPost(context, "Remark");
			
            model.CreateTime = UrlHelper.ReqDateTimeByGetOrPost(context, "CreateTime");
			
            model.WFAdministrator = UrlHelper.ReqStrByGetOrPost(context, "WFAdministrator");
			
            model.Enabled = UrlHelper.ReqBoolByGetOrPost(context, "Enabled");
			    
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