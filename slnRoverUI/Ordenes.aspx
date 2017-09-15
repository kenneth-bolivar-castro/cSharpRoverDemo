<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="slnRoverUI.Ordenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvOrdenes" runat="server" AutoGenerateColumns="False" DataKeyNames="IdOrden">
        <Columns>
            <asp:BoundField DataField="IdOrden" HeaderText="IdOrden" ReadOnly="True" SortExpression="IdOrden" />
            <asp:BoundField DataField="TipoPago" HeaderText="TipoPago" SortExpression="TipoPago" />
            <asp:BoundField DataField="Zona" HeaderText="Zona" SortExpression="Zona" />
            <asp:CheckBoxField DataField="Procesada" HeaderText="Procesada" SortExpression="Procesada" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
        </Columns>
        <EmptyDataTemplate>
            <strong>
                <font face="Arial, Helvetica, sans-serif" color="#00CC00" size="4">No Existen Ordenes Registradas</font>
            </strong>
        </EmptyDataTemplate>
    </asp:GridView>
    <br />
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
