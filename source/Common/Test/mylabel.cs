using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;

namespace Common.Test
{
    public class TestControls:Label,INamingContainer
    {
        Label Label1;
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
            base.CreateChildControls();
        }


    }
}