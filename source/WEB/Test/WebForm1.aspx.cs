using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WEB.Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           //bool yes =  DBControl.BLL.SystemRightBLL.IsExistRight("001001002", 10000);
           //testAddData();
           testEditData();
        }


        private void testGetMultiTableData() {
            IDataReader idr = DBControl.Base.DBAccess.GetFirstPageDataMultiTableIDR("SystemRoleRightRelation", "*", "SystemRoleRightRelationID", 0, false, 3, "", "b.*", "inner join dbo.SystemRight b on  a.SystemRightID=b.ID and a.SystemRoleID=1");

            
        }

        private void testAddData()
        {
            DBControl.Base.BLLOpt<Model.Users_Model> bll = new DBControl.Base.BLLOpt<Model.Users_Model>();

            Model.Users_Model userModel = new Model.Users_Model();
            userModel.LoginID = "LQJ";
            userModel.Mobile = "15300001111";
            userModel.QQ = "3425806176";
            userModel.Email = "3425806176@qq.com";

            bll.AddModel(userModel);
        }

        private void testEditData()
        {
            DBControl.Base.BLLOpt<Model.Users_Model> bll = new DBControl.Base.BLLOpt<Model.Users_Model>();

            Model.Users_Model userModel = bll.GetModelByKeyValue("10002");
            if (null != userModel)
            {
                userModel.RealName = "LQJ";
                userModel.Remark = "修改数据";
                bll.UpdateModel(userModel);
            }
        }

    }
}