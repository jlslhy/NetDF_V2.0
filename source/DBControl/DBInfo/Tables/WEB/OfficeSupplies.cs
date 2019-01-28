/*
 * 框架版本：NetDF2.0  
 * 架构设计与开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBControl.DBInfo.Tables.WEB
{
    public class OfficeSupplies : TableBase
    {
        
        public string TableDesc="办公用品";
        
        public OfficeSupplies() {
            TableName = "OfficeSupplies";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"","序号"));
            FieldInfoList.Add(new TableFieldInfo("Code",false,typeof(System.String),50,true,"","物品编号"));
            FieldInfoList.Add(new TableFieldInfo("GoodsName",false,typeof(System.String),100,true,"","物品名称"));
            FieldInfoList.Add(new TableFieldInfo("GoodsCateogory",false,typeof(System.String),100,true,"","物品类别"));
            FieldInfoList.Add(new TableFieldInfo("Specification",false,typeof(System.String),100,true,"","规格"));
            FieldInfoList.Add(new TableFieldInfo("Unit",false,typeof(System.String),100,true,"","单位"));
            FieldInfoList.Add(new TableFieldInfo("IndicativePrice",false,typeof(System.Decimal),8,true,"","参考价格"));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"","创建时间"));
            FieldInfoList.Add(new TableFieldInfo("EditTime",false,typeof(System.DateTime),8,true,"","修改时间"));
            FieldInfoList.Add(new TableFieldInfo("Creator",false,typeof(System.String),50,true,"","创建者"));
        }

        public TableFieldInfo GetTableFieldInfo(string fieldName)
        {
            
            TableFieldInfo tInfo = null;
            foreach (TableFieldInfo t in FieldInfoList)
            {
                if (t.FieldName.Equals(fieldName.Trim()))
                {
                    tInfo = t;
                    break;
                }
            }
            return tInfo;
        }

        public Type GetFieldType(string fieldName)
        {
            TableFieldInfo tInfo = GetTableFieldInfo(fieldName);
            if (null == tInfo)
            {
                throw new Exception(string.Format("表{0}中没有字段：{1}",TableName,fieldName));
            }
            
            return   tInfo.DataType ;

        }
        
        public enum Field { 
         
            /// <summary>
            /// 序号
            /// </summary>
             ID,
            /// <summary>
            /// 物品编号
            /// </summary>
             Code,
            /// <summary>
            /// 物品名称
            /// </summary>
             GoodsName,
            /// <summary>
            /// 物品类别
            /// </summary>
             GoodsCateogory,
            /// <summary>
            /// 规格
            /// </summary>
             Specification,
            /// <summary>
            /// 单位
            /// </summary>
             Unit,
            /// <summary>
            /// 参考价格
            /// </summary>
             IndicativePrice,
            /// <summary>
            /// 创建时间
            /// </summary>
             CreateTime,
            /// <summary>
            /// 修改时间
            /// </summary>
             EditTime,
            /// <summary>
            /// 创建者
            /// </summary>
             Creator
        }
    }
}
