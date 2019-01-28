using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DBControl.BLL
{
    public partial class AttachmentBLL
    {
        /// <summary>
        /// 根据批量ID获取数据
        /// </summary>
        /// <param name="batchGUID"></param>
        /// <returns></returns>
        public IDataReader GetDataByBatchGUID(string batchGUID) {
            return dal.GetDataByBatchGUID(batchGUID);
        }


        /// <summary>
        /// 根据附件ID获取数据
        /// </summary>
        /// <param name="attachID"></param>
        /// <returns></returns>
        public IDataReader GetDataByAttachID(string attachID)
        {
            return dal.GetDataByAttachID(attachID);
        }
        /// <summary>
        /// 增加下载次数
        /// </summary>
        /// <param name="attachID"></param>
        public void AddDownloadCount(string attachID)
        {
            dal.AddDownloadCount(attachID);
        }
    }
}
