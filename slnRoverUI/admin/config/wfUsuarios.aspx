<%@ Page Title="" Language="C#" MasterPageFile="~/admin/config/Configuracion.master" AutoEventWireup="true" CodeBehind="wfUsuarios.aspx.cs" Inherits="slnRoverUI.admin.config.wfUsuarios" %>

<%@ MasterType VirtualPath="~/admin/config/Configuracion.master" %>

<%@ Register Src="../../controles/jQGridTable/jQGridTable.ascx" TagName="jQGridTable" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PaginaActual" runat="server">
    <asp:Label ID="lblPaginaActual" CssClass="titulos" runat="server" Text="Usuarios" Font-Names="Arial"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cabecera" runat="server">
    <script type="text/javascript">
        $(function () {
            var configuraciones = {
                "url": "ProcesosRepuestos.aspx",
                "detalles": [{ "alto": "600", "ancho": "600" }],
                "nuevo": [{ "alto": "600", "ancho": "1250" }],
                "editar": [{ "alto": "600", "ancho": "1250" }],
                "eliminar": [{ "alto": "150", "ancho": "600" }]
            };
            $.activaModals(configuraciones);
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <uc1:jQGridTable ID="jQGridTable1" runat="server" />
</asp:Content>
