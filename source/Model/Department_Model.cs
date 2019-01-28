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
    public class Department_Model:Model.Base.ModelBase
    {
	    public Department_Model()
        {
            TableName = "Department";
            PKey = "DepartmentID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_DepartmentID;
            }
            set
            {
                M_DepartmentID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [Department]
           ( [DeptName],[DeptFullID],[DeptFullName],[PDepartmentID],[DeptLevel],[DeptDesc],[IsEnabled],[CreateTime],[ModifyTime],[ordernum]) VALUES (@DeptName,@DeptFullID,@DeptFullName,@PDepartmentID,@DeptLevel,@DeptDesc,@IsEnabled,@CreateTime,@ModifyTime,@ordernum);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [Department]
            SET [DeptName]=@DeptName,[DeptFullID]=@DeptFullID,[DeptFullName]=@DeptFullName,[PDepartmentID]=@PDepartmentID,[DeptLevel]=@DeptLevel,[DeptDesc]=@DeptDesc,[IsEnabled]=@IsEnabled,[CreateTime]=@CreateTime,[ModifyTime]=@ModifyTime,[ordernum]=@ordernum WHERE  [DepartmentID]=@DepartmentID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@DepartmentID", M_DepartmentID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@DeptName",M_DeptName));
            list.Add(new SqlParameter("@DeptFullID",M_DeptFullID));
            list.Add(new SqlParameter("@DeptFullName",M_DeptFullName));
            list.Add(new SqlParameter("@PDepartmentID",M_PDepartmentID));
            list.Add(new SqlParameter("@DeptLevel",M_DeptLevel));
            list.Add(new SqlParameter("@DeptDesc",M_DeptDesc));
            list.Add(new SqlParameter("@IsEnabled",M_IsEnabled));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
            list.Add(new SqlParameter("@ModifyTime",M_ModifyTime));
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
 private int M_DepartmentID;

 // 
 private string M_DeptName;

 // 
 private string M_DeptFullID;

 // 全称
 private string M_DeptFullName;

 // 
 private int? M_PDepartmentID;

 // 部门层级
 private int? M_DeptLevel;

 // 
 private string M_DeptDesc;

 // 
 private bool? M_IsEnabled;

 // 创建时间
 private DateTime? M_CreateTime;

 // 修改时间
 private DateTime? M_ModifyTime;

 // 
 private double? M_ordernum;

		/// <summary>
        /// (主键)
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
 public string DeptName{

            get{
                return M_DeptName;
                }
                 
            set{
                M_DeptName=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string DeptFullID{

            get{
                return M_DeptFullID;
                }
                 
            set{
                M_DeptFullID=value;
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
 public int? PDepartmentID{

            get{
                return M_PDepartmentID;
                }
                 
            set{
                M_PDepartmentID=value;
                }
                 
}
/// <summary>
        /// 部门层级
        /// </summary>
 public int? DeptLevel{

            get{
                return M_DeptLevel;
                }
                 
            set{
                M_DeptLevel=value;
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
 public bool? IsEnabled{

            get{
                return M_IsEnabled;
                }
                 
            set{
                M_IsEnabled=value;
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
/// <summary>
        /// 
        /// </summary>
 public double? ordernum{

            get{
                return M_ordernum;
                }
                 
            set{
                M_ordernum=value;
                }
                 
}

    }
}