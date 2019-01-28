/*
 * 设计者：LHY 2013-02-26  
 * 建议请邮：869067911@qq.com
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DBControl.Base
{
    public class BLLOpt<T> :  DALBase<T> where T : Model.Base.ModelBase, new()
    {
         Base.DALFactory<T> dal = new  Base.DALFactory<T>();


        /// <summary>
        /// 统计记录数
        /// </summary>
        /// <param name="condition">不要带 where </param>
        /// <returns></returns>
        public long Count(string condition)
        {
            return dal.Count(condition);

        }

        public T GetModelByKeyValue(string pKeyValue)
        {
            return dal.GetModelByKeyValue(pKeyValue);
        }

        public T GetFirstModel(string condition)
        {
            List<T> list = GetList(condition);
            if (null != list && list.Count > 0)
            {
                return list[0];
            }
            else {
                return null;
            }
        }
        public T GetFirstModel(string condition, string orderBy)
        {
            List<T> list = GetList(condition,orderBy);
            if (null != list && list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        public List<T> GetListByKeyValues(string orderBy, List<string> pKeyValueList)
        {
            return dal.GetListByKeyValues(orderBy, pKeyValueList);
        }

        public List<T> GetListByKeyValues(string orderBy, params string[] pKeyValues)
        {
            return dal.GetListByKeyValues(orderBy, pKeyValues);
        }

        public List<T> GetAllList()
        {
            return dal.GetAllList();
        }
        public List<T> GetAllList(string orderby)
        {
            return dal.GetAllList(orderby);
        }


        public List<T> GetList(int top, string condition, string orderBy)
        {
            return dal.GetList(top, condition, orderBy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="orderBy">前面不要加order by</param>
        /// <returns></returns>
        public List<T> GetList(string condition, string orderBy)
        {
            return dal.GetList(condition, orderBy);
        }

        public List<T> GetList(string condition)
        {
            return dal.GetList(condition);
        }


        #region 高级分页
        public List<T> GetPageData(string pageCol, int pageColType, bool descOrder, int pageSize, int page, int selectType, string minid, string maxid, string condition)
        {
            return dal.GetPageData(pageCol, pageColType, descOrder, pageSize, page, selectType, minid, maxid, condition);
        }


        public List<T> GetPageData(int pageSize, int page, int selectType, string minid, string maxid, string condition, bool descOrder)
        {
            return dal.GetPageData(pageSize, page, selectType, minid, maxid, condition, descOrder);
        }

        public List<T> GetPageData(int pageSize, int page, string condition, bool descOrder)
        {
            return dal.GetPageData(pageSize, page, condition, descOrder);
        }


        public List<T> GetFirstPage(int pageSize, string condition, bool descOrder)
        {
            return dal.GetFirstPage(pageSize, condition, descOrder);
        }
        public List<T> GetFirstPage(int pageSize, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            return dal.GetFirstPage(pageSize, condition, orderCol, orderColType, descOrder);
        }




        public List<T> GetLastPage(int pageSize, string condition, bool descOrder)
        {
            return dal.GetLastPage(pageSize, condition, descOrder);
        }
        public List<T> GetLastPage(int pageSize, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            return dal.GetLastPage(pageSize, condition, orderCol, orderColType, descOrder);
        }





        public List<T> GetPrevPage(int pageSize, string minid, string maxid, string condition, bool descOrder)
        {
            return dal.GetPrevPage(pageSize, minid, maxid, condition, descOrder);
        }

        public List<T> GetPrevPage(int pageSize, string minid, string maxid, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            return dal.GetPrevPage(pageSize, minid, maxid, condition, orderCol, orderColType, descOrder);
        }



        public List<T> GetNextPage(int pageSize, string minid, string maxid, string condition, bool descOrder)
        {
            return dal.GetNextPage(pageSize, minid, maxid, condition, descOrder);
        }
        public List<T> GetNextPage(int pageSize, string minid, string maxid, string condition, string orderCol, Type orderColType, bool descOrder)
        {
            return dal.GetNextPage(pageSize, minid, maxid, condition, orderCol, orderColType, descOrder);
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
            return dal.GetPage(col, collist, PageSize, PageIndex, Conditionn, Orderby, out  TotalRowsCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collist">查询哪些列的数据,有逗号隔开 如 id,CName,CreateTime </param>
        /// <param name="PageSize">每页面的记录数</param>
        /// <param name="PageIndex">当前页面的序号 从0开始，0表示第一页数据，1表示第二页数据，如此类推。</param>
        /// <param name="Conditionn">条件，不要加where,如 ID=5 and CName='李' </param>
        /// <param name="Orderby">排序,不要加 order by ,如：ID desc 或 CreateTime desc </param>
        /// <param name="TotalRowsCount"></param>
        /// <returns></returns>
        public DataTable GetPage(string collist, int PageSize, int PageIndex, string Conditionn, string Orderby, out int TotalRowsCount)
        {
            return dal.GetPage(collist, PageSize, PageIndex, Conditionn, Orderby, out TotalRowsCount);
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="PageSize">每页面的记录数</param>
        /// <param name="PageIndex">当前页面的序号 从0开始，0表示第一页数据，1表示第二页数据，如此类推。</param>
        /// <param name="Conditionn">条件，不要加where,如 ID=5 and CName='李' </param>
        /// <param name="Orderby">排序,不要加 order by ,如：ID desc 或 CreateTime desc </param>
        /// <param name="TotalRowsCount"></param>
        /// <returns></returns>
        public DataTable GetPage(int PageSize, int PageIndex, string Conditionn, string Orderby, out int TotalRowsCount)
        {
            return dal.GetPage(PageSize, PageIndex, Conditionn, Orderby, out TotalRowsCount);
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="PageSize">每页面的记录数</param>
        /// <param name="PageIndex">当前页面的序号 从0开始，0表示第一页数据，1表示第二页数据，如此类推。</param>
        /// <param name="Conditionn">条件，不要加where,如 ID=5 and CName='李' </param>

        /// <param name="TotalRowsCount"></param>
        /// <returns></returns>
        public DataTable GetPage(int PageSize, int PageIndex, string Conditionn, out int TotalRowsCount)
        {
            return dal.GetPage(PageSize, PageIndex, Conditionn, out TotalRowsCount);
        }

        /// <summary>
        /// 
        /// </summary>

        /// <param name="PageSize">每页面的记录数</param>
        /// <param name="PageIndex">当前页面的序号 从0开始，0表示第一页数据，1表示第二页数据，如此类推。</param>
        /// <param name="Conditionn">条件，不要加where,如 ID=5 and CName='李' </param>

        /// <param name="TotalRowsCount"></param>
        /// <returns></returns>
        public DataTable GetPage(int PageSize, int PageIndex, out int TotalRowsCount)
        {
            return dal.GetPage(PageSize, PageIndex, out TotalRowsCount);
        }

        #endregion



        public bool AddModel(T model)
        {
            return dal.AddModel(model);
        }

        public string AddModelBackKey(T model)
        {
            return dal.AddModelBackKey(model);
        }

        public bool AddModelsByTransaction(List<T> models)
        {
            return dal.AddModelsByTransaction(models);
        }

        public bool AddModels(List<T> models, out List<T> errModels)
        {
            return dal.AddModels(models, out errModels);
        }


        public bool UpdateModel(T model)
        {
            return dal.UpdateModel(model);
        }


        public bool UpdateModelsByTransaction(List<T> models)
        {
            return dal.UpdateModelsByTransaction(models);
        }

        public bool UpdateModels(List<T> models, out List<T> errModels)
        {
            return dal.UpdateModels(models, out errModels);
        }

        #region 删除数据
        public bool DeleteModel(T model)
        {
            return dal.DeleteModel(model);
        }

        public bool DeleteModels(List<T> models, out List<T> errModels)
        {
            return dal.DeleteModels(models,out errModels);
        }

        public bool Delete(string pKeyValue)
        {
            return dal.Delete(pKeyValue);
        }

        public bool Delete(List<string> pKeyValueList, out List<string> errValueList)
        {
            return dal.Delete(pKeyValueList,out errValueList);
        }


        public bool Delete(List<string> pKeyValueList)
        {
            return dal.Delete(pKeyValueList);
        }



        #endregion

    }
}
