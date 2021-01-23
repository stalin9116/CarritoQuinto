<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmCatalogo.aspx.cs" Inherits="CarritoQuinto.Web.WebForms.Public.wfmCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>
        <asp:Label ID="Label1" runat="server" Text="Productos"></asp:Label></h3>

    <br />

    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" Width="95%" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <table>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="200px" Width="250px" ImageUrl='<%#Eval("Url") %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                        <br />
                        <strong>$<asp:Label ID="lblPrecio" runat="server" Text='<%#Eval("Precio") %>'></asp:Label></strong>
                    </td>
                </tr>
                 <tr>
                    <td align="center">
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Comprar" CommandArgument='<%#Eval("ID") %>' Height="200px" Width="150px" ImageUrl="~/images/iconcomprar.png" />
                    </td>
                </tr>
            </table>


        </ItemTemplate>



    </asp:DataList>

</asp:Content>
