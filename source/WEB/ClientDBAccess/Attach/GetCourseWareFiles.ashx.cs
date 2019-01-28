using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DBControl;
using DBControl.DBInfo.Tables;
using Common;
using NetServ.Net.Json;
using SystemExtend;
using WEB.DataAccessBase;
namespace WEB.ClientDBAccess.Attach
{
    /// <summary>
    /// GetCourseWareFiles 的摘要说明
    /// </summary>
    public class GetCourseWareFiles : GetDataBase, IHttpHandler
    {
        DBControl.BLL.AttachmentBLL attaBllExt = new DBControl.BLL.AttachmentBLL();
        public void ProcessRequest(HttpContext context)
        { 
            CurrentContext = context; 
            context.Response.ContentType = "text/plain";
           // context.Response.Write("Hello World");
            if (UrlHelper.ReqStrByGetOrPost("m").Equals("ByBatchGUID"))
            {
                GetCourseWareFilesByBatchGUID();
            }
            else if (UrlHelper.ReqStrByGetOrPost("m").Equals("ByAttachID"))
            {
                GetCourseWareFilesByAttachID();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        private void GetCourseWareFilesByBatchGUID()
        {
            string BatchGUID = UrlHelper.ReqStrByGetOrPost("batchguid");
            
            IDataReader idr = attaBllExt.GetDataByBatchGUID(BatchGUID);

            string[] fieldArr = new string[]{
                  	  
				"[AttachID]"
				  	  
				,"[AttachGUID]"
				  	  
				,"[FileName]"
				  	  
				,"[Fix]"
				  	  
				,"[FileType]"

                ,"[RelativeURL]"

                ,"[FileSize]"

                ,"[Description]"

                ,"[OrderNum]"
                };
            JsonObject jsonData = JsonResult(false, enumReturnTitle.GetData, "数据获取失败。");
            JsonArray jArray = DataListToJson(idr, "OrderNum", _descOrder, ref _minid, ref _maxid, fieldArr);
            if (jArray.Count > 0)
            {
                jsonData = JsonResult(true, enumReturnTitle.GetData, "数据获取成功。");

                jsonData.Add("rowsccount", jArray.Count);

                jsonData.Add("rows", jArray);
            }
            else
            {
                jsonData = JsonResult(false, enumReturnTitle.GetData, "没数据。");
            }
            JsonWriter jWriter = new JsonWriter();
            jsonData.Write(jWriter);
            CurrentContext.Response.Write(jWriter.ToString());

        }

        private void GetCourseWareFilesByAttachID() {
            string AttachID = UrlHelper.ReqStrByGetOrPost("attachid");
            DBControl.BLL.AttachmentBLL attaBllExt = new DBControl.BLL.AttachmentBLL();
            IDataReader idr = attaBllExt.GetDataByAttachID(AttachID);

            string[] fieldArr = new string[]{
                  	  
				"[AttachID]"
				  	  
				,"[AttachGUID]"
				  	  
				,"[FileName]"
				  	  
				,"[Fix]"
				  	  
				,"[FileType]"

                ,"[RelativeURL]"

                ,"[FileSize]"

                ,"[Description]"

                ,"[OrderNum]"
                };
            JsonObject jsonData = JsonResult(false, enumReturnTitle.GetData, "数据获取失败。");
            JsonArray jArray = DataListToJson(idr, "OrderNum", _descOrder, ref _minid, ref _maxid, fieldArr);
            if (jArray.Count > 0)
            {
                attaBllExt.AddDownloadCount(AttachID);
                jsonData = JsonResult(true, enumReturnTitle.GetData, "数据获取成功。");

                jsonData.Add("rowsccount", jArray.Count);

                jsonData.Add("rows", jArray);
                 
            }
            else
            {
                jsonData = JsonResult(false, enumReturnTitle.GetData, "没数据。");
            }
            JsonWriter jWriter = new JsonWriter();
            jsonData.Write(jWriter);
            CurrentContext.Response.Write(jWriter.ToString());
        }

         
    }
}