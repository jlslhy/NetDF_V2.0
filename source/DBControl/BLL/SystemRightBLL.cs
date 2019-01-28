using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DBControl.BLL
{
    public class SystemRightBLL
    {
        /// <summary>
        /// 是否具有权限
        /// </summary>
        /// <param name="rightCode"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool IsExistRight(string rightCode, int userID)
        {
            bool yes = false;
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@RightCode",rightCode),
                new SqlParameter("@UserID",userID)
            };
            IDataReader idr = DBUtility.DbHelperSQL.RunProcedure("IsExistRight",parameters);
            if (null != idr && idr.Read())
            {
                object obj = idr["cnt"];
                if (null != obj && (int)obj > 0)
                {
                    yes = true;
                }
                idr.Close();
                idr.Dispose();
            }
            return yes;
        }
    }
}
