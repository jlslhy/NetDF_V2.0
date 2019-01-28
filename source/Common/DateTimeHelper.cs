using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class DateTimeHelper
    {
        /// <summary>
        /// 获取时间差
        /// </summary>
        /// <param name="StartDT"></param>
        /// <param name="EndDT"></param>
        /// <returns></returns>
        public static string GetDatediffddHHmmssStr(DateTime StartDT, DateTime EndDT)
        {
            TimeSpan ts = EndDT - StartDT;
            return ts.Days + "天" + ts.Hours + "时" + ts.Minutes + "分" + ts.Seconds + "秒";

        }
    }
}
