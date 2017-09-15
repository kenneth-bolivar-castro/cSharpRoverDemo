<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Buscador.aspx.cs" Inherits="slnRoverUI.Buscador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="449" height="329" border="0" align="center" cellpadding="0" cellspacing="0"
        id="Table_01">
        <tr>
            <td width="449" height="35">
                <img src="images/ImgBuscador/images/buscador1.png" width="450" height="35" alt="">
            </td>
        </tr>
        <tr>
            <td width="450" height="263" background="images/ImgBuscador/images/buscador2.png">
                <table width="82%" border="0" align="center">
                    <tr>
                        <td>
                            <table width="258" border="0" align="center" cellpadding="5">
                                <tr>
                                    <td colspan="5" class="textorosa">
                                        <strong><font face="Arial, Helvetica, sans-serif" color="#00CC00" size="4">Busqueda
                                            de Productos</font></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="77">
                                        <font face="Arial, Helvetica, sans-serif" color="#FFFFFF" font size="2">Nombre:</font>
                                    </td>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtNombre" Width="330px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font face="Arial, Helvetica, sans-serif" color="#FFFFFF" font size="2">Categor&iacute;a:</font>
                                    </td>
                                    <td colspan="4">
                                        <asp:DropDownList ID="ddlCategorias" runat="server" DataTextField="Descripcion" DataValueField="Id">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font face="Arial, Helvetica, sans-serif" color="#FFFFFF" font size="2">Modelo:</font>
                                    </td>
                                    <td colspan="4">
                                        <asp:DropDownList ID="ddlModelos" runat="server" AutoPostBack="True" DataTextField="Modelo" DataValueField="Id">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font face="Arial, Helvetica, sans-serif" color="#FFFFFF" font size="2">Tipo:</font>
                                    </td>
                                    <td colspan="4">
                                        <asp:DropDownList ID="ddlTipoModelo" runat="server" DataTextField="Nombre" DataValueField="Id">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font face="Arial, Helvetica, sans-serif" color="#FFFFFF" font size="2">Combustible:</font>
                                    </td>
                                    <td colspan="4">
                                        <asp:DropDownList ID="ddlCombustible" runat="server" DataTextField="Nombre" DataValueField="Id">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font face="Arial, Helvetica, sans-serif" color="#FFFFFF" font size="2">Tipo:</font>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblEsUsado" runat="server">
                                            <asp:ListItem Selected="True" Value="false">Nuevo</asp:ListItem>
                                            <asp:ListItem Value="true">Usado</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                            <p align="center">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Height="35px"
                                    Style="margin-left: 0px" Width="206px" OnClick="btnBuscar_Click" />
                            </p>
                        </td>
                    </tr>
                </table>
                &nbsp;</td>
        </tr>
        <tr>
            <td height="31">
                <img src="images/ImgBuscador/images/buscador3.png" width="450" height="31" alt="">
            </td>
        </tr>
    </table>
    <hr />
    <asp:Literal ID="ltlRepuestos" runat="server"></asp:Literal> 
</asp:Content>
