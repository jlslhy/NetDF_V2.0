using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEB.DataAccessBase
{
    public class AjaxBasePageForJson : AjaxBasePage
    {
        public AjaxBasePageForJson()
        {
            this.Load += new EventHandler(AjaxBasePageForJson_Load);
        }

        void AjaxBasePageForJson_Load(object sender, EventArgs e)
        {


            if (!CurrentUser.IsOnline())
            {
                string jsonStr = "{\"Result\":\"Error\",\"Message\":\"登录已超时，请登录.\"}";
                WriteAndEnd(jsonStr);
            }

            //throw new NotImplementedException();
        }
    }
}
