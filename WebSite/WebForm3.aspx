<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebGas.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GasDelivery Consola</title>
    <meta charset="utf-8">
		<link href="style.css" rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		<!--webfonts-->
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700' rel='stylesheet' type='text/css'>
		<!--//webfonts-->
    <style type="text/css">
        .auto-style1 {
            width: 120px;
            height: 120px;
        }
    </style>
</head>
<body>
   <!----start-main--->
    <div class="main">
        <div class="login-form">
            <h1>Iniciar Sesión</h1>
                <div class="head">
	            &nbsp;<img alt="" class="auto-style1" src="user.png" /></div>
                <form id="form1" runat="server">
                  
                    <asp:TextBox ID="txtusuario" runat="server" value="Usuario"></asp:TextBox>
                    <asp:TextBox ID="txtcontraseña" runat="server" value="Password" TextMode="Password"></asp:TextBox>
                    <div class="submit"> 
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Iniciar Sesion" />  
                    &nbsp; 
                    </div>
                    <p><a href="#">Forgot Password ?</a></p>
                </form>


          </div>



     </div>
    

</body>
</html>
