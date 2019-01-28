using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;

namespace DBControl.DAL
{
   
    public class DepartmentDAL
    {
        public string[] AnalyzeDepartmentPathAndDeptLevel(string departmentid)
        {
            string[] result = new string[3];
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@tableName","Department"),
                new SqlParameter("@idField","DepartmentID"),
                new SqlParameter("@pidField","PDepartmentID"),
                new SqlParameter("@textField","DeptName"),
                new SqlParameter("@separator",">>"),
                new SqlParameter("@id",departmentid)
            };
            SqlDataReader dr = DbHelperSQL.RunProcedure("GetFullPath", parameters);
            if (null != dr)
            {
                if (dr.Read())
                {
                    result[0] = dr["idStr"].ToString();
                    result[1] = dr["textStr"].ToString();
                    result[2] = dr["currentLevel"].ToString();
                    dr.Close();
                }
                dr.Dispose();
            }
            return result;
        }


    }
}
