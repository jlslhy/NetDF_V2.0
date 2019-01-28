using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace App.Web.UI.Control
{
    public class Albumn : System.Web.UI.Control
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign,"center");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width,"194px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height,"130px");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.WriteLine("ddwwdd");
            writer.RenderEndTag();


            //base.Render(writer);
        }
    }
}
