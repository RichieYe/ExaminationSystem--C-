<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExaminationSystem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>在线考试系统</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 134px;
        }
        .auto-style4 {
            width: 322px;
        }
        .auto-style5 {
            width: 202px;
        }
        .auto-style6 {
            width: 363px;
        }
        .auto-style7 {
            color: rgb(255, 0, 0);
            text-decoration: line-through;
        }
        .auto-style8 {
            width: 202px;
            color: rgb(255, 0, 0);
            text-decoration: line-through;
        }
        .auto-style9 {
            width: 322px;
            color: rgb(255, 0, 0);
            text-decoration: line-through;
        }
        .auto-style10 {
            width: 154px;
        }
        .auto-style11 {
            width: 363px;
            color: rgb(255, 0, 0);
            text-decoration: line-through;
        }
        .auto-style12 {
            width: 363px;
            text-decoration: line-through;
        }
        .auto-style13 {
            text-decoration: line-through;
        }
        .auto-style14 {
            width: 202px;
            text-decoration: line-through;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="text-align: center">在线考试系统</h1>
        <hr />
        <br />
        <div><b>服务器地址：http://192.168.1.155:8081    命名空间："http://www.ExaminationSystem.com/</b></div>
        <br />
        <table class="auto-style1" align="center" border="2px">
            <tr>
                <td class="auto-style3" style="text-align: center">表名</td>
                <td style="text-align: center" class="auto-style4">WebService接口名</td>
                <td style="text-align: center" class="auto-style5">说明</td>
                <td style="text-align: center">返回值</td>
            </tr>
            <tr>
                <td class="auto-style3" rowspan="6">班级(tb_Classes)<br />
                    <br />
                    <br />
                    WebService名称：<br />
                    Classes_Operator.asmx</td>
                <td class="auto-style9"><strong>Insert(String strClassName)</strong></td>
                <td class="auto-style8"><strong>向班级表中插入一条记录</strong></td>
                <td><span class="auto-style7"><strong>如果插入成功，则返回Json数据(</strong></span><span style="font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;" class="auto-style7"><strong>[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</strong></span><span class="auto-style7"><strong>);格式为：ID：3是新添加记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style9"><strong>DeleteForID(int id)</strong></td>
                <td class="auto-style8"><strong>向班级表中删除一条记录</strong></td>
                <td><span class="auto-style7"><strong>如果删除成功，则返回Json数据(</strong></span><span style="font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;" class="auto-style7"><strong>[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</strong></span><span class="auto-style7"><strong>);格式为：ID：3是删除记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style9"><strong>Update(int id,String strClassName)</strong></td>
                <td class="auto-style8"><strong>向班级表中更新一条记录</strong></td>
                <td><span class="auto-style7"><strong>如果更新成功，则返回Json数据(</strong></span><span style="font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;" class="auto-style7"><strong>[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</strong></span><span class="auto-style7"><strong>);格式为：ID：3是修改记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style4">GetAllClasses()</td>
                <td class="auto-style5">返回表中所有班级的名称</td>
                <td>如果成功，返回表中所有班级的Json数据；失败则返回空。</td>
            </tr>
            <tr>
                <td class="auto-style4">GetClassesForID(int id)</td>
                <td class="auto-style5">查询表中指定ID的班级名称</td>
                <td>如果成功，返回表中指定ID的班级Json数据；失败则返回空。</td>
            </tr>
            <tr>
                <td class="auto-style4">GetClassesForName(String strClassName)</td>
                <td class="auto-style5">查询表中指定班级名称的ID</td>
                <td>如果成功，返回表中指定班级名称的班级Json数据；失败则返回空。</td>
            </tr>
        </table>
        <br />
        <hr />
        <br />
         <table class="auto-style1" align="center" border="2px">
            <tr>
                <td class="auto-style3" style="text-align: center">表名</td>
                <td style="text-align: center" class="auto-style6">WebService接口名</td>
                <td style="text-align: center" class="auto-style5">说明</td>
                <td style="text-align: center">返回值</td>
            </tr>
            <tr>
                <td class="auto-style3" rowspan="7">学生(tb_Student)<br />
                    <br />
                    <br />
                    WebService名称：<br />
                    User_Operator.asmx</td>
                <td class="auto-style6">Insert(String UserName,String No,int CId,String Password,String Gender,String Phone,String Address)</td>
                <td class="auto-style5">向学生表中插入一条记录</td>
                <td>如果插入成功，则返回Json数据(<span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span>);格式为：ID：3是新添加记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</td>
            </tr>
            <tr>
                <td class="auto-style6">DeleteForID(int id)</td>
                <td class="auto-style5">向学生表中删除一条记录</td>
                <td>如果删除成功，则返回Json数据(<span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span>);格式为：ID：3是删除记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</td>
            </tr>
            <tr>
                <td class="auto-style6">Update(int id,String UserName,String No,int CId,String Password,String Gender,String Phone,String Address)</td>
                <td class="auto-style5">向学生表中更新一条记录</td>
                <td>如果更新成功，则返回Json数据(<span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span>);格式为：ID：3是修改记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</td>
            </tr>
            <tr>
                <td class="auto-style6">GetAllStudents()</td>
                <td class="auto-style5">返回表中所有学生的信息</td>
                <td>如果成功，返回表中所有学生信息的Json数据；失败则返回空。</td>
            </tr>
            <tr>
                <td class="auto-style6">GetStudentForID(int id)</td>
                <td class="auto-style5">查询表中指定ID的学生信息</td>
                <td>如果成功，返回表中指定ID的学生信息Json数据；失败则返回空。</td>
            </tr>
            <tr>
                <td class="auto-style6">GetStudentForName(String UserName)</td>
                <td class="auto-style5">查询表中指定学生姓名的信息</td>
                <td>如果成功，返回表中指定学生名称的学生信息Json数据；失败则返回空。</td>
            </tr>
            <tr>
                <td class="auto-style6">Login(string UserName,string No,int CId,string Password)</td>
                <td class="auto-style5">根据学生姓名，学号，班级及密码进行登录</td>
                <td>如果成功，返回一条JSon数据表示登录成功；失败则返回错误信息。格式如下：<span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span></td>
            </tr>
        </table>
         <br />
        <hr />
        <br />
         <table class="auto-style1" align="center" border="2px">
            <tr>
                <td class="auto-style10" style="text-align: center">表名</td>
                <td style="text-align: center" class="auto-style6">WebService接口名</td>
                <td style="text-align: center" class="auto-style5">说明</td>
                <td style="text-align: center">返回值</td>
            </tr>
            <tr>
                <td class="auto-style10" rowspan="7">考试(tb_Testing)<br />
                    <br />
                    <br />
                    WebService名称：<br />
                    Testing_Operator.asmx</td>
                <td class="auto-style6">Insert(string SID, string TestDate, string Flag, string StartTime, string EndTime)</td>
                <td class="auto-style5">向考试表中插入一条记录</td>
                <td>如果插入成功，则返回Json数据(<span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span>);格式为：ID：3是新添加记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</td>
            </tr>
            <tr>
                <td class="auto-style11"><strong>DeleteForID(int id)</strong></td>
                <td class="auto-style8"><strong>向考试表中删除一条记录</strong></td>
                <td><span class="auto-style7"><strong>如果删除成功，则返回Json数据(</strong></span><span style="font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;" class="auto-style7"><strong>[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</strong></span><span class="auto-style7"><strong>);格式为：ID：3是删除记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style6">Update(int ID, string SID, string TestDate, string Flag,string StartTime,string EndTime)</td>
                <td class="auto-style5">向考试表中更新一条记录</td>
                <td>如果更新成功，则返回Json数据(<span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span>);格式为：ID：3是修改记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</td>
            </tr>
            <tr>
                <td class="auto-style11"><strong>GetAllTest()</strong></td>
                <td class="auto-style8"><strong>返回表中所有考试的信息</strong></td>
                <td class="auto-style7"><strong>如果成功，返回表中所有学生信息的Json数据；失败则返回空。</strong></td>
            </tr>
            <tr>
                <td class="auto-style6">GetAllTestForSID(string SID)</td>
                <td class="auto-style5">查询表中指定学生ID的考试信息</td>
                <td>如果成功，返回表中指定学生ID的考试信息Json数据；失败则返回空。</td>
            </tr>
            <tr>
                <td class="auto-style6">GetTestForID(string ID)</td>
                <td class="auto-style5">查询表中指定ID的考试信息</td>
                <td>如果成功，返回表中指定ID的考试信息Json数据；失败则返回空。</td>
            </tr>           
        </table>
         <br />
        <hr />
        <br />
        <table class="auto-style1" align="center" border="2px">
            <tr>
                <td class="auto-style10" style="text-align: center">表名</td>
                <td style="text-align: center" class="auto-style6">WebService接口名</td>
                <td style="text-align: center" class="auto-style5">说明</td>
                <td style="text-align: center">返回值</td>
            </tr>
            <tr>
                <td class="auto-style10" rowspan="7">填空(tb_Completion)<br />
                    <br />
                    <br />
                    WebService名称：<br />
                    Completion_Operator.asmx</td>
                <td class="auto-style6">Insert(string Content, string Answer)</td>
                <td class="auto-style5">向填空题表中插入一条记录</td>
                <td>如果插入成功，则返回Json数据(<span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span>);格式为：ID：3是新添加记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</td>
            </tr>
            <tr>
                <td class="auto-style11"><strong>DeleteForID(int id)</strong></td>
                <td class="auto-style8"><strong>向填空题表中删除一条记录</strong></td>
                <td><span class="auto-style7"><strong>如果删除成功，则返回Json数据(</strong></span><span style="font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;" class="auto-style7"><strong>[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</strong></span><span class="auto-style7"><strong>);格式为：ID：3是删除记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style12">Update(int ID, string Content, string Answer)</td>
                <td class="auto-style14">向填空题表中更新一条记录</td>
                <td><span class="auto-style13">如果更新成功，则返回Json数据(</span><span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;" class="auto-style13">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span><span class="auto-style13">);格式为：ID：3是修改记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</span></td>
            </tr>
            <tr>
                <td class="auto-style11"><strong>GetAllTest()</strong></td>
                <td class="auto-style8"><strong>返回表中所有考试的信息</strong></td>
                <td class="auto-style7"><strong>如果成功，返回表中所有学生信息的Json数据；失败则返回空。</strong></td>
            </tr>
            <tr>
                <td class="auto-style12">GetAllTestForSID(string SID)</td>
                <td class="auto-style14">查询表中指定学生ID的考试信息</td>
                <td class="auto-style13">如果成功，返回表中指定学生ID的考试信息Json数据；失败则返回空。</td>
            </tr>
            <tr>
                <td class="auto-style12">GetTestForID(string ID)</td>
                <td class="auto-style14">查询表中指定ID的考试信息</td>
                <td class="auto-style13">如果成功，返回表中指定ID的考试信息Json数据；失败则返回空。</td>
            </tr>           
        </table>
         <br />
        <hr />
        <br />
        <table class="auto-style1" align="center" border="2px">
            <tr>
                <td class="auto-style10" style="text-align: center">表名</td>
                <td style="text-align: center" class="auto-style6">WebService接口名</td>
                <td style="text-align: center" class="auto-style5">说明</td>
                <td style="text-align: center">返回值</td>
            </tr>
            <tr>
                <td class="auto-style10" rowspan="7">选择(tb_Choice)<br />
                    <br />
                    <br />
                    WebService名称：<br />
                    Choice_Operator.asmx</td>
                <td class="auto-style6">Insert(string Content, string AnswerA, string AnswerB, string AnswerC, string AnswerD,<br />
                    string Answer)</td>
                <td class="auto-style5">向选择题表中插入一条记录</td>
                <td>如果插入成功，则返回Json数据(<span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span>);格式为：ID：3是新添加记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</td>
            </tr>
            <tr>
                <td class="auto-style11"><strong>DeleteForID(int id)</strong></td>
                <td class="auto-style8"><strong>向考试表中删除一条记录</strong></td>
                <td><span class="auto-style7"><strong>如果删除成功，则返回Json数据(</strong></span><span style="font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;" class="auto-style7"><strong>[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</strong></span><span class="auto-style7"><strong>);格式为：ID：3是删除记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style12">Update(int ID, string SID, string TestDate, string Flag,string StartTime,string EndTime)</td>
                <td class="auto-style14">向考试表中更新一条记录</td>
                <td><span class="auto-style13">如果更新成功，则返回Json数据(</span><span style="color: rgb(0, 0, 0); font-family: monospace; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;" class="auto-style13">[{&quot;ID&quot;:3,&quot;Flag&quot;:&quot;OK&quot;}]</span><span class="auto-style13">);格式为：ID：3是修改记录的ID;Flag：OK表示插入成功！失败则返回Flag的值为Error</span></td>
            </tr>
            <tr>
                <td class="auto-style11"><strong>GetAllTest()</strong></td>
                <td class="auto-style8"><strong>返回表中所有考试的信息</strong></td>
                <td class="auto-style7"><strong>如果成功，返回表中所有学生信息的Json数据；失败则返回空。</strong></td>
            </tr>
            <tr>
                <td class="auto-style12">GetAllTestForSID(string SID)</td>
                <td class="auto-style14">查询表中指定学生ID的考试信息</td>
                <td class="auto-style13">如果成功，返回表中指定学生ID的考试信息Json数据；失败则返回空。</td>
            </tr>
            <tr>
                <td class="auto-style12">GetTestForID(string ID)</td>
                <td class="auto-style14">查询表中指定ID的考试信息</td>
                <td class="auto-style13">如果成功，返回表中指定ID的考试信息Json数据；失败则返回空。</td>
            </tr>           
        </table>
    </div>
    </form>
    <p>
        其功能尚未完成！！</p>
</body>
</html>
