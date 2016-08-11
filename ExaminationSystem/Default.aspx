<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExaminationSystem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>在线考试系统---登录</title>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            alert("Hello,World!");
        });
        /*
            window.onload=function(){
                //alert("Hello World");
                var txt = document.getElementsByName("txtPassword");
            
                alert(txt.attributes["value"]);
            };

            function txtUserName_mouseover()
            {
                var txt = document.getElementsByName("txtUserName");
                alert(txt.valueOf);
            }
            */
    </script>

    <link href="CSS/loginsheet.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="login_div">
            <div class="login_div_label">
                <div class="login_div_title">
                    <span>班级：</span>
                </div>
                <div class="login_div_content">
                    <asp:DropDownList runat="server" CssClass="login_div_droplist" ID="ddlClass">
                        <asp:ListItem Value="aaaaaa"></asp:ListItem>
                        <asp:ListItem Value="bbbbbb"></asp:ListItem>
                        <asp:ListItem Value="cccccc"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="login_div_error">
                    bbbbbbb
                </div>
            </div>
            <div class="login_div_label">
                <div class="login_div_title">
                    <span>学号：</span>
                </div>
                <div class="login_div_content">
                    <asp:TextBox runat="server" CssClass="login_div_text" ID="txtNo">请输入学号！</asp:TextBox>
                </div>
                <div class="login_div_error">
                    bbbbbbb
                </div>
            </div>
            <div class="login_div_label">
                <div class="login_div_title">
                    <span>姓名：</span>
                </div>
                <div class="login_div_content">
                    <asp:TextBox runat="server" CssClass="login_div_text" ID="txtUserName">请输入姓名！</asp:TextBox>
                </div>
                <div class="login_div_error">
                    bbbbbbb
                </div>
            </div>
            <div class="login_div_label">
                <div class="login_div_title">
                    <span>密码：</span>
                </div>
                <div class="login_div_content">
                    <asp:TextBox runat="server" CssClass="login_div_text" name="txtPassword" ID="txtPassword" ClientIDMode="Static" TextMode="Password">请输入密码！</asp:TextBox>
                </div>
                
                <div class="login_div_error">
                    bbbbbbb
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>