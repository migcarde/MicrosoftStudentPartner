<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Practica_1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet1.css" />
    <link rel="icon" href="Images/favicon-16x16.png" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Divided Sentece</title>
    
    
    
</head>
<body>
    <form id="form1" runat="server">
        <div id="Cabecera">
            <a href="Default.aspx">
                <p class="Titulo">Divided Sentence
                    <img class="Logo" src="Images/logo.png"/>
                </p>
            </a>
        </div>
        <div id ="Izquierda">
            <p>Introduzca el texto</p>
            <p>
                <asp:TextBox ID="Texto" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
            <p>Introduzca las columnas que debe contener cada parte del texto</p>
            <p>
                <asp:TextBox ID="Columnas" runat="server" CssClass="nuevoEstilo2"></asp:TextBox>
            </p>
            <asp:Button ID="Enviar" runat="server" OnClick="Button1_Click" Text="Enviar" />
            <asp:Button ID="How" runat="server" OnClick="Button2_Click" Text="Guía" /> 
        </div>
        <asp:Panel ID="PanelDerecho" runat="server" Height="1481px" style="margin-left: 0px">
            <asp:Label ID="Resultado" runat="server" Text="Label" >Resultado</asp:Label>
            <div id="Derecha" margin-left: 0px">
                &nbsp;<asp:Label ID="TextoModificado" runat="server" Text="Label" ></asp:Label>
                </div>
        </asp:Panel>
    </form>
    
    <p>
        &nbsp;</p>
    
</body>
</html>
