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
    public class Customer_Model:Model.Base.ModelBase
    {
	    public Customer_Model()
        {
            TableName = "Customer";
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
                return @"INSERT INTO [Customer]
           ( [CustomerCode],[CustomerName],[CustomerType],[CustomerOwner],[Region],[Contact],[CompanyTel],[MobilePhone],[QQ],[EMail],[DocumentaryContent],[Remarks],[WorkingField],[CustomerLevel],[Address],[CompanyWebsite],[MicroBlog],[OfficialAccounts],[RegisteredCapital],[CompanyIntroduction],[TotalStaff],[Sales],[CreateTime],[EditTime],[Creator]) VALUES (@CustomerCode,@CustomerName,@CustomerType,@CustomerOwner,@Region,@Contact,@CompanyTel,@MobilePhone,@QQ,@EMail,@DocumentaryContent,@Remarks,@WorkingField,@CustomerLevel,@Address,@CompanyWebsite,@MicroBlog,@OfficialAccounts,@RegisteredCapital,@CompanyIntroduction,@TotalStaff,@Sales,@CreateTime,@EditTime,@Creator);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [Customer]
            SET [CustomerCode]=@CustomerCode,[CustomerName]=@CustomerName,[CustomerType]=@CustomerType,[CustomerOwner]=@CustomerOwner,[Region]=@Region,[Contact]=@Contact,[CompanyTel]=@CompanyTel,[MobilePhone]=@MobilePhone,[QQ]=@QQ,[EMail]=@EMail,[DocumentaryContent]=@DocumentaryContent,[Remarks]=@Remarks,[WorkingField]=@WorkingField,[CustomerLevel]=@CustomerLevel,[Address]=@Address,[CompanyWebsite]=@CompanyWebsite,[MicroBlog]=@MicroBlog,[OfficialAccounts]=@OfficialAccounts,[RegisteredCapital]=@RegisteredCapital,[CompanyIntroduction]=@CompanyIntroduction,[TotalStaff]=@TotalStaff,[Sales]=@Sales,[CreateTime]=@CreateTime,[EditTime]=@EditTime,[Creator]=@Creator WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@CustomerCode",M_CustomerCode));
            list.Add(new SqlParameter("@CustomerName",M_CustomerName));
            list.Add(new SqlParameter("@CustomerType",M_CustomerType));
            list.Add(new SqlParameter("@CustomerOwner",M_CustomerOwner));
            list.Add(new SqlParameter("@Region",M_Region));
            list.Add(new SqlParameter("@Contact",M_Contact));
            list.Add(new SqlParameter("@CompanyTel",M_CompanyTel));
            list.Add(new SqlParameter("@MobilePhone",M_MobilePhone));
            list.Add(new SqlParameter("@QQ",M_QQ));
            list.Add(new SqlParameter("@EMail",M_EMail));
            list.Add(new SqlParameter("@DocumentaryContent",M_DocumentaryContent));
            list.Add(new SqlParameter("@Remarks",M_Remarks));
            list.Add(new SqlParameter("@WorkingField",M_WorkingField));
            list.Add(new SqlParameter("@CustomerLevel",M_CustomerLevel));
            list.Add(new SqlParameter("@Address",M_Address));
            list.Add(new SqlParameter("@CompanyWebsite",M_CompanyWebsite));
            list.Add(new SqlParameter("@MicroBlog",M_MicroBlog));
            list.Add(new SqlParameter("@OfficialAccounts",M_OfficialAccounts));
            list.Add(new SqlParameter("@RegisteredCapital",M_RegisteredCapital));
            list.Add(new SqlParameter("@CompanyIntroduction",M_CompanyIntroduction));
            list.Add(new SqlParameter("@TotalStaff",M_TotalStaff));
            list.Add(new SqlParameter("@Sales",M_Sales));
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

	    

         // (主键)
         private int M_ID;

         // 客户编码
         private int? M_CustomerCode;

         // 客户名称
         private string M_CustomerName;

         // 客户类型
         private string M_CustomerType;

         // 客户所有人
         private string M_CustomerOwner;

         // 所属区域
         private string M_Region;

         // 联系人
         private string M_Contact;

         // 公司电话
         private string M_CompanyTel;

         // 手机
         private string M_MobilePhone;

         // QQ号码
         private string M_QQ;

         // 电子邮箱
         private string M_EMail;

         // 跟单内容
         private string M_DocumentaryContent;

         // 备注
         private string M_Remarks;

         // 所属行业
         private string M_WorkingField;

         // 客户级别
         private string M_CustomerLevel;

         // 地址
         private string M_Address;

         // 公司网址
         private string M_CompanyWebsite;

         // 微博
         private string M_MicroBlog;

         // 公众号
         private string M_OfficialAccounts;

         // 注册资本
         private string M_RegisteredCapital;

         // 公司简介
         private string M_CompanyIntroduction;

         // 总人数
         private int? M_TotalStaff;

         // 销售额
         private decimal? M_Sales;

         // 创建时间
         private DateTime? M_CreateTime;

         // 编辑时间
         private DateTime? M_EditTime;

         // 创建者
         private string M_Creator;

		
         /// <summary>
         /// (主键)
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
         /// 客户名称
         /// </summary>
         public string CustomerName
         {
            get
              {
                   return M_CustomerName;
              }
            set
              {
                   M_CustomerName=value;
              }
          }

         /// <summary>
         /// 客户类型
         /// </summary>
         public string CustomerType
         {
            get
              {
                   return M_CustomerType;
              }
            set
              {
                   M_CustomerType=value;
              }
          }

         /// <summary>
         /// 客户所有人
         /// </summary>
         public string CustomerOwner
         {
            get
              {
                   return M_CustomerOwner;
              }
            set
              {
                   M_CustomerOwner=value;
              }
          }

         /// <summary>
         /// 所属区域
         /// </summary>
         public string Region
         {
            get
              {
                   return M_Region;
              }
            set
              {
                   M_Region=value;
              }
          }

         /// <summary>
         /// 联系人
         /// </summary>
         public string Contact
         {
            get
              {
                   return M_Contact;
              }
            set
              {
                   M_Contact=value;
              }
          }

         /// <summary>
         /// 公司电话
         /// </summary>
         public string CompanyTel
         {
            get
              {
                   return M_CompanyTel;
              }
            set
              {
                   M_CompanyTel=value;
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
         /// QQ号码
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
         /// 电子邮箱
         /// </summary>
         public string EMail
         {
            get
              {
                   return M_EMail;
              }
            set
              {
                   M_EMail=value;
              }
          }

         /// <summary>
         /// 跟单内容
         /// </summary>
         public string DocumentaryContent
         {
            get
              {
                   return M_DocumentaryContent;
              }
            set
              {
                   M_DocumentaryContent=value;
              }
          }

         /// <summary>
         /// 备注
         /// </summary>
         public string Remarks
         {
            get
              {
                   return M_Remarks;
              }
            set
              {
                   M_Remarks=value;
              }
          }

         /// <summary>
         /// 所属行业
         /// </summary>
         public string WorkingField
         {
            get
              {
                   return M_WorkingField;
              }
            set
              {
                   M_WorkingField=value;
              }
          }

         /// <summary>
         /// 客户级别
         /// </summary>
         public string CustomerLevel
         {
            get
              {
                   return M_CustomerLevel;
              }
            set
              {
                   M_CustomerLevel=value;
              }
          }

         /// <summary>
         /// 地址
         /// </summary>
         public string Address
         {
            get
              {
                   return M_Address;
              }
            set
              {
                   M_Address=value;
              }
          }

         /// <summary>
         /// 公司网址
         /// </summary>
         public string CompanyWebsite
         {
            get
              {
                   return M_CompanyWebsite;
              }
            set
              {
                   M_CompanyWebsite=value;
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
         /// 公众号
         /// </summary>
         public string OfficialAccounts
         {
            get
              {
                   return M_OfficialAccounts;
              }
            set
              {
                   M_OfficialAccounts=value;
              }
          }

         /// <summary>
         /// 注册资本
         /// </summary>
         public string RegisteredCapital
         {
            get
              {
                   return M_RegisteredCapital;
              }
            set
              {
                   M_RegisteredCapital=value;
              }
          }

         /// <summary>
         /// 公司简介
         /// </summary>
         public string CompanyIntroduction
         {
            get
              {
                   return M_CompanyIntroduction;
              }
            set
              {
                   M_CompanyIntroduction=value;
              }
          }

         /// <summary>
         /// 总人数
         /// </summary>
         public int? TotalStaff
         {
            get
              {
                   return M_TotalStaff;
              }
            set
              {
                   M_TotalStaff=value;
              }
          }

         /// <summary>
         /// 销售额
         /// </summary>
         public decimal? Sales
         {
            get
              {
                   return M_Sales;
              }
            set
              {
                   M_Sales=value;
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