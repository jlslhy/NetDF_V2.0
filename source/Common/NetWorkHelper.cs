using System;
using System.Text;
using System.IO;

namespace Common
{
    /// <summary>
    /// 有关网络的封装
    /// </summary>
    public class NetWorkHelper
    {
        /// <summary>
        /// 读取页面内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encodingType"></param>
        /// <returns></returns>
        public static string ReadPageContentByUrl(string url, string encodingType)
        {
            try
            {
                StringBuilder dataReturnString = new StringBuilder();
                Stream dataStream;
                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                req.AllowAutoRedirect = true;
                System.Net.HttpWebResponse resp = (System.Net.HttpWebResponse)req.GetResponse();

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dataStream = resp.GetResponseStream();
                    System.Text.Encoding encode = System.Text.Encoding.GetEncoding(encodingType);
                    StreamReader readStream = new StreamReader(dataStream, encode);
                    char[] cCount = new char[500];
                    int count = readStream.Read(cCount, 0, 256);
                    while (count > 0)
                    {
                        String str = new String(cCount, 0, count);
                        dataReturnString.Append(str);
                        count = readStream.Read(cCount, 0, 256);
                    }
                    resp.Close();
                    return dataReturnString.ToString();
                }
                resp.Close();
                return null;
            }
            catch
            {
                return "网络异常...请稍后再试。";
            }
        }

        /// <summary>
        /// 数据库备份
        /// </summary>
        public static bool DbBackup(string url)
        {

            SQLDMO.Backup oBackup = new SQLDMO.BackupClass();
            SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
            try
            {

                oSQLServer.LoginSecure = false;

                oSQLServer.Connect(System.Configuration.ConfigurationManager.AppSettings["Server"], System.Configuration.ConfigurationManager.AppSettings["User"], System.Configuration.ConfigurationManager.AppSettings["Password"]);

                oBackup.Action = SQLDMO.SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;

                oBackup.Database = System.Configuration.ConfigurationManager.AppSettings["DB"];

                oBackup.Files = url;//"d:\Northwind.bak";

                oBackup.BackupSetName = System.Configuration.ConfigurationManager.AppSettings["DB"];

                oBackup.BackupSetDescription = "数据库备份";

                oBackup.Initialize = true;

                oBackup.SQLBackup(oSQLServer);

                return true;

            }
            catch
            {
                return false;
                throw;

            }
            finally
            {
                oSQLServer.DisConnect();
            }
        }
    }
}
