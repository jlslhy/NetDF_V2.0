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
namespace Model.SysMgr
{
    public class UsersInfo_Model:Model.Base.ModelBase
    {
	    public UsersInfo_Model()
        {
            TableName = "UsersInfo";
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
        { get
            {
                return @"INSERT INTO [UsersInfo]
           ( [UserID],[UserPwd],[RealName],[DepartmentID],[RoleID],[CreatTime],[ModifyTime],[Creator],[Editor],[LastLoginIP],[LastLoginTime],[Enabled],[IsLocked],[Remark]) VALUES (@UserID,@UserPwd,@RealName,@DepartmentID,@RoleID,@CreatTime,@ModifyTime,@Creator,@Editor,@LastLoginIP,@LastLoginTime,@Enabled,@IsLocked,@Remark)";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [UsersInfo]
            SET [UserID]=@UserID,[UserPwd]=@UserPwd,[RealName]=@RealName,[DepartmentID]=@DepartmentID,[RoleID]=@RoleID,[CreatTime]=@CreatTime,[ModifyTime]=@ModifyTime,[Creator]=@Creator,[Editor]=@Editor,[LastLoginIP]=@LastLoginIP,[LastLoginTime]=@LastLoginTime,[Enabled]=@Enabled,[IsLocked]=@IsLocked,[Remark]=@Remark WHERE  [ID]=@ID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID",M_UserID));
            list.Add(new SqlParameter("@UserPwd",M_UserPwd));
            list.Add(new SqlParameter("@RealName",M_RealName));
            list.Add(new SqlParameter("@DepartmentID",M_DepartmentID));
            list.Add(new SqlParameter("@RoleID",M_RoleID));
            list.Add(new SqlParameter("@CreatTime",M_CreatTime));
            list.Add(new SqlParameter("@ModifyTime",M_ModifyTime));
            list.Add(new SqlParameter("@Creator",M_Creator));
            list.Add(new SqlParameter("@Editor",M_Editor));
            list.Add(new SqlParameter("@LastLoginIP",M_LastLoginIP));
            list.Add(new SqlParameter("@LastLoginTime",M_LastLoginTime));
            list.Add(new SqlParameter("@Enabled",M_Enabled));
            list.Add(new SqlParameter("@IsLocked",M_IsLocked));
            list.Add(new SqlParameter("@Remark",M_Remark));
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

 // 
 private string M_UserID;

 // 
 private string M_UserPwd;

 // 
 private string M_RealName;

 // 
 private int M_DepartmentID;

 // 
 private int M_RoleID;

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
 private bool? M_Enabled;

 // 
 private bool? M_IsLocked;

 // 备注
 private string M_Remark;

		/// <summary>
        /// (主键)
        /// </summary>
 public int ID{

            get{
                return M_ID;
                }
                 
            set{
                M_ID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string UserID{

            get{
                return M_UserID;
                }
                 
            set{
                M_UserID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string UserPwd{

            get{
                return M_UserPwd;
                }
                 
            set{
                M_UserPwd=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string RealName{

            get{
                return M_RealName;
                }
                 
            set{
                M_RealName=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int DepartmentID{

            get{
                return M_DepartmentID;
                }
                 
            set{
                M_DepartmentID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int RoleID{

            get{
                return M_RoleID;
                }
                 
            set{
                M_RoleID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public DateTime? CreatTime{

            get{
                return M_CreatTime;
                }
                 
            set{
                M_CreatTime=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public DateTime? ModifyTime{

            get{
                return M_ModifyTime;
                }
                 
            set{
                M_ModifyTime=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string Creator{

            get{
                return M_Creator;
                }
                 
            set{
                M_Creator=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string Editor{

            get{
                return M_Editor;
                }
                 
            set{
                M_Editor=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string LastLoginIP{

            get{
                return M_LastLoginIP;
                }
                 
            set{
                M_LastLoginIP=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public DateTime? LastLoginTime{

            get{
                return M_LastLoginTime;
                }
                 
            set{
                M_LastLoginTime=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public bool? Enabled{

            get{
                return M_Enabled;
                }
                 
            set{
                M_Enabled=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public bool? IsLocked{

            get{
                return M_IsLocked;
                }
                 
            set{
                M_IsLocked=value;
                }
                 
}
/// <summary>
        /// 备注
        /// </summary>
 public string Remark{

            get{
                return M_Remark;
                }
                 
            set{
                M_Remark=value;
                }
                 
}

    }
}