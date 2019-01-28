/*
 * 框架版本：NetDF2.0  
 * 架构设计与开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Model.WEB
{
    public class CustomerContact_Model:Model.Base.ModelBase
    {
	    public CustomerContact_Model()
        {
            TableName = "CustomerContact";
            PKey = "ID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_ID;
            }
            set
            {
                M_ID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { 
            get
            {
                return @"INSERT INTO [CustomerContact]
           ( [IsMainContact],[Name],[CustomerCode],[Position],[Email],[MobilePhone],[ProjectRoles],[QQ],[Remark],[Department],[MicroBlog],[WeChat],[NativePlace],[GraduateSchool],[Sex],[Birthdate],[LoverWorkUnit],[PreviousWorkUnits],[MaritalStatus],[HaveAnyChildren],[HomeAddress],[CreateTime],[EditTime],[Creator]) VALUES (@IsMainContact,@Name,@CustomerCode,@Position,@Email,@MobilePhone,@ProjectRoles,@QQ,@Remark,@Department,@MicroBlog,@WeChat,@NativePlace,@GraduateSchool,@Sex,@Birthdate,@LoverWorkUnit,@PreviousWorkUnits,@MaritalStatus,@HaveAnyChildren,@HomeAddress,@CreateTime,@EditTime,@Creator);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [CustomerContact]
            SET [IsMainContact]=@IsMainContact,[Name]=@Name,[CustomerCode]=@CustomerCode,[Position]=@Position,[Email]=@Email,[MobilePhone]=@MobilePhone,[ProjectRoles]=@ProjectRoles,[QQ]=@QQ,[Remark]=@Remark,[Department]=@Department,[MicroBlog]=@MicroBlog,[WeChat]=@WeChat,[NativePlace]=@NativePlace,[GraduateSchool]=@GraduateSchool,[Sex]=@Sex,[Birthdate]=@Birthdate,[LoverWorkUnit]=@LoverWorkUnit,[PreviousWorkUnits]=@PreviousWorkUnits,[MaritalStatus]=@MaritalStatus,[HaveAnyChildren]=@HaveAnyChildren,[HomeAddress]=@HomeAddress,[CreateTime]=@CreateTime,[EditTime]=@EditTime,[Creator]=@Creator WHERE  [ID]=@ID";
            }
        }

        public override SqlParameter[] ParamsForAdd
        { 
            get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                 return list.ToArray();
            }
        }

        public override SqlParameter[] ParamsForUpdate
        { 
            get
            {
                List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@ID", M_ID));
                return list.ToArray();
            }
        }

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@IsMainContact",M_IsMainContact));
            list.Add(new SqlParameter("@Name",M_Name));
            list.Add(new SqlParameter("@CustomerCode",M_CustomerCode));
            list.Add(new SqlParameter("@Position",M_Position));
            list.Add(new SqlParameter("@Email",M_Email));
            list.Add(new SqlParameter("@MobilePhone",M_MobilePhone));
            list.Add(new SqlParameter("@ProjectRoles",M_ProjectRoles));
            list.Add(new SqlParameter("@QQ",M_QQ));
            list.Add(new SqlParameter("@Remark",M_Remark));
            list.Add(new SqlParameter("@Department",M_Department));
            list.Add(new SqlParameter("@MicroBlog",M_MicroBlog));
            list.Add(new SqlParameter("@WeChat",M_WeChat));
            list.Add(new SqlParameter("@NativePlace",M_NativePlace));
            list.Add(new SqlParameter("@GraduateSchool",M_GraduateSchool));
            list.Add(new SqlParameter("@Sex",M_Sex));
            list.Add(new SqlParameter("@Birthdate",M_Birthdate));
            list.Add(new SqlParameter("@LoverWorkUnit",M_LoverWorkUnit));
            list.Add(new SqlParameter("@PreviousWorkUnits",M_PreviousWorkUnits));
            list.Add(new SqlParameter("@MaritalStatus",M_MaritalStatus));
            list.Add(new SqlParameter("@HaveAnyChildren",M_HaveAnyChildren));
            list.Add(new SqlParameter("@HomeAddress",M_HomeAddress));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
            list.Add(new SqlParameter("@EditTime",M_EditTime));
            list.Add(new SqlParameter("@Creator",M_Creator));
            foreach (SqlParameter par in list)
            {
                if (null == par.Value)
                {
                    par.Value = DBNull.Value;
                }
            }
            return list;
        }

	    

         // 序号(主键)
         private int M_ID;

         // 是否主联系人
         private bool? M_IsMainContact;

         // 姓名
         private string M_Name;

         // 客户编码
         private int? M_CustomerCode;

         // 职务
         private string M_Position;

         // 电子邮箱
         private string M_Email;

         // 手机
         private string M_MobilePhone;

         // 项目角色
         private string M_ProjectRoles;

         // QQ
         private string M_QQ;

         // 备注
         private string M_Remark;

         // 部门
         private string M_Department;

         // 微博
         private string M_MicroBlog;

         // 微信
         private string M_WeChat;

         // 籍贯
         private string M_NativePlace;

         // 毕业学校
         private string M_GraduateSchool;

         // 性别
         private string M_Sex;

         // 出生日期
         private DateTime? M_Birthdate;

         // 爱人工作单位
         private string M_LoverWorkUnit;

         // 之前的工作单位
         private string M_PreviousWorkUnits;

         // 婚否
         private bool? M_MaritalStatus;

         // 是否有小孩
         private bool? M_HaveAnyChildren;

         // 家庭地址
         private string M_HomeAddress;

         // 创建时间
         private DateTime? M_CreateTime;

         // 编辑时间
         private DateTime? M_EditTime;

         // 创建者
         private string M_Creator;

		
         /// <summary>
         /// 序号(主键)
         /// </summary>
         public int ID
         {
            get
              {
                   return M_ID;
              }
            set
              {
                   M_ID=value;
              }
          }

         /// <summary>
         /// 是否主联系人
         /// </summary>
         public bool? IsMainContact
         {
            get
              {
                   return M_IsMainContact;
              }
            set
              {
                   M_IsMainContact=value;
              }
          }

         /// <summary>
         /// 姓名
         /// </summary>
         public string Name
         {
            get
              {
                   return M_Name;
              }
            set
              {
                   M_Name=value;
              }
          }

         /// <summary>
         /// 客户编码
         /// </summary>
         public int? CustomerCode
         {
            get
              {
                   return M_CustomerCode;
              }
            set
              {
                   M_CustomerCode=value;
              }
          }

         /// <summary>
         /// 职务
         /// </summary>
         public string Position
         {
            get
              {
                   return M_Position;
              }
            set
              {
                   M_Position=value;
              }
          }

         /// <summary>
         /// 电子邮箱
         /// </summary>
         public string Email
         {
            get
              {
                   return M_Email;
              }
            set
              {
                   M_Email=value;
              }
          }

         /// <summary>
         /// 手机
         /// </summary>
         public string MobilePhone
         {
            get
              {
                   return M_MobilePhone;
              }
            set
              {
                   M_MobilePhone=value;
              }
          }

         /// <summary>
         /// 项目角色
         /// </summary>
         public string ProjectRoles
         {
            get
              {
                   return M_ProjectRoles;
              }
            set
              {
                   M_ProjectRoles=value;
              }
          }

         /// <summary>
         /// QQ
         /// </summary>
         public string QQ
         {
            get
              {
                   return M_QQ;
              }
            set
              {
                   M_QQ=value;
              }
          }

         /// <summary>
         /// 备注
         /// </summary>
         public string Remark
         {
            get
              {
                   return M_Remark;
              }
            set
              {
                   M_Remark=value;
              }
          }

         /// <summary>
         /// 部门
         /// </summary>
         public string Department
         {
            get
              {
                   return M_Department;
              }
            set
              {
                   M_Department=value;
              }
          }

         /// <summary>
         /// 微博
         /// </summary>
         public string MicroBlog
         {
            get
              {
                   return M_MicroBlog;
              }
            set
              {
                   M_MicroBlog=value;
              }
          }

         /// <summary>
         /// 微信
         /// </summary>
         public string WeChat
         {
            get
              {
                   return M_WeChat;
              }
            set
              {
                   M_WeChat=value;
              }
          }

         /// <summary>
         /// 籍贯
         /// </summary>
         public string NativePlace
         {
            get
              {
                   return M_NativePlace;
              }
            set
              {
                   M_NativePlace=value;
              }
          }

         /// <summary>
         /// 毕业学校
         /// </summary>
         public string GraduateSchool
         {
            get
              {
                   return M_GraduateSchool;
              }
            set
              {
                   M_GraduateSchool=value;
              }
          }

         /// <summary>
         /// 性别
         /// </summary>
         public string Sex
         {
            get
              {
                   return M_Sex;
              }
            set
              {
                   M_Sex=value;
              }
          }

         /// <summary>
         /// 出生日期
         /// </summary>
         public DateTime? Birthdate
         {
            get
              {
                   return M_Birthdate;
              }
            set
              {
                   M_Birthdate=value;
              }
          }

         /// <summary>
         /// 爱人工作单位
         /// </summary>
         public string LoverWorkUnit
         {
            get
              {
                   return M_LoverWorkUnit;
              }
            set
              {
                   M_LoverWorkUnit=value;
              }
          }

         /// <summary>
         /// 之前的工作单位
         /// </summary>
         public string PreviousWorkUnits
         {
            get
              {
                   return M_PreviousWorkUnits;
              }
            set
              {
                   M_PreviousWorkUnits=value;
              }
          }

         /// <summary>
         /// 婚否
         /// </summary>
         public bool? MaritalStatus
         {
            get
              {
                   return M_MaritalStatus;
              }
            set
              {
                   M_MaritalStatus=value;
              }
          }

         /// <summary>
         /// 是否有小孩
         /// </summary>
         public bool? HaveAnyChildren
         {
            get
              {
                   return M_HaveAnyChildren;
              }
            set
              {
                   M_HaveAnyChildren=value;
              }
          }

         /// <summary>
         /// 家庭地址
         /// </summary>
         public string HomeAddress
         {
            get
              {
                   return M_HomeAddress;
              }
            set
              {
                   M_HomeAddress=value;
              }
          }

         /// <summary>
         /// 创建时间
         /// </summary>
         public DateTime? CreateTime
         {
            get
              {
                   return M_CreateTime;
              }
            set
              {
                   M_CreateTime=value;
              }
          }

         /// <summary>
         /// 编辑时间
         /// </summary>
         public DateTime? EditTime
         {
            get
              {
                   return M_EditTime;
              }
            set
              {
                   M_EditTime=value;
              }
          }

         /// <summary>
         /// 创建者
         /// </summary>
         public string Creator
         {
            get
              {
                   return M_Creator;
              }
            set
              {
                   M_Creator=value;
              }
          }

    }
}