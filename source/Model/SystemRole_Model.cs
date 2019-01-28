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
namespace Model
{
    public class SystemRole_Model : Model.Base.ModelBase
    {
        public SystemRole_Model()
        {
            TableName = "SystemRole";
            PKey = "SystemRoleID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_SystemRoleID;
            }
            set
            {
                M_SystemRoleID = (System.Int32)value;
            }
        }

        public override string AddSQL
        {
            get
            {
                return @"INSERT INTO [SystemRole]
           ( [SystemRoleName],[RoleDesc],[IsSystem]) VALUES (@SystemRoleName,@RoleDesc,@IsSystem);select @@identity ";
            }
        }

        public override string UpdateSQL
        {
            get
            {
                return @"UPDATE [SystemRole]
            SET [SystemRoleName]=@SystemRoleName,[RoleDesc]=@RoleDesc,[IsSystem]=@IsSystem WHERE  [SystemRoleID]=@SystemRoleID";
            }
        }

        public override SqlParameter[] ParamsForAdd
        {
            get
            {
                List<SqlParameter> list = GetNotKeyParams(); return list.ToArray();
            }
        }

        public override SqlParameter[] ParamsForUpdate
        {
            get
            {
                List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@SystemRoleID", M_SystemRoleID));
                return list.ToArray();
            }
        }

        public List<SqlParameter> GetNotKeyParams()
        {

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@SystemRoleName", M_SystemRoleName));
            list.Add(new SqlParameter("@RoleDesc", M_RoleDesc));
            list.Add(new SqlParameter("@IsSystem", M_IsSystem));
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
        private int M_SystemRoleID;

        // 角色名称
        private string M_SystemRoleName;

        // 
        private string M_RoleDesc;

        // 是否系统角色
        private bool? M_IsSystem;

        /// <summary>
        /// (主键)
        /// </summary>
        public int SystemRoleID
        {

            get
            {
                return M_SystemRoleID;
            }

            set
            {
                M_SystemRoleID = value;
            }

        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string SystemRoleName
        {

            get
            {
                return M_SystemRoleName;
            }

            set
            {
                M_SystemRoleName = value;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public string RoleDesc
        {

            get
            {
                return M_RoleDesc;
            }

            set
            {
                M_RoleDesc = value;
            }

        }
        /// <summary>
        /// 是否系统角色
        /// </summary>
        public bool? IsSystem
        {

            get
            {
                return M_IsSystem;
            }

            set
            {
                M_IsSystem = value;
            }

        }

    }
}