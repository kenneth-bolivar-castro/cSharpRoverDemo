<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Procesos.Master" AutoEventWireup="true" CodeBehind="Procesos.aspx.cs" Inherits="slnRoverUI.admin.tienda.procesos.repuestos.Procesos" ValidateRequest="false" %>

<%@ Register Src="RepuestosForm.ascx" TagName="RepuestosForm" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/js/libs/jquery-ui/jquery-ui.css" />
    <script type="text/javascript" src="/js/libs/jquery-ui/jquery-ui.js"></script>
    <script type="text/javascript" src="/js/plugins/simpleModal/jquery.simplemodal.js"></script>
    <script type="text/javascript" src="/js/plugins/tiny_mce/jquery.tinymce.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RepuestosForm ID="RepuestosForm1" runat="server" />
</asp:Content>
