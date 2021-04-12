<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmButton.aspx.cs" Inherits="_210409_FirstWebApp.FrmButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> 버튼컨트롤 </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TxtNum" runat="server" />
            <asp:Button ID="BtnInc" runat="server" Text="증가" OnClick="BtnInc_Click" />
            <asp:Button ID="BtnDec" runat="server" Text="감소" OnClick="BtnDec_Click" /> <br />

            <asp:LinkButton ID="BtnLink" runat="server" Text="네이버" OnClick="BtnLink_Click"/> <br />
            <asp:ImageButton 
                ID="BtnImage" runat="server" 
                AlternateText="글쓰기" ToolTip="글쓰기" OnClick="BtnImage_Click" 
                ImageUrl="~/Images/btn_post.gif" /> <!-- ImageUrl에서 컨트롤+스페이스를 통해 프로젝트창에서 이미지를 클릭해줌. -->

        </div>
    </form>
</body>
</html>
