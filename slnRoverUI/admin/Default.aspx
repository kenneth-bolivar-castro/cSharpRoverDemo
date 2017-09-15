<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="slnRoverUI.admin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>REPUESTOS ROVER Administracion</title>
    <link rel="shortcut icon" href="/favicon.ico" />
    <style type="text/css">
        .botonesForm
        {
            width: 100px;
            padding: 5px;
            display: block;
            float: right;
            background-color: #003399;
            color: #FFFFFF;
            text-decoration: none;
            text-align: center;
        }
    </style>
</head>
<body style="margin: 0; padding: 0; color: #FFF; font-family: Arial, Helvetica, sans-serif; font-size: 12px; background-color: #040703; background-image: url(../images/general/back.jpg); background-position: top center;">
    <br />
    <table width="686" height="369" border="0" align="center" cellpadding="0" cellspacing="0" id="Table_01">
        <tr>
            <td>
                <img src="/images/Box/box_01.png" width="686" height="26" alt=""></td>
        </tr>
        <tr>
            <td height="316" background="/images/Box/box_02.png">
                <table width="88%" border="0" align="center">
                    <tr>
                        <td height="98">
                            <div align="center">
                                <img src="/images/general/logo.png" width="145" height="119" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td height="98">
                            <form id="form1" runat="server">
                            <div>
                                <div style="width: 600px; margin-top: 10%" align="center">
                                    <asp:Login ID="lgnIngresar" runat="server" BorderWidth="1px"
                                        DestinationPageUrl="~/admin/tienda/Repuestos.aspx"
                                        UserNameLabelText="Correo Electronico:" OnAuthenticate="lgnIngresar_Authenticate">
                                        <LayoutTemplate>
                                            <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                                <tr>
                                                    <td>
                                                        <table cellpadding="0">
                                                            <tr>
                                                                <td align="center" colspan="2">Iniciar sesión<br />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Correo Electronico:<br /></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                                        ControlToValidate="UserName" ForeColor="Red"
                                                                        ErrorMessage="El correo electronico es obligatorio."
                                                                        ToolTip="El nombre de usuario es obligatorio." ValidationGroup="lgnIngresar">*</asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                                                        ControlToValidate="UserName" ToolTip="Debe ser correo electronico valido." ForeColor="Red"
                                                                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                                        ValidationGroup="lgnIngresar">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:<br /></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ForeColor="Red"
                                                                        ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria."
                                                                        ToolTip="La contraseña es obligatoria." ValidationGroup="lgnIngresar">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" style="color: Red;">
                                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div align="center" style="width: 205px;">
                                                                        <asp:Button ID="LoginButton" CssClass="botonesForm" runat="server" CommandName="Login"
                                                                            Text="Inicio de sesión" ValidationGroup="lgnIngresar" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                    </asp:Login>
                                    <br />
                                </div>
                            </div>
                            </form>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr>
            <td>
                <img src="/images/Box/box_03.png" width="686" height="27" alt=""></td>
        </tr>
    </table>
</body>
</html>
