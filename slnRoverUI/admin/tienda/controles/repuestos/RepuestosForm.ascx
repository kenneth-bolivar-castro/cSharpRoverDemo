<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RepuestosForm.ascx.cs" Inherits="slnRoverUI.admin.tienda.procesos.repuestos.RepuestosForm" %>

<script type="text/javascript">
    $(function () {

        $("#tabs").tabs();

        $('textarea.tinymce').tinymce({
            // Location of TinyMCE script
            script_url: '/js/plugins/tiny_mce/tiny_mce.js',

            // General options
            theme: "advanced",
            plugins: "autolink,lists,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,advlist",

            // Theme options
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,

            // Example content CSS (should be your site CSS)
            content_css: "/js/plugins/tiny_mce/themes/advanced/skins/default/content.css"
        });

    });
</script>

<div id="tabs">
    <ul>
        <li><a href="#tabs-1">Repuesto</a></li>
        <li><a href="#tabs-2">Modelos</a></li>
        <li><a href="#tabs-3">Fotografias</a></li>
    </ul>
    <div id="tabs-1">
        <table>
            <caption align="center" class="titulos" valign="top">Repuesto</caption>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Nombre:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtNombre" Width="400px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Text="*"
                        ValidationGroup="GI" ControlToValidate="txtNombre" Display="Dynamic" ForeColor="Red"
                        Width="100%" ToolTip="Campo nombre requerido."> </asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Codigo:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtCodigo" Width="400px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*"
                        ValidationGroup="GI" ControlToValidate="txtCodigo" Display="Dynamic" ForeColor="Red"
                        Width="100%" ToolTip="Campo Codigo requerido."> </asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label13" runat="server" Font-Bold="true" Text="Precio:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*"
                        ValidationGroup="GI" ControlToValidate="txtPrecio" Display="Dynamic" ForeColor="Red"
                        Width="100%" ToolTip="Campo Precio requerido."> </asp:RequiredFieldValidator>
                    <br />
                    <asp:CheckBox ID="chkEsUsadoIncl" Font-Bold="true" Text="Es Usado?" TextAlign="Left" runat="server" />
                </td>
                <td>
                    <asp:Label ID="Label16" runat="server" Font-Bold="true" Text="Categorias:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlCategorias" runat="server" DataTextField="Descripcion" DataValueField="Id" Height="17px" Width="289px">
                        <asp:ListItem Text=".NA." Value=".NA."></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label18" runat="server" Font-Bold="true" Text="Combustibles:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlCombustibleIncl" runat="server" DataTextField="Nombre" DataValueField="Id" Height="16px" Width="287px">
                        <asp:ListItem Text=".NA." Value=".NA."></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Cantidad:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                        ValidationGroup="GI" ControlToValidate="txtCantidad" Display="Dynamic" ForeColor="Red"
                        Width="100%" ToolTip="Campo Cantidad requerido."> </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                        Text="*" Width="100%" ControlToValidate="txtCantidad" ValidationGroup="GI" ForeColor="Red"
                        ValidationExpression="^(\d{1,})$" ToolTip="El Cantidad debe ser un numero entero">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="text-align: left;">
                        <asp:Label ID="Label4" Font-Bold="true" runat="server" Text="Descripcion:"></asp:Label>
                    </div>
                    <textarea id="txtDescripcion" name="txtDescripcion" class="tinymce" runat="server"></textarea>
                </td>
            </tr>
        </table>
    </div>
    <div id="tabs-2">
        <table>
            <caption align="center" class="titulos" valign="top">Modelos</caption>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Modelo:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="Modelo" DataValueField="Id" Width="285px">
                        <asp:ListItem Text=".NA." Value=".NA."></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Tipo:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="Nombre" DataValueField="Id" Width="285px">
                        <asp:ListItem Text=".NA." Value=".NA."></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label8" runat="server" Font-Bold="true" Text="Incluir Modelo Seleccionado:"></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="Incluir" />
                    <div>
                        <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Modelos Seleccionados:"></asp:Label>
                    </div>
                    <asp:ListBox ID="ListBox1" runat="server" Width="423px" Height="164px"></asp:ListBox>
                    <br />
                    <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="Exluir Modelo Seleccionado:"></asp:Label>
                    <asp:Button ID="Button2" runat="server" Text="Excluir" />
                </td>
            </tr>
        </table>
    </div>
    <div id="tabs-3">
        <table>
            <caption align="center" class="titulos" valign="top">Fotografias</caption>
            <tr>
                <td colspan="2" align="center">
                    <p>Fotografias</p>
                </td>
            </tr>
        </table>
    </div>
</div>
<div>
    <table>
        <tr>
            <td>
                <!-- ValidationGroup="GI" -->
                <input type="button" value="Cancelar" class="botonesForm" />
                <asp:Button ID="btnIncluir" Text="Incluir" CssClass="botonesForm"  runat="server" OnClick="btnIncluir_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMensaje" Font-Bold="true" Visible="true" ForeColor="Red" runat="server" Text=""></asp:Label>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" DisplayMode="BulletList" runat="server" ForeColor="Red"
                    ValidationGroup="GI" HeaderText="Verifique los valores de los campos" Font-Name="Arial"
                    Font-Size="10" />
            </td>
        </tr>
    </table>
</div>
