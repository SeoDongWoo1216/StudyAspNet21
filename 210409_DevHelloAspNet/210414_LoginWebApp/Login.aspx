<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_210414_LoginWebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>로그인</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h2>로그인</h2>
            
            아이디 : <asp:TextBox ID="TxtUserID" runat="server" /> <br />
            암호 : <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" /> <br />
            <asp:Button ID="BtnLogin" runat="server" Text="로그인" OnClick="BtnLogin_Click" />
        </div>
    </form>
</body>
</html>
