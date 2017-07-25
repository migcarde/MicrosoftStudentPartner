<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HowToUse.aspx.cs" Inherits="Practica_1.HowToUse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet1.css" />
    <link rel="icon" href="Images/favicon-16x16.png" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Cabecera"> <!-- Cabecera de la página -->
            <a href="Default.aspx"> <!-- La cabecera tiene una referencia a la página principal -->
                <p class="Titulo">Divided Sentence <!-- Título de la página -->
                    <img class="Logo" src="Images/logo.png"/> <!-- Logo de la página -->
                </p>
            </a>
        </div>
    <p class="Presentacion">Con divided sentence se puede dividir una frase indicando el número de columnas deseado, siguiendo siempre las reglas de ortografía españolas. Para ello solo se tienen que seguir los pasos siguientes:</p>
    <!-- Se realizan varios espacios con el mismo estilo para poder diferenciar claramente los pasos a seguir -->
    <div class="Tarjeta"> <!-- Paso 1 -->
        <p class="Descripcion">En primer lugar, introduzca la frase que desea dividir en el campo.</p>
        <img class="Pasos" alt="Paso 1" src="Images/Paso1.PNG" />
    </div>
    <div class="Tarjeta"> <!-- Paso 2 -->
        <p class="Descripcion">En segundo lugar, introduzca un número sin signo dentro del apartado correspondiente.</p>
        <img class="Pasos" alt="Paso 2" src="Images/Paso2.PNG" />
    </div>
    <div class="Tarjeta"> <!-- Paso final -->
        <p class="Descripcion">Por último, pulse el botón "Enviar" y le aparecerá a la derecha la frase dividida.</p>
        <img class="PasoFinal" alt="Paso 3" src="Images/Paso3.PNG" />
    </div>
    </form>
</body>
</html>
