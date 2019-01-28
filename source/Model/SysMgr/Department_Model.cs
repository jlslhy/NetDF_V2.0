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
    public class Department_Model:Model.Base.ModelBase
    {
	    public Department_Model()
        {
            TableName = "Department";
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
                return @"INSERT INTO [Department]
           ( [PID],[DeptName],[DeptFullName],[DeptDesc],[Enabled],[CreateTime],[ModifyTime]) VALUES (@PID,@DeptName,@DeptFullName,@DeptDesc,@Enabled,@CreateTime,@ModifyTime)";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [Department]
            SET [PID]=@PID,[DeptName]=@DeptName,[DeptFullName]=@DeptFullName,[DeptDesc]=@DeptDesc,[Enabled]=@Enabled,[CreateTime]=@CreateTime,[ModifyTime]=@ModifyTime WHERE  [ID]=@ID";}}

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
            list.Add(new SqlParameter("@PID",M_PID));
            list.Add(new SqlParameter("@DeptName",M_DeptName));
            list.Add(new SqlParameter("@DeptFullName",M_DeptFullName));
            list.Add(new SqlParameter("@DeptDesc",M_DeptDesc));
            list.Add(new SqlParameter("@Enabled",M_Enabled));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
            list.Add(new SqlParameter("@ModifyTime",M_ModifyTime));
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
 private int? M_PID;

 // 
 private string M_DeptName;

 // 全称
 private string M_DeptFullName;

 // 
 private string M_DeptDesc;

 // 
 private bool? M_Enabled;

 // 创建时间
 private DateTime? M_CreateTime;

 // 修改时间
 private DateTime? M_ModifyTime;

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
 public int? PID{

            get{
                return M_PID;
                }
                 
            set{
                M_PID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string DeptName{

            get{
                return M_DeptName;
                }
                 
            set{
                M_DeptName=value;
                }
                 
}
/// <summary>
        /// 全称
        /// </summary>
 public string DeptFullName{

            get{
                return M_DeptFullName;
                }
                 
            set{
                M_DeptFullName=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string DeptDesc{

            get{
                return M_DeptDesc;
                }
                 
            set{
                M_DeptDesc=value;
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
        /// 创建时间
        /// </summary>
 public DateTime? CreateTime{

            get{
                return M_CreateTime;
                }
                 
            set{
                M_CreateTime=value;
                }
                 
}
/// <summary>
        /// 修改时间
        /// </summary>
 public DateTime? ModifyTime{

            get{
                return M_ModifyTime;
                }
                 
            set{
                M_ModifyTime=value;
                }
                 
}

    }
}