<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_210414_LoginWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>메인페이지</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>회원관리</h1>
            <h2>메인페이지</h2>
            <asp:LoginView ID="LgvDefault" runat="server" >

                <%--로그인안했을때 템플릿--%>
                <AnonymousTemplate>
                    <asp:LoginStatus ID="LgsLogin" runat="server" LoginText="로그인" /> |
                    <asp:HyperLink ID="LnkRegUser" runat="server" NavigateUrl="~/Register.aspx" Text="회원가입" />
                </AnonymousTemplate>

                <%--로그인했을때 템플릿--%>
                <LoggedInTemplate>
                    <asp:LoginStatus ID="LgsLogout" runat="server" LogoutText="로그아웃" />
                    <a href="Logout.aspx" >로그아웃</a> | 
                    <asp:HyperLink ID="LnkUserInfo" runat="server" NavigateUrl="~/UserInfo.aspx" Text="회원정보" >
                        <asp:LoginName ID="LgnUser" runat="server" />
                    </asp:HyperLink>
                </LoggedInTemplate>

            </asp:LoginView>
        </div>
    </form>
</body>
</html>
