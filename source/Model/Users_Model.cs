/*
 * 框架版本：NetDF2.0  
 * 架构设计开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Model
{
    public class Users_Model:Model.Base.ModelBase
    {
	    public Users_Model()
        {
            TableName = "Users";
            PKey = "UserID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_UserID;
            }
            set
            {
                M_UserID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { 
            get
            {
                return @"INSERT INTO [Users]
           ( [LoginID],[UserPwd],[RealName],[DepartmentID],[Mobile],[Email],[QQ],[CreatTime],[ModifyTime],[Creator],[Editor],[LastLoginIP],[LastLoginTime],[IsEnabled],[IsLocked],[Remark],[ordernum]) VALUES (@LoginID,@UserPwd,@RealName,@DepartmentID,@Mobile,@Email,@QQ,@CreatTime,@ModifyTime,@Creator,@Editor,@LastLoginIP,@LastLoginTime,@IsEnabled,@IsLocked,@Remark,@ordernum);select @@identity ";
            }
        }

        public override string UpdateSQL
        { 
            get
            {
                return @"UPDATE [Users]
            SET [LoginID]=@LoginID,[UserPwd]=@UserPwd,[RealName]=@RealName,[DepartmentID]=@DepartmentID,[Mobile]=@Mobile,[Email]=@Email,[QQ]=@QQ,[CreatTime]=@CreatTime,[ModifyTime]=@ModifyTime,[Creator]=@Creator,[Editor]=@Editor,[LastLoginIP]=@LastLoginIP,[LastLoginTime]=@LastLoginTime,[IsEnabled]=@IsEnabled,[IsLocked]=@IsLocked,[Remark]=@Remark,[ordernum]=@ordernum WHERE  [UserID]=@UserID";
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
                list.Add(new SqlParameter("@UserID", M_UserID));
                return list.ToArray();
            }
        }

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@LoginID",M_LoginID));
            list.Add(new SqlParameter("@UserPwd",M_UserPwd));
            list.Add(new SqlParameter("@RealName",M_RealName));
            list.Add(new SqlParameter("@DepartmentID",M_DepartmentID));
            list.Add(new SqlParameter("@Mobile",M_Mobile));
            list.Add(new SqlParameter("@Email",M_Email));
            list.Add(new SqlParameter("@QQ",M_QQ));
            list.Add(new SqlParameter("@CreatTime",M_CreatTime));
            list.Add(new SqlParameter("@ModifyTime",M_ModifyTime));
            list.Add(new SqlParameter("@Creator",M_Creator));
            list.Add(new SqlParameter("@Editor",M_Editor));
            list.Add(new SqlParameter("@LastLoginIP",M_LastLoginIP));
            list.Add(new SqlParameter("@LastLoginTime",M_LastLoginTime));
            list.Add(new SqlParameter("@IsEnabled",M_IsEnabled));
            list.Add(new SqlParameter("@IsLocked",M_IsLocked));
            list.Add(new SqlParameter("@Remark",M_Remark));
            list.Add(new SqlParameter("@ordernum",M_ordernum));
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
         private int M_UserID;

         // 
         private string M_LoginID;

         // 
         private string M_UserPwd;

         // 
         private string M_RealName;

         // 
         private int? M_DepartmentID;

         // 
         private string M_Mobile;

         // 
         private string M_Email;

         // 
         private string M_QQ;

         // 
         private DateTime? M_CreatTime;

         // 
         private DateTime? M_ModifyTime;

         // 
         private string M_Creator;

         // 
         private string M_Editor;

         // 
         private string M_LastLoginIP;

         // 
         private DateTime? M_LastLoginTime;

         // 
         private bool? M_IsEnabled;

         // 
         private bool? M_IsLocked;

         // 备注
         private string M_Remark;

         // 
         private Single? M_ordernum;

		
         /// <summary>
         /// (主键)
         /// </summary>
         public int UserID
         {
            get
              {
                   return M_UserID;
              }
            set
              {
                   M_UserID=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string LoginID
         {
            get
              {
                   return M_LoginID;
              }
            set
              {
                   M_LoginID=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string UserPwd
         {
            get
              {
                   return M_UserPwd;
              }
            set
              {
                   M_UserPwd=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string RealName
         {
            get
              {
                   return M_RealName;
              }
            set
              {
                   M_RealName=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public int? DepartmentID
         {
            get
              {
                   return M_DepartmentID;
              }
            set
              {
                   M_DepartmentID=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string Mobile
         {
            get
              {
                   return M_Mobile;
              }
            set
              {
                   M_Mobile=value;
              }
          }

         /// <summary>
         /// 
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
         /// 
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
         /// 
         /// </summary>
         public DateTime? CreatTime
         {
            get
              {
                   return M_CreatTime;
              }
            set
              {
                   M_CreatTime=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public DateTime? ModifyTime
         {
            get
              {
                   return M_ModifyTime;
              }
            set
              {
                   M_ModifyTime=value;
              }
          }

         /// <summary>
         /// 
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

         /// <summary>
         /// 
         /// </summary>
         public string Editor
         {
            get
              {
                   return M_Editor;
              }
            set
              {
                   M_Editor=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public string LastLoginIP
         {
            get
              {
                   return M_LastLoginIP;
              }
            set
              {
                   M_LastLoginIP=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public DateTime? LastLoginTime
         {
            get
              {
                   return M_LastLoginTime;
              }
            set
              {
                   M_LastLoginTime=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public bool? IsEnabled
         {
            get
              {
                   return M_IsEnabled;
              }
            set
              {
                   M_IsEnabled=value;
              }
          }

         /// <summary>
         /// 
         /// </summary>
         public bool? IsLocked
         {
            get
              {
                   return M_IsLocked;
              }
            set
              {
                   M_IsLocked=value;
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
         /// 
         /// </summary>
         public Single? ordernum
         {
            get
              {
                   return M_ordernum;
              }
            set
              {
                   M_ordernum=value;
              }
          }

    }
}