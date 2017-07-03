using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica_1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //Función que aplica acciones al cargar la página
        {
            PanelDerecho.Visible = false; //Establece el panel como no visible
        }

        
        protected void Button1_Click(object sender, EventArgs e) //Función que se activa cuanso se pulsa el botón Enviar
        {
            String cadena = Texto.Text; //Guarda en la variable cadena el contenido del objeto Texto
            long columnas = 0; //Establece las columnas a 0
            if (String.IsNullOrWhiteSpace(cadena) == true) //Si el usuario no ha introducido el texto a modificar
            {
                TextoModificado.Text = "Debe introducir el texto que desea dividir."; //Se le informa que ha de introducir dicho texto
            }
            else if (long.TryParse(Columnas.Text, out columnas) == false) //Comprueba que el texto no está vacío o el número de columnas es demasiado grande
            {
                if (String.IsNullOrWhiteSpace(Columnas.Text) == true) //En el caso de que el campo esté vacío
                {
                    TextoModificado.Text = "No se han introducido las columnas en las que se ha de dividir el texto"; //Se le informa al usuario que ha de rellenarlo
                }
                else //Si no está vacío significa que el número es demasiado grande
                {
                    TextoModificado.Text = "El número introducido es demasiado grande, por favor, introduzca uno más pequeño"; //Informa al usuario que el número de columnas es demasiado grande
                }
            }
            else //Si ha rellenado los campos correctamente
            {
                if (columnas <= 0) //Comprueba que si el número es negativo
                {
                    TextoModificado.Text = "El número de columnas no puede ser negativo o 0."; //Si lo es, se le informa que ha de introducir un número positivo
                }
                else //Si es un número positivo
                {
                    Dividir c = new Dividir(cadena, columnas); //Se crea el objeto dividir con el contenido de Texto y Columna
                    c.analizar(); //Se utiliza la función analizar para dividir la frase
                    TextoModificado.Text = c.getCadena(); //Se añade a TextoModificado el resultado de analizar dicha frase
                }
            }
            //Establece el panel como visible con una animación
            PanelDerecho.Visible = true;
            PanelDerecho.Style.Add("animation", "fadeIn 1s");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e) //Esta función se activa si se pulsa el botón de Guía
        {
            Server.Transfer("HowToUse.aspx", true);  //El servidor redirige al usuario a la página correspondiente a la guía
        }
    }
}