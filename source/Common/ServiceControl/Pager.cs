/*
 * 作者：LHY
 * Email:869067911@qq.com
 * 
 */

using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;

namespace Common.ServiceControl
{
    /// <summary>
    /// 分页控件
    /// </summary>
    public class Pager : Label, INamingContainer
    {
        #region 成员变量和构造函数
        HttpContext context = HttpContext.Current;
        Label countLabel;
        HyperLink previousButton;
        HyperLink nextButton;
        HyperLink firstButton;
        HyperLink lastButton;
        HyperLink[] pagingLinkButtons;


        public override ControlCollection Controls
        {
            get
            {
                EnsureChildControls();
                return base.Controls;

            }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();

            AddCountLabel();

            AddPageButtons();

            AddPreviousNextHyperLinks();

            AddFirstLastHyperLinks();
        }
        #endregion

        #region 呈现方法
        protected override void Render(HtmlTextWriter writer)
        {
            //            修改总页数小于等于1的时候不呈现任何控件
            //            int totalPages = CalculateTotalPages();
            //
            //            if (totalPages <= 1)
            //                return;

            AddAttributesToRender(writer);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass, false);

            RenderCountLabel(writer);

            RenderFirst(writer);

            RenderPrevious(writer);

            RenderPagingButtons(writer);

            RenderNext(writer);

            RenderLast(writer);
        }

        void RenderCountLabel(HtmlTextWriter writer)
        {
            countLabel.RenderControl(writer);

            LiteralControl l = new LiteralControl("&nbsp;");
            l.RenderControl(writer);
        }

        void RenderFirst(HtmlTextWriter writer)
        {
            firstButton.RenderControl(writer);

            LiteralControl l = new LiteralControl("&nbsp;");
            l.RenderControl(writer);
        }

        void RenderLast(HtmlTextWriter writer)
        {
            lastButton.RenderControl(writer);

            LiteralControl l = new LiteralControl("&nbsp;");
            l.RenderControl(writer);
        }

        void RenderPrevious(HtmlTextWriter writer)
        {
            previousButton.RenderControl(writer);

            LiteralControl l = new LiteralControl("&nbsp;");
            l.RenderControl(writer);
        }

        void RenderNext(HtmlTextWriter writer)
        {
            nextButton.RenderControl(writer);

            LiteralControl l = new LiteralControl("&nbsp;");
            l.RenderControl(writer);
        }

        private void RenderButtonRange(int start, int end, HtmlTextWriter writer)
        {
            for (int i = start; i < end; i++)
            {
                if (PageIndex == i)
                {
                    Literal l = new Literal();
                    l.Text = "<font color =red>" + (i + 1).ToString() + "</font>";

                    l.RenderControl(writer);
                }
                else
                {
                    pagingLinkButtons[i].RenderControl(writer);
                }
                if (i < (end - 1))
                    writer.Write("&nbsp;");
            }

            LiteralControl l1 = new LiteralControl("&nbsp;");
            l1.RenderControl(writer);
        }

        private void RenderPagingButtons(HtmlTextWriter writer)
        {
            int totalPages;

            totalPages = CalculateTotalPages();

            if (totalPages <= 10)
            {
                RenderButtonRange(0, totalPages, writer);
            }
            else
            {
                int lowerBound = (PageIndex - 4);
                int upperBount = (PageIndex + 6);

                if (lowerBound <= 0)
                    lowerBound = 0;

                if (PageIndex <= 4)
                    RenderButtonRange(0, 10, writer);

                else if (PageIndex < (totalPages - 5))
                    RenderButtonRange(lowerBound, (PageIndex + 6), writer);

                else if (PageIndex >= (totalPages - 5))
                    RenderButtonRange((totalPages - 10), totalPages, writer);
            }
        }

        #endregion

        #region 控件树方法
        /// <summary>
        /// 信息标签
        /// </summary>
        void AddCountLabel()
        {
            countLabel = new Label();
            countLabel.ID = "countLabel";
            countLabel.Text = string.Format(text, CalculateTotalPages().ToString("n0"));

            Controls.Add(countLabel);
        }

        private void AddPageButtons()
        {
            pagingLinkButtons = new HyperLink[CalculateTotalPages()];

            for (int i = 0; i < pagingLinkButtons.Length; i++)
            {
                pagingLinkButtons[i] = new HyperLink();
                pagingLinkButtons[i].EnableViewState = false;
                pagingLinkButtons[i].Text = (i + 1).ToString();
                pagingLinkButtons[i].ID = i.ToString();
                pagingLinkButtons[i].CssClass = linkCss;
                pagingLinkButtons[i].NavigateUrl = GetHrefString(i);

                Controls.Add(pagingLinkButtons[i]);
            }
        }



        /// <summary>
        /// 首页末页
        /// </summary>
        void AddFirstLastHyperLinks()
        {
            firstButton = new HyperLink();
            firstButton.ID = "First";
            firstButton.Text = "首页";
            if (PageIndex != 0 && CalculateTotalPages() > 0)
            {
                firstButton.NavigateUrl = GetHrefString(0);
            }
            else
            {
                firstButton.Enabled = false;
            }

            Controls.Add(firstButton);

            lastButton = new HyperLink();
            lastButton.ID = "Last";
            lastButton.Text = "末页";
            if (PageIndex != CalculateTotalPages() - 1)
            {
                lastButton.NavigateUrl = GetHrefString(CalculateTotalPages() - 1);
            }
            else
            {
                lastButton.Enabled = false;
            }
            Controls.Add(lastButton);
        }

        /// <summary>
        /// 上一页下一页
        /// </summary>
        void AddPreviousNextHyperLinks()
        {
            previousButton = new HyperLink();
            previousButton.ID = "Prev";
            previousButton.Text = "上一页";
            if (HasPrevious)
            {
                previousButton.NavigateUrl = GetHrefString(PageIndex - 1);
            }
            else
            {
                previousButton.Enabled = false;
            }
            Controls.Add(previousButton);

            nextButton = new HyperLink();
            nextButton.ID = "Next";
            nextButton.Text = "下一页";
            if (HasNext)
            {
                nextButton.NavigateUrl = GetHrefString(PageIndex + 1);
            }
            else
            {
                nextButton.Enabled = false;
            }
            Controls.Add(nextButton);
        }
        #endregion

        #region 私有属性
        private bool HasPrevious
        {
            get
            {
                if (PageIndex > 0)
                    return true;

                return false;
            }
        }

        private bool HasNext
        {
            get
            {
                if (PageIndex + 1 < CalculateTotalPages())
                    return true;

                return false;
            }
        }
        #endregion

        #region 帮助方法和公共属性

        /// <summary>
        /// 获取分页导航按钮的超链接字符串
        /// </summary>
        /// <param name="pageIndex">该分页按钮相对应的页索引</param>
        /// <returns>分页导航按钮的超链接字符串</returns>
        private string GetHrefString(int pageIndex)
        {
            string url = Page.Request.RawUrl;
            //string url = Page.Request.Url.AbsolutePath;
            url = AddParam(url, "pageindex=" + pageIndex.ToString());

            return Page.Server.UrlPathEncode(url);
        }

        public int CalculateTotalPages()
        {
            int totalPagesAvailable;

            if (TotalRecords == 0)
                return 0;

            totalPagesAvailable = TotalRecords / PageSize;

            if ((TotalRecords % PageSize) > 0)
                totalPagesAvailable++;

            return totalPagesAvailable;
        }


        private int _PageIndex = 1;

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get
            {

                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
            }
        }



        private int _PageSize = 10;
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize
        {
            get
            {

                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }

        }


        private int _TotalRecords = 0;

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecords
        {
            get
            {
                return _TotalRecords;
            }
            set
            {
                _TotalRecords = value;
            }
        }

        private string text = "共{0}页";

        private string linkCss = "";
        /// <summary>
        /// 链接样式
        /// </summary>
        public string LinkCss
        {
            get { return linkCss; }
            set { linkCss = value; }
        }

        private string textCss = "";
        /// <summary>
        /// 文字样式
        /// </summary>
        public string TextCss
        {
            get { return textCss; }
            set { textCss = value; }
        }

        public string TextFormat
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        #endregion


        /// <summary>
        /// 向url添加参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string AddParam(string url, string param)
        {
            string newurl = url;



            if (newurl.IndexOf("?") >= 0)
            {
                string fileurl = newurl.Substring(0, newurl.IndexOf("?"));
                string querystr = newurl.Substring(newurl.IndexOf("?") + 1);
                string tmepQueryStr = "";

                string[] paramArr = querystr.Split('&');
                bool hasparam = false;
                for (int i = 0; i < paramArr.Length; i++)
                {
                    string par = paramArr[i];
                    if (par.Substring(0, par.IndexOf("=")).Equals(param.Substring(0, param.IndexOf("="))))
                    {
                        hasparam = true;
                        paramArr[i] = param;
                    }
                    if (i > 0)
                    {
                        tmepQueryStr += "&";
                    }
                    tmepQueryStr += paramArr[i];


                }


                if (!hasparam)
                {
                    tmepQueryStr += "&" + param;
                }

                newurl = fileurl + "?" + tmepQueryStr;

            }
            else
            {
                newurl = url + "?" + param;
            }

            return newurl;
        }


        /// <summary>
        /// 向url添加多个参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param_s"></param>
        /// <returns></returns>
        public string AddParams(string url, string param_s)
        {
            string newurl = url;
            string[] paramArr = param_s.Split('&');
            for (int i = 0; i < paramArr.Length; i++)
            {
                newurl = AddParam(newurl, paramArr[i]);
            }
            return newurl;
        }



    }
}
