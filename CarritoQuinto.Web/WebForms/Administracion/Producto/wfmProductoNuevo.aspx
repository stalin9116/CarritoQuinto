<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoNuevo.aspx.cs" Inherits="CarritoQuinto.Web.WebForms.Administracion.Producto.wfmProductoNuevo" %>

<%@ Register Src="~/UserControl/ucCategoria.ascx" TagName="UC_Categoria" TagPrefix="Uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td colspan="2">
                <h3><strong>Producto Nuevo</strong> </h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="75%" style="height: 35px">
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgbNuevo" runat="server" Width="32px" Height="32px"  ImageUrl="~/images/icon_nuevo.png" OnClick="imgbNuevo_Click" CausesValidation="false"/>
                            <asp:LinkButton ID="lnkNuevo" runat="server" OnClick="lnkNuevo_Click" CausesValidation="false">Nuevo</asp:LinkButton>
                        </td>
                        <td>
                            <asp:ImageButton ID="imgbGuardar" runat="server" Width="32px" Height="32px" ImageUrl="~/images/icon_guardar.png" OnClick="imgbGuardar_Click" />
                            <asp:LinkButton ID="lnkGuardar" runat="server" OnClick="lnkGuardar_Click" >Guardar</asp:LinkButton>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageRegresar" runat="server" Width="32px" Height="32px" ImageUrl="~/images/regresar.png" OnClick="ImageRegresar_Click"/>
                            <asp:LinkButton ID="lnkRegresar" runat="server" OnClick="lnkRegresar_Click">Regresar</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Id"></asp:Label></td>
            <td>
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server" ControlToValidate="txtCodigo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Codigo Campo Obligatorio" ControlToValidate="txtCodigo" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Categoría"></asp:Label></td>
            <td>
                <%--<asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>--%>
                <Uc1:UC_Categoria ID="UC_Categoria1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nombre Campo Obligatorio" ControlToValidate="txtNombre" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Precio Compra"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtPrecioCompra" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Precio Compra Campo Obligatorio" ControlToValidate="txtPrecioCompra" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Precio Venta"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Precio Venta Campo Obligatorio" ControlToValidate="txtPrecioVenta" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Imagen"></asp:Label></td>
            <td>
                <asp:FileUpload ID="fuImagenProducto" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Descripción"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Descripcion Campo Obligatorio" ControlToValidate="txtDescripcion" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Stock Minimo"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtStockMinimo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Stock Minimo Campo Obligatorio" ControlToValidate="txtStockMinimo" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Stock Maximo"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtStockMaximo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Stock máximo Campo Obligatorio" ControlToValidate="txtStockMaximo" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Mensaje"></asp:Label></td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ForeColor="#CC0000" />
                <asp:Label ID="lblMesagge" runat="server" Text=""></asp:Label>
            </td>
        </tr>


    </table>


</asp:Content>
