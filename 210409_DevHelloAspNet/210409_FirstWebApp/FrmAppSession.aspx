<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmAppSession.aspx.cs" Inherits="_210409_FirstWebApp.FrmAppSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             현재 페이지가 모든 사용자에 의해 <asp:Label ID="LblApp" runat="server"> 번 호출 되었습니다.</asp:Label> <br />
            현재 페이지가 나에 의해 <asp:Label ID="LblSession" runat="server">번 호출 되었습니다.</asp:Label> <br />
            나의 고유 아이디<asp:Label ID="LblSessionID" runat="server"></asp:Label> <br />
            현재 세션유지시간 <asp:Label ID="LblTimeout" runat="server"></asp:Label> <br />
        </div>
    </form>
</body>
</html>
