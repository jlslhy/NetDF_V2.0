using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEB.Module.LoginManage
{
    [Serializable]
    public class UserBaseInfo
    {
        
        public int UserID
        {
            set;
            get;
        }
        public string LoginID
        {
            set;
            get;
        }
        public string RealName
        {
            set;
            get;
        }

        public int DepartmentID
        {
            set;
            get;
        }



        public string SystemRoleIDStr
        {
            set;
            get;
        }   


         


    }
}
