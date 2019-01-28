using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using SystemExtend;
using SystemExtend.ExceptionExt;
using WEB.DataAccessBase;

namespace WEB.DataAccess.DepartmentTBL
{
    /// <summary>
    /// OperateData 的摘要说明
    /// </summary>
    public class OperateData : OperateDataBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        /********   可修改区域 Start  ********/
        DBControl.Base.BLLOpt<Model.Department_Model> bll = new DBControl.Base.BLLOpt<Model.Department_Model>();
        DBControl.BLL.DepartmentBLL bllExt = new DBControl.BLL.DepartmentBLL();

        /********   可修改区域 End  ********/

        public void ProcessRequest(HttpContext context)
        {
            /********  初始化 可修改区域 Start  ********/
            _tableName = "Department";

            /********  初始化 可修改区域 End  ********/

            context.Response.ContentType = "text/plain";
            Initial(context);
            if (UrlHelper.ReqStr("m").Equals("DeleteByID"))
            {
                DeleteByID();
            }
             
            else
            {
                OptData();
            }

        }


        private void OptData()
        {
            /********   可修改区域 Start  ********/
            Model.Department_Model model = GetNewDataModel(CurrentContext);
            /********   可修改区域 End  ********/



            bool issuccess = false;
            string msg = string.Empty;

            try
            {
                if (IsAdd)
                {
                    
                    issuccess = bll.AddModel(model);
                    

                    msg = issuccess ? "添加成功。" : "添加失败！";
                    
                }
                else
                {
                    issuccess = bll.UpdateModel(model);
                     
                    msg = issuccess ? "修改成功。" : "修改失败！";
                }

                string[] DepartmentPathAndDeptLevel = bllExt.AnalyzeDepartmentPathAndDeptLevel(model.DepartmentID.ToString());
                model.DeptFullID = DepartmentPathAndDeptLevel[0];
                model.DeptFullName = DepartmentPathAndDeptLevel[1];
                model.DeptLevel = int.Parse(DepartmentPathAndDeptLevel[2]);
                bll.UpdateModel(model);

            }
            catch (Exception ex)
            {
                issuccess = false;
                msg = string.Format("{0} {1}", msg, ex.Message);
            }

            ReturnMsg(issuccess,enumReturnTitle.OptData, msg);

        }

        private void DeleteByID()
        {
            if (bll.Delete(_pKeyValue))
            {
                ReturnMsg(true,enumReturnTitle.OptData, "删除成功!");
            }
            else
            {
                ReturnMsg(false,enumReturnTitle.OptData, "删除失败!");
            }


        }


        /********  获取数据  可修改区域 Start  ********/
        private Model.Department_Model GetNewDataModel(HttpContext context)
        {

            Model.Department_Model model = new Model.Department_Model();
            if (IsEdit)
            {

                model = bll.GetModelByKeyValue(_pKeyValue);
                
                if (null == model)
                {
                    throw new HasNotRecordException(_pKeyValue);
                }
                

            }

            model.DepartmentID = string.IsNullOrWhiteSpace(_pKeyValue) ? 0 : int.Parse(_pKeyValue);
            model.DeptName = UrlHelper.ReqStrByGetOrPost(context, "DeptName");
            model.PDepartmentID = UrlHelper.ReqIntByGetOrPost(context, "PDepartmentID");
            model.DeptDesc = UrlHelper.ReqStrByGetOrPost(context, "DeptDesc");


            

            return model;

        }
        /********  获取数据  可修改区域 End  ********/


        #region 其他

 
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