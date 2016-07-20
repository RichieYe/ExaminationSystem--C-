<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default .aspx.cs" Inherits="ExaminationSystem.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>在线考试系统---登录</title>

    <script type="text/javascript">
        window.onload=function(){
            alert("Hello World");
        };

        function txtUserName_mouseover()
        {
            var txt = document.getElementsByName("txtUserName");
            alert(txt.valueOf);
        }
    </script>

    <link href="CSS/mainSheet.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="login">
            用户名：<input type="text" name="txtUserName" value="请输入用户名！" onmouseover="" />
            <hr />
            密 码：<input type="password" name="txtUserPassword" />
            <hr />
            <input type="radio" name="rdUserType" value="student" />学生
            <input type="radio" name="rdUserType" value="teacher" />教师
        </div>
    </div>
    </form>
</body>
</html>
