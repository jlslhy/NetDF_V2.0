using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBUtility
{
    public class SQLString
    {
        /// <summary>
        /// 数据库所有数据表名称
        /// </summary>
        public static string TblNamesSQL = @"select    [name]    from    sysobjects    where    type='U' order by [name] asc";
        /// <summary>
        /// 表信息
        /// </summary>
        public static string TblInfoSQL = @"DECLARE @tableName VARCHAR(100)--表名
SET @tableName = '{0}'
 
SELECT  ISNULL((SELECT  ep.value
                FROM    sys.sysobjects obj
                        INNER JOIN sys.extended_properties ep ON obj.id = ep.major_id
                WHERE   obj.name = @tableName
                        AND ep.minor_id = 0
               ), @tableName) AS tableDesc,
        col.name AS colName,
        CASE WHEN EXISTS ( SELECT   1
                           FROM     sysobjects
                           WHERE    xtype = 'PK'
                                    AND name IN (SELECT  name
                                                FROM    sysindexes
                                                WHERE   id = col.id
                                                        AND indid IN (SELECT
                                                              indid
                                                              FROM
                                                              sysindexkeys
                                                              WHERE
                                                              id = col.id
                                                              AND colid = col.colid
                                                              )
                                               ) ) THEN 'Y'
             ELSE ''
        END AS isPK,
        t.name AS dataType,
        col.length AS [dataLength],
        CASE col.isnullable
          WHEN 1 THEN 'Y'
          ELSE 'N'
        END AS isNullable,
        ISNULL(colDefault.text, '') AS defaultVal,
        ISNULL(ep.value, '') AS ColDesc
FROM    sys.syscolumns col
        INNER JOIN sys.sysobjects obj ON obj.id = col.id
        INNER JOIN systypes t ON col.xtype = t.xusertype
        LEFT JOIN syscomments colDefault ON col.cdefault = colDefault.id
        LEFT JOIN sys.extended_properties ep ON ep.major_id = obj.id
                                                AND col.colorder = ep.minor_id
                                                AND ep.minor_id > 0
WHERE   obj.name = @tableName
ORDER BY col.colorder";





    }
}
