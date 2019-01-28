using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace DBControl.DAL.WEB
{
   
    public partial class CustomerDAL
    {
         
		
		/// <summary>
        /// 是否有下级数据
        /// </summary>
        /// <returns></returns>
        public bool HasChildData(string code)
        {
		    if (DBUtility.DbHelperSQL.Exists("CustomerContact", "CustomerCode", code)){ 
                return true;
            }
           
            return false;
        }
		 
    }
}
