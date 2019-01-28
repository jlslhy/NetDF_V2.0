using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetServ.Net.Json;
using System.IO;
 

namespace WEB.Test.JSON
{
    public partial class GridData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["R"] != null)
                {
                    switch(Request.QueryString["R"])
                    {
                        case "userdata":
                          GetUsersData();
                          break;
                        case "getdata2":
                          Response.Write(GetData2());
                          break;
                        case "getdata3":
                          Response.Write(GetData3());
                          break;
                        case "GetTreeData1":
                          Response.Write(GetTreeData1());
                          break;
                        case "GetTreeData2":
                          Response.Write(GetTreeData2());
                          break;
                    }
                }
            }

        }





        //////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        private void GetUsersData() {
            JsonArray Rows = new JsonArray();
            Rows.Add(userInfo("001","张三","湛江"));
            Rows.Add(userInfo("002","李四","广州"));

            JsonWriter jwriter = new JsonWriter();
            Rows.Write(jwriter);
            Response.Write(jwriter.ToString());

        }

        private JsonObject userInfo(string code, string name,string address)
        {
            JsonObject jObj = new JsonObject();
            jObj.Add("Code",code);
            jObj.Add("Name",name);
            jObj.Add("Address",address);
            return jObj;
        
        }


        /////////////////////////////////////////////////////////////////////////


        private string GetData2()
        {
            return @"{""total"":4,""rows"":[    
    {""name"":""Name"",""value"":""Bill Smith"",""group"":""ID Settings"",""editor"":""text""},    
    {""name"":""Address"",""value"":"""",""group"":""ID Settings"",""editor"":""text""},    
    {""name"":""SSN"",""value"":""123-456-7890"",""group"":""ID Settings"",""editor"":""text""},    
    {""name"":""Email"",""value"":""bill@gmail.com"",""group"":""Marketing Settings"",""editor"":{    
        ""type"":""validatebox"",    
        ""options"":{    
            ""validType"":""email""   
        }    
    }}    
]} ";
        }


        private string GetData3()
        {
            string str = "";
            //str = Tool.FileHelper.ReaderContentByTXTFile(MapPath("data3.txt"));
            str = Common.FileHelper.ReaderContentByTXTFile(MapPath("data3.txt"));
            return str;
        }

        private string GetTreeData1()

        {
            string str = "";
            //str = Tool.FileHelper.ReaderContentByTXTFile(MapPath("treedata1.txt"));
            str = Common.FileHelper.ReaderContentByTXTFile(MapPath("treedata1.txt"));
            return str; 
        }


        private string GetTreeData2()
        { 
            string str = @"[{
        ""id"": ""1"",
        ""text"": ""Languages"",
        ""children"": [{
            ""id"": ""11"",
            ""text"": ""Java""
        }, {
            ""id"": ""12"",
            ""text"": ""C++""
        }]
    }]";


            return str; 


        }


    }
}