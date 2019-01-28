/*
 * 作者：LHY
 * Email:869067911@qq.com
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web;
using System.Security.Permissions;
using System.Web.UI;
using System.Text.RegularExpressions;

[assembly: TagPrefix("AppWebUI.WebControls", "AppWebUI")]
[assembly: WebResource("AppWebUI.WebControls.Css.css.css", "text/css")]
[assembly: WebResource("AppWebUI.WebControls.JS.DataPage.js", "text/javascript")]
 
namespace AppWebUI.WebControls
{
    [
     AspNetHostingPermission(SecurityAction.Demand,
         Level = AspNetHostingPermissionLevel.Minimal),
     AspNetHostingPermission(SecurityAction.InheritanceDemand,
         Level = AspNetHostingPermissionLevel.Minimal),
     DefaultProperty("Title"),
     ToolboxData("<{0}:DataPage runat=\"server\"> </{0}:DataPage>")
     ]
    public class DataPage : Control //, INamingContainer, ICompositeControlDesignerAccessor
    {

        private string _tablename = string.Empty;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName {
            get { return _tablename; }
            set { _tablename = value; }
        }
        private string _col = string.Empty;
        /// <summary>
        /// 按该列来进行分页
        /// </summary>
        public string Col {
            get { return _col; }
            set { _col = value; }
        }

        private int _coltype = 0;
        /// <summary>
        /// col列的类型,0-数字类型,1-字符类型,2-日期时间类型 
        /// </summary>
        public int ColType {
            get { return _coltype; }
            set { _coltype = value; }
        }
        private string _orderby = string.Empty;
        /// <summary>
        /// 排序,0-顺序,1-倒序
        /// </summary>
        public string OrderBy
        {
            get { return _orderby; }
            set { _orderby = value; }
        }

        private string _collist = "*";
        /// <summary>
        /// 要查询出的字段列表,*表示全部字段 
        /// </summary>
        public string ColList {
            get { return _collist; }
            set { _collist = value; }
        }

        private int _selecttype = 3;
        /// <summary>
        /// 查询类型,1-前页,2-后页,3-首页,4-末页,5-指定页
        /// </summary>
        public int SelectType
        {
            get { return _selecttype; }
            set { _selecttype = value; }
        }

        private string _minid = string.Empty;
        /// <summary>
        /// 当前页最小号
        /// </summary>
        public string MinID {
            get { return _minid; }
            set { _minid = value; }
        }
        private string _maxid = string.Empty;
        /// <summary>
        /// 当前页最大号
        /// </summary>
        public string MaxID
        {
            get { return _maxid; }
            set { _maxid = value; }
        }

        private string _condition = string.Empty;
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        private int _pageSize = 10;
        [
        Bindable(true),
        Category("PageSettings"),
        DefaultValue(""),
        Description("每页记录数"),
        Localizable(true)
        ]
        public virtual int PageSize
        {
            get
            {
                //string pagesize = (string)ViewState["pagesize"];
                //return pagesize == null ? 10 : int.Parse(pagesize);

                if (HasParam("PageSize"))
                {
                    _pageSize = ReqInt("PageSize");
                }
                return _pageSize;
            }
            set
            {
                //ViewState["pagesize"] = value;
                _pageSize = value;
            }
        }
        private int _currentPageIndex = 0;
        [
        Bindable(true),
        Category("PageSettings"),
        DefaultValue(""),
        Description("当前页索引号,从0开始。"),
        Localizable(true)
        ]

        public virtual int CurrentPageIndex
        {
            get
            {
                //string currentPageIndex = (string)ViewState["CurrentPageIndex"];
                //return currentPageIndex == null ? 0 : int.Parse(currentPageIndex);

                if (HasParam("CurrentPageIndex"))
                {
                    _currentPageIndex = ReqInt("CurrentPageIndex");
                }
                return _currentPageIndex;
            }
            set
            {
                //ViewState["CurrentPageIndex"] = value;
                _currentPageIndex = value;
            }
        }





        private string _firstPageUrl = "#";
        private string _lastPageUrl = "#";
        private string _prevPageUrl = "#";
        private string _nextPageUrl = "#";
        
         
        private int _recordCount = 0;
        


        

        [
        Bindable(true),
        Category("PageSettings"),
        DefaultValue(""),
        Description("总记录数"),
        Localizable(true)
        ]
        public virtual int RecordCount
        {
            get {
                //string recordcount = (string)ViewState["recordcount"];
                //return recordcount == null ? 0 : int.Parse(recordcount);

                if (HasParam("RecordCount"))
                {
                    _recordCount = ReqInt("RecordCount");
                }

                return _recordCount;
 
            }
            set {
                //ViewState["recordcount"] = value;
                _recordCount = value;
            }
        }


        

        /// <summary>
        /// 最后页索引号
        /// </summary>
        public virtual int LastPageIndex {
            get {
                if (RecordCount == 0) { return 0; }
                return (RecordCount-1) / PageSize;
            }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public virtual int PageCount {
            get {
                return LastPageIndex + 1;
            }
        }


        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        private string FirstPageHtml()
        {
            if (CurrentPageIndex > 0)
            {
                return string.Format("<li><a href=\"{0}\">首页</a></li>", GetFirstPageUrl());
            }
            else {
                return string.Format("<li>首页</li>", GetFirstPageUrl());
            }
             
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <returns></returns>
        private string LastPageHtml()
        {
            if (CurrentPageIndex < LastPageIndex)
            {
                return string.Format("<li><a href=\"{0}\">尾页</a></li>", GetLastPageUrl());
            }
            else {
                return string.Format("<li>尾页</li>", GetLastPageUrl());
            }
        }

        /// <summary>
        /// 上页
        /// </summary>
        /// <returns></returns>
        private string PrevPageHtml()
        {
            if (CurrentPageIndex > 0)
            {
                return string.Format("<li><a href=\"{0}\">上页</a></li>", GetPrevPageUrl());
            }
            else {
                return string.Format("<li>上页</li>", GetPrevPageUrl());
            }
        }

        /// <summary>
        /// 下页
        /// </summary>
        /// <returns></returns
        /// >
        private string NextPageHtml()
        {
            if (CurrentPageIndex < LastPageIndex)
            {
                return string.Format("<li><a href=\"{0}\">下页</a></li>", GetNextPageUrl());
            }
            else {
                return string.Format("<li>下页</li>", GetNextPageUrl());
            }
        }

        /// <summary>
        /// 数字分页按钮
        /// </summary>
        /// <returns></returns>
        private string GetNumericsButtonHtml()
        {
            StringBuilder HtmlSB = new StringBuilder();
            int PrevTen = 10;
            PrevTen = (CurrentPageIndex / 10)*10-1;
            int NextTen = PrevTen + 11;
            if (PrevTen > 0)
            {
                HtmlSB.Append(string.Format("<li><a href='{0}'>...</a></li>", UpdateUrl(CurrentUrl, "CurrentPageIndex",PrevTen.ToString())));
            }

            int forEnd = LastPageIndex >=NextTen ?NextTen-1:LastPageIndex;

            for (int i = PrevTen + 1; i <= forEnd; i++)
            {
                if (i == CurrentPageIndex)
                {
                    HtmlSB.Append(string.Format("<li><b>{0}</b></li>",(i+1).ToString()));
                }
                else
                {
                    HtmlSB.Append(string.Format("<li><a href='{0}'>{1}</a></li>", UpdateUrl(CurrentUrl, "CurrentPageIndex", i.ToString()), (i + 1).ToString()));
                }
            }

            if (LastPageIndex >= NextTen)
            {
                HtmlSB.Append(string.Format("<li><a href='{0}'>...</a></li>", UpdateUrl(CurrentUrl, "CurrentPageIndex", NextTen.ToString())));
            }
            return HtmlSB.ToString();
        }


        public string GetGoToHtml()
        {
            StringBuilder HtmlSB = new StringBuilder();
            HtmlSB.Append(string.Format("<div id='div_GoToPage'><input id='pagenumberIpt' type='text' size='4' value='{0}' />", (CurrentPageIndex + 1).ToString()));
            HtmlSB.Append(string.Format("<input type='button' value='跳转' onclick='DataPage_GoToPage();' /></div>"));
         
            return HtmlSB.ToString();
        }

        public string GetFirstPageUrl()
        {
            
            _firstPageUrl = UpdateUrl(CurrentUrl, "SelectType", "3");
            _firstPageUrl = UpdateUrl(_firstPageUrl, "CurrentPageIndex", "0");
            _firstPageUrl = UpdateUrl(_firstPageUrl, "MaxID", "");
            _firstPageUrl = UpdateUrl(_firstPageUrl, "MinID", "");
            return _firstPageUrl;
        }

        public string GetLastPageUrl()
        {
            _lastPageUrl = UpdateUrl(CurrentUrl, "SelectType", "4");
            _lastPageUrl = UpdateUrl(_lastPageUrl, "CurrentPageIndex", LastPageIndex.ToString());
            _lastPageUrl = UpdateUrl(_lastPageUrl, "MaxID", "");
            _lastPageUrl = UpdateUrl(_lastPageUrl, "MinID", "");
            return _lastPageUrl;
        }

        public string GetPrevPageUrl()
        {
            _prevPageUrl = UpdateUrl(CurrentUrl, "SelectType", "1");
            _prevPageUrl = UpdateUrl(_prevPageUrl, "MaxID", MaxID);
            _prevPageUrl = UpdateUrl(_prevPageUrl, "MinID", MinID);
            _prevPageUrl = UpdateUrl(_prevPageUrl, "CurrentPageIndex", CurrentPageIndex>0? (CurrentPageIndex-1).ToString():"0");
            return _prevPageUrl;
        }

        public string GetNextPageUrl()
        {
            _nextPageUrl = UpdateUrl(CurrentUrl, "SelectType", "2");
            _nextPageUrl = UpdateUrl(_nextPageUrl, "MaxID", MaxID);
            _nextPageUrl = UpdateUrl(_nextPageUrl, "MinID", MinID);
            _nextPageUrl = UpdateUrl(_nextPageUrl, "CurrentPageIndex", CurrentPageIndex<LastPageIndex?(CurrentPageIndex+1).ToString():LastPageIndex.ToString());
            return _nextPageUrl;
        }




        /// <summary>
        /// 更新Url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paramName"></param>
        /// <param name="paramVal"></param>
        /// <returns></returns>
        public string UpdateUrl(string url, string paramName, string paramVal)
        {
            string patternStr = "(?<=[\\?&]{1})" + paramName + "=[^&]{0,}";
            Regex regex = new Regex(patternStr, RegexOptions.IgnoreCase);

            string oldParamValueStr = regex.Match(url).Value;
            string newParamValueStr = string.Format("{0}={1}", paramName, paramVal);
            if (oldParamValueStr.Trim() != string.Empty)
            {
                url = url.Replace(oldParamValueStr, newParamValueStr);
            }
            else
            {
                url = string.Format("{0}{1}{2}", url, url.Contains("?") ? "&" : "?", newParamValueStr);
            }

            return url;
        }

        private bool HasParamName(string url, string paramName)
        {
            url = url.ToLower();
            paramName = paramName.ToLower();
            string str1 = "?{0}=";
            string str2="&{0}=";
            return url.Contains(string.Format(str1, paramName)) || url.Contains(string.Format(str2, paramName));
        }


        protected override void OnLoad(EventArgs e)
        {
            
            //base.OnLoad(e);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {

            writer.AddAttribute(HtmlTextWriterAttribute.Id, "PageControlDiv");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Id, "PageControlUl");
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            writer.Write(FirstPageHtml());
            writer.Write(PrevPageHtml());
            writer.Write(GetNumericsButtonHtml());
            writer.Write(NextPageHtml());
            writer.Write(LastPageHtml());
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Id, "PageControlGoToUl");
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            writer.Write(GetGoToHtml());
            writer.RenderEndTag();
            writer.RenderEndTag();

           

            //base.RenderContents(writer);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Page.ClientScript.RegisterClientScriptResource(this.GetType(), "AppWebUI.WebControls.JS.DataPage.js");

            if (Page.Header.FindControl("DataPageCSS") == null)//防止同一页面多个该自定义控件向宿主页面添加相同的<link>标记
            {
                HtmlLink css = new HtmlLink();
                css.ID = "DataPageCSS";
                css.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), "AppWebUI.WebControls.Css.css.css");
                css.Attributes.Add("rel", "stylesheet");
                css.Attributes.Add("type", "text/css");

                Page.Header.Controls.Add(css);
            }//<link type="text/css" rel="stylesheet" href="......css"/>
             
         }

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();
        //}

        // void ICompositeControlDesignerAccessor.RecreateChildControls()
        //{ 
          
        //}


        private bool HasParam(string par)
        {
            return HttpContext.Current.Request.QueryString[par] != null;
        }

        private string ReqStr(string par)
        {
            if (HttpContext.Current.Request.QueryString[par] != null)
            {
                return HttpContext.Current.Request.QueryString[par].ToString();
            }
            else {
                return string.Empty;
            }
        }

        private int ReqInt(string par)
        {
            string v = ReqStr(par);
            int num;
            if (int.TryParse(v, out num))
            {
                return num;
            }
            else {
                return 0;
            }

        }

        private string CurrentUrl {
            get {
                return HttpContext.Current.Request.Url.AbsoluteUri;
            }
        }

    }


}
