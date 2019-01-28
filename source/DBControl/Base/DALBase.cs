/*
 * 设计者：LHY 2013-02-26  
 * 建议请邮：869067911@qq.com
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using SystemExtend;

namespace DBControl.Base
{
    public class DALBase<T> where T:Model.Base.ModelBase,new ()
    {
        /// <summary>
        /// DataReader 转换为 Model
        /// </summary>
        /// <param name="idr"></param>
        /// <returns></returns>
        protected virtual T DataReaderToModel(IDataReader idr)
        {
            if (null == idr)
            {
                return null;
            }
            if (idr.Read())
            {
                T model = new T();
                PropertyInfo[] arrPInfo = model.GetType().GetProperties();
                foreach (PropertyInfo PInfo in arrPInfo)
                {

                    if (!idr.HasField(PInfo.Name)) continue;

                    if (DBNull.Value != idr[PInfo.Name])
                    {
                        PInfo.SetValue(model, idr[PInfo.Name], null);
                        
                    }
                }
                return model;
            }
            else {
                return null;
            }
            
        }

        /// <summary>
        /// DataReader 转换为 ModelList
        /// </summary>
        /// <param name="idr"></param>
        /// <returns></returns>
        protected virtual List<T> DataReaderToList(IDataReader idr)
        {
            if (null == idr)
            {
                return null;
            }
            List<T> modelList = new List<T>();
            while (idr.Read())
            {
                T model = new T();

                PropertyInfo[] arrPInfo = model.GetType().GetProperties();
                foreach (PropertyInfo PInfo in arrPInfo)
                {
                    if (!idr.HasField(PInfo.Name)) continue;
                    if (DBNull.Value != idr[PInfo.Name])
                    {
                        PInfo.SetValue(model, idr[PInfo.Name], null);
                    }
                }
                modelList.Add( model);
            }

            if (modelList.Count > 0)
            {
                return modelList;
            }
            else {
                return null;
            }
        }


    }
}
