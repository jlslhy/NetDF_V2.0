/*
 * 框架版本：NetDF2.0  
 * 架构设计与开发、版权所有者：李青锦 
 * QQ：3425806176 
 * 技术网站：软艺软件(www.ruanyi.online) 
 * 技术交流群：826373349
 * */

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Model.WEB
{
    public class Images_Model:Model.Base.ModelBase
    {
	    public Images_Model()
        {
            TableName = "Images";
            PKey = "ImagesID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_ImagesID;
            }
            set
            {
                M_ImagesID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [Images]
           ( [ImageGUID],[FileName],[Fix],[FileType],[HasThumbnail],[Url],[FileSize],[OrderNum],[Description],[CreateTime],[ModifyTime]) VALUES (@ImageGUID,@FileName,@Fix,@FileType,@HasThumbnail,@Url,@FileSize,@OrderNum,@Description,@CreateTime,@ModifyTime);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [Images]
            SET [ImageGUID]=@ImageGUID,[FileName]=@FileName,[Fix]=@Fix,[FileType]=@FileType,[HasThumbnail]=@HasThumbnail,[Url]=@Url,[FileSize]=@FileSize,[OrderNum]=@OrderNum,[Description]=@Description,[CreateTime]=@CreateTime,[ModifyTime]=@ModifyTime WHERE  [ImagesID]=@ImagesID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@ImagesID", M_ImagesID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@ImageGUID",M_ImageGUID));
            list.Add(new SqlParameter("@FileName",M_FileName));
            list.Add(new SqlParameter("@Fix",M_Fix));
            list.Add(new SqlParameter("@FileType",M_FileType));
            list.Add(new SqlParameter("@HasThumbnail",M_HasThumbnail));
            list.Add(new SqlParameter("@Url",M_Url));
            list.Add(new SqlParameter("@FileSize",M_FileSize));
            list.Add(new SqlParameter("@OrderNum",M_OrderNum));
            list.Add(new SqlParameter("@Description",M_Description));
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
 private int M_ImagesID;

 // 
 private string M_ImageGUID;

 // 
 private string M_FileName;

 // 
 private string M_Fix;

 // 
 private string M_FileType;

 // 
 private bool? M_HasThumbnail;

 // 
 private string M_Url;

 // 
 private double? M_FileSize;

 // 
 private double? M_OrderNum;

 // 
 private string M_Description;

 // 
 private DateTime? M_CreateTime;

 // 
 private DateTime? M_ModifyTime;

		/// <summary>
        /// (主键)
        /// </summary>
 public int ImagesID{

            get{
                return M_ImagesID;
                }
                 
            set{
                M_ImagesID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string ImageGUID{

            get{
                return M_ImageGUID;
                }
                 
            set{
                M_ImageGUID=value;
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
        /// 
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
        /// 
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
        /// 
        /// </summary>
 public string Url{

            get{
                return M_Url;
                }
                 
            set{
                M_Url=value;
                }
                 
}
/// <summary>
        /// 
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