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

namespace WEB.DataAccessCommon
{
    /// <summary>
    /// GetData 的摘要说明
    /// </summary>
    public class GetData : GetDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Initial(context);
            if (UrlHelper.ReqStr("m").Equals("GetJsonDataByCategoryCode"))
            {
                GetJsonDataForComboBox();
            }
            else if (UrlHelper.ReqStr("m").Equals("GetKeyValueJsonDataByDataTable"))
            {
                GetKeyValueJsonDataByDataTable();
            }

        }

        /// <summary>
        /// 获取ComboBox所需的数据
        /// </summary>
        private void GetJsonDataForComboBox()
        {
            string DataTable = UrlHelper.ReqStr("DataTable");
            string KeyField = UrlHelper.ReqStr("KeyField");
            string ValueField = UrlHelper.ReqStr("ValueField");
            try
            {
                IDataReader idr = DBControl.Base.DBAccess.GetDataIDR(string.Format("{0},{1}", KeyField, ValueField), DataTable, "", "");
                JsonArray jArray = new JsonArray();
                if (null != idr)
                {
                    int index = 0;
                    while (idr.Read())
                    {
                        JsonObject tempObj = new JsonObject();
                        tempObj.Add("id", idr[ValueField].ToString());
                        tempObj.Add("text", idr[KeyField].ToString());
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

        /// <summary>
        /// 根据表名称或表名与值获取键值对json数据
        /// </summary>
        private void GetKeyValueJsonDataByDataTable()
        {
            JsonObject jsonData = JsonResult(false, enumReturnTitle.GetData, "数据获取失败。");
            string DataTable = UrlHelper.ReqStr("DataTable");
            string KeyField = UrlHelper.ReqStr("KeyField");
            string ValueField = UrlHelper.ReqStr("ValueField");
            bool IsSingle = UrlHelper.ReqBoolByGetOrPost("IsSingle");
            string Val = UrlHelper.ReqStr("Val");
            string condition = "";
            if (IsSingle) {
                condition = string.Format(" {0}='{1}' ",ValueField,Val);
            }
            try
            {
                IDataReader idr = DBControl.Base.DBAccess.GetDataIDR(string.Format("{0},{1}", KeyField, ValueField), DataTable, condition, "");
                JsonArray jArray = new JsonArray();
                if (null != idr)
                {
                    jsonData = JsonResult(true, enumReturnTitle.GetData, "数据获取成功。");
                    int index = 0;
                    while (idr.Read())
                    {
                        JsonObject tempObj = new JsonObject();
                        tempObj.Add("DataValue", idr[ValueField].ToString());
                        tempObj.Add("DataKey", idr[KeyField].ToString());
                        jArray.Add(tempObj);
                        index++;
                    }
                    idr.Close();
                    idr.Dispose();
                }
                jsonData.Add("rows", jArray);
                JsonWriter jWriter = new JsonWriter();
                jsonData.Write(jWriter);
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