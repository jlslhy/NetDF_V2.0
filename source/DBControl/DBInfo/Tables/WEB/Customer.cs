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
    public class Customer : TableBase
    {
        
        public string TableDesc="客户表";
        
        public Customer() {
            TableName = "Customer";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"",""));
            FieldInfoList.Add(new TableFieldInfo("CustomerCode",false,typeof(System.Int32),4,true,"","客户编码"));
            FieldInfoList.Add(new TableFieldInfo("CustomerName",false,typeof(System.String),200,true,"","客户名称"));
            FieldInfoList.Add(new TableFieldInfo("CustomerType",false,typeof(System.String),100,true,"","客户类型"));
            FieldInfoList.Add(new TableFieldInfo("CustomerOwner",false,typeof(System.String),50,true,"","客户所有人"));
            FieldInfoList.Add(new TableFieldInfo("Region",false,typeof(System.String),100,true,"","所属区域"));
            FieldInfoList.Add(new TableFieldInfo("Contact",false,typeof(System.String),100,true,"","联系人"));
            FieldInfoList.Add(new TableFieldInfo("CompanyTel",false,typeof(System.String),50,true,"","公司电话"));
            FieldInfoList.Add(new TableFieldInfo("MobilePhone",false,typeof(System.String),50,true,"","手机"));
            FieldInfoList.Add(new TableFieldInfo("QQ",false,typeof(System.String),50,true,"","QQ号码"));
            FieldInfoList.Add(new TableFieldInfo("EMail",false,typeof(System.String),50,true,"","电子邮箱"));
            FieldInfoList.Add(new TableFieldInfo("DocumentaryContent",false,typeof(System.String),16,true,"","跟单内容"));
            FieldInfoList.Add(new TableFieldInfo("Remarks",false,typeof(System.String),16,true,"","备注"));
            FieldInfoList.Add(new TableFieldInfo("WorkingField",false,typeof(System.String),100,true,"","所属行业"));
            FieldInfoList.Add(new TableFieldInfo("CustomerLevel",false,typeof(System.String),50,true,"","客户级别"));
            FieldInfoList.Add(new TableFieldInfo("Address",false,typeof(System.String),200,true,"","地址"));
            FieldInfoList.Add(new TableFieldInfo("CompanyWebsite",false,typeof(System.String),150,true,"","公司网址"));
            FieldInfoList.Add(new TableFieldInfo("MicroBlog",false,typeof(System.String),250,true,"","微博"));
            FieldInfoList.Add(new TableFieldInfo("OfficialAccounts",false,typeof(System.String),50,true,"","公众号"));
            FieldInfoList.Add(new TableFieldInfo("RegisteredCapital",false,typeof(System.String),100,true,"","注册资本"));
            FieldInfoList.Add(new TableFieldInfo("CompanyIntroduction",false,typeof(System.String),16,true,"","公司简介"));
            FieldInfoList.Add(new TableFieldInfo("TotalStaff",false,typeof(System.Int32),4,true,"","总人数"));
            FieldInfoList.Add(new TableFieldInfo("Sales",false,typeof(System.Decimal),8,true,"","销售额"));
            FieldInfoList.Add(new TableFieldInfo("CreateTime",false,typeof(System.DateTime),8,true,"","创建时间"));
            FieldInfoList.Add(new TableFieldInfo("EditTime",false,typeof(System.DateTime),8,true,"","编辑时间"));
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
            /// 
            /// </summary>
             ID,
            /// <summary>
            /// 客户编码
            /// </summary>
             CustomerCode,
            /// <summary>
            /// 客户名称
            /// </summary>
             CustomerName,
            /// <summary>
            /// 客户类型
            /// </summary>
             CustomerType,
            /// <summary>
            /// 客户所有人
            /// </summary>
             CustomerOwner,
            /// <summary>
            /// 所属区域
            /// </summary>
             Region,
            /// <summary>
            /// 联系人
            /// </summary>
             Contact,
            /// <summary>
            /// 公司电话
            /// </summary>
             CompanyTel,
            /// <summary>
            /// 手机
            /// </summary>
             MobilePhone,
            /// <summary>
            /// QQ号码
            /// </summary>
             QQ,
            /// <summary>
            /// 电子邮箱
            /// </summary>
             EMail,
            /// <summary>
            /// 跟单内容
            /// </summary>
             DocumentaryContent,
            /// <summary>
            /// 备注
            /// </summary>
             Remarks,
            /// <summary>
            /// 所属行业
            /// </summary>
             WorkingField,
            /// <summary>
            /// 客户级别
            /// </summary>
             CustomerLevel,
            /// <summary>
            /// 地址
            /// </summary>
             Address,
            /// <summary>
            /// 公司网址
            /// </summary>
             CompanyWebsite,
            /// <summary>
            /// 微博
            /// </summary>
             MicroBlog,
            /// <summary>
            /// 公众号
            /// </summary>
             OfficialAccounts,
            /// <summary>
            /// 注册资本
            /// </summary>
             RegisteredCapital,
            /// <summary>
            /// 公司简介
            /// </summary>
             CompanyIntroduction,
            /// <summary>
            /// 总人数
            /// </summary>
             TotalStaff,
            /// <summary>
            /// 销售额
            /// </summary>
             Sales,
            /// <summary>
            /// 创建时间
            /// </summary>
             CreateTime,
            /// <summary>
            /// 编辑时间
            /// </summary>
             EditTime,
            /// <summary>
            /// 创建者
            /// </summary>
             Creator
        }
    }
}
