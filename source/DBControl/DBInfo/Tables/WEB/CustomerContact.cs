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
    public class CustomerContact : TableBase
    {
        
        public string TableDesc="联系人列表";
        
        public CustomerContact() {
            TableName = "CustomerContact";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
            
            FieldInfoList.Add(new TableFieldInfo("ID",true,typeof(System.Int32),4,false,"","序号"));
            FieldInfoList.Add(new TableFieldInfo("IsMainContact",false,typeof(System.Boolean),1,true,"","是否主联系人"));
            FieldInfoList.Add(new TableFieldInfo("Name",false,typeof(System.String),100,true,"","姓名"));
            FieldInfoList.Add(new TableFieldInfo("CustomerCode",false,typeof(System.Int32),4,true,"","客户编码"));
            FieldInfoList.Add(new TableFieldInfo("Position",false,typeof(System.String),100,true,"","职务"));
            FieldInfoList.Add(new TableFieldInfo("Email",false,typeof(System.String),50,true,"","电子邮箱"));
            FieldInfoList.Add(new TableFieldInfo("MobilePhone",false,typeof(System.String),50,true,"","手机"));
            FieldInfoList.Add(new TableFieldInfo("ProjectRoles",false,typeof(System.String),100,true,"","项目角色"));
            FieldInfoList.Add(new TableFieldInfo("QQ",false,typeof(System.String),50,true,"","QQ"));
            FieldInfoList.Add(new TableFieldInfo("Remark",false,typeof(System.String),100,true,"","备注"));
            FieldInfoList.Add(new TableFieldInfo("Department",false,typeof(System.String),100,true,"","部门"));
            FieldInfoList.Add(new TableFieldInfo("MicroBlog",false,typeof(System.String),150,true,"","微博"));
            FieldInfoList.Add(new TableFieldInfo("WeChat",false,typeof(System.String),50,true,"","微信"));
            FieldInfoList.Add(new TableFieldInfo("NativePlace",false,typeof(System.String),100,true,"","籍贯"));
            FieldInfoList.Add(new TableFieldInfo("GraduateSchool",false,typeof(System.String),100,true,"","毕业学校"));
            FieldInfoList.Add(new TableFieldInfo("Sex",false,typeof(System.String),100,true,"","性别"));
            FieldInfoList.Add(new TableFieldInfo("Birthdate",false,typeof(System.DateTime),3,true,"","出生日期"));
            FieldInfoList.Add(new TableFieldInfo("LoverWorkUnit",false,typeof(System.String),300,true,"","爱人工作单位"));
            FieldInfoList.Add(new TableFieldInfo("PreviousWorkUnits",false,typeof(System.String),300,true,"","之前的工作单位"));
            FieldInfoList.Add(new TableFieldInfo("MaritalStatus",false,typeof(System.Boolean),1,true,"","婚否"));
            FieldInfoList.Add(new TableFieldInfo("HaveAnyChildren",false,typeof(System.Boolean),1,true,"","是否有小孩"));
            FieldInfoList.Add(new TableFieldInfo("HomeAddress",false,typeof(System.String),300,true,"","家庭地址"));
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
            /// 序号
            /// </summary>
             ID,
            /// <summary>
            /// 是否主联系人
            /// </summary>
             IsMainContact,
            /// <summary>
            /// 姓名
            /// </summary>
             Name,
            /// <summary>
            /// 客户编码
            /// </summary>
             CustomerCode,
            /// <summary>
            /// 职务
            /// </summary>
             Position,
            /// <summary>
            /// 电子邮箱
            /// </summary>
             Email,
            /// <summary>
            /// 手机
            /// </summary>
             MobilePhone,
            /// <summary>
            /// 项目角色
            /// </summary>
             ProjectRoles,
            /// <summary>
            /// QQ
            /// </summary>
             QQ,
            /// <summary>
            /// 备注
            /// </summary>
             Remark,
            /// <summary>
            /// 部门
            /// </summary>
             Department,
            /// <summary>
            /// 微博
            /// </summary>
             MicroBlog,
            /// <summary>
            /// 微信
            /// </summary>
             WeChat,
            /// <summary>
            /// 籍贯
            /// </summary>
             NativePlace,
            /// <summary>
            /// 毕业学校
            /// </summary>
             GraduateSchool,
            /// <summary>
            /// 性别
            /// </summary>
             Sex,
            /// <summary>
            /// 出生日期
            /// </summary>
             Birthdate,
            /// <summary>
            /// 爱人工作单位
            /// </summary>
             LoverWorkUnit,
            /// <summary>
            /// 之前的工作单位
            /// </summary>
             PreviousWorkUnits,
            /// <summary>
            /// 婚否
            /// </summary>
             MaritalStatus,
            /// <summary>
            /// 是否有小孩
            /// </summary>
             HaveAnyChildren,
            /// <summary>
            /// 家庭地址
            /// </summary>
             HomeAddress,
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
