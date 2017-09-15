<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="RestableceClave.aspx.cs" Inherits="slnRoverUI.RestableceClave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <strong>
            <font face="Arial, Helvetica, sans-serif" color="#00CC00" size="4">Restablecer Clave:</font>
        </strong>
    </div>
    <hr />
    <asp:Panel ID="pnlSolicitaRestablecer" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Digite Su Correo Electronico:"></asp:Label><br />
        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCorreo"
            ErrorMessage="Correo Electronico es requerido" ForeColor="Red"
            ValidationGroup="Restablece" runat="server" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Correo Electronico no valido"
            ForeColor="Red" ValidationGroup="Restablece" ControlToValidate="txtCorreo" Display="Dynamic"
            ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
        </asp:RegularExpressionValidator><br />
        <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer" ValidationGroup="Restablece" OnClick="btnRestablecer_Click" />
    </asp:Panel>
    <asp:Panel ID="pnlRestableceClave" Visible="false" runat="server">
        <asp:HiddenField ID="hfIdentificadorUsuario" runat="server" />
        <asp:Label ID="Label4" runat="server" Text="Digite Su Nueva Clave:"></asp:Label><br />
        <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtClave" ErrorMessage="Clave es requerido"
            ForeColor="Red" ValidationGroup="ClaveNueva" runat="server" Display="Dynamic"></asp:RequiredFieldValidator><br />
        <asp:Label ID="Label5" runat="server" Text="Verifica Su Nueva Clave:"></asp:Label><br />
        <asp:TextBox ID="txtVClave" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtVClave" ErrorMessage="Verifica Clave es requerido"
            ForeColor="Red" ValidationGroup="ClaveNueva" runat="server" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Claves deben coincidir" ControlToCompare="txtVClave" ControlToValidate="txtClave" Display="Dynamic" ForeColor="Red" ValidationGroup="R"></asp:CompareValidator><br />
       <asp:Button ID="btnActualizaClave" ValidationGroup="ClaveNueva" runat="server" Text="Actualiza Clave" OnClick="btnActualizaClave_Click" /><br />
    </asp:Panel>
    <asp:Label ID="lblProceso" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
</asp:Content>
