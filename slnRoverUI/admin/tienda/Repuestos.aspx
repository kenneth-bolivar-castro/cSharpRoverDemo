<%@ Page Title="" Language="C#" MasterPageFile="~/admin/tienda/Inventario.master" AutoEventWireup="true" CodeBehind="Repuestos.aspx.cs" Inherits="slnRoverUI.admin.tienda.Repuestos" %>

<%@ MasterType VirtualPath="~/admin/tienda/Inventario.master" %>

<%@ Register Src="../../controles/jQGridTable/jQGridTable.ascx" TagName="jQGridTable" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PaginaActual" runat="server">
    <asp:Label ID="lblPaginaActual" CssClass="titulos" runat="server" Text="Repuestos" Font-Names="Arial"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cabecera" runat="server">
    <script type="text/javascript">
        $(function () {
            var configuraciones = {
                "url": "controles/repuestos/Procesos.aspx",
                "detalles": [{ "alto": "600", "ancho": "600" }],
                "nuevo": [{ "alto": "600", "ancho": "800" }],
                "editar": [{ "alto": "600", "ancho": "900" }],
                "eliminar": [{ "alto": "150", "ancho": "600" }]
            };
            $.activaModals(configuraciones);
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <uc1:jQGridTable ID="jQGridTable1" runat="server" />
</asp:Content>
