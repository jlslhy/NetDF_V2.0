using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using WEB.DataAccessBase;
namespace WEB.Upload
{
    /// <summary>
    ///  
    /// </summary>
    public class fileupload : OperateDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        #region 文件分片

        public void ProcessRequest(HttpContext context)
        {
            FileProcess fp = new FileProcess();
            string OldFileName = "";
            context.Response.ContentType = "text/plain";
            Initial(context);
            DateTime NowDT = DateTime.Now;
            //如果进行了分片
            if (context.Request.Form.AllKeys.Any(m => m == "chunk"))
            {
                //取得chunk和chunks
                int chunk = Convert.ToInt32(context.Request.Form["chunk"]);//当前分片在上传分片中的顺序（从0开始）
                int chunks = Convert.ToInt32(context.Request.Form["chunks"]);//总分片数
                //根据GUID创建用该GUID命名的临时文件夹
                //string folder = context.Server.MapPath(WEB.Config.WebConfig.AttachmentFileFoler + "/" + context.Request["guid"] + "/");
                string folder = context.Server.MapPath(WEB.Config.WebConfig.AttachmentFileFoler + "/" + string.Format("{0}/{1}/{2}/", NowDT.Year, NowDT.Month, NowDT.Day) + context.Request["guid"] + "/");

                string path = folder + chunk;

                //建立临时传输文件夹
                if (!Directory.Exists(Path.GetDirectoryName(folder)))
                {
                    Directory.CreateDirectory(folder);
                }

                FileStream addFile = new FileStream(path, FileMode.Append, FileAccess.Write);
                BinaryWriter AddWriter = new BinaryWriter(addFile);
                //获得上传的分片数据流
                HttpPostedFile file = context.Request.Files[0];
                Stream stream = file.InputStream;
                OldFileName = file.FileName;

                BinaryReader TempReader = new BinaryReader(stream);
                //将上传的分片追加到临时文件末尾
                AddWriter.Write(TempReader.ReadBytes((int)stream.Length));
                //关闭BinaryReader文件阅读器
                TempReader.Close();
                stream.Close();
                AddWriter.Close();
                addFile.Close();

                TempReader.Dispose();
                stream.Dispose();
                AddWriter.Dispose();
                addFile.Dispose();

                context.Response.Write("{\"chunked\" : true, \"hasError\" : false, \"f_ext\" : \"" + Path.GetExtension(file.FileName) + "\"}");


            }
            else//没有分片直接保存
            {
                string folder = context.Server.MapPath(WEB.Config.WebConfig.AttachmentFileFoler + "/" + string.Format("{0}/{1}/{2}/", NowDT.Year, NowDT.Month, NowDT.Day));
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string tempFileName = folder+ DateTime.Now.ToFileTime() + Path.GetExtension(context.Request.Files[0].FileName);
                //string tempFileName = context.Server.MapPath(WEB.Config.WebConfig.AttachmentFileFoler  + "/" + string.Format("{0}/{1}/{2}/", NowDT.Year, NowDT.Month, NowDT.Day) + DateTime.Now.ToFileTime() + Path.GetExtension(context.Request.Files[0].FileName));
                
                 
                context.Request.Files[0].SaveAs(tempFileName);
                OldFileName = context.Request.Files[0].FileName;
                string batchGUID = context.Request["guid"];

                string attachGUID = Guid.NewGuid().ToString();

                fp.SaveToAttachment(tempFileName, OldFileName, context.Request["guid"].ToString(), attachGUID, WEB.Config.WebConfig.AttachmentFileFoler + "/" + string.Format("{0}/{1}/{2}", NowDT.Year, NowDT.Month, NowDT.Day));
                // context.Response.Write("{\"chunked\" : false, \"hasError\" : false}");

                context.Response.Write("{\"chunked\" : false, \"hasError\" : false,\"attachGUID\":\"" + attachGUID + "\",\"batchGUID\":\"" + batchGUID + "\"}");
            }
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}