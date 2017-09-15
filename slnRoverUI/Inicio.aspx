<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="slnRoverUI.Inicio1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlImgPrincipales" runat="server">
        <img alt="" src="images/infocentral/images/1.jpg" width="546" height="331" />
        <img alt="" src="#" width="277" height="192" />
        <a href="Nosotros.aspx" title="nosotros">
            <img alt="" src="images/infocentral/images/3.gif" width="265" height="192" />
        </a>
    </asp:Panel>
    <div class="clear">
    </div>
    <div id="nuevoproductotit">
    </div>
    <div style="overflow: hidden;">
        <asp:Literal ID="ltlRepuestos" runat="server"></asp:Literal> 
    </div>
</asp:Content>
