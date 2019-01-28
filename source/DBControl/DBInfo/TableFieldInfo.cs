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
    public class TableFieldInfo
    {
        
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName;
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPK;
        /// <summary>
        /// 数据类型
        /// </summary>
        public Type DataType;
        /// <summary>
        /// 字段长度
        /// </summary>
        public int DataLength;
        /// <summary>
        /// 允许空值
        /// </summary>
        public bool IsNullAble;
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue;
        /// <summary>
        /// 字段描述
        /// </summary>
        public string FieldDesc;

        public TableFieldInfo() { }
        public TableFieldInfo(string fieldName, bool isPK, Type dataType, int dataLength, bool isNullAble, string defaultValue, string fieldDesc)
        {

            this.FieldName = fieldName;
            this.IsPK = isPK;
            this.DataType = dataType;
            this.DataLength = dataLength;
            this.IsNullAble = isNullAble;
            this.DefaultValue = defaultValue;
            this.FieldDesc = fieldDesc;

        }
    }
}
