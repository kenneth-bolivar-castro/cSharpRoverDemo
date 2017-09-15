<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="slnRoverUI.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>REPUESTOS ROVER</title>
    <link rel="shortcut icon" href="favicon.ico" />
    <script type="text/javascript" src="/js/libs/jquery-1.8.2.js"></script>
    <link href="css/portada.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <script type="text/javascript">
        $(document).ready(function(){ 
            $(window).keydown(function(e){
                if(e.keyCode == 13) $('#imgBtnIngresar').click();
            }); 
        });
    </script>
    <form id="form1" runat="server">
   <div id="home-contenedor-general">
        <div id="home-contenedor-info">
            <div id="home-banner-top">
                <a href="#" class="home-logotipo"></a>
                <div class="home-txt">
                </div>
            </div>
            <div id="home-contenedor-informacion">
             <div class="home-caja-ingreso">
                    <strong class="home-titulo">
                        <br />
                        <br />
                        DEBE DE SELECCIONAR UN MODELO DE VEHICULO:</strong><br /> 
                    <label for="MODELO">
                    </label>
                    <div align="center">
                        <br />
                        <table width="500px" border="0">
                            <thead>
                                <tr>
                                    <th>
                                        <strong>Modelo </strong>
                                    </th>
                                    <th>
                                        <strong>Tipo </strong>
                                    </th>
                                    <th>
                                        &nbsp;
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td width="45%">
                                        <asp:DropDownList ID="ddlModelos" DataValueField="Id" DataTextField="Modelo" runat="server" AutoPostBack="True">
                                            <asp:ListItem>.ND.</asp:ListItem>
                                        </asp:DropDownList>  
                                    </td>
                                    <td width="45%">
                                        <asp:DropDownList ID="ddlTipoModelo" DataValueField="Id" DataTextField="Nombre" runat="server">
                                            <asp:ListItem>.ND.</asp:ListItem>
                                        </asp:DropDownList>
                                    </td> 
                                    <td width="10%">
                                        <asp:ImageButton ID="imgBtnIngresar" Width="80px" Height="26px"
                                            ImageUrl="images/ImgInicio/btn.png" runat="server" OnClick="imgBtnIngresar_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <br />
                    </div>
                </div>
                <div id="home-foto-principal">
                </div> 
            </div>
        </div>
    </div>
    </form>
</body>
</html>
