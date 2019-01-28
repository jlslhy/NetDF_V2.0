using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;

namespace Common
{
    public class Converter
    {
        /// <summary>
        /// Ilist<T> 转换成 DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(IList<T> i_objlist)
        {
            if (i_objlist == null || i_objlist.Count <= 0)
            {
                return null;
            }
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (T t in i_objlist)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// Ilist 转换成 DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable(IList i_objlist)
        {
            if (i_objlist == null || i_objlist.Count <= 0)
            {
                return null;
            }
            DataTable dt = new DataTable();
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = i_objlist[0].GetType().GetProperties();

            foreach (System.Reflection.PropertyInfo pi in myPropertyInfo)
            {
                if (pi == null)
                {
                    continue;
                }
                dt.Columns.Add(pi.Name, System.Type.GetType(pi.PropertyType.ToString()));
            }
            for (int j = 0; j < i_objlist.Count; j++)
            {
                row = dt.NewRow();
                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];
                    row[pi.Name] = pi.GetValue(i, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }



    }


    /// <summary> 
    /// 实体转换辅助类 
    /// </summary> 
    public class DataTableToIList<T> where T : new()
    {
        /// <summary>
        /// DataTable转换成Model
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<T> ConvertDataTableToModel(DataTable dt)
        {
            // 定义集合 
            IList<T> ts = new List<T>();

            // 获得此模型的类型 
            Type type = typeof(T);

            string tempName = "";

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();

                // 获得此模型的公共属性 
                PropertyInfo[] propertys = t.GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;

                    // 检查DataTable是否包含此列 
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter 
                        if (!pi.CanWrite) continue;

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }

                ts.Add(t);
            }

            return ts;

        }

        /// <summary>
        /// DataSet转换成Model
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static IList<T> ConvertDataSetToModel(DataSet ds)
        {
            List<T> l = new List<T>();
            T model = default(T);

            if (ds.Tables[0].Columns[0].ColumnName == "RowNumber")
            {
                ds.Tables[0].Columns.Remove("RowNumber");
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                model = Activator.CreateInstance<T>();

                foreach (DataColumn dc in dr.Table.Columns)
                {
                    PropertyInfo pi = model.GetType().GetProperty(dc.ColumnName);
                    if (null == pi)
                    {
                        continue;
                    }
                    if (dr[dc.ColumnName] != DBNull.Value)
                        pi.SetValue(model, dr[dc.ColumnName], null);
                    else
                        pi.SetValue(model, null, null);
                }

                l.Add(model);
            }

            return l;


        }



    }
}
