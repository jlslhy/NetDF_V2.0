using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Common
{
    public static class JsonHelper
    {
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling            
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{\"totalCount\":" + dt.Rows.Count.ToString() + ",");
                JsonString.Append("\"JsonData\":[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                        }
                    }                /**/                /**/                /**/                /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else { JsonString.Append("},"); }
                } JsonString.Append("]}"); return JsonString.ToString();
            }
            else { return null; }
        }


        public static string ListDataToJson<T>(bool isHasJsonData, IList<T> list, List<string> generateJson)
        {
            StringBuilder Json = new StringBuilder();

            if (list != null && list.Count > 0)
            {
                if (isHasJsonData)
                {
                    Json.Append("{\"totalCount\":" + list.Count.ToString() + ",");
                    Json.Append("\"JsonData\":[");
                }
                else
                {
                    Json.Append("[");
                }

                for (int i = 0; i < list.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();

                    PropertyInfo[] pi = obj.GetType().GetProperties();

                    Json.Append("{");

                    for (int j = 0; j < pi.Length; j++)
                    {
                        if (generateJson.Contains(pi[j].Name))
                        {
                            Type type = pi[j].PropertyType.FullName.GetType();


                            object piValue = pi[j].GetValue(list[i], null);
                            Json.Append("\"" + pi[j].Name.ToString() + "\":" + StringFormat(piValue == null ? string.Empty : piValue.ToString(), type));


                            Json.Append(",");

                        }
                    }

                    Json.Replace(",", "", Json.Length - 1, 1);

                    Json.Append("}");

                    if (i < list.Count - 1)
                    {
                        Json.Append(",");
                    }
                }

                if (isHasJsonData)
                {
                    Json.Append("]}");
                }
                else
                {
                    Json.Append("]");
                }
            }
            else
            {
                return null;
            }

            return Json.ToString();
        }


        public static string DataReaderToJson (bool isHasJsonData, IDataReader iDr, IList<string> fieldList)
        {
            StringBuilder JsonFirst = new StringBuilder();
            StringBuilder Json = new StringBuilder();
 
            int i = 0;
            if (iDr != null )
            {
                

                
                while (iDr.Read())
                {
                    if (i > 0)
                    {
                        Json.Append(",");
                    }

                    

                    Json.Append("{");

                    for (int j = 0; j < iDr.FieldCount; j++)
                    {
                        if (fieldList.Contains(iDr.GetName(j)))
                        {

                            if (j > 0)
                            {
                                Json.Append(",");
                            }
                            Json.Append("\"" + iDr.GetName(j) + "\":\"" + iDr[j].ToString()+"\"");

                             
                        }
                    }

                    

                    Json.Append("}");


                    i++;
                    
                }

                iDr.Close();
                iDr.Dispose();

                if (isHasJsonData)
                {
                    Json.Append("]}");
                }
                else
                {
                    Json.Append("]");
                }
            }
            else
            {
                return null;
            }

            if (isHasJsonData)
            {
                JsonFirst.Append("{\"totalCount\":"+i.ToString()+",");
                JsonFirst.Append("\"JsonData\":[");
            }
            else
            {
                JsonFirst.Append("[");
            }
             
            return JsonFirst.Append(Json.ToString()).ToString();
        }


        public static string AddToJson(string newVars, string oldJson)
        {
            StringBuilder jsonSB = new StringBuilder();
            jsonSB.Append("{" + newVars + ",");
            jsonSB.Append(oldJson.Substring(1));
            return jsonSB.ToString();
        }

        public static string ModelToJsonData<T>(T model)
        {
            StringBuilder jsonSB = new StringBuilder();
            jsonSB.Append("{");
            Type t = typeof(T);
            PropertyInfo[] propertyArr = t.GetProperties();
            int index = 0;
            foreach (PropertyInfo PInfo in propertyArr)
            {
                if (index > 0)
                {
                    jsonSB.Append(",");
                }
                jsonSB.Append("\"" + PInfo.Name + "\":\"" + PInfo.GetValue(model, null).ToString().Replace((char)13, ' ').Replace((char)10, ' ').Replace("\n\r", " ") + "\"");
                index++;
            }
            jsonSB.Append("}");
            return jsonSB.ToString();

        }




        #region 辅助方法    过滤特殊字符、格式化字符型、日期型、布尔型

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="s">字符</param>
        /// <returns></returns>
        private static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];

                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 格式化字符型、日期型、布尔型
        /// </summary>
        /// <param name="str">字符内容</param>
        /// <param name="type">字符类型</param>
        /// <returns></returns>
        private static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            else if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }

            return str;
        }

        #endregion


    }
}
