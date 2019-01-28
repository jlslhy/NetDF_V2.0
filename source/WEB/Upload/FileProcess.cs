using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WEB.Upload
{
    public class FileProcess
    {
        DBControl.Base.BLLOpt<Model.Attachment_Model> bll = new DBControl.Base.BLLOpt<Model.Attachment_Model>();
        /// <summary>
        /// 文件保存至附件表
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool SaveToAttachment(string newFileName, string oldFileName, string guid, string attachGUID, string relativeFolder)
        {
            bool isOK = false;
            FileInfo f = new FileInfo(newFileName);
            Model.Attachment_Model model = new Model.Attachment_Model();
            model.AttachGUID = attachGUID;
            model.BatchGUID = guid;
            model.FileName = f.Name;
            model.Fix = f.Extension;
            model.URI = f.FullName;
            model.RelativeURL = relativeFolder+"/" + f.Name;// WEB.Config.WebConfig.AttachmentFileFoler + "/" + f.Name;
            model.FileSize = f.Length;
            model.OrderNum = 0;
            model.Description = oldFileName;//.Substring(0,oldFileName.LastIndexOf('.'));
            model.UserUploader = WEB.Module.LoginManage.LoginHelper.CurrentUser.BaseInfo.LoginID;
            model.CreateTime = DateTime.Now;
            isOK = bll.AddModel(model);
            return isOK;
        }
    }
}