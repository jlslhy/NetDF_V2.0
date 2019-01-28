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

namespace WEB.DataAccess.CustomerTBL
{
    /// <summary>
    /// GetData 的摘要说明
    /// </summary>
    public class GetData_Select : GetDataBase, IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        DBControl.Base.BLLOpt<Model.WEB.Customer_Model> Bll = new DBControl.Base.BLLOpt<Model.WEB.Customer_Model>();
        DBControl.DBInfo.Tables.WEB.Customer tableInfo = new DBControl.DBInfo.Tables.WEB.Customer();
        public void ProcessRequest(HttpContext context)
        {
            /********  初始化 Start  ********/
            _tableName = "Customer";
            _orderBy = "ID asc";
            _idField = "ID";
           

            /********  初始化 End  ********/

            context.Response.ContentType = "text/plain";
            Initial(context);
            if (UrlHelper.ReqStr("m").Equals("GetAllJsonTreeData"))
            {
                string[] fieldArr = new String[] { 
                Department.Field.DepartmentID.ToString(),
                Department.Field.DeptName.ToString(),
                Department.Field.DeptFullName.ToString()
                 };
                GetAllJsonTreeData(context, _idField, _pidField, fieldArr);
            }
            else if (UrlHelper.ReqStr("m").Equals("GetJsonDataByID"))
            {
                GetJsonDataByID();
            }
            else if (UrlHelper.ReqStr("m").Equals("GetDataList"))
            {
                GetDataList();
            }
            else if (UrlHelper.ReqStr("m").Equals("GetDataTotal"))
            {
                GetDataTotal();  
            }
            else
            {
                ReturnMsg(false, enumReturnTitle.Param, "请传递一个有效的参数。");
            }

        }

		 
		


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void GetJsonDataByID()
        {
            string id = UrlHelper.ReqStr("id");
            if (!string.IsNullOrWhiteSpace(id))
            {
                /*******************  字段 可修改区域 Start  **********************/
                string[] fieldArr = new string[]{
				  	  
				"[ID]"
				  	  
				,"[CustomerCode]"
				  	  
				,"[CustomerName]"
				  	  
				,"[CustomerType]"
				  	  
				,"[CustomerOwner]"
				  	  
				,"[Region]"
				  	  
				,"[Contact]"
				      
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

        public void GetDataList()
        {
            _pageSize = UrlHelper.ReqIntByGetOrPost("pagesize", _pageSize);
            _total = UrlHelper.ReqLongByGetOrPost("total");
            _selectTypeName = UrlHelper.ReqStrByGetOrPost("selecttypename");
            _page = UrlHelper.ReqIntByGetOrPost("page");
            _minid = UrlHelper.ReqStrByGetOrPost("minid");
            _maxid = UrlHelper.ReqStrByGetOrPost("maxid");
            _descOrder = UrlHelper.ReqBoolByGetOrPost("descorder", true);

            bool IsGetTotal = UrlHelper.ReqBoolByGetOrPost("isgettotal", true);


            string[] fieldArr = new string[]{
                  	  
				"[ID]"
				  	  
				,"[CustomerCode]"
				  	  
				,"[CustomerName]"
				  	  
				,"[CustomerType]"
				  	  
				,"[CustomerOwner]"
				  	  
				,"[Region]"
				  	  
				,"[Contact]"
				      
                };
            int pageSize = UrlHelper.ReqIntByGetOrPost("pageSize");
            int pageNumber = UrlHelper.ReqIntByGetOrPost("pageNumber");


            string condition = MakeConditionString<DBControl.DBInfo.Tables.WEB.Customer>(HttpContext.Current, "s_");

            try
            {
                JsonObject jsonData = JsonResult(false, enumReturnTitle.GetData, "数据获取失败。");
                IDataReader idr = null;
                if (string.IsNullOrWhiteSpace(_selectTypeName))
                {
                    throw new Exception("请指定加载页面数据的类型，如首页selecttypename=firstpage等");
                }
                enumSelectType selectType = (enumSelectType)Enum.Parse(typeof(enumSelectType), _selectTypeName, true);

                switch (selectType)
                {
                    case enumSelectType.FirstPage:
                        idr = DBControl.Base.DBAccess.GetFirstPageDataIDR<DBControl.DBInfo.Tables.WEB.Customer>(fieldArr.ToString(","), _descOrder, _pageSize, condition);
                        break;
                    case enumSelectType.LastPage:
                        idr = DBControl.Base.DBAccess.GetLastPageDataIDR<DBControl.DBInfo.Tables.WEB.Customer>(fieldArr.ToString(","), _descOrder, _pageSize, condition);
                        break;
                    case enumSelectType.PrevPage:
                        idr = DBControl.Base.DBAccess.GetPrevPageDataIDR<DBControl.DBInfo.Tables.WEB.Customer>(fieldArr.ToString(","), _descOrder, _pageSize, _minid, _maxid, condition);
                        break;
                    case enumSelectType.NextPage:
                        idr = DBControl.Base.DBAccess.GetNextPageDataIDR<DBControl.DBInfo.Tables.WEB.Customer>(fieldArr.ToString(","), _descOrder, _pageSize, _minid, _maxid, condition);
                        break;
                    case enumSelectType.GoToPage:
                        idr = DBControl.Base.DBAccess.GetPageDataIDR<DBControl.DBInfo.Tables.WEB.Customer>(fieldArr.ToString(","), _descOrder, _pageSize, _page, condition);
                        break;


                }

                JsonArray jArray = DataListToJson(idr, tableInfo.PKey, _descOrder, ref _minid, ref _maxid, fieldArr);

                if (jArray.Count > 0)
                {
                    jsonData = JsonResult(true, enumReturnTitle.GetData, "数据获取成功。");

                    jsonData.Add("rowsccount", jArray.Count);
                    if (IsGetTotal)
                    {
                        _total = DBControl.Base.DBAccess.Count<DBControl.DBInfo.Tables.WEB.Customer>(condition);
                    }
                    jsonData.Add("total", _total);

                    jsonData.Add("minid", _minid);
                    jsonData.Add("maxid", _maxid);
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
            catch (Exception ex)
            {
                ReturnMsg(false, enumReturnTitle.GetData, string.Format("获取数据失败:{0}", ex.Message));
            }

        }
		/// <summary>
        /// 获取数据的总记录数
        /// </summary>
        private void GetDataTotal() {
            string condition = MakeConditionString<DBControl.DBInfo.Tables.WEB.Customer>(HttpContext.Current, "s_");
            bool IsGetTotal = UrlHelper.ReqBoolByGetOrPost("isgettotal", true);
            if (IsGetTotal)
            {
                _total = DBControl.Base.DBAccess.Count<DBControl.DBInfo.Tables.WEB.Customer>(condition);
            }
            JsonObject jsonData = JsonResult(true, enumReturnTitle.GetData, "数据获取成功。");
            jsonData.Add("total", _total);
            JsonWriter jWriter = new JsonWriter();
            jsonData.Write(jWriter);
            CurrentContext.Response.Write(jWriter.ToString());
        }

        #region 其他

       

        #endregion


    }
}