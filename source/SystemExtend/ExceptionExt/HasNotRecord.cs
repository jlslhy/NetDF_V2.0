using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemExtend.ExceptionExt
{
    public class HasNotRecordException : Exception
    {
        public HasNotRecordException(string pKeyValue)
            : base(string.Format("不存在主键值为\"{0}\"的数据记录！", pKeyValue))
        {
           
        }
    }
}
