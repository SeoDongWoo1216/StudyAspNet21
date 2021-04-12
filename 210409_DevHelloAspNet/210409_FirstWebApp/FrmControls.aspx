<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmControls.aspx.cs" Inherits="_210409_FirstWebApp.FrmControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>대체컨트롤</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="CtlHidden" runat="server" />
            <asp:Button ID="BtnOK" runat="server" Text="히든필드값 출력" OnClick="BtnOK_Click" /> <br />

            <asp:HyperLink ID="LnkMicrosoft" NavigateUrl="Https://www.microsoft.com" runat="server" Text="마이크로소프트 링크"/> <br />

            <asp:Image ID="ImgChange" runat="server" ImageUrl="~/Images/ASP-NET-Banners-01.png" /> <br />
            <asp:Button ID="BtnChange" runat="server" OnClick="BtnChange_Click" Text="이미지변경" /> <br />

            <!-- 
            <br />
            <table style="border: 1px Solid black">
                <thead>
                    <tr>
                        <th>제목1</th>
                        <th>제목2</th>
                        <th>제목3</th>
                    </tr>
                </thead>
                <tr>
                    <td>글1</td>
                    <td>글2</td>
                    <td>글3</td>
                </tr>
                 <tr>
                    <td>글4</td>
                    <td>글5</td>
                    <td>글6</td>
                </tr>
            </table>
            <br />
            -->
            <br />
            <asp:DropDownList ID="CboPhoneNum" runat="server">
                <asp:ListItem Text="010" />
                <asp:ListItem > 019 </asp:ListItem>
                <asp:ListItem Value ="018">018</asp:ListItem>
                <asp:ListItem Value ="011" Text="011">018</asp:ListItem>
            </asp:DropDownList>

            <asp:ListBox ID="LsbHobby" runat="server">
                <asp:ListItem Text="축구" />

            </asp:ListBox>

        </div>
    </form>
</body>
</html>
