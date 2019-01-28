/*
 * 框架版本：NetDF2.0  
 * 架构设计开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBControl.DBInfo
{
    public class TableBase
    {
        /// <summary>
        /// 表名字
        /// </summary>
        public string TableName = string.Empty;
        /// <summary>
        /// 主键
        /// </summary>
        public string PKey = string.Empty;
        /// <summary>
        /// 主键类型
        /// </summary>
        public Type PKeyDataType = typeof(object);

        public IList<TableFieldInfo> FieldInfoList = new List<TableFieldInfo>();
        public TableFieldInfo GetTabelFieldInfo(string Fieldname)
        {
            TableFieldInfo tabelFieldInfo = null;
            foreach (TableFieldInfo temp in FieldInfoList)
            {
                if (temp.FieldName.Equals(Fieldname))
                {
                    tabelFieldInfo = temp;
                    break;
                }
            }

            return tabelFieldInfo;
        }

         

    }
}
