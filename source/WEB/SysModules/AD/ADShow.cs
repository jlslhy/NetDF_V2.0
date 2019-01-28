using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.UI.HtmlControls;

namespace WEB.SysModules.AD
{
     [
    AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal),
    DefaultProperty("Title"),
    ToolboxData("<{0}:ADShow runat=\"server\"> </{0}:ADShow>")
    ]
    public class ADShow : WebControl
    {
         DBControl.Base.BLLOpt<Model.ADModule.AD_Model> adBll = new DBControl.Base.BLLOpt<Model.ADModule.AD_Model>();
         DBControl.Base.BLLOpt<Model.ADModule.ADDisplayMode_Model> addmBll = new DBControl.Base.BLLOpt<Model.ADModule.ADDisplayMode_Model>();
         DBControl.Base.BLLOpt<Model.ADModule.ADContentList_Model> adlBll = new DBControl.Base.BLLOpt<Model.ADModule.ADContentList_Model>();

        [
        Bindable(true),
        Category("AD"),
        DefaultValue(""),
        Description("广告标题"),
        Localizable(true)
        ]
        public virtual string ADTitle
        {
            get
            {
                string s = (string)ViewState["ADTitle"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["ADTitle"] = value;
            }
        }

        [
        Bindable(true),
        Category("AD"),
        DefaultValue(""),
        Description("广告ID"),
        Localizable(true)
        ]
        public virtual string ADID
        {
            get
            {
                string s = (string)ViewState["ADID"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["ADID"] = value;
            }
        }

        [
        Bindable(true),
        Category("AD"),
        DefaultValue(""),
        Description("是否加载共用的CSS和JS代码"),
        Localizable(true)
        ]
        public bool IsLoadCommonCSSAndJsCode {
            get
            {  
                object b =  ViewState["IsLoadCommonCSSAndJsCode"];
                return  b == null?false:bool.Parse(b.ToString());
            }
            set
            {
                ViewState["IsLoadCommonCSSAndJsCode"] = value;
            }
        }

         /// <summary>
         /// 获取广告模板
         /// </summary>
         /// <returns></returns>
        public string GettTemplateCode() 
        {
            string templatecode = string.Empty;
            
            Model.ADModule.AD_Model admodel = adBll.GetModelByKeyValue(ADID);
            if (admodel == null)
                return string.Empty;

            
            Model.ADModule.ADDisplayMode_Model addmModel = addmBll.GetModelByKeyValue(admodel.ADDisplayModeCode);
            if (null != addmModel)
            {
                templatecode = addmModel.DisplayModeTemplateCode;
            }
             
            return templatecode;
           
        }

         /// <summary>
         /// 解析模板
         /// </summary>
         /// <returns></returns>
        public string ParseTemplateCode()
        {
            

            string templatecode = string.Empty;

            Model.ADModule.AD_Model admodel = adBll.GetModelByKeyValue(ADID);
            if (admodel == null)
                return string.Empty;


            Model.ADModule.ADDisplayMode_Model addmModel = addmBll.GetModelByKeyValue(admodel.ADDisplayModeCode);
            if (null != addmModel)
            {
                templatecode = addmModel.DisplayModeTemplateCode;
            }

             

            //Regex regex = new Regex("(?<=\\[ADList:loop\\])(.|\n)*?(?=\\[/ADList:loop\\])", RegexOptions.IgnoreCase);
            //MatchCollection matchcol = regex.Matches(tmeplatecode);

            Regex regex = new Regex("\\[ADList:loop\\](.|\n)*?\\[/ADList:loop\\]", RegexOptions.IgnoreCase);
            MatchCollection matchcol = regex.Matches(templatecode);


            string ADControlID = string.Format("ADControlID_{0}_{1}_{2}", admodel.ADID.ToString(),this.ID, new Random().Next(100000000).ToString());

            foreach (Match match in matchcol)
            {
                Regex tempRegex = new Regex("(?<=\\[ADList:loop\\])(.|\n)*?(?=\\[/ADList:loop\\])", RegexOptions.IgnoreCase);
                string Ptempstr = match.Value;
                Match tempMatch = tempRegex.Match(Ptempstr);

                StringBuilder tempCodeSB = new StringBuilder();

                List<Model.ADModule.ADContentList_Model> adcontentlist  =   adlBll.GetList(100, "ADID="+ADID,"");


                int index = 0;
                foreach (Model.ADModule.ADContentList_Model item in adcontentlist)
                {
                    string tempCode = tempMatch.Value;
                    index++;

                    tempCode = tempCode.Replace("#LinkUrl#", item.LinkUrl);
                    tempCode = tempCode.Replace("#index#", index.ToString());
                    tempCode = tempCode.Replace("#PicUrl#", item.PicUrl);
                    tempCode = tempCode.Replace("#ADText#", item.ADText);
                    tempCode = tempCode.Replace("#ToolTip#", item.ToolTip);
                    tempCode = tempCode.Replace("#Description#", item.Description);
                    tempCode = tempCode.Replace("#FlashUrl#", item.FlashUrl);
                    tempCode = tempCode.Replace("#DisplayHeight#", admodel.DisplayHeight.Value.ToString());
                    tempCode = tempCode.Replace("#DisplayWidth#", admodel.DisplayWidth.Value.ToString());
                    tempCode = tempCode.Replace("#DisplayPrickle#", admodel.DisplayPrickle);
                    
                    tempCodeSB.Append(tempCode);
 
                }

                templatecode = templatecode.Replace(Ptempstr, tempCodeSB.ToString());
 
            }

            templatecode = templatecode.Replace("#ADControlID#", ADControlID);
            templatecode = templatecode.Replace("#DisplayHeight#", admodel.DisplayHeight.Value.ToString());
            templatecode = templatecode.Replace("#DisplayWidth#", admodel.DisplayWidth.Value.ToString());
            templatecode = templatecode.Replace("#DisplayPrickle#", admodel.DisplayPrickle);


            //if (IsLoadCommonCSSAndJsCode)
            //{
            //    templatecode = string.Format("{0} \n {1} \n {2}",addmModel.CSSCode,addmModel.JsCode,templatecode);
            //}

            //if (ViewState[admodel.ADDisplayModeCode] == null)
            //{
               
              
            //    ViewState[admodel.ADDisplayModeCode] = "true";
            //}

           
            return templatecode;
        }




        protected override void RenderContents(HtmlTextWriter writer)
        {
           
            writer.Write(ParseTemplateCode());
 
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);

             
        }

        protected override object SaveViewState()
        {
            
            return base.SaveViewState();
        }

        protected override void TrackViewState()
        {
            
            base.TrackViewState();
        }


        public void LoadCSSAndJSCode(System.Web.UI.Page p)
        {
            
            Model.ADModule.AD_Model admodel = adBll.GetModelByKeyValue(ADID);
            if (admodel == null)
                return ;


            Model.ADModule.ADDisplayMode_Model addmModel = addmBll.GetModelByKeyValue(admodel.ADDisplayModeCode);
            if (null != addmModel)
            {
                RegisterCode(addmModel.CSSCode+"\n"+addmModel.JsCode,addmModel.ADDisplayModeCode,p);
            }

             
        }


        /// 注册脚本块(或者样式块)
        /// </summary>
        /// <param name="script"></param>
        /// <param name="key"></param>
        /// <param name="type"></param>
        public void RegisterCode(string code, string key,System.Web.UI.Page p)
        {
            
            //是否已输出
            if (!p.ClientScript.IsClientScriptBlockRegistered(this.GetType(), key))
            {
                if (p.Header != null)
                {
                    LiteralControl link = new LiteralControl();
                    link.Text = "\r\n" + code;
                    p.Header.Controls.Add(link);
                }
                p.ClientScript.RegisterClientScriptBlock(this.GetType(), key, "", false);//注册资源key
            }
        }
    }
}