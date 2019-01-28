using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common
{
    public class UrlHelper
    {

        public static string ReqStr(string par)
        {
            if (System.Web.HttpContext.Current.Request[par] == null)
            {
                return string.Empty;

            }
            else
            {
                return   System.Web.HttpContext.Current.Request[par].ToString() ;
            }
        }
        public static string ReqStr(string par, string defaultStr)
        {
            string v = ReqStr(par);
            return v.Trim().Equals(string.Empty) ? defaultStr : v;
        }
        public static int ReqInt(string par)
        {
            int rev = 0;
            if (System.Web.HttpContext.Current.Request[par] != null)
            {
                try
                {
                    if (!Int32.TryParse(ReqStr(par), out rev))
                    {
                         
                        rev = 0;
                    }
                }
                catch { }
            }


            return rev;
        }


        public static int ReqInt(string par, int defaultVal)
        {
            int v = ReqInt(par);
            return v == 0 ? defaultVal : v;
        }
        public static long ReqLong(string par)
        {
            long rev = 0L;
            if (System.Web.HttpContext.Current.Request[par] != null)
            {

                try
                {
                    if (!long.TryParse(ReqStr(par), out rev))
                    {

                        rev = 0L;
                    }
                }
                catch { }
            }
            return rev;
        }
        public static long ReqLong(string par, long defaultVal)
        {
            long v = ReqLong(par);
            return v == 0 ? defaultVal : v;
        }

        public static bool ReqBoolean(string par)
        {
            bool rev = false;
            if (System.Web.HttpContext.Current.Request[par] != null)
            {
                try
                {
                    bool.TryParse(System.Web.HttpContext.Current.Request[par], out rev);
                    
                }
                catch { }
            }
            return rev;
        }




        public static string ReqStrByGetOrPost(HttpContext context,string par)
        {
            
            if (null == context.Request.Form[par] && null == context.Request.QueryString[par])
            {
                return string.Empty;
            }
            else if (null != context.Request.Form[par])
            {
                return context.Request.Form[par].ToString();
            }
            else
            {
                return context.Request.QueryString[par].ToString();

            }
            
        }
        public static string ReqStrByGetOrPost(HttpContext context, string par, string defaultValue)
        {
            if (!HasParam(context, par))
            {
                return defaultValue;
            }
            return ReqStrByGetOrPost(context, par);
        }


        


        public static string ReqStrByGetOrPost(string par)
        {
            return ReqStrByGetOrPost(HttpContext.Current, par);
        }
        public static string ReqStrByGetOrPost(string par,string defaultValue)
        {
            if (!HasParam(HttpContext.Current,par)) {
                return defaultValue;
            }
            return ReqStrByGetOrPost(HttpContext.Current, par);
        }








        public static int ReqIntByGetOrPost(HttpContext context, string par) {
            string val = ReqStrByGetOrPost(context,par).Trim();
            int result;
            if (int.TryParse(val, out result))
            {
                return result;
            }
            else {
                return 0;
            }
 
        }
        public static int ReqIntByGetOrPost(HttpContext context, string par,int defaultValue) {
            if (!HasParam(context, par))
            {
                return defaultValue;
            }
             
            return ReqIntByGetOrPost(context,par);
        }

        

        public static int ReqIntByGetOrPost(string par) {
            return ReqIntByGetOrPost(HttpContext.Current,par);
        }
        public static int ReqIntByGetOrPost(string par, int defaultValue)
        {
            if (!HasParam(HttpContext.Current, par))
            {
                return defaultValue;
            }
            return ReqIntByGetOrPost(HttpContext.Current, par);
        }




        public static long ReqLongByGetOrPost(HttpContext context, string par)
        {
            string val = ReqStrByGetOrPost(context, par).Trim();
            long result;
            if (long.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }

        }
        public static long ReqLongByGetOrPost(HttpContext context, string par,long defaultValue)
        {
            if (!HasParam(context, par))
            {
                return defaultValue;
            }
            return ReqLongByGetOrPost(context,par);
        }


        public static long ReqLongByGetOrPost( string par)
        {
            return ReqLongByGetOrPost(HttpContext.Current,par);
        }
        public static long ReqLongByGetOrPost(string par,long defaultValue)
        {
            if (!HasParam(HttpContext.Current, par))
            {
                return defaultValue;
            }
            return ReqLongByGetOrPost(HttpContext.Current,par);
        }




        public static decimal ReqDecimalByGetOrPost(HttpContext context, string par)
        {
            string val = ReqStrByGetOrPost(context, par).Trim();
            decimal result;
            if (decimal.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }

        }
        public static decimal ReqDecimalByGetOrPost(HttpContext context, string par,decimal defaultValue)
        {
            if (!HasParam(context, par))
            {
                return defaultValue;
            }
            return ReqDecimalByGetOrPost(context,par);
        }


        public static decimal ReqDecimalByGetOrPost(string par)
        {
            return ReqDecimalByGetOrPost(HttpContext.Current,par);
        }
        public static decimal ReqDecimalByGetOrPost(string par,decimal defaultValue)
        {
            if (!HasParam(HttpContext.Current, par))
            {
                return defaultValue;
            }
            return ReqDecimalByGetOrPost(HttpContext.Current,par);
        }





        public static double ReqDoubleByGetOrPost(HttpContext context, string par)
        {
            string val = ReqStrByGetOrPost(context, par).Trim();
            double result;
            if (double.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }

        }
        public static double ReqDoubleByGetOrPost(HttpContext context, string par,double defaultValue)
        {
            if (!HasParam(context, par))
            {
                return defaultValue;
            }
            return ReqDoubleByGetOrPost(context,par);
        }

        public static double ReqDoubleByGetOrPost( string par)
        {
            return ReqDoubleByGetOrPost(HttpContext.Current,par);
        }
        public static double ReqDoubleByGetOrPost(string par, double defaultValue)
        {
            if (!HasParam(HttpContext.Current, par))
            {
                return defaultValue;
            }
            return ReqDoubleByGetOrPost(HttpContext.Current,par);
        }




        public static float ReqFloatByGetOrPost(HttpContext context, string par)
        {
            string val = ReqStrByGetOrPost(context, par).Trim();
            float result;
            if (float.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }

        }
        public static float ReqFloatByGetOrPost(HttpContext context, string par, float defaultValue)
        {
            if (!HasParam(context, par))
            {
                return defaultValue;
            }
            return ReqFloatByGetOrPost(context, par);
        }

        public static float ReqFloatByGetOrPost(string par)
        {
            return ReqFloatByGetOrPost(HttpContext.Current, par);
        }
        public static float ReqFloatByGetOrPost(string par, float defaultValue)
        {
            if (!HasParam(HttpContext.Current, par))
            {
                return defaultValue;
            }
            return ReqFloatByGetOrPost(HttpContext.Current, par);
        }




        public static bool ReqBoolByGetOrPost(HttpContext context, string par)
        {
            string val = ReqStrByGetOrPost(context, par).Trim();
            bool result;
            if (bool.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return false;
            }

        }

        public static bool ReqBoolByGetOrPost(HttpContext context, string par,bool defaultValue)
        {
            if (!HasParam(context, par))
            {
                return defaultValue;
            }
            return ReqBoolByGetOrPost(context,par);
        }



        public static bool ReqBoolByGetOrPost(string par)
        {
            return ReqBoolByGetOrPost(HttpContext.Current,par);
        }
        public static bool ReqBoolByGetOrPost(string par,bool defaultValue)
        {
            if (!HasParam(HttpContext.Current, par))
            {
                return defaultValue; 
            }
            return ReqBoolByGetOrPost(HttpContext.Current,par);
        }










        public static DateTime? ReqDateTimeByGetOrPost(HttpContext context, string par)
        {
            string val = ReqStrByGetOrPost(context, par).Trim();
            DateTime result;
            if (DateTime.TryParse(val, out result))
            {
                return result;
            }
            else
            {
                return null;
            }

        }
        public static DateTime? ReqDateTimeByGetOrPost(HttpContext context, string par, DateTime? defaultValue)
        {
            if (!HasParam(context, par))
            {
                return defaultValue;
            }
            return ReqDateTimeByGetOrPost(context, par);
        }
        public static DateTime? ReqDateTimeByGetOrPost(string par)
        {
            return ReqDateTimeByGetOrPost(HttpContext.Current, par);
        }
        public static DateTime? ReqDateTimeByGetOrPost(string par, DateTime? defaultValue)
        {
            if (!HasParam(HttpContext.Current, par))
            {
                return defaultValue;
            }
            return ReqDateTimeByGetOrPost(HttpContext.Current, par);
        }






        public static Dictionary<string, string> GetParamValueDic(HttpContext httpContext, string ParamLeftFix, bool isUrlDecode)
        {
            Dictionary<string, string> paramValueDic = new Dictionary<string, string>();
            System.Collections.Specialized.NameValueCollection paramVals = httpContext.Request.Params;
            foreach (string key in paramVals.AllKeys)
            {
                if (key.StartsWith(ParamLeftFix))
                {
                    paramValueDic.Add(key, isUrlDecode ? httpContext.Server.UrlDecode(paramVals.Get(key)) : paramVals.Get(key));
                }
            }

            return paramValueDic;
        }

        public static bool HasParam(HttpContext httpContext,string par)
        {
            return httpContext.Request.QueryString[par] != null || httpContext.Request.Form[par] != null;
        }

    }
}
