<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="jQGridTable.ascx.cs" Inherits="slnRoverUI.controles.jQGridTable.jQGridTable" %>

<style type="text/css" title="currentStyle">
    @import "/js/plugins/dataTable/css/demo_page.css";
    @import "/js/plugins/dataTable/css/demo_table.css";
    @import "/js/plugins/dataTable/css/demo_table_jui.css";
    @import "/js/plugins/dataTable/css/themes/smoothness/jquery-ui-1.8.4.custom.css";
</style>
<script src="/controles/jQGridTable/fuente.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/plugins/metaData/jquery.metadata.js"></script>
<script type="text/javascript" src="/js/plugins/dataTable/jquery.dataTables.js"></script>
<script type="text/javascript">
    var gTable;
    $(function () {
        $.crearDataTable("#<%= gvDatos.ClientID %>", "#<%= hdfIdentificador.ClientID %>", gTable);
    });
</script>
<div>
    <asp:HiddenField ID="hdfIdentificador" runat="server" />
    <div class="dvGvDatos">
        <asp:GridView ID="gvDatos" class="grid" runat="server" Width="100%" CssClass="display dataTable"
            CellPadding="4" Font-Names="Tahoma" Font-Size="Small" ForeColor="#333333" GridLines="None">
            <EmptyDataTemplate>
                <th>
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="Red" Text="No se encontraron datos."></asp:Label>
                </th>
            </EmptyDataTemplate>
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="Link" Visible="false" />
            </Columns>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:Label ID="lblInformacion" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
    </div>
</div>
