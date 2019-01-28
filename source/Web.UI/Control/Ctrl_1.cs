using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Web.UI.Control
{
    public class Ctrl_1 : System.Web.UI.Control
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.WriteLine("你好");
            //base.Render(writer);
        }
    }
}
