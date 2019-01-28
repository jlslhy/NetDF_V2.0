using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEB.Module.LoginManage;

namespace WEB.DataAccessBase
{
    public class AjaxBasePage:UserBasePage
    {
         

        /// <summary>
        /// 字符串输出并且调用 Response.End();
        /// </summary>
        /// <param name="outStr"></param>
        protected void WriteAndEnd(string outStr)
        {
            Response.Write(outStr);
            Response.End();
        }
    }
}
