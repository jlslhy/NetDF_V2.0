<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WEB.Test.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link rel="stylesheet" type="text/css" href="/UIFramkwork/jquery_easyui_1_3_2/themes/default/easyui.css" />   
<link rel="stylesheet" type="text/css" href="/UIFramkwork/jquery_easyui_1_3_2/themes/icon.css" />   
<link href="/Styles/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/UIFramkwork/jquery_easyui_1_3_2/jquery-1.8.0.min.js"></script>   
<script type="text/javascript" src="/UIFramkwork/jquery_easyui_1_3_2/jquery.easyui.min.js"></script> 
<script src="/Scripts/JQPrototype.js" type="text/javascript"></script>
 


<script type="text/javascript">
    function OpenWindow(Url) {
        alert(Url);
        var relValue = window.showModalDialog("/Upload/index.html");
        alert(relValue);
    }
    
</script>  
 <script type="text/javascript">
      
</script>
    <script type="text/javascript">
        function f() {
            window.open('/Upload/index.html?RtnHtmlObj=aaab&RtnValueObj=aaac');
        }
	</script>
<head runat="server">
    <title></title>
</head>
<body  >
     <div id="aaab">123456</div>
     <input id="aaac" type="text" value="11111" />
	<input type="button" value="打开" onclick="f()">
    <div>
    <div id="win" class="easyui-window" title="Modal Window" data-options="modal:true,closed:true,iconCls:'icon-save'" style="width:500px;height:200px;padding:10px;">
		The window content.
	</div>

    <input class="easyui-combotree" data-options="url:'tree_data1.json',required:true" style="width:200px;">
    </div>
    <div id="div2">

    </div>

    <button onclick="ShowIframe('上传','/Upload/index.html',800,450)">dsdf</button>
     
</body>
        <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/webuploader.js" type="text/javascript"></script>
    <script src="Scripts/upload.js" type="text/javascript"></script>
</html>
