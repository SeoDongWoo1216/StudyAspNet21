<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSqlDataSource.aspx.cs" Inherits="_210414_DataControlWebApp.FrmSqlDataSource" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>데이터소스컨트롤</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="CboMemoName" runat="server" DataSourceID="SdsMemoName" DataTextField="Name" DataValueField="Num"></asp:DropDownList>  
            <%--  데이터 소스 선택으로 DB와 바인딩을 해줘야함(여기서는 DataValueField로 되어있다.  --%>

            <asp:SqlDataSource ID="SdsMemoName" runat="server" ConnectionString="<%$ ConnectionStrings:ConnString %>" SelectCommand="SELECT [Num], [Name] FROM [Memos]"></asp:SqlDataSource> <%--  SqlDataSource => Sds   --%>
            <%--  ~~~Source 로 끝나는 컴포넌트는 디자인상에는 나오지만, 실행화면에서는 뜨지않음.  --%>
           
            <asp:Chart runat="server" ID="Chart1">
                <Series>
                    <asp:Series Name="Series1">
                    <%--
                        제일 무식한 방법으로 차트에 데이터 삽입(좋은 방법은 아님)
                        <Points>
                            <asp:DataPoint AxisLabel="국어" YValues="90.0" />
                            <asp:DataPoint AxisLabel="영어" YValues="100.0" />
                            <asp:DataPoint AxisLabel="수학" YValues="95.0" />
                        </Points>
                     --%>

                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">

                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </form>
</body>
</html>
