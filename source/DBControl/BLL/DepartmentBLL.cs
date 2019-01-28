using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;

namespace DBControl.BLL
{
    public class DepartmentBLL
    {
        DAL.DepartmentDAL dal = new DAL.DepartmentDAL();
        /// <summary>
        /// index : 0为idstr,1为textStr ,2为级别深度数
        /// </summary>
        /// <param name="departmentid"></param>
        /// <returns></returns>
        public string[] AnalyzeDepartmentPathAndDeptLevel(string departmentid)
        {
            return dal.AnalyzeDepartmentPathAndDeptLevel(departmentid);
        }
    }
}
