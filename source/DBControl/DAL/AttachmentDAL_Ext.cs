using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace DBControl.DAL
{
   
    public partial class AttachmentDAL
    {
        /// <summary>
        /// 根据批量ID获取数据
        /// </summary>
        /// <param name="batchGUID"></param>
        /// <returns></returns>
        public IDataReader GetDataByBatchGUID(string batchGUID)
        {
            string cmdtext = "select * from Attachment where BatchGUID='" + batchGUID + "'";
            return DbHelperSQL.ExecuteReader(cmdtext);
        }

        /// <summary>
        /// 根据附件ID获取数据
        /// </summary>
        /// <param name="attachID"></param>
        /// <returns></returns>
        public IDataReader GetDataByAttachID(string attachID)
        {
            string cmdtext = "select * from Attachment where AttachID='" + attachID + "'";
            return DbHelperSQL.ExecuteReader(cmdtext);
        }
        /// <summary>
        /// 增加下载次数
        /// </summary>
        /// <param name="attachID"></param>
        public void AddDownloadCount(string attachID)
        {
            string cmdtext = 
          @"update   Attachment 
            set DownloadCount= CASE  when DownloadCount is null 
            then 1 
            else DownloadCount+1 
            end 
            where attachID=" + attachID;

            DbHelperSQL.ExecuteSql(cmdtext);
        }

    }
}
