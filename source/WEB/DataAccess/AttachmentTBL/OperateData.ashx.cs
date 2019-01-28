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

namespace WEB.DataAccess.AttachmentTBL
{
    /// <summary>
    /// OperateData 的摘要说明
    /// </summary>
    public class OperateData : OperateDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        /********   可修改区域 Start  ********/
        DBControl.Base.BLLOpt<Model.Attachment_Model> bll = new DBControl.Base.BLLOpt<Model.Attachment_Model>();
        // DBControl.BLL.AttachmentBLL bllExt = new DBControl.BLL.AttachmentBLL();

        /********   可修改区域 End  ********/

        public void ProcessRequest(HttpContext context)
        {
            /********  初始化 可修改区域 Start  ********/
            _tableName = "Attachment";
            _idField = "AttachID";
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
				  	  
				"[AttachID]"
				  	  
				,"[AttachGUID]"
				  	  
				,"[BatchGUID]"
				  	  
				,"[FileName]"
				  	  
				,"[Fix]"
				  	  
				,"[FileType]"
				  	  
				,"[HasThumbnail]"
				  	  
				,"[URI]"
				  	  
				,"[RelativeURL]"
				  	  
				,"[FileSize]"
				  	  
				,"[OrderNum]"
				  	  
				,"[Description]"
				  	  
				,"[MemberUpLoader]"
				  	  
				,"[UserUploader]"
				      
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
            Model.Attachment_Model model = GetNewDataModel(CurrentContext);
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
        private Model.Attachment_Model GetNewDataModel(HttpContext context)
        {
            Model.Attachment_Model model = new Model.Attachment_Model();
            if (IsEdit)
            {
                model = bll.GetModelByKeyValue(_pKeyValue);

                if (null == model)
                {
                    throw new HasNotRecordException(_pKeyValue);
                }
            }

            model.AttachID = string.IsNullOrWhiteSpace(_pKeyValue) ? 0 : int.Parse(_pKeyValue);

            model.AttachGUID = UrlHelper.ReqStrByGetOrPost(context, "AttachGUID");

            model.BatchGUID = UrlHelper.ReqStrByGetOrPost(context, "BatchGUID");

            model.FileName = UrlHelper.ReqStrByGetOrPost(context, "FileName");

            model.Fix = UrlHelper.ReqStrByGetOrPost(context, "Fix");

            model.FileType = UrlHelper.ReqStrByGetOrPost(context, "FileType");

            model.HasThumbnail = UrlHelper.ReqBoolByGetOrPost(context, "HasThumbnail");

            model.URI = UrlHelper.ReqStrByGetOrPost(context, "URI");

            model.RelativeURL = UrlHelper.ReqStrByGetOrPost(context, "RelativeURL");

            model.FileSize = UrlHelper.ReqFloatByGetOrPost(context, "FileSize");

            model.OrderNum = UrlHelper.ReqFloatByGetOrPost(context, "OrderNum");

            model.Description = UrlHelper.ReqStrByGetOrPost(context, "Description");

            model.MemberUpLoader = UrlHelper.ReqStrByGetOrPost(context, "MemberUpLoader");

            model.UserUploader = UrlHelper.ReqStrByGetOrPost(context, "UserUploader");

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