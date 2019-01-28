using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBControl.DBInfo
{
    public class TypeHelper
    {
        /// <summary>
        /// 根据表名获取对应的表信息类类型
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static Type GetTypeByTableName(string tableName)
        {
            Type t;
            switch (tableName)
            {
                case "SystemRoleRightRelation":
                    t = typeof(Tables.SystemRoleRightRelation);
                    
                    break;
                case "SystemRoleUsersRelation":
                    t = typeof(Tables.SystemRoleUsersRelation);
                    break;
                case "SystemRight":
                    t = typeof(Tables.SystemRight);
                    break;
                case "SystemRole":
                    t = typeof(Tables.SystemRole);
                    break;
                case "Users":
                    t = typeof(Tables.Users);
                    break;
                default:
                    t = typeof(object);
                    break;
            }
            return t;
        }
    }
}
