<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="IniciarSession.aspx.cs" Inherits="slnRoverUI.IniciarSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <strong>
            <font face="Arial, Helvetica, sans-serif" color="#00CC00" size="4">Iniciar Session:</font>
        </strong>
    </div>
    <hr />
    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Usuario:"></asp:Label><br />
    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" Display="Dynamic"
        ControlToValidate="txtCorreo" ErrorMessage="El correo electronico es obligatorio."
        ForeColor="Red" ValidationGroup="lgnIngresar"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
        ControlToValidate="txtCorreo" ErrorMessage="Debe ser correo electronico valido." ForeColor="Red" Display="Dynamic"
        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        ValidationGroup="lgnIngresar"></asp:RegularExpressionValidator><br />
    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Clave:"></asp:Label><br />
    <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ForeColor="Red"
        ControlToValidate="txtClave" ErrorMessage="La clave es obligatoria." ValidationGroup="lgnIngresar"></asp:RequiredFieldValidator><br />
    <asp:Button ID="btnIniciaSession" ValidationGroup="lgnIngresar" runat="server" Text="Iniciar Session" OnClick="btnIniciaSession_Click" /><br />
    <asp:Label ID="lblInicioSession" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>
</asp:Content>
