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
        <div id="Cabecera"> <!-- Cabecera de la página -->
            <a href="Default.aspx"> <!-- La cabecera tiene una referencia a ella misma a la página principal -->
                <p class="Titulo">Divided Sentence <!-- Título de la página -->
                    <img class="Logo" src="Images/logo.png"/> <!-- Logo de la página -->
                </p>
            </a>
        </div>
        <div id ="Izquierda"> <!-- Espacio donde se encuentran los datos que ha de introducir el usuario -->
            <p>Introduzca el texto
            </p>
            <p>
                
                <asp:TextBox ID="Texto" runat="server" OnTextChanged="TextBox1_TextChanged" required="required"></asp:TextBox> <!-- TextBox que recoge el texto introducido por el usuario -->
  
            </p>
            <p>Introduzca las columnas que debe contener cada parte del texto</p>
            <p>
                <asp:TextBox ID="Columnas" runat="server" CssClass="nuevoEstilo2" MaxLength="15" required="required"></asp:TextBox> <!--TextBox que recoge el número de columnas indicadas por el usuario -->
            </p>

            <asp:Button ID="Enviar" runat="server" OnClick="Button1_Click" Text="Enviar" /> <!-- Botón con el que se inicia la función "Buttón1_Click" -->
            <asp:Button ID="How" runat="server" OnClick="Button2_Click" Text="Guía" formnovalidate="formnovalidate"/>  <!-- Botón que redirige al usuario a una guía de uso de la página -->
        </div>
        <asp:Panel ID="PanelDerecho" runat="server" Height="1481px" style="margin-left: 0px"> <!-- Espacio donde se encuentra el resultado -->
            <asp:Label ID="Resultado" runat="server" Text="Label" >Resultado</asp:Label>
            <div id="Derecha" margin-left: 0px">
                &nbsp;<asp:Label ID="TextoModificado" runat="server" Text="Label" ></asp:Label> <!-- Resultado -->
                </div>
        </asp:Panel>
    </form>
    
    <p>
        &nbsp;</p>
    
</body>
</html>
