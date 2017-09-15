<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Contactenos.aspx.cs" Inherits="slnRoverUI.Contactenos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 150px;">
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label><br />
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNombre" ErrorMessage="Nombre es requerido"
            ForeColor="Red" ValidationGroup="R" runat="server" Display="Dynamic"></asp:RequiredFieldValidator><br />
        <asp:Label ID="Label2" runat="server" Text="Apellidos:"></asp:Label><br />
        <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtApellidos" ErrorMessage="Apellidos es requerido"
            ForeColor="Red" ValidationGroup="R" runat="server" Display="Dynamic"></asp:RequiredFieldValidator><br />
        <asp:Label ID="Label3" runat="server" Text="Correo Electronico:"></asp:Label><br />
        <asp:TextBox ID="txtCorreoElectronico" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCorreoElectronico" ErrorMessage="Correo Electronico es requerido"
            ForeColor="Red" ValidationGroup="R" runat="server" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Correo Electronico no valido"
            ForeColor="Red" ValidationGroup="R" ControlToValidate="txtCorreoElectronico" Display="Dynamic" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator><br />
        <asp:Label ID="Label6" runat="server" Text="Telefono:"></asp:Label><br />
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtTelefono" ErrorMessage="Telefono es requerido"
            ForeColor="Red" ValidationGroup="R" runat="server" Display="Dynamic"></asp:RequiredFieldValidator><br />
        <asp:Label ID="Label7" runat="server" Text="Comentario:"></asp:Label><br />
        <asp:TextBox ID="txtComentario" Columns="40" Rows="6" TextMode="MultiLine" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtComentario" ErrorMessage="Comentario es requerido"
            ForeColor="Red" ValidationGroup="R" runat="server" Display="Dynamic"></asp:RequiredFieldValidator><br />
        <asp:Label ID="Label10" runat="server" Text="Modelo:"></asp:Label><br />
        <asp:DropDownList ID="ddlModelos" runat="server" AutoPostBack="True" DataTextField="Modelo" DataValueField="Id"></asp:DropDownList><br />
        <asp:Label ID="Label4" runat="server" Text="Tipo:"></asp:Label><br />
        <asp:DropDownList ID="ddlTipoModelo" DataValueField="Id" DataTextField="Nombre" runat="server"></asp:DropDownList><br />
        <asp:Label ID="Label11" runat="server" Text="Combustible:"></asp:Label><br />
        <asp:DropDownList ID="ddlCombustibles" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList><br />
        <asp:Label ID="Label8" runat="server" Text="A&ntilde;o:"></asp:Label><br />
        <asp:TextBox ID="txtA_o" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtA_o" ErrorMessage="A&ntilde;o es requerido"
            ForeColor="Red" ValidationGroup="R" runat="server" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtA_o" Display="Dynamic"
            ForeColor="Red" runat="server" ValidationExpression="^(\d{4})$" ErrorMessage="Año invalido usar formato dddd (Ejemplo: 2012)" ValidationGroup="R"></asp:RegularExpressionValidator><br />
        <asp:Label ID="Label9" runat="server" Text="Serie VIN:"></asp:Label><br />
        <asp:TextBox ID="txtVIN" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtVIN" ErrorMessage="VIN es requerido"
            ForeColor="Red" ValidationGroup="R" runat="server" Display="Dynamic"></asp:RequiredFieldValidator><br />
        <asp:Button ID="btnContactenos" ValidationGroup="R" runat="server" Text="Enviar" OnClick="btnContactenos_Click" /><br />
        <asp:Label ID="lblMensajeProceso" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
