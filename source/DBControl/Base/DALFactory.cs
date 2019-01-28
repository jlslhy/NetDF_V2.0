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
using System.Reflection;

namespace DBControl.Base
{
    public partial class DALFactory<T> : Base.DALBase<T> where T : Model.Base.ModelBase, new()
    {

        public string TableName = string.Empty;
        public string PKey;
        public Type PKeyDataType;
        public DALFactory()
        {
            T model = new T();
            TableName = model.TableName;
            PKey = model.PKey;
            PKeyDataType = model.PKeyDataType;
        }

        /// <summary>
        /// 统计记录数
        /// </summary>
        /// <param name="condition">不要带 where </param>
        /// <returns></returns>
        public long Count(string condition)
        {
            string cmdtext = string.Format("select count(1) as cnt from {0} {1}", TableName, string.IsNullOrWhiteSpace(condition) ? string.Empty : "where " + condition);
            object obj = DbHelperSQL.GetSingle(cmdtext);
            if (null == obj)
            {
                return 0;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
        }

        #region 查询区域
        /// <summary>
        /// 根据主键值来获取一条记录
        /// </summary>
        /// <param name="pKeyValue">键值</param>
        /// <returns></returns>
        public T GetModelByKeyValue(string pKeyValue)
        {
            T model = new T();

            if (!model.PKeyDataType.IsDigitType())
            {
                pKeyValue = string.Format("'{0}'", pKeyValue);

            }
            string cmdtext = string.Format("select * from {0} where {1}={2}", model.TableName, model.PKey, pKeyValue);
            IDataReader idr = DbHelperSQL.ExecuteReader(cmdtext);
            model = DataReaderToModel(idr);
            if (null != idr && !idr.IsClosed)
            {
                idr.Close();

            }

            return model;
        }
         
        /// <summary>
        /// 根据多个主键值来获取多条记录
        /// </summary>
        /// <param name="orderBy">排序，如 ID DESC[,CreateTime DESC]，不需要加order by</param>
        /// <param name="pKeyValueList">键值集合</param>
        /// <returns></returns>
        public List<T> GetListByKeyValues(string orderBy, List<string> pKeyValueList)
        {
            if (null == pKeyValueList)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = string.Format(" order by {0} ", orderBy);
            }

            T model = new T();
            StringBuilder pKeysSB = new StringBuilder();
            foreach (string pKey in pKeyValueList)
            {
                if (model.PKeyDataType.IsDigitType())
                {
                    pKeysSB.Append(string.Format("{0},", pKey));
                }
                else
                {
                    pKeysSB.Append(string.Format("'{0}',", pKey));
                }
            }

            List<T> list = new List<T>();
            string cmdtext = string.Format("select * from {0} where {1} in ({2})  {3}", model.TableName, model.PKey, pKeysSB.ToString().Trim(','), orderBy);
            IDataReader idr = DbHelperSQL.ExecuteReader(cmdtext);
            list = DataReaderToList(idr);
            if (null != idr && !idr.IsClosed)
            {
                idr.Close();

            }

            return list;
        }
        /// <summary>
        /// 根据多个主键值来获取多条记录
        /// </summary>
        /// <param name="orderBy">排序，如 ID DESC[,CreateTime DESC]，不需要加order by</param>
        /// <param name="pKeyValues">键值数据</param>
        /// <returns></returns>
        public List<T> GetListByKeyValues(string orderBy, params string[] pKeyValues)
        {
            if (null == pKeyValues)
            { return null; }
            List<string> pKeyValueList = pKeyValues.ToList<string>();

            return GetListByKeyValues(orderBy, pKeyValueList);
        }


        public List<T> GetAllList()
        {
            string cmdtext = string.Format("select * from {0} ", TableName);
            IDataReader idr = DbHelperSQL.ExecuteReader(cmdtext);
            List<T> list = DataReaderToList(idr);
            if (null != idr && !idr.IsClosed)
            {
                idr.Close();

            }
            return list;
        }

        public List<T> GetAllList(string orderby)
        {
            StringBuilder cmdtextSB = new StringBuilder();
            cmdtextSB.Append(string.Format("select * from {0} ", TableName));


            if (!string.IsNullOrWhiteSpace(orderby))
            {
                cmdtextSB.Append(string.Format(" {0}", orderby));
            }
            IDataReader idr = DbHelperSQL.ExecuteReader(cmdtextSB.ToString());
            List<T> list = DataReaderToList(idr);
            if (null != idr && !idr.IsClosed)
            {
                idr.Close();

            }
            return list;
        }



        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="top">前面N条</param>
        /// <param name="condition">查询条件，不用带where</param>
        /// <param name="orderBy">排序，不用带order by</param>
        /// <returns></returns>
        public List<T> GetList(int top, string condition, string orderBy)
        {
            string topstr = "";
            if (top > 0)
            {
                topstr = string.Format(" top {0} ", top);
            }
            if (!string.IsNullOrWhiteSpace(condition))
            {
                condition = string.Format(" where {0} ", condition);
            }
            else
            {
                condition = "";
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = string.Format(" order by {0} ", orderBy);
            }
            else
            {
                orderBy = "";
            }

            string cmdtext = string.Format("select {0} * from {1} {2} {3}", topstr, TableName, condition, orderBy);
            IDataReader idr = DbHelperSQL.ExecuteReader(cmdtext);

            List<T> list = DataReaderToList(idr);

            if (null != idr && !idr.IsClosed)
            {
                idr.Close();
            }

            return list;

        }

        public List<T> GetList(string condition, string orderBy)
        {

            if (!string.IsNullOrWhiteSpace(condition))
            {
                condition = string.Format(" where {0} ", condition);
            }
            else
            {
                condition = "";
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = string.Format(" order by {0} ", orderBy);
            }
            else
            {
                orderBy = "";
            }

            string cmdtext = string.Format("select   * from {0} {1} {2} ", TableName, condition, orderBy);
            IDataReader idr = DbHelperSQL.ExecuteReader(cmdtext);

            List<T> list = DataReaderToList(idr);

            if (null != idr && !idr.IsClosed)
            {
                idr.Close();
            }

            return list;

        }

        public List<T> GetList(string condition)
        {
            return GetList(condition, string.Empty);
        }

        #region 高级分页

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageCol">按该列来进行分页</param>
        /// <param name="pageColType">pageCol列的类型,0-数字类型,1-字符类型,2-日期时间类型 </param>
        /// <param name="descOrder">排序,false-顺序,true-倒序 </param>
        /// <param name="pageSize">每页记录数 </param>
        /// <param name="page">指定页</param>
        /// <param name="selectType">查询类型,1-前页,2-后页,3-首页,4-末页,5-指定页</param>
        /// <param name="minid">当前页最小号</param>
        /// <param name="maxid">当前页最大号</param>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public List<T> GetPageData(string orderCol, int pageColType, bool descOrder, int pageSize, int page, int selectType, string minid, string maxid, string condition)
        {
            if (page <= 0 && selectType == 5)
            {
                return null;
            }

            SqlParameter[] sqlparams = new SqlParameter[] { 
                new SqlParameter("@tb",TableName),
                new SqlParameter("@col",orderCol),
                new SqlParameter("@coltype",pageColType),
                new SqlParameter("@orderby",descOrder),
                new SqlParameter("@collist","*"),
                new SqlParameter("@selecttype",selectType),
                new SqlParameter("@pagesize",pageSize),
                new SqlParameter("@page",page),
                new SqlParameter("@minid",minid),
                new SqlParameter("@maxid",maxid),
                new SqlParameter("@condition",condition)
            };

            IDataReader idr = DbHelperSQL.RunProcedure("sp_page", sqlparams);
            List<T> list = DataReaderToList(idr);
            if (null != idr && !idr.IsClosed)
            {
                idr.Close();
            }
            return list;
        }

        public List<T> GetPageData(int pageSize, int page, int selectType, string minid, string maxid, string condition, bool descOrder)
        {
            int pageColType = 1;
            if (PKeyDataType.IsDigitType())
            {
                pageColType = 0;
            }
            else if (PKeyDataType.Equals(typeof(System.String)))
            {
                pageColType = 1;

            }
            else if (PKeyDataType.Equals(typeof(System.DateTime)))
            {
                pageColType = 2;
            }
            return GetPageData(PKey, pageColType, descOrder, pageSize, page, selectType, minid, maxid, condition);
        }



        public List<T> GetPageData(int pageSize, int page, int selectType, string minid, string maxid, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            int pageColType = 1;
            if (orderColType.IsDigitType())
            {
                pageColType = 0;
            }
            else if (orderColType.Equals(typeof(System.String)))
            {
                pageColType = 1;

            }
            else if (orderColType.Equals(typeof(System.DateTime)))
            {
                pageColType = 2;
            }
            return GetPageData(orderCol, pageColType, descOrder, pageSize, page, selectType, minid, maxid, condition);
        }



        public List<T> GetPageData(int pageSize, int page, string condition, bool descOrder)
        {
            return GetPageData(pageSize, page, 5, null, null, condition, descOrder);
        }
        public List<T> GetPageData(int pageSize, int page, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            return GetPageData(pageSize, page, 5, null, null, condition, orderCol, orderColType, descOrder);
        }


        public List<T> GetFirstPage(int pageSize, string condition, bool descOrder)
        {
            return GetPageData(pageSize, 0, 3, null, null, condition, descOrder);
        }
        public List<T> GetFirstPage(int pageSize, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            return GetPageData(pageSize, 0, 3, null, null, condition, orderCol, orderColType, descOrder);
        }

        public List<T> GetLastPage(int pageSize, string condition, bool descOrder)
        {
            return GetPageData(pageSize, 0, 4, null, null, condition, descOrder);
        }
        public List<T> GetLastPage(int pageSize, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            return GetPageData(pageSize, 0, 4, null, null, condition, orderCol, orderColType, descOrder);
        }


        public List<T> GetPrevPage(int pageSize, string minid, string maxid, string condition, bool descOrder)
        {
            return GetPageData(pageSize, 0, 1, minid, maxid, condition, descOrder);
        }
        public List<T> GetPrevPage(int pageSize, string minid, string maxid, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            return GetPageData(pageSize, 0, 1, minid, maxid, condition, orderCol, orderColType, descOrder);
        }


        public List<T> GetNextPage(int pageSize, string minid, string maxid, string condition, bool descOrder)
        {
            return GetPageData(pageSize, 0, 2, minid, maxid, condition, descOrder);
        }
        public List<T> GetNextPage(int pageSize, string minid, string maxid, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            return GetPageData(pageSize, 0, 2, minid, maxid, condition, orderCol, orderColType, descOrder);
        }
        #endregion

        #region 普通分页

        /// <summary>
        /// 普通分页
        /// </summary>
        /// <param name="col">用以分页的列名 如 ID </param>
        /// <param name="collist">查询哪些列的数据,有逗号隔开 如 id,CName,CreateTime </param>
        /// <param name="PageSize">每页面的记录数</param>
        /// <param name="PageIndex">当前页面的序号 从0开始，0表示第一页数据，1表示第二页数据，如此类推。</param>
        /// <param name="Conditionn">条件，不要加where,如 ID=5 and CName='李' </param>
        /// <param name="Orderby">排序,不要加 order by ,如：ID desc 或 CreateTime desc </param>
        /// <returns></returns>
        public DataTable GetPage(string col, string collist, int PageSize, int PageIndex, string Conditionn, string Orderby, out int TotalRowsCount)
        {
            TotalRowsCount = 0;
            DataTable pagedata = new DataTable();
            SqlParameter[] sqlparams = new SqlParameter[] { 
                new SqlParameter("@TableName",TableName),
                new SqlParameter("@col",col),
                new SqlParameter("@collist",collist),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@Conditionn",Conditionn),
                new SqlParameter("@Orderby",Orderby)};

            DataSet ds = DbHelperSQL.RunProcedureDS("GetPage", sqlparams);
            if (null != ds && ds.Tables.Count.Equals(2))
            {
                pagedata = ds.Tables[0];
                TotalRowsCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            }

            return pagedata;

        }

        public DataTable GetPage(string collist, int PageSize, int PageIndex, string Conditionn, string Orderby, out int TotalRowsCount)
        {
            return GetPage(PKey, collist, PageSize, PageIndex, Conditionn, Orderby, out TotalRowsCount);
        }

        public DataTable GetPage(int PageSize, int PageIndex, string Conditionn, string Orderby, out int TotalRowsCount)
        {
            return GetPage(PKey, "*", PageSize, PageIndex, Conditionn, Orderby, out TotalRowsCount);
        }

        public DataTable GetPage(int PageSize, int PageIndex, string Conditionn, out int TotalRowsCount)
        {
            return GetPage(PKey, "*", PageSize, PageIndex, Conditionn, PKey + " desc ", out TotalRowsCount);
        }

        public DataTable GetPage(int PageSize, int PageIndex, out int TotalRowsCount)
        {
            return GetPage(PKey, "*", PageSize, PageIndex, "", PKey + " desc ", out TotalRowsCount);
        }


        #endregion

        #endregion







        #region  添加数据
        public bool AddModel(T model)
        {
            bool isSuccess = false;
            string cmdtext = model.AddSQL;
            try
            {
                if (model.PKeyDataType.IsDigitType())
                {
                    object obj = DbHelperSQL.GetSingle(cmdtext, model.ParamsForAdd);

                    if (null != obj && DBNull.Value != obj && obj.ToString() != "0")
                    {
                        PropertyInfo[] arrPInfo = model.GetType().GetProperties();
                        foreach (PropertyInfo PInfo in arrPInfo)
                        {

                            if (PInfo.Name.Equals(PKey))
                            {
                                if (model.PKeyDataType == typeof(System.Int32))
                                {
                                    PInfo.SetValue(model, System.Int32.Parse(obj.ToString()), null);
                                }
                                else if ((model.PKeyDataType == typeof(System.Int64))) {
                                    PInfo.SetValue(model, System.Int64.Parse(obj.ToString()), null);
                                }

                                break;
                            }
                        }
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                    }
                }
                else
                {
                    if (DbHelperSQL.ExecuteSql(cmdtext, model.ParamsForAdd) > 0)
                    {
                        isSuccess = true;
                    }
                }

            }
            catch(Exception ex)
            {
                isSuccess = false;
                throw ex;
            }

            return isSuccess;
        }
        /// <summary>
        /// 添加实体，返回主键值
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddModelBackKey(T model)
        {
            string cmdtext = model.AddSQL;
            try
            {

                if (!model.PKeyDataType.IsDigitType())
                {
                    if (DbHelperSQL.ExecuteSql(cmdtext, model.ParamsForAdd) > 0)
                    {
                        return model.PKeyValue.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    object obj = DbHelperSQL.GetSingle(cmdtext, model.ParamsForAdd);
                    if (null != obj && DBNull.Value != obj && obj.ToString() != "0")
                    {
                        return obj.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 批量插入实体数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public bool AddModelsByTransaction(List<T> models)
        {
            bool isSuccess = false;
            if (models != null && models.Count > 0)
            {
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.Transaction = tran;
                try
                {
                    if (models[0].PKeyDataType.IsDigitType())
                    {
                        foreach (T model in models)
                        {
                            comm.CommandText = model.AddSQL;
                            comm.Parameters.AddRange(model.ParamsForAdd);
                            object obj = comm.ExecuteScalar();
                            comm.Parameters.Clear();
                            if (null != obj && DBNull.Value != obj && obj.ToString() != "0")
                            {
                                PropertyInfo[] arrPInfo = model.GetType().GetProperties();
                                foreach (PropertyInfo PInfo in arrPInfo)
                                {

                                    if (PInfo.Name.Equals(PKey))
                                    {
                                        PInfo.SetValue(model, obj, null);

                                        break;
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }
                    else
                    {
                        foreach (T model in models)
                        {
                            comm.CommandText = model.AddSQL;
                            comm.Parameters.AddRange(model.ParamsForAdd);
                            if (comm.ExecuteNonQuery() < 0)
                            {
                                throw new Exception();
                            }
                            comm.Parameters.Clear();
                        }
                    }

                    tran.Commit();
                    isSuccess = true;
                }
                catch
                {
                    tran.Rollback();
                    conn.Close();
                }
                comm.Dispose();
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return isSuccess;

        }


        /// <summary>
        /// 批量插入实体数据,全部插入成功才返回True
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public bool AddModels(List<T> models, out List<T> errModels)
        {
            bool isSuccess = true;

            errModels = new List<T>();

            if (models != null && models.Count > 0)
            {
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;

                try
                {
                    if (models[0].PKeyDataType.IsDigitType())
                    {
                        foreach (T model in models)
                        {
                            comm.CommandText = model.AddSQL;
                            comm.Parameters.AddRange(model.ParamsForAdd);
                            object obj = comm.ExecuteScalar();
                            comm.Parameters.Clear();
                            if (null != obj && DBNull.Value != obj && obj.ToString() != "0")
                            {
                                PropertyInfo[] arrPInfo = model.GetType().GetProperties();
                                foreach (PropertyInfo PInfo in arrPInfo)
                                {

                                    if (PInfo.Name.Equals(PKey))
                                    {
                                        PInfo.SetValue(model, obj, null);

                                        break;
                                    }
                                }
                            }
                            else
                            {
                                errModels.Add(model);
                                isSuccess = false;
                            }
                        }
                    }
                    else
                    {
                        foreach (T model in models)
                        {
                            comm.CommandText = model.AddSQL;
                            comm.CommandType = CommandType.Text;
                            comm.Parameters.AddRange(model.ParamsForAdd);
                            if (comm.ExecuteNonQuery() <= 0)
                            {
                                errModels.Add(model);
                                isSuccess = false;
                            }
                            comm.Parameters.Clear();
                        }
                    }

                }
                catch
                {
                    isSuccess = false;
                    conn.Close();
                }
                comm.Dispose();
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return isSuccess;

        }


        #endregion

        public bool UpdateModel(T model)
        {
            bool ok = false;

            int i = DbHelperSQL.ExecuteSql(model.UpdateSQL, model.ParamsForUpdate);
            if (i > 0)
            {
                ok = true;
            }
            return ok;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public bool UpdateModelsByTransaction(List<T> models)
        {
            bool isSuccess = true;
            SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            SqlTransaction tran = conn.BeginTransaction();
            comm.Connection = conn;
            comm.Transaction = tran;
            try
            {
                foreach (T model in models)
                {
                    comm.CommandText = model.UpdateSQL;
                    comm.Parameters.AddRange(model.ParamsForUpdate);
                    if (comm.ExecuteNonQuery() <= 0)
                    {

                        tran.Rollback();
                        comm.Dispose();
                        conn.Close();
                        return false;

                    }
                    comm.Parameters.Clear();
                }
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                conn.Close();
                isSuccess = false;
            }

            comm.Dispose();
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }

            return isSuccess;

        }

        /// <summary>
        /// 只有全部更新成功才返回True
        /// </summary>
        /// <param name="models"></param>
        /// <param name="errModels"></param>
        /// <returns></returns>
        public bool UpdateModels(List<T> models, out List<T> errModels)
        {
            bool isSuccess = true;
            errModels = new List<T>();
            if (null != models && models.Count > 0)
            {
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                try
                {
                    conn.Open();
                    foreach (T model in models)
                    {
                        comm.CommandText = model.UpdateSQL;
                        comm.Parameters.AddRange(model.ParamsForUpdate);
                        if (comm.ExecuteNonQuery() <= 0)
                        {
                            errModels.Add(model);
                            isSuccess = false;
                        }
                        comm.Parameters.Clear();
                    }

                }
                catch
                {
                    isSuccess = false;
                    comm.Dispose();
                    conn.Close();
                }

                comm.Dispose();
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }

            }
            else
            {
                isSuccess = false;
            }


            return isSuccess;
        }


        #region 删除数据
        public bool DeleteModel(T model)
        {
            string cmdtext = string.Format("delete from {0} where {1}={2}",model.TableName,model.PKey,model.PKeyDataType.IsDigitType()?model.PKeyValue:"'"+model.PKeyValue+"'");
            return DbHelperSQL.ExecuteSql(cmdtext)>0;
        }

        public bool DeleteModels(List<T> models, out List<T> errModels)
        {
            bool isSuccess = true;
            errModels = new List<T>();
            foreach (T model in models)
            {
                if (!DeleteModel(model))
                {
                    isSuccess = false;
                    errModels.Add(model);
                }
            }
            return isSuccess;
        }


        public bool Delete(string pKeyValue)
        {
            T model = new T();
            string cmdtext = string.Format("delete from {0} where {1}={2}", model.TableName, model.PKey, model.PKeyDataType.IsDigitType() ? pKeyValue : "'" + pKeyValue + "'");
            return DbHelperSQL.ExecuteSql(cmdtext) > 0;
        }

        public bool Delete(List<string> pKeyValueList,out List<string> errValueList)
        {
            bool isSuccess = true;
            errValueList = new List<string>();
            foreach (string pKeyValue in pKeyValueList)
            {
                if (Delete(pKeyValue))
                {
                    isSuccess = false;
                    errValueList.Add(pKeyValue);
                }
            }
            return isSuccess;
        }

        public bool Delete(List<string> pKeyValueList)
        {
            T model = new T();
            bool isSuccess = false;
            if (null != pKeyValueList&&pKeyValueList.Count>0)
            {
                StringBuilder pKeyValueSB = new StringBuilder();
                foreach(string pKeyValue in pKeyValueList)
                {
                    if (model.PKeyDataType.IsDigitType())
                    {
                        pKeyValueSB.Append(string.Format(",{0}", pKeyValue));
                    }
                    else
                    {
                        pKeyValueSB.Append(string.Format(",'{0}'", pKeyValue));
                    }
                }
                string cmdtext = string.Format("delete from {0} where {1} in ({2})", model.TableName, model.PKey,pKeyValueSB.ToString().Trim(',') );
                isSuccess = DbHelperSQL.ExecuteSql(cmdtext)>0;
            }
            return isSuccess;
        }



        #endregion


    }
}
