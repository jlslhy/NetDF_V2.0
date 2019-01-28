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
namespace Model.ADModule
{
    public class ADContentList_Model:Model.Base.ModelBase
    {
	    public ADContentList_Model()
        {
            TableName = "ADContentList";
            PKey = "ADContentListID";
            PKeyDataType = typeof(System.Int32);
        }

        public override object PKeyValue
        {
            get
            {
                return M_ADContentListID;
            }
            set
            {
                M_ADContentListID = (System.Int32)value;
            }
        }

        public override string AddSQL
        { get
            {
                return @"INSERT INTO [ADContentList]
           ( [ADID],[ADText],[PicUrl],[FlashUrl],[ToolTip],[LinkUrl],[Description]) VALUES (@ADID,@ADText,@PicUrl,@FlashUrl,@ToolTip,@LinkUrl,@Description);select @@identity ";}}

        public override string UpdateSQL
        { get
            {
                return @"UPDATE [ADContentList]
            SET [ADID]=@ADID,[ADText]=@ADText,[PicUrl]=@PicUrl,[FlashUrl]=@FlashUrl,[ToolTip]=@ToolTip,[LinkUrl]=@LinkUrl,[Description]=@Description WHERE  [ADContentListID]=@ADContentListID";}}

        public override SqlParameter[] ParamsForAdd
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();return list.ToArray();}}

        public override SqlParameter[] ParamsForUpdate
        { get
            {
                 List<SqlParameter> list = GetNotKeyParams();
                list.Add(new SqlParameter("@ADContentListID", M_ADContentListID));
                return list.ToArray();}}

        public List<SqlParameter> GetNotKeyParams()
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@ADID",M_ADID));
            list.Add(new SqlParameter("@ADText",M_ADText));
            list.Add(new SqlParameter("@PicUrl",M_PicUrl));
            list.Add(new SqlParameter("@FlashUrl",M_FlashUrl));
            list.Add(new SqlParameter("@ToolTip",M_ToolTip));
            list.Add(new SqlParameter("@LinkUrl",M_LinkUrl));
            list.Add(new SqlParameter("@Description",M_Description));
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
 private int M_ADContentListID;

 // 
 private int? M_ADID;

 // 
 private string M_ADText;

 // 
 private string M_PicUrl;

 // 
 private string M_FlashUrl;

 // 
 private string M_ToolTip;

 // 
 private string M_LinkUrl;

 // 
 private string M_Description;

		/// <summary>
        /// (主键)
        /// </summary>
 public int ADContentListID{

            get{
                return M_ADContentListID;
                }
                 
            set{
                M_ADContentListID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public int? ADID{

            get{
                return M_ADID;
                }
                 
            set{
                M_ADID=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string ADText{

            get{
                return M_ADText;
                }
                 
            set{
                M_ADText=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string PicUrl{

            get{
                return M_PicUrl;
                }
                 
            set{
                M_PicUrl=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string FlashUrl{

            get{
                return M_FlashUrl;
                }
                 
            set{
                M_FlashUrl=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string ToolTip{

            get{
                return M_ToolTip;
                }
                 
            set{
                M_ToolTip=value;
                }
                 
}
/// <summary>
        /// 
        /// </summary>
 public string LinkUrl{

            get{
                return M_LinkUrl;
                }
                 
            set{
                M_LinkUrl=value;
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

    }
}