using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WEB.DataAccessBase;

namespace WEB.Upload
{
    /// <summary>
    ///  
    /// </summary>
    public class MergeFiles : OperateDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            FileProcess fp = new FileProcess();

            context.Response.ContentType = "text/plain";
            Initial(context);
            string OldFileName = context.Request["fileName"];

            string batchGUID = context.Request["guid"];
            //if (context.Request["batchGUID"] != null && context.Request["batchGUID"] != "")
            //{
            //    batchGUID = context.Request["batchGUID"];
            //}
            string attachGUID = Guid.NewGuid().ToString();
            string fileExt = context.Request["fileExt"];
            //string root = context.Server.MapPath(WEB.Config.WebConfig.AttachmentFileFoler + "/");
            DateTime NowDT = DateTime.Now;
            string root = context.Server.MapPath(WEB.Config.WebConfig.AttachmentFileFoler + "/") + string.Format("{0}/{1}/{2}/", NowDT.Year, NowDT.Month, NowDT.Day);

            string sourcePath = Path.Combine(root, batchGUID + "/");//源数据文件夹
            string targetPath = Path.Combine(root, attachGUID + fileExt);//合并后的文件

            DirectoryInfo dicInfo = new DirectoryInfo(sourcePath);
            if (Directory.Exists(Path.GetDirectoryName(sourcePath)))
            {
                FileInfo[] files = dicInfo.GetFiles();
                foreach (FileInfo file in files.OrderBy(f => int.Parse(f.Name)))
                {
                    FileStream addFile = new FileStream(targetPath, FileMode.Append, FileAccess.Write);
                    BinaryWriter AddWriter = new BinaryWriter(addFile);

                    //获得上传的分片数据流
                    Stream stream = file.Open(FileMode.Open);
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
                }
                DeleteFolder(sourcePath);

                fp.SaveToAttachment(targetPath, OldFileName, batchGUID, attachGUID,WEB.Config.WebConfig.AttachmentFileFoler + "/"+ string.Format("{0}/{1}/{2}", NowDT.Year, NowDT.Month, NowDT.Day));
                //context.Response.Write("{\"chunked\" : true, \"hasError\" : false, \"savePath\" :\"" + System.Web.HttpUtility.UrlEncode(targetPath) + "\"}");
                //context.Response.Write("{\"chunked\" : true, \"hasError\" : false, \"savePath\" :\"" +  context.Request["guid"].ToString()  + "\"}");
                context.Response.Write("{\"chunked\" : true, \"hasError\" : false, \"savePath\" :\"" + System.Web.HttpUtility.UrlEncode(targetPath) + "\",\"attachGUID\":\"" + attachGUID + "\",\"batchGUID\":\"" + batchGUID + "\"}");



            }
            else
                context.Response.Write("{\"hasError\" : true}");
        }



        /// <summary>
        /// 删除文件夹及其内容
        /// </summary>
        /// <param name="dir"></param>
        private static void DeleteFolder(string strPath)
        {
            //删除这个目录下的所有子目录
            if (Directory.GetDirectories(strPath).Length > 0)
            {
                foreach (string fl in Directory.GetDirectories(strPath))
                {
                    Directory.Delete(fl, true);
                }
            }
            //删除这个目录下的所有文件
            if (Directory.GetFiles(strPath).Length > 0)
            {
                foreach (string f in Directory.GetFiles(strPath))
                {
                    System.IO.File.Delete(f);
                }
            }
            Directory.Delete(strPath, true);
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