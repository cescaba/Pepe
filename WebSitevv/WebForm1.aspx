<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina_Inicio.aspx.cs" Inherits="WebApplication2.Pagina_Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 39%;
            margin-top: 0px;
        }
        .auto-style2 {
            width: 121px;
        }
        .auto-style3 {
            width: 121px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            width: 100%;
        }
        .auto-style6 {
            width: 167px;
        }
        .auto-style7 {
            width: 221px;
        }
        .auto-style10 {
            width: 167px;
            height: 49px;
        }
        .auto-style11 {
            width: 221px;
            height: 49px;
        }
        .auto-style12 {
            height: 49px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="387px">
            <table class="auto-style5">
                <tr>
                    <td class="auto-style10"></td>
                    <td class="auto-style11">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="30pt" ForeColor="Red" Text="  CLICK IT" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></asp:Label>
                    </td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style3">Usuario</td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txtusuario" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Contraseña</td>
                                <td>
                                    <asp:TextBox ID="txtcontraseña" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Ingresar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Usuario o Contraseña Incorrectos" Visible="False"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            &nbsp;</asp:Panel>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>