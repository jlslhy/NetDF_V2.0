/*
 * 设计者：LHY 2013-02-26  
 * 建议请邮：869067911@qq.com
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using SystemExtend;

namespace DBControl.Base
{
    public class DBAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="collist">要查询出的字段列表,*表示全部字段</param>
        /// <param name="orderCol">按该列来进行分页  </param>
        /// <param name="pageColType">@col列的类型,0-数字类型,1-字符类型,2-日期时间类型</param>
        /// <param name="descOrder">排序,0-顺序,1-倒序  </param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="page">指定页</param>
        /// <param name="selectType">查询类型,1-前页,2-后页,3-首页,4-末页,5-指定页  </param>
        /// <param name="minid">当前页最小号</param>
        /// <param name="maxid">当前页最大号</param>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static IDataReader GetPageDataIDR(string tableName,string collist,string orderCol, int pageColType, bool descOrder, int pageSize, int page, int selectType, string minid, string maxid, string condition)
        {
            if (page <= 0 && selectType == 5)
            {
                return null;
            }

            SqlParameter[] sqlparams = new SqlParameter[] { 
                new SqlParameter("@tb",tableName),
                new SqlParameter("@col",orderCol),
                new SqlParameter("@coltype",pageColType),
                new SqlParameter("@orderby",descOrder),
                new SqlParameter("@collist",collist),
                new SqlParameter("@selecttype",selectType),
                new SqlParameter("@pagesize",pageSize),
                new SqlParameter("@page",page),
                new SqlParameter("@minid",minid),
                new SqlParameter("@maxid",maxid),
                new SqlParameter("@condition",condition)
            };

            IDataReader idr = DbHelperSQL.RunProcedure("sp_page", sqlparams);

            return idr;
        }
 
        private static IDataReader GetPageDataIDR<T>(string collist, string orderCol, int pageColType, bool descOrder, int pageSize, int page, int selectType, string minid, string maxid, string condition) where T : DBControl.DBInfo.TableBase, new()
        {
            T tableInfo = new T();
            return GetPageDataIDR(tableInfo.TableName, collist, orderCol, pageColType, descOrder, pageSize, page, selectType, minid, maxid, condition);
        }


        #region 分页，传类型

        public static IDataReader GetPageDataIDR<T>(string collist, string orderCol,  bool descOrder, int pageSize, int page,  string condition) where T : DBControl.DBInfo.TableBase, new()
        {
            T tableInfo = new T();
            int pageColType=0;
            DBInfo.TableFieldInfo tFieldInfo = tableInfo.GetTabelFieldInfo(orderCol);
            if (tFieldInfo.DataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tFieldInfo.DataType.IsDateTimeType())
            {
                pageColType = 2;
            }
 
            return GetPageDataIDR<T>( collist,  orderCol,  pageColType,  descOrder,  pageSize,  page,5, string.Empty,string.Empty,  condition);
        }

        public static IDataReader GetPageDataIDR<T>(string collist, bool descOrder, int pageSize, int page, string condition) where T : DBControl.DBInfo.TableBase, new()
        {
            T tableInfo = new T();
            int pageColType = 0;

            if (tableInfo.PKeyDataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tableInfo.PKeyDataType.IsDateTimeType())
            {
                pageColType = 2;
            }
            
            return GetPageDataIDR<T>(collist, tableInfo.PKey, pageColType, descOrder, pageSize, page, 5, string.Empty, string.Empty, condition);
        }

        public static IDataReader GetFirstPageDataIDR<T>(string collist, string orderCol, bool descOrder, int pageSize, string condition) where T : DBControl.DBInfo.TableBase, new()
        { 
            T tableInfo = new T();
            int pageColType=0;
            DBInfo.TableFieldInfo tFieldInfo = tableInfo.GetTabelFieldInfo(orderCol);
            if (tFieldInfo.DataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tFieldInfo.DataType.IsDateTimeType())
            {
                pageColType = 2;
            }

            return  GetPageDataIDR<T>( collist,  orderCol,  pageColType,  descOrder,  pageSize, 0, 3, string.Empty, string.Empty,  condition);

        }
 
        public static IDataReader GetFirstPageDataIDR<T>(string collist, bool descOrder, int pageSize, string condition) where T : DBControl.DBInfo.TableBase, new()
        {
            T tableInfo = new T();
            int pageColType = 0;

            if (tableInfo.PKeyDataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tableInfo.PKeyDataType.IsDateTimeType())
            {
                pageColType = 2;
            }

            return GetPageDataIDR<T>(collist, tableInfo.PKey, pageColType, descOrder, pageSize, 0, 3, string.Empty, string.Empty, condition);

        }
 
        public static IDataReader GetLastPageDataIDR<T>(string collist, string orderCol, bool descOrder, int pageSize, string condition) where T : DBControl.DBInfo.TableBase, new()
        {
            T tableInfo = new T();
            int pageColType = 0;
            DBInfo.TableFieldInfo tFieldInfo = tableInfo.GetTabelFieldInfo(orderCol);
            if (tFieldInfo.DataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tFieldInfo.DataType.IsDateTimeType())
            {
                pageColType = 2;
            }

            return GetPageDataIDR<T>(collist, orderCol, pageColType, descOrder, pageSize, 0, 4, string.Empty, string.Empty, condition);

        }


        public static IDataReader GetLastPageDataIDR<T>(string collist, bool descOrder, int pageSize, string condition) where T : DBControl.DBInfo.TableBase, new()
        
        {
            T tableInfo = new T();
            int pageColType = 0;

            if (tableInfo.PKeyDataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tableInfo.PKeyDataType.IsDateTimeType())
            {
                pageColType = 2;
            }

            return GetPageDataIDR<T>(collist, tableInfo.PKey, pageColType, descOrder, pageSize, 0, 4, string.Empty, string.Empty, condition);

        }


        public static IDataReader GetPrevPageDataIDR<T>(string collist, string orderCol, bool descOrder, int pageSize,string minid,string maxid, string condition) where T : DBControl.DBInfo.TableBase, new()
        {
            T tableInfo = new T();
            int pageColType = 0;
            DBInfo.TableFieldInfo tFieldInfo = tableInfo.GetTabelFieldInfo(orderCol);
            if (tFieldInfo.DataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tFieldInfo.DataType.IsDateTimeType())
            {
                pageColType = 2;
            }

            return GetPageDataIDR<T>(collist, orderCol, pageColType, descOrder, pageSize, 0, 1, minid, maxid, condition);

        }


        public static IDataReader GetPrevPageDataIDR<T>(string collist, bool descOrder, int pageSize, string minid, string maxid, string condition) where T : DBControl.DBInfo.TableBase, new()
        {
            T tableInfo = new T();
            int pageColType = 0;

            if (tableInfo.PKeyDataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tableInfo.PKeyDataType.IsDateTimeType())
            {
                pageColType = 2;
            }

            return GetPageDataIDR<T>(collist, tableInfo.PKey, pageColType, descOrder, pageSize, 0, 1, minid, maxid, condition);

        }


        public static IDataReader GetNextPageDataIDR<T>(string collist, string orderCol, bool descOrder, int pageSize, string minid, string maxid, string condition) where T : DBControl.DBInfo.TableBase, new()
        {
            T tableInfo = new T();
            int pageColType = 0;
            DBInfo.TableFieldInfo tFieldInfo = tableInfo.GetTabelFieldInfo(orderCol);
            if (tFieldInfo.DataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tFieldInfo.DataType.IsDateTimeType())
            {
                pageColType = 2;
            }

            return GetPageDataIDR<T>(collist, orderCol, pageColType, descOrder, pageSize, 0, 2, minid, maxid, condition);

        }

        public static IDataReader GetNextPageDataIDR<T>(string collist, bool descOrder, int pageSize, string minid, string maxid, string condition) where T : DBControl.DBInfo.TableBase, new()
        {
            T tableInfo = new T();
            int pageColType = 0;

            if (tableInfo.PKeyDataType.IsStringType())
            {
                pageColType = 1;
            }
            else if (tableInfo.PKeyDataType.IsDateTimeType())
            {
                pageColType = 2;
            }

            return GetPageDataIDR<T>(collist, tableInfo.PKey, pageColType, descOrder, pageSize, 0, 2, minid, maxid, condition);

        }

        #endregion

        #region 分页 
        public static IDataReader GetPageDataIDR(string tableName, string collist, string orderCol, int pageColType, bool descOrder, int pageSize, int page, string condition)
        {
            return GetPageDataIDR(tableName, collist, orderCol, pageColType, descOrder, pageSize, page, 5, string.Empty, string.Empty, condition);
        }
        public static IDataReader GetFirstPageDataIDR(string tableName, string collist, string orderCol,int pageColType, bool descOrder, int pageSize, string condition)
        {
            return GetPageDataIDR(tableName,collist, orderCol, pageColType, descOrder, pageSize, 0, 3, string.Empty, string.Empty, condition);
        }

        public static IDataReader GetLastPageDataIDR(string tableName, string collist, string orderCol, int pageColType, bool descOrder, int pageSize, string condition)
        {
            return GetPageDataIDR(tableName,collist, orderCol, pageColType, descOrder, pageSize, 0, 4, string.Empty, string.Empty, condition);
        }

        public static IDataReader GetPrevPageDataIDR(string tableName, string collist, string orderCol,int pageColType, bool descOrder, int pageSize, string minid, string maxid, string condition)
        {
            return GetPageDataIDR(tableName,collist, orderCol, pageColType, descOrder, pageSize, 0, 1, minid, maxid, condition);
        
        }
        public static IDataReader GetNextPageDataIDR(string tableName, string collist, string orderCol, int pageColType, bool descOrder, int pageSize, string minid, string maxid, string condition)
        {
            return GetPageDataIDR(tableName,collist, orderCol, pageColType, descOrder, pageSize, 0, 2, minid, maxid, condition);
        }




        #endregion


        #region 多表关联查询，分页

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="collist">要查询出的字段列表,*表示全部字段</param>
        /// <param name="orderCol">按该列来进行分页  </param>
        /// <param name="pageColType">@col列的类型,0-数字类型,1-字符类型,2-日期时间类型</param>
        /// <param name="descOrder">排序,0-顺序,1-倒序  </param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="page">指定页</param>
        /// <param name="selectType">查询类型,1-前页,2-后页,3-首页,4-末页,5-指定页  </param>
        /// <param name="minid">当前页最小号</param>
        /// <param name="maxid">当前页最大号</param>
        /// <param name="condition">查询条件</param>
        /// <param name="otherTableCollist">另一个数据表的列列表 如：b.id,b.Name</param>
        /// <param name="otherTableAndCondition">另一个数据表的表名和关联条件 如 inner join otherTableName on a.bid = b.id and b.Name='testname'</param>
        /// <returns></returns>
        public static IDataReader GetPageDataMultiTableIDR(string tableName, string collist, string orderCol, int pageColType, bool descOrder, int pageSize, int page, int selectType, string minid, string maxid, string condition, string otherTableCollist, string otherTableAndCondition)
        {
            if (page <= 0 && selectType == 5)
            {
                return null;
            }

            SqlParameter[] sqlparams = new SqlParameter[] { 
                new SqlParameter("@tb",tableName),
                new SqlParameter("@col",orderCol),
                new SqlParameter("@coltype",pageColType),
                new SqlParameter("@orderby",descOrder),
                new SqlParameter("@collist",collist),
                new SqlParameter("@selecttype",selectType),
                new SqlParameter("@pagesize",pageSize),
                new SqlParameter("@page",page),
                new SqlParameter("@minid",minid),
                new SqlParameter("@maxid",maxid),
                new SqlParameter("@condition",condition),
new SqlParameter("@OtherTableCollist",otherTableCollist),
new SqlParameter("@OtherTableAndCondition",otherTableAndCondition)
            };

            IDataReader idr = DbHelperSQL.RunProcedure("sp_page_Multi_table", sqlparams);

            return idr;
        }

        public static IDataReader GetPageDataMultiTableIDR(string tableName, string collist, string orderCol, int pageColType, bool descOrder, int pageSize, int page, string condition, string otherTableCollist, string otherTableAndCondition)
        {
            return GetPageDataMultiTableIDR(tableName, collist, orderCol, pageColType, descOrder, pageSize, page, 5, string.Empty, string.Empty, condition, otherTableCollist, otherTableAndCondition);
        }
        public static IDataReader GetFirstPageDataMultiTableIDR(string tableName, string collist, string orderCol, int pageColType, bool descOrder, int pageSize, string condition, string otherTableCollist, string otherTableAndCondition)
        {
            return GetPageDataMultiTableIDR(tableName, collist, orderCol, pageColType, descOrder, pageSize, 0, 3, string.Empty, string.Empty, condition, otherTableCollist, otherTableAndCondition);
        }

        public static IDataReader GetLastPageDataMultiTableIDR(string tableName, string collist, string orderCol, int pageColType, bool descOrder, int pageSize, string condition, string otherTableCollist, string otherTableAndCondition)
        {
            return GetPageDataMultiTableIDR(tableName, collist, orderCol, pageColType, descOrder, pageSize, 0, 4, string.Empty, string.Empty, condition, otherTableCollist, otherTableAndCondition);
        }

        public static IDataReader GetPrevPageDataMultiTableIDR(string tableName, string collist, string orderCol, int pageColType, bool descOrder, int pageSize, string minid, string maxid, string condition, string otherTableCollist, string otherTableAndCondition)
        {
            return GetPageDataMultiTableIDR(tableName, collist, orderCol, pageColType, descOrder, pageSize, 0, 1, minid, maxid, condition, otherTableCollist, otherTableAndCondition);

        }
        public static IDataReader GetNextPageDataMultiTableIDR(string tableName, string collist, string orderCol, int pageColType, bool descOrder, int pageSize, string minid, string maxid, string condition, string otherTableCollist, string otherTableAndCondition)
        {
            return GetPageDataMultiTableIDR(tableName, collist, orderCol, pageColType, descOrder, pageSize, 0, 2, minid, maxid, condition, otherTableCollist, otherTableAndCondition);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">主表</param>
        /// <param name="collist">主表列</param>
        /// <param name="condition">主表条件</param>
        /// <param name="otherTableAndCondition">另一个数据表的表名和关联条件 如 inner join otherTableName on a.bid = b.id and b.Name='testname'</param>
        /// <returns></returns>
        public static long CountMultiTable(string tableName, string collist, string condition,   string otherTableAndCondition)
        {
            string cmdtext = string.Format("select COUNT(1) from (select {0} from {1} where {2} ) a {3}", collist, tableName, string.IsNullOrWhiteSpace(condition) ? "1=1" : condition, otherTableAndCondition);
             

            object obj = DbHelperSQL.GetSingle(cmdtext);
            if (null == obj || DBNull.Value == obj)
            {
                return 0L;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
        }

        #endregion







        public static IDataReader GetDataIDR(string top, string fieldStr, string tableName, string condition, string orderBy)
        {
            return GetDataIDR( top,  fieldStr,  tableName,  condition,  orderBy,null);
        }

        public static IDataReader GetDataIDR(string top, string fieldStr, string tableName, string condition, string orderBy,SqlParameter[] parameters)
        {
            top = string.IsNullOrWhiteSpace(top) ? string.Empty : "top " + top;
            fieldStr = string.IsNullOrWhiteSpace(fieldStr) ? "*" : fieldStr;
            condition = string.IsNullOrWhiteSpace(condition) ? "1=1" : condition;
            orderBy = string.IsNullOrWhiteSpace(orderBy) ? string.Empty : "order by " + orderBy;
            string cmdtext = string.Format("select {0} {1} from {2} where {3} {4}", top, fieldStr, tableName, condition, orderBy);
            if (null != parameters)
            {
                return DbHelperSQL.ExecuteReader(cmdtext);
            }
            else
            {
                return DbHelperSQL.ExecuteReader(cmdtext, parameters);
            }
        }




        public static IDataReader GetDataIDR(string top, string[] fieldsArr, string tableName, string condition, string orderBy)
        {
            StringBuilder fieldSB = new StringBuilder();
            if (null == fieldsArr || fieldsArr.Length == 0)
            {
                fieldSB.Append("*");
            }
            else {
                for (int i = 0; i < fieldsArr.Length; i++)
                {
                    if (i > 0) fieldSB.Append(",");
                    fieldSB.Append(fieldsArr[i]);
                }
            }

            return GetDataIDR(top,fieldSB.ToString(),tableName,condition,orderBy);


        }





        public static IDataReader GetDataIDR(string[] fieldsArr, string tableName, string condition, string orderBy)
        {
            return GetDataIDR("",fieldsArr,tableName,condition,orderBy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldStr"></param>
        /// <param name="tableName"></param>
        /// <param name="condition"></param>
        /// <param name="orderBy">不用带 order by</param>
        /// <returns></returns>
        public static IDataReader GetDataIDR(string fieldStr, string tableName, string condition, string orderBy)
        {
            return GetDataIDR("",fieldStr,tableName,condition,orderBy);
        }



        public static IDataReader GetAllDataIDR(string fieldStr, string tableName,  string orderBy)
        {
            return GetDataIDR(fieldStr,tableName,"",orderBy);
        }

        public static IDataReader GetAllDataIDR(string[] fieldsArr, string tableName, string orderBy)
        {
            return GetDataIDR(fieldsArr,tableName,"",orderBy);
        }

        public static bool HasRecord(string tableName, string condition)
        {
            if (string.IsNullOrWhiteSpace(condition))
            {
                condition = "1=1";
            }
            string cmdtext = string.Format("select count(1) from {0} where {1}",tableName,condition);
            object obj = DbHelperSQL.GetSingle(cmdtext);
            if (null == obj || DBNull.Value == obj)
            {
                return false;
            }
            else {
                return int.Parse(obj.ToString()) > 0;
            }

        }

        public static long Count(string tableName, string condition)
        {
            string cmdtext = string.Format("select count(1) from {0} ",tableName);
            if (!string.IsNullOrWhiteSpace(condition))
            {
                cmdtext = string.Format("{0} where {1}",cmdtext,condition);
            }

            object obj = DbHelperSQL.GetSingle(cmdtext);
            if (null == obj || DBNull.Value == obj)
            {
                return 0L;
            }
            else {
                return long.Parse(obj.ToString());
            }
        }

        public static long Count<T>( string condition) where T:DBControl.DBInfo.TableBase,new()
        {
            T tableInfo = new T();
            return Count(tableInfo.TableName,condition);
        }

    }
}
