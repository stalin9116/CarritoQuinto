<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfmLogin.aspx.cs" Inherits="CarritoQuinto.Web.WebForms.Login.wfmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>



</head>
<body>
    <form id="form1" runat="server">
        <div align="center" >
            <table >
                <tr>
                    <td colspan="2">Login</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Correo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtuser" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                       
                        <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click"  />
                    </td>
                   
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
