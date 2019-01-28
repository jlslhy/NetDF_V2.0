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
    public class TablesRelationChildTable : GetDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private string RelationTableName = string.Empty;
        private string RelationTableParentCode = string.Empty;
        private string RelationTableChildCode = string.Empty;
        private string RelationTableParentCodeVal = string.Empty;
        private string ChildTableName = string.Empty;
        private string ChildTableRelationCode = string.Empty;
        private string ChildTablePKey = string.Empty;
        private string FieldsStr = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Initial(context);

            RelationTableName = UrlHelper.ReqStr("RelationTableName");
            RelationTableParentCode = UrlHelper.ReqStr("RelationTableParentCode");
            RelationTableChildCode = UrlHelper.ReqStr("RelationTableChildCode");
            RelationTableParentCodeVal = UrlHelper.ReqStr("RelationTableParentCodeVal");
            ChildTableName = UrlHelper.ReqStr("ChildTableName");
            ChildTableRelationCode = UrlHelper.ReqStr("ChildTableRelationCode");
            ChildTablePKey = UrlHelper.ReqStr("ChildTablePKey");
            FieldsStr = UrlHelper.ReqStr("FieldsStr");

            if (UrlHelper.ReqStr("m").Equals("GetDataList"))
            {
                if (UrlHelper.ReqStr("sqljoinway").ToLower().Equals("relationleftjionchildtable"))
                {
                    GetDataList(enumSqlJoinWay.RelationLeftJoinChildTable);
                }
                else
                {
                    GetDataList();
                }
            }

            else
            {
                ReturnMsg(false, enumReturnTitle.Param, "请传递一个有效的参数。");
            }
           // context.Response.Write("Hello World");
        }
        public void GetDataList()
        {
            GetDataList(enumSqlJoinWay.ChildTableLeftJoinRelation);
        }

        public void GetDataList(enumSqlJoinWay sqlJoinWay)
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
            string condition = "";


            string TableCollist = FieldsStr.Trim(',');
            /*
            string[] arrFields = FieldsStr.Split(',');
            for (int i = 0; i < arrFields.Length; i++)
            {
                if (i > 0)  TableCollist =  TableCollist + ",";
                TableCollist =  TableCollist  +arrFields[i];
            }
            */


            string otherTableAndCondition = "";
            string mainTable = "";
            string orderCol = "";
            string otherTableColList = "*";
            
            switch (sqlJoinWay) { 
                case enumSqlJoinWay.ChildTableLeftJoinRelation:
                    mainTable = ChildTableName;
                    orderCol = ChildTablePKey;
                    otherTableAndCondition = string.Format(" Left Join {0} b on a.{1}=b.{2} and b.{3}={4}", RelationTableName, ChildTableRelationCode, RelationTableChildCode, RelationTableParentCode, RelationTableParentCodeVal);  
                    break;
                case enumSqlJoinWay.RelationLeftJoinChildTable:
                    mainTable = RelationTableName;
                    orderCol = RelationTableChildCode;
                    //otherTableColList = TableCollist;
                    otherTableColList = "*";
                    //TableCollist = "*";
                    TableCollist = string.Format(" {0},{1} ", RelationTableParentCode, RelationTableChildCode);
                    condition = string.Format(" {0}='{1}' ", RelationTableParentCode, RelationTableParentCodeVal);
                    otherTableAndCondition = string.Format(" Left Join {0} b on a.{1}=b.{2} ", ChildTableName, RelationTableChildCode, ChildTableRelationCode);  
                    break;
                 
            }
            

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
                        idr = DBControl.Base.DBAccess.GetFirstPageDataMultiTableIDR(mainTable, TableCollist, orderCol, 0, _descOrder, _pageSize, condition, otherTableColList, otherTableAndCondition);

                        break;
                    case enumSelectType.LastPage:
                        idr = DBControl.Base.DBAccess.GetLastPageDataMultiTableIDR(mainTable, TableCollist, orderCol, 0, _descOrder, _pageSize, condition, otherTableColList, otherTableAndCondition);
                        break;
                    case enumSelectType.PrevPage:
                        idr = DBControl.Base.DBAccess.GetPrevPageDataMultiTableIDR(mainTable, TableCollist, orderCol, 0, _descOrder, _pageSize, _minid, _maxid, condition, otherTableColList, otherTableAndCondition);
                        break;
                    case enumSelectType.NextPage:
                        idr = DBControl.Base.DBAccess.GetNextPageDataMultiTableIDR(mainTable, TableCollist, orderCol, 0, _descOrder, _pageSize, _minid, _maxid, condition, otherTableColList, otherTableAndCondition);
                        break;
                    case enumSelectType.GoToPage:
                        idr = DBControl.Base.DBAccess.GetPageDataMultiTableIDR(mainTable, TableCollist, orderCol, 0, _descOrder, _pageSize, _page, condition, otherTableColList, otherTableAndCondition);
                        break;
                }
                
               // JsonArray jArray = DataListToJson(idr, ChildTablePKey, _descOrder, ref _minid, ref _maxid, FieldsStr.Split(','));
                JsonArray jArray = DataListToJson(idr, orderCol, _descOrder, ref _minid, ref _maxid, (FieldsStr + "," + RelationTableChildCode).Split(','));

                if (jArray.Count > 0)
                {
                    jsonData = JsonResult(true, enumReturnTitle.GetData, "数据获取成功。");

                    jsonData.Add("rowsccount", jArray.Count);
                    if (IsGetTotal)
                    {
                        _total = DBControl.Base.DBAccess.CountMultiTable(mainTable, TableCollist, condition, otherTableAndCondition);
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

        public enum enumSqlJoinWay { 
            ChildTableLeftJoinRelation,
            RelationLeftJoinChildTable
            
        }
    }
}