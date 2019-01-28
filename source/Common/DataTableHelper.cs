using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SSSE.Common
{
    public class DataTableHelper
    {
        /// <param name="dt1">要合并的表一</param>
        /// <param name="dt2">要合并的表二</param>
        /// <param name="KeyColName">dt1与dt2联系的关键列名 </param>
        public static DataTable MergeDataTable(DataTable dt1, DataTable dt2, String KeyColName)
        {
            //定义临时变量 
            DataTable dtReturn = new DataTable();
            int i = 0;
            int j = 0;
            int k = 0;
            int colKey1 = 0;
            int colKey2 = 0;

            //设定表dtReturn的名字 
            dtReturn.TableName = dt1.TableName;
            //设定表dtReturn的列名 
            for (i = 0; i < dt1.Columns.Count; i++)
            {
                if (dt1.Columns[i].ColumnName == KeyColName)
                {
                    colKey1 = i;
                }
                dtReturn.Columns.Add(dt1.Columns[i].ColumnName);
            }
            for (j = 0; j < dt2.Columns.Count; j++)
            {
                if (dt2.Columns[j].ColumnName == KeyColName)
                {
                    colKey2 = j;
                    continue;
                }
                dtReturn.Columns.Add(dt2.Columns[j].ColumnName);
            }
            //建立表的空间 
            for (i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr;
                dr = dtReturn.NewRow();
                dtReturn.Rows.Add(dr);
            }

            //将表dt1,dt2的数据写入dtReturn 
            for (i = 0; i < dt1.Rows.Count; i++)
            {
                int m = -1;
                //表dt1的第i行数据拷贝到dtReturn中去 
                for (j = 0; j < dt1.Columns.Count; j++)
                {
                    dtReturn.Rows[i][j] = dt1.Rows[i][j].ToString();
                }
                //查找的dt2中KeyColName的数据,与dt1相同的行
                for (k = 0; k < dt2.Rows.Count; k++)
                {
                    if (dt1.Rows[i][colKey1].ToString() == dt2.Rows[k][colKey2].ToString())
                    {
                        m = k;
                    }
                }

                //表dt2的第m行数据拷贝到dtReturn中去,且不要KeyColName(ID)列 
                if (m != -1)
                {
                    for (k = 0; k < dt2.Columns.Count; k++)
                    {
                        if (k == colKey2)
                        {
                            continue;
                        }
                        dtReturn.Rows[i][j] = dt2.Rows[m][k].ToString();
                        j++;
                    }
                }
            }
            return dtReturn;
        }
    }
}
