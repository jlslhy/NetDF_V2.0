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

namespace WEB.DataAccess.DataDictionaryTBL
{
    /// <summary>
    /// GetData_Extend 的摘要说明
    /// </summary>
    public class GetData_Extend : GetDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        DBControl.Base.BLLOpt<Model.DataDictionary_Model> Bll = new DBControl.Base.BLLOpt<Model.DataDictionary_Model>();
        DBControl.DBInfo.Tables.DataDictionary tableInfo = new DBControl.DBInfo.Tables.DataDictionary();


        public void ProcessRequest(HttpContext context)
        {
            /********  初始化 Start  ********/
            _tableName = "DataDictionary";
            _orderBy = "ID asc";
            _idField = "ID";


            /********  初始化 End  ********/
            context.Response.ContentType = "text/plain";
            Initial(context);

            if (UrlHelper.ReqStr("m").Equals("GetJsonDataByCategoryCode"))
            {
                GetDataListByCategoryCode();
            }
            else
            {
                ReturnMsg(false,  enumReturnTitle.Param, "请传递一个有效的参数。");
            }
             
        }


        public void GetDataListByCategoryCode()
        {
            string CategoryCode = UrlHelper.ReqStr("CategoryCode");
 

            try
            {
                
                IDataReader idr =  DBControl.Base.DBAccess.GetDataIDR("DataKey,DataValue", _tableName, "CategoryCode='" + CategoryCode + "'", " OrderNumber asc ");

                JsonArray jArray = new JsonArray();
                if (null != idr)
                {
                    int index = 0;
                    while (idr.Read())
                    {
                        JsonObject tempObj = new JsonObject();
                        tempObj.Add("DataValue", idr["DataValue"].ToString());
                        tempObj.Add("DataKey", idr["DataKey"].ToString());
                        jArray.Add(tempObj);
                        index++;
                    }
                    idr.Close();
                    idr.Dispose();
                }
                JsonWriter jWriter = new JsonWriter();
                jArray.Write(jWriter);
                CurrentContext.Response.Write(jWriter.ToString());
            }
            catch (Exception ex)
            {
                ReturnMsg(false, enumReturnTitle.GetData, string.Format("获取数据失败:{0}", ex.Message));
            }

        }
 
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
       
    }
}