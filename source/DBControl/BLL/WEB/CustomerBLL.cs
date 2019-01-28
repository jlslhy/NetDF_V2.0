using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DBControl.BLL.WEB
{
    public partial class CustomerBLL
    {
        DAL.WEB.CustomerDAL dal = new DAL.WEB.CustomerDAL();
        Base.BLLOpt<Model.WEB.Customer_Model> bll = new Base.BLLOpt<Model.WEB.Customer_Model>();
        
	    /// <summary>
        /// 是否有下级数据
        /// </summary>
        /// <returns></returns>
        public bool HasChildData(string PCode) {
            return dal.HasChildData(PCode);
        }

        public bool HasChildDataByID(string id)
        {
            Model.WEB.Customer_Model model = bll.GetModelByKeyValue(id);
            if (null != model)
            {
			    return HasChildData(model.CustomerCode.Value==null?"0":model.CustomerCode.Value.ToString());
                
            }
            return false;
        }

        public bool HasChildDataByIDs(string ids)
        {
            string[] arrId = ids.Split(',');
            foreach (string id in arrId)
            {
                if (HasChildDataByID(id)) return true;
            }
            return false;
        }
		
	}
}
