<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoLista.aspx.cs" Inherits="CarritoQuinto.Web.WebForms.Administracion.Producto.wfmProductoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div align="center" width="95%">
        <table width="95%">
            <tr>
                <td>
                    <h3>Lista Producto</h3>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/images/icon_nuevo.png" Width="32px" Height="32px" />
                    <asp:LinkButton ID="lnkNuevo" runat="server">Nuevo</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gdvDatosProductos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="gdvDatosProductos_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbModificar" runat="server" ImageUrl="~/images/modificar.png" Width="32px" Height="32px"  CommandName="Modificar" CommandArgument='<%#Eval("ID") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbEliminar" runat="server" ImageUrl="~/images/icon_delete.png" Width="32px" Height="32px"  CommandName="Eliminar" CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('Desea eliminar el registro ?')"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>
            </tr>

        </table>

    </div>



</asp:Content>
