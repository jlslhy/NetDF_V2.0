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
    /// TablesRelationOpt 的摘要说明
    /// </summary>
    public class TablesRelationOpt : GetDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Initial(context);

            if (UrlHelper.ReqStr("m").Equals("RelevanceTable"))
            {
                RelevanceTable();
            }

            else
            {
                ReturnMsg(false, enumReturnTitle.Param, "请传递一个有效的参数。");
            }


        }

        private void RelevanceTable() {
            string RelationTableName = UrlHelper.ReqStrByGetOrPost("RelationTableName");
            string RelationTableParentCode = UrlHelper.ReqStrByGetOrPost("RelationTableParentCode");
            string RelationTableParentCodeVal = UrlHelper.ReqStrByGetOrPost("RelationTableParentCodeVal");
            string RelationTableChildCode = UrlHelper.ReqStrByGetOrPost("RelationTableChildCode");
            string RelationTableChildCodeVal = UrlHelper.ReqStrByGetOrPost("RelationTableChildCodeVal");
            bool IsRelevance = UrlHelper.ReqBoolByGetOrPost("IsRelevance");
            string sql = "";
            bool IsOK = true;
            if (IsRelevance) // 关联，添加记录
            {
                bool exist = DBUtility.DbHelperSQL.Exists(string.Format("select COUNT(1) from {0} where {1}='{2}' and {3}= '{4}' ", RelationTableName, RelationTableParentCode, RelationTableParentCodeVal, RelationTableChildCode, RelationTableChildCodeVal));
                if (!exist) {
                    sql = string.Format("insert into {0} ({1},{2})values('{3}','{4}')", RelationTableName, RelationTableParentCode, RelationTableChildCode, RelationTableParentCodeVal, RelationTableChildCodeVal);
                    IsOK = DBUtility.DbHelperSQL.ExecuteSql(sql)>0;
                }

            }
            else { // 去除关联，删除记录
                sql = string.Format("delete {0} where {1}='{2}' and {3}='{4}'", RelationTableName, RelationTableParentCode, RelationTableParentCodeVal, RelationTableChildCode, RelationTableChildCodeVal);
                IsOK = DBUtility.DbHelperSQL.ExecuteSql(sql) > 0;
            }

            if (IsOK)
            {
                ReturnMsg(true, enumReturnTitle.OptData, "操作成功。");
            }
            else 
            {
                ReturnMsg(false,enumReturnTitle.OptData, "操作失败。");
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