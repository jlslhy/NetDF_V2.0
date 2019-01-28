using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBUtility
{
    public class DBTypeMap
    {
        /// <summary>
        /// 映射数据类型
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="isNullable"></param>
        /// <returns></returns>
        public static string GetTypeNameByDBType(string typeName, string isNullable)
        {
            string result = "";
            switch (typeName)
            {
                case "bit":
                    result = string.Format("bool{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "tinyint":
                    result = string.Format("byte{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "smallint":
                    result = string.Format("short{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "int":
                    result = string.Format("int{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "bigint":
                    result = string.Format("long{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "numeric":
                case "decimal":
                case "smallmoney":
                case "money":
                    result = string.Format("decimal{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "float":
                    result = string.Format("double{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "real":
                    result = string.Format("Single{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "datetime":
                case "smalldatetime":
                case "date":
                case "time":
                case "datetimeoffset":
                case "datetime2":
                    result = string.Format("DateTime{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "char":
                case "varchar":
                case "text":
                case "nchar":
                case "nvarchar":
                case "ntext":
                    result = "string";
                    break;

                case "binary":
                case "varbinary":
                case "image":
                    result = string.Format("byte{0}[]", isNullable.Equals("Y") ? "?" : "");
                    break;

                case "timestamp":
                    result = string.Format("DateTime{0}", isNullable.Equals("Y") ? "?" : "");
                    break;
                case "uniqueidentifier":
                    result = string.Format("Guid{0}", isNullable.Equals("Y") ? "?" : "");
                    break;


                default:
                    result = "string";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 把Sql字段类型名称转为C#类型
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type GetTypeByDBTypeName(string typeName)
        {
            Type t = null;
            switch (typeName.ToLower())
            {
                case "bit":
                    t = typeof(Boolean);
                    break;
                case "tinyint":
                    t = typeof(System.Byte);
                    break;
                case "smallint":
                    t = typeof(Int16);
                    break;
                case "int":
                    t = typeof(Int32);
                    break;
                case "bigint":
                    t = typeof(Int64);
                    break;
                case "numeric":
                case "decimal":
                case "smallmoney":
                case "money":
                    t = typeof(System.Decimal);
                    break;
                case "float":
                    t = typeof(System.Double);
                    break;
                case "real":
                    t = typeof(System.Single);
                    break;
                case "datetime":
                case "smalldatetime":
                case "date":
                case "time":
                case "datetimeoffset":
                case "datetime2":
                    t = typeof(System.DateTime);
                    break;
                case "char":
                case "varchar":
                case "text":
                case "nchar":
                case "nvarchar":
                case "ntext":
                    t = typeof(String);
                    break;
                case "binary":
                case "varbinary":
                case "image":
                    t = typeof(System.Byte[]);
                    break;
                case "timestamp":
                    t = typeof(System.DateTime);
                    break;
                case "uniqueidentifier":
                    t = typeof(System.Guid);
                    break;

            }
            return t;
        }
    }
}
