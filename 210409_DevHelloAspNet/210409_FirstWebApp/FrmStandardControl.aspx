<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmStandardControl.aspx.cs" Inherits="_210409_FirstWebApp.FrmStandardControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>표준컨트롤</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>표준컨트롤</h1>
            
            <!--  <asp:TextBox ID="TxtSingleLine" runat="server" TextMode="SingleLine" /><br />   -->
            <asp:TextBox ID="TxtUserID" runat="server" TextMode="SingleLine" /><br />
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" /><br />
            <asp:TextBox ID="TxtDesc" runat="server" TextMode="MultiLine" /><br />
            <asp:Button Text="로그인" runat="server" ID="BtnLogin" OnClick="BtnLogin_Click"  />

            <br /><br /><br /><br />

            <asp:Label ID="LblDateTime" runat="server" Text="Sample"></asp:Label>

            <h3> 1. 순수 HTML 사용해서 버튼 만들기</h3>
            <input type="button" value="버튼1" id="BtnInput"  /><br />

            <h3> 2. runat 속성을 추가해서 서버 컨트롤 버튼 만들기</h3>
            <input type="button" value="버튼2" id="BtnHtml" runat="server" /> <br /> <!-- input에는 onclick을 자동으로 생성할 수 없다. -->
            
            <h3> 3. ASP.NET 표준 컨트롤을 사용해서 버튼 만들기 </h3>
            <asp:Button Text="버튼3" runat="server" ID="BtnServer" OnClick="BtnServer_Click"  /> <br />  <!-- OnClientClick은 자바스크립트 클릭임. -->
           


        </div>
    </form>
</body>
</html>
