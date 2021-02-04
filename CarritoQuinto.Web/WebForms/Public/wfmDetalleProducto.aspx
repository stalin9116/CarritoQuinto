<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmDetalleProducto.aspx.cs" Inherits="CarritoQuinto.Web.WebForms.Public.wfmDetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table width="95%">
        <tr>
            <td colspan="2">

            </td>
        </tr>
        <tr>
            <td width="40%">
                <asp:Image ID="imgProducto" runat="server" Width="350px" Height="400px"/>

            </td>
            <td width="*" style="vertical-align:top">
                <table width="100%">
                    <tr>
                        <td align="center">
                           <h4> <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label></h4>

                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                           <h5> <asp:Label ID="lblDescripcion" runat="server" Text="Label"></asp:Label> </h5>
                        </td>

                    </tr>
                     <tr>
                        <td align="center">
                           <h5>Precio: USD$ <asp:Label ID="lblPrecio" runat="server" Text="Label" ForeColor="#0a86d9"></asp:Label> </h5>
                        </td>

                    </tr>
                      <tr>
                        <td align="center">
                           Cantidad: <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" min="1" max="20" step="1" Text="0"></asp:TextBox>
                        </td>

                    </tr>

                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>

                     <tr>
                        <td align="center">
                            <asp:ImageButton ID="btnComprar" runat="server" Height="200px" Width="150px" ImageUrl="~/images/iconcomprar.png" OnClick="btnComprar_Click" />
                        </td>
                    </tr>
                </table>

            </td>

        </tr>
    </table>

</asp:Content>
