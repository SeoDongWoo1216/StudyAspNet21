<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_210409_FirstWebApp.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <div>
            <h1>Hello ASP.NET</h1>
        </div>

        <!-- 두개의 텍스트 박스 비교-->
        <input id="TxtOther" name="TxtOther" type="text" runat="server" /> <br />        <!--직접 코딩해야함 -->
        <asp:TextBox ID="TxtDisplay" runat="server" ></asp:TextBox>                 <!-- 드래그 앤 드롭으로 설정가능-->
        
        <asp:Button ID="BtnClick" runat="server" Text="클릭" Width="57px" OnClick="BtnClick_Click" style="height: 21px" /> <br />
        <asp:Label ID="LblResult" runat="server"></asp:Label>
    </form>
</body>
</html>
