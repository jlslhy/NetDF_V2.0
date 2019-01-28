<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB.Manage.Layout.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        function myBrowser() {
            var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串
            //alert(userAgent);
            var isOpera = userAgent.indexOf("Opera") > -1;
            if (isOpera) {
                return "Opera"
            }; //判断是否Opera浏览器
            if (userAgent.indexOf("Firefox") > -1) {
                return "FF";
            } //判断是否Firefox浏览器
            if (userAgent.indexOf("Chrome") > -1) {
                return "Chrome";
            }
            if (userAgent.indexOf("Safari") > -1) {
                return "Safari";
            } //判断是否Safari浏览器
            if (userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1 && !isOpera) {
                return "IE";
            }; //判断是否IE浏览器
        }

        function IsBrowserOK() {
            var mb = myBrowser();
            if (mb != "FF" && mb != "Chrome") {
                alert("请用火狐或者谷歌浏览器打开。如果还没安装，请在本页下面下载。");
                return false;
            } else {
                 
                return true;
            }
        }

        

        IsBrowserOK();

        //以下是调用上面的函数
        //var mb = myBrowser();
        //if (mb != "FF" && mb != "Chrome") {
        //    alert("请用火狐或者谷歌浏览器打开。如果还没安装，请在本页下面下载。");
        //}

         
    </script>

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
<body style=" background-color:#1AA2CC;" >
    <form id="form1" runat="server">
        <div style="width: 500px; height: 300px; background-color: #2EABD7; margin: auto; margin-top: 150px; border: 3px solid #9BE8FF;">
            <table align="center" cellpadding="10" style="margin-top: 70px; color: White;">
                <tr>
                    <td>用户名：</td>
                    <td>
                        <asp:TextBox ID="UserIDTB" runat="server">admin</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>密码：</td>
                    <td>
                        <asp:TextBox ID="PassTB" runat="server" TextMode="Password" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:ImageButton ID="OKIBtn" runat="server"    ImageUrl="~/Manage/Images/login.jpg" OnClick="OKIBtn_Click" OnClientClick="return IsBrowserOK();" />
                        
                    </td>
                </tr>
                
            </table>
        </div>
        <div style="text-align:center; color:white; margin-top:26px; padding:10px; background-color:#9BE8FF;">
            <a href="https://www.baidu.com/s?ie=utf-8&f=3&rsv_bp=1&rsv_idx=1&tn=monline_3_dg&wd=%E7%81%AB%E7%8B%90%E6%B5%8F%E8%A7%88%E5%99%A8%E5%AE%98%E6%96%B9%E4%B8%8B%E8%BD%BD&oq=js%2520%25E6%25A3%2580%25E6%25B5%258B%25E6%25B5%258F%25E8%25A7%2588%25E5%2599%25A8%25E7%2589%2588%25E6%259C%25AC&rsv_pq=8d20b36e0009f5e8&rsv_t=2c6dT5%2FmWmDFIZc5ROdNfpwDcvyKs%2BKfE3%2B7WSzfLkmGZ7NprZFDt1RgNR1%2F2DOeGxz5&rqlang=cn&rsv_enter=0&rsv_sug3=41&rsv_sug1=36&rsv_sug7=100&rsv_sug2=1&prefixsug=%25E7%2581%25AB%25E7%258B%2590&rsp=1&inputT=4336&rsv_sug4=7317" target="_blank">火狐浏览器下载</a>
            <a href="https://www.baidu.com/s?ie=utf-8&f=8&rsv_bp=1&rsv_idx=1&tn=monline_3_dg&wd=%E8%B0%B7%E6%AD%8C%E6%B5%8F%E8%A7%88%E5%99%A8%E5%AE%98%E6%96%B9%E4%B8%8B%E8%BD%BD&oq=%25E8%25B0%25B7%25E6%25AD%258C%25E6%25B5%258F%25E8%25A7%2588%25E5%2599%25A8%25E5%25AE%2598%25E6%2596%25B9%25E4%25B8%258B%25E8%25BD%25BD&rsv_pq=8f52d555000937e5&rsv_t=1eae5pj%2FwiXNlOhZ2z2RuAbmDgZAx8OcCFMwiopqfDwS2npcdzY456IjjkH33FlLkTAp&rqlang=cn&rsv_enter=0&rsv_sug3=52&rsv_sug1=43&rsv_sug7=100&rsv_sug4=921" target="_blank">谷歌浏览器下载</a>
        </div>
        <div style="text-align:center; color:white; margin-top:26px; padding:10px;">
            <a href="http://www.ruanyi.online/" target="_blank" style="color:white;text-decoration: none;">开发框架技术支持：软艺软件</a>
        </div>
    </form>
    
    

</body>
</html>


