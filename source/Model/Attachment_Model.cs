/*
 * 框架版本：NetDF2.0  
 * 架构设计开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Model
{
    public class Attachment_Model:Model.Base.ModelBase
    {
	    public Attachment_Model()
        {
            TableName = "Attachment";
            PKey = "AttachID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_AttachID;
            }
            set
            {
                M_AttachID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [Attachment]
           ( [AttachGUID],[BatchGUID],[FileName],[Fix],[FileType],[HasThumbnail],[URI],[RelativeURL],[FileSize],[OrderNum],[Description],[MemberUpLoader],[UserUploader],[CreateTime],[ModifyTime]) VALUES (@AttachGUID,@BatchGUID,@FileName,@Fix,@FileType,@HasThumbnail,@URI,@RelativeURL,@FileSize,@OrderNum,@Description,@MemberUpLoader,@UserUploader,@CreateTime,@ModifyTime);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [Attachment]
            SET [AttachGUID]=@AttachGUID,[BatchGUID]=@BatchGUID,[FileName]=@FileName,[Fix]=@Fix,[FileType]=@FileType,[HasThumbnail]=@HasThumbnail,[URI]=@URI,[RelativeURL]=@RelativeURL,[FileSize]=@FileSize,[OrderNum]=@OrderNum,[Description]=@Description,[MemberUpLoader]=@MemberUpLoader,[UserUploader]=@UserUploader,[CreateTime]=@CreateTime,[ModifyTime]=@ModifyTime WHERE  [AttachID]=@AttachID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@AttachID", M_AttachID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@AttachGUID",M_AttachGUID));
            list.Add(new SqlParameter("@BatchGUID",M_BatchGUID));
            list.Add(new SqlParameter("@FileName",M_FileName));
            list.Add(new SqlParameter("@Fix",M_Fix));
            list.Add(new SqlParameter("@FileType",M_FileType));
            list.Add(new SqlParameter("@HasThumbnail",M_HasThumbnail));
            list.Add(new SqlParameter("@URI",M_URI));
            list.Add(new SqlParameter("@RelativeURL",M_RelativeURL));
            list.Add(new SqlParameter("@FileSize",M_FileSize));
            list.Add(new SqlParameter("@OrderNum",M_OrderNum));
            list.Add(new SqlParameter("@Description",M_Description));
            list.Add(new SqlParameter("@MemberUpLoader",M_MemberUpLoader));
            list.Add(new SqlParameter("@UserUploader",M_UserUploader));
            list.Add(new SqlParameter("@CreateTime",M_CreateTime));
            list.Add(new SqlParameter("@ModifyTime",M_ModifyTime));
            foreach (SqlParameter par in list)
            {
                if (null == par.Value)
                {
                    par.Value = DBNull.Value;
                }
            }
            return list;
        }

	    

 // (主键)
 private int M_AttachID;

 // 
 private string M_AttachGUID;

 // 批次GUID
 private string M_BatchGUID;

 // 
 private string M_FileName;

 // 后缀名
 private string M_Fix;

 // 文件类型
 private string M_FileType;

 // 
 private bool? M_HasThumbnail;

 // 绝对资源地址
 private string M_URI;

 // 相对网址
 private string M_RelativeURL;

 // 文件大小，单位为字节
 private double? M_FileSize;

 // 
 private double? M_OrderNum;

 // 
 private string M_Description;

 // 上传者 会员 
 private string M_MemberUpLoader;

 // 上传者 系统管理员 
 private string M_UserUploader;

 // 
 private DateTime? M_CreateTime;

 // 
 private DateTime? M_ModifyTime;

		/// <summary>
        /// (主键)
        /// </summary>
 public int AttachID{

            get{
                return M_AttachID;
                }
                 
            set{
                M_AttachID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string AttachGUID{

            get{
                return M_AttachGUID;
                }
                 
            set{
                M_AttachGUID=value;
                }
                 
}
/// <summary>
        /// 批次GUID
        /// </summary>
 public string BatchGUID{

            get{
                return M_BatchGUID;
                }
                 
            set{
                M_BatchGUID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string FileName{

            get{
                return M_FileName;
                }
                 
            set{
                M_FileName=value;
                }
                 
}
/// <summary>
        /// 后缀名
        /// </summary>
 public string Fix{

            get{
                return M_Fix;
                }
                 
            set{
                M_Fix=value;
                }
                 
}
/// <summary>
        /// 文件类型
        /// </summary>
 public string FileType{

            get{
                return M_FileType;
                }
                 
            set{
                M_FileType=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public bool? HasThumbnail{

            get{
                return M_HasThumbnail;
                }
                 
            set{
                M_HasThumbnail=value;
                }
                 
}
/// <summary>
        /// 绝对资源地址
        /// </summary>
 public string URI{

            get{
                return M_URI;
                }
                 
            set{
                M_URI=value;
                }
                 
}
/// <summary>
        /// 相对网址
        /// </summary>
 public string RelativeURL{

            get{
                return M_RelativeURL;
                }
                 
            set{
                M_RelativeURL=value;
                }
                 
}
/// <summary>
        /// 文件大小，单位为字节
        /// </summary>
 public double? FileSize{

            get{
                return M_FileSize;
                }
                 
            set{
                M_FileSize=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public double? OrderNum{

            get{
                return M_OrderNum;
                }
                 
            set{
                M_OrderNum=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string Description{

            get{
                return M_Description;
                }
                 
            set{
                M_Description=value;
                }
                 
}
/// <summary>
        /// 上传者 会员 
        /// </summary>
 public string MemberUpLoader{

            get{
                return M_MemberUpLoader;
                }
                 
            set{
                M_MemberUpLoader=value;
                }
                 
}
/// <summary>
        /// 上传者 系统管理员 
        /// </summary>
 public string UserUploader{

            get{
                return M_UserUploader;
                }
                 
            set{
                M_UserUploader=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public DateTime? CreateTime{

            get{
                return M_CreateTime;
                }
                 
            set{
                M_CreateTime=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public DateTime? ModifyTime{

            get{
                return M_ModifyTime;
                }
                 
            set{
                M_ModifyTime=value;
                }
                 
}

    }
}