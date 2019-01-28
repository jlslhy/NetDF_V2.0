using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DBControl;
using DBControl.DBInfo.Tables;
using Common;
using NetServ.Net.Json;
using SystemExtend;
using WEB.DataAccessBase;

namespace WEB.ClientDBAccess.Attach
{
    /// <summary>
    /// Opt 的摘要说明
    /// </summary>
    public class Opt : GetDataBase, IHttpHandler
    {
        DBControl.BLL.AttachmentBLL attaBllExt = new DBControl.BLL.AttachmentBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            CurrentContext = context;
            if (UrlHelper.ReqStrByGetOrPost("m").Equals("AddDownloadCount"))
            {
                AddDownloadCount();
            }
        }

        public void AddDownloadCount() {
            string AttachID = UrlHelper.ReqStrByGetOrPost("attachid");
            attaBllExt.AddDownloadCount(AttachID);
            ReturnMsg(true, enumReturnTitle.OptData, "操作成功");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}