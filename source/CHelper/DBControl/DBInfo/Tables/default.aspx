<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CH.DBControl.DBInfo.Tables._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="/Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="/Js/ZeroClipboard/ZeroClipboard.js" type="text/javascript"></script>
    <title></title>
    <script>
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "https://hm.baidu.com/hm.js?32df3afd017cbd4fd714b16081481acc";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
     </script>
</head>
<body>
      <form id="form1" runat="server">
    <div>
        <div class="PageTitle" > DBInfo代码生成 </div>
        <table  style="width:100%;">
          <tr>
            <td style="width:150px;">目录：</td><td> <asp:TextBox ID="FolderTB" runat="server"></asp:TextBox>  </td>
          </tr>
          <tr>
            <td>表名：</td><td> <asp:DropDownList ID="TableDDL" runat="server"></asp:DropDownList> </td>
          </tr>
          <tr>
            <td>是否公用表：</td><td>  <asp:CheckBox ID="IsPublicTableCB" runat="server" />   </td>
          </tr>
           <tr>
            <td>文件名：</td><td> <asp:TextBox ID="FileNameTB" runat="server"  Columns="60" ></asp:TextBox>    </td>
          </tr>
          <tr>
            <td colspan="2"> 
            
            <asp:Button ID="MakeCodeBtn" runat="server" Text="生成代码" 
                    onclick="MakeCodeBtn_Click" /> &nbsp;
                    <asp:Button ID="MakeCodeToFileBtn" runat="server" Text="生成代码并写入文件" onclick="MakeCodeToFileBtn_Click" 
                      /> &nbsp;
                    <asp:Button ID="DeleteFileBtn" runat="server" Text="删除文件" 
                    onclick="DeleteFileBtn_Click"      />

                     </td>
          </tr>
          <tr>
            <td>代码：
             <button id="d_clip_button" class="my_clip_button" data-clipboard-target="CodeTB"><b>复制到剪贴板</b></button>
            </td>
            <td>
                <asp:TextBox ID="CodeTB" runat="server" TextMode="MultiLine" Rows="20"     Width="100%"  ></asp:TextBox>
            </td>
          </tr>
          <tr>
              <td colspan="2" style="height:180px; ">
                  <iframe id="iframeMsg" runat="server" width="100%" height="100%" frameborder="0"></iframe>
              </td>
          </tr>
        </table>
    </div>
     
    </form>

    <script type="text/javascript">
        // 定义一个新的复制对象
        var clip = new ZeroClipboard(document.getElementById("d_clip_button"), {
            moviePath: "/js/ZeroClipboard/ZeroClipboard.swf"
        });

        // 复制内容到剪贴板成功后的操作
        clip.on('complete', function (client, args) {
            alert("复制成功");
        });

</script>
</body>
</html>
