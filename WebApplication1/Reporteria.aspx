<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporteria.aspx.cs" Inherits="WebApplication1.Reporteria" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1185px">
            <LocalReport ReportPath="Reportes\Reporte1.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WebApplication1.SubsidioTablasTableAdapters.DETALLE_PUNTAJETableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ID_DETALLE" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID_DETALLE" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_EDAD" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_CARGA" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_CIVIL" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_INDIGENA" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_AHORRO" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_TITULO" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_REGION" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_TOTAL" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PUNTJ_EDAD" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_CARGA" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_CIVIL" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_INDIGENA" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_AHORRO" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_TITULO" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_REGION" Type="Decimal" />
                <asp:Parameter Name="PUNTJ_TOTAL" Type="Decimal" />
                <asp:Parameter Name="Original_ID_DETALLE" Type="Decimal" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
    
    </div>
        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" />
        <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
    </form>
</body>
</html>
