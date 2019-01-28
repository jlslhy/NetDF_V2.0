using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;

namespace Common
{
    public class ExcelHelper
    {
        public static void DateTableToExcel(global::System.Data.DataTable dt, string FileName)
        {

            string[] Fields = new string[dt.Columns.Count];
            for (int i = 0; i < Fields.Length; i++)
            {
                Fields[i] = dt.Columns[i].ColumnName;
            }
 
            try
            {
                HttpResponse resp;
 
                string[] headers = Fields;
 
                resp = HttpContext.Current.Response;
 
                resp.ContentEncoding = global:: System.Text.Encoding.Default;

                resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
                //标题                  内容 
                string colHeaders = "", ls_item = "";
                int i = 0;
                DataRow[] myRow = dt.Select("");
                //取得数据表各列标题，各标题之间以\t分割，最后一个列标题后加回车符  
                for (i = 0; i < headers.Length; i++)
                {
                    colHeaders += headers[i] + "\t";
                }
                colHeaders += "\n";
                //向HTTP输出流中写入取得的数据信息  
                resp.Write(colHeaders);
                //逐行处理数据                    
                foreach (DataRow row in myRow)
                {
                    //在当前行中，逐列获得数据，数据之间以\t分割，结束时加回车符\n  
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        StringBuilder strSB = new StringBuilder();
                         
                        strSB.Append("\"" + row[i].ToString().Replace("\"", "\"\"") + "\"");
                        ls_item += strSB.ToString() + "\t";
                        //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据 
                    }
                    ls_item += "\n";
                    resp.Write(ls_item);
                    ls_item = "";
                }
                //写缓冲区中的数据到HTTP头文件中                  
                resp.End();
            }
            catch
            {
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="FieldsENameCName">字段名与别名的集合，把字段名换为别名，如果在集合找不到，即显示原字段名 格式  key:ID value:序号  </param>
        /// <param name="dt"></param>
        /// <param name="FileName"></param>
        public static void CreateExcel(Dictionary<string, string> FieldsENameCName, global::System.Data.DataTable dt, string FileName)
        {
            string[] Fields = new string[dt.Columns.Count];
            for (int i = 0; i < Fields.Length; i++)
            {
                Fields[i] = dt.Columns[i].ColumnName;
            }


            try
            {
                HttpResponse resp;

                string[] headers = Fields;

                //string[] headers = new string[] { "投稿人", "作者", "来源", "单位", "时间", "文章标题", "栏目", "积分" };



                resp = HttpContext.Current.Response;



                resp.ContentEncoding = global:: System.Text.Encoding.Default;

                resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
                //标题                  内容 
                string colHeaders = "", ls_item = "";
                int i = 0;
                DataRow[] myRow = dt.Select("");
                //取得数据表各列标题，各标题之间以\t分割，最后一个列标题后加回车符  
                for (i = 0; i < headers.Length; i++)
                {
                    if (FieldsENameCName != null && FieldsENameCName.ContainsKey(headers[i]))
                    {
                        colHeaders += FieldsENameCName[headers[i]] += "\t";
                    }
                    else
                    {
                        colHeaders += headers[i] + "\t";
                    }

                }
                colHeaders += "\n";
                //向HTTP输出流中写入取得的数据信息  
                resp.Write(colHeaders);
                //逐行处理数据                    
                foreach (DataRow row in myRow)
                {
                    //在当前行中，逐列获得数据，数据之间以\t分割，结束时加回车符\n  
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        StringBuilder strSB = new StringBuilder();
                        //string tempStr = row[i].ToString().Replace("\r\n","|");
                        //string[] tempArr = tempStr.Split('|');
                        //if (tempArr.Length > 0)
                        //{
                        //    foreach (string str in tempArr)
                        //    {
                        //        strSB.Append(str);
                        //    }
                        //}
                        //else {
                        //    strSB.Append(tempStr);
                        //}

                        strSB.Append("\"" + row[i].ToString().Replace("\"", "\"\"") + "\"");
                        ls_item += strSB.ToString() + "\t";
                        //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据 
                    }
                    ls_item += "\n";
                    resp.Write(ls_item);
                    ls_item = "";
                }
                //写缓冲区中的数据到HTTP头文件中                  
                resp.End();
            }
            catch
            {
            }
        }


    }
}
