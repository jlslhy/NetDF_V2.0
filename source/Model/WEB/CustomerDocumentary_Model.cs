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
    public class CustomerDocumentary_Model:Model.Base.ModelBase
    {
	    public CustomerDocumentary_Model()
        {
            TableName = "CustomerDocumentary";
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
                return @"INSERT INTO [CustomerDocumentary]
           ( [CustomerCode],[DocumentaryPeople],[CustomerLevel],[SalesStage],[DocumentaryContent],[NextDocumentaryDate],[ReminderNote],[Attachment],[CreateTime],[EditTime],[Creator]) VALUES (@CustomerCode,@DocumentaryPeople,@CustomerLevel,@SalesStage,@DocumentaryContent,@NextDocumentaryDate,@ReminderNote,@Attachment,@CreateTime,@EditTime,@Creator);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [CustomerDocumentary]
            SET [CustomerCode]=@CustomerCode,[DocumentaryPeople]=@DocumentaryPeople,[CustomerLevel]=@CustomerLevel,[SalesStage]=@SalesStage,[DocumentaryContent]=@DocumentaryContent,[NextDocumentaryDate]=@NextDocumentaryDate,[ReminderNote]=@ReminderNote,[Attachment]=@Attachment,[CreateTime]=@CreateTime,[EditTime]=@EditTime,[Creator]=@Creator WHERE  [ID]=@ID";
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
            list.Add(new SqlParameter("@DocumentaryPeople",M_DocumentaryPeople));
            list.Add(new SqlParameter("@CustomerLevel",M_CustomerLevel));
            list.Add(new SqlParameter("@SalesStage",M_SalesStage));
            list.Add(new SqlParameter("@DocumentaryContent",M_DocumentaryContent));
            list.Add(new SqlParameter("@NextDocumentaryDate",M_NextDocumentaryDate));
            list.Add(new SqlParameter("@ReminderNote",M_ReminderNote));
            list.Add(new SqlParameter("@Attachment",M_Attachment));
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

         // 跟单人
         private string M_DocumentaryPeople;

         // 客户级别
         private string M_CustomerLevel;

         // 销售阶段
         private string M_SalesStage;

         // 跟单内容
         private string M_DocumentaryContent;

         // 下次跟单日期
         private DateTime? M_NextDocumentaryDate;

         // 提醒备注
         private string M_ReminderNote;

         // 附件
         private string M_Attachment;

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
         /// 跟单人
         /// </summary>
         public string DocumentaryPeople
         {
            get
              {
                   return M_DocumentaryPeople;
              }
            set
              {
                   M_DocumentaryPeople=value;
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
         /// 销售阶段
         /// </summary>
         public string SalesStage
         {
            get
              {
                   return M_SalesStage;
              }
            set
              {
                   M_SalesStage=value;
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
         /// 下次跟单日期
         /// </summary>
         public DateTime? NextDocumentaryDate
         {
            get
              {
                   return M_NextDocumentaryDate;
              }
            set
              {
                   M_NextDocumentaryDate=value;
              }
          }

         /// <summary>
         /// 提醒备注
         /// </summary>
         public string ReminderNote
         {
            get
              {
                   return M_ReminderNote;
              }
            set
              {
                   M_ReminderNote=value;
              }
          }

         /// <summary>
         /// 附件
         /// </summary>
         public string Attachment
         {
            get
              {
                   return M_Attachment;
              }
            set
              {
                   M_Attachment=value;
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