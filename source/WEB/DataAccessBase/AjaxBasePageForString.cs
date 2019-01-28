using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEB.DataAccessBase
{
    public class AjaxBasePageForString : AjaxBasePage
    {
        public AjaxBasePageForString()
        {
            this.Load += new EventHandler(AjaxBasePageForString_Load);
        }

        void AjaxBasePageForString_Load(object sender, EventArgs e)
        {
            
            if (!CurrentUser.IsOnline())
            {
                Response.Write("False|登录已超时，请登录.");
                Response.End();
            }
            //throw new NotImplementedException();
        }
    }
}
