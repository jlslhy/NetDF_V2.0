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
    /// TablesRelation 的摘要说明
    /// </summary>
    public class TablesRelation : GetDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private string RelationTableName = string.Empty;
        private string RelationTableParentID = string.Empty;
        private string RelationTableChildID = string.Empty;
        private string RelationTableParentIDVal = string.Empty;
        private string ChildTableName = string.Empty;
        private string ChildTableRelationID = string.Empty;
        private string ChildTablePKey = string.Empty;
        private string FieldsStr = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Initial(context);

            RelationTableName = UrlHelper.ReqStr("RelationTableName");
            RelationTableParentID = UrlHelper.ReqStr("RelationTableParentID");
            RelationTableChildID = UrlHelper.ReqStr("RelationTableChildID");
            RelationTableParentIDVal = UrlHelper.ReqStr("RelationTableParentIDVal");
            ChildTableName = UrlHelper.ReqStr("ChildTableName");
            ChildTableRelationID = UrlHelper.ReqStr("ChildTableRelationID");
            ChildTablePKey = UrlHelper.ReqStr("ChildTablePKey");
            FieldsStr = UrlHelper.ReqStr("FieldsStr");

            if (UrlHelper.ReqStr("m").Equals("GetDataList"))
            {
                GetDataList();
            }

            else
            {
                ReturnMsg(false, enumReturnTitle.Param, "请传递一个有效的参数。");
            }
           // context.Response.Write("Hello World");
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

             
            int pageSize = UrlHelper.ReqIntByGetOrPost("pageSize");
            int pageNumber = UrlHelper.ReqIntByGetOrPost("pageNumber");
            string condition = string.Format(" {0}={1} ", RelationTableParentID, RelationTableParentIDVal);


            string otherTableCollist = "";
            string[] arrFields = FieldsStr.Split(',');
            for (int i = 0; i < arrFields.Length; i++)
            {
                if (i > 0) otherTableCollist = otherTableCollist + ",";
                otherTableCollist = otherTableCollist + "b."+arrFields[i];
            }

            string otherTableAndCondition = string.Format(" inner join {0} b on a.{1}=b.{2}", ChildTableName, RelationTableChildID, ChildTableRelationID);  

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
                        idr = DBControl.Base.DBAccess.GetFirstPageDataMultiTableIDR(RelationTableName, "*", RelationTableChildID, 0, _descOrder, _pageSize, condition, otherTableCollist, otherTableAndCondition);

                        break;
                    case enumSelectType.LastPage:
                        idr = DBControl.Base.DBAccess.GetLastPageDataMultiTableIDR(RelationTableName, "*", RelationTableChildID, 0, _descOrder, _pageSize, condition, otherTableCollist, otherTableAndCondition);
                        break;
                    case enumSelectType.PrevPage:
                        idr = DBControl.Base.DBAccess.GetPrevPageDataMultiTableIDR(RelationTableName, "*", RelationTableChildID, 0, _descOrder, _pageSize, _minid, _maxid, condition, otherTableCollist, otherTableAndCondition);
                        break;
                    case enumSelectType.NextPage:
                        idr = DBControl.Base.DBAccess.GetNextPageDataMultiTableIDR(RelationTableName, "*", RelationTableChildID, 0, _descOrder, _pageSize, _minid, _maxid, condition, otherTableCollist, otherTableAndCondition);
                        break;
                    case enumSelectType.GoToPage:
                        idr = DBControl.Base.DBAccess.GetPageDataMultiTableIDR(RelationTableName, "*", RelationTableChildID, 0, _descOrder, _pageSize, _page, condition, otherTableCollist, otherTableAndCondition);
                        break;
                }

                JsonArray jArray = DataListToJson(idr, ChildTablePKey, _descOrder, ref _minid, ref _maxid, FieldsStr.Split(','));

                if (jArray.Count > 0)
                {
                    jsonData = JsonResult(true, enumReturnTitle.GetData, "数据获取成功。");

                    jsonData.Add("rowsccount", jArray.Count);
                    if (IsGetTotal)
                    {
                        _total = DBControl.Base.DBAccess.CountMultiTable(RelationTableName,"*",condition,otherTableAndCondition);
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}