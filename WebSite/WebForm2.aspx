<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebGas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 318px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img src="http://www.limagas.com/images/top/logo.png" /><br />
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="14pt" Text="#"></asp:Label>
                </td> 
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="15pt" Text="Dirección"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="14pt" Text="Hora"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="14pt" Text="Dist."></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="14pt" Text="Balon"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="14pt" Text="Precio"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>1</td>
                <td class="auto-style2">Calle Lopez de Ayala 1045 San Borja</td>
                <td>14:00</td>
                <td>3 Km</td>
                <td>Premiun</td>
                <td>36</td>
            </tr>
            <tr>
                <td>2</td>
                <td class="auto-style2">Calle 27 #1045 San Borja</td>
                <td>14:50</td>
                <td>2 Km</td>
                <td>Premiun</td>
                <td>36</td>
            </tr>
            <tr>
                <td>3</td>
                <td class="auto-style2">Calle San Borja Norte 612 San Borja</td>
                <td>15:40</td>
                <td>3.1 Km</td>
                <td>Premiun</td>
                <td>36</td>
            </tr>
            <tr>
                <td>4</td>
                <td class="auto-style2">Calle San Borja Sur 890 San Borja</td>
                <td>15:44</td>
                <td>2.2 Km</td>
                <td>Normal</td>
                <td>32</td>
            </tr>
            <tr>
                <td>5</td>
                <td class="auto-style2">Calle Russo 500 San Borja</td>
                <td>16:40</td>
                <td>1.9 Km</td>
                <td>Premiun</td>
                <td>36</td>
            </tr>
            <tr>
                <td>6</td>
                <td class="auto-style2">Calle Aviación&nbsp; 2845 San Borja</td>
                <td>17:20</td>
                <td>1.1 Km</td>
                <td>Normal</td>
                <td>32</td>
            </tr>
            <tr>
                <td>7</td>
                <td class="auto-style2">Calle Lopez de Ayala 545 San Borja</td>
                <td>17:21</td>
                <td>2 Km</td>
                <td>Premiun</td>
                <td>36</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
