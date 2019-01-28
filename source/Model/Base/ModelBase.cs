using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model.Base
{
    public abstract class ModelBase
    {
        public  string TableName = string.Empty;
        public  string PKey = string.Empty;
        public virtual object PKeyValue { get; set; }
        public Type PKeyDataType;
        public abstract string AddSQL { get; }
        public abstract string UpdateSQL { get; }
        public abstract SqlParameter[] ParamsForUpdate { get; }
        public abstract SqlParameter[] ParamsForAdd { get; }
    }
}
