﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Test.JSON
{
    /// <summary>
    /// ComboBox 的摘要说明
    /// </summary>
    public class ComboBox : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(@"[{
	""id"":1,
	""text"":""Java"",
	""desc"":""Write once, run anywhere""
},{
	""id"":2,
	""text"":""C#"",
	""desc"":""One of the programming languages designed for the Common Language Infrastructure""
},{
	""id"":3,
	""text"":""Ruby"",
	""selected"":true,
	""desc"":""A dynamic, reflective, general-purpose object-oriented programming language""
},{
	""id"":4,
	""text"":""Perl"",
	""desc"":""A high-level, general-purpose, interpreted, dynamic programming language""
},{
	""id"":5,
	""text"":""Basic"",
	""desc"":""A family of general-purpose, high-level programming languages""
}]");


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}