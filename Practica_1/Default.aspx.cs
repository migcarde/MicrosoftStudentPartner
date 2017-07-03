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
        //Función que aplica acciones al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Establece el panel como no visible
            PanelDerecho.Visible = false;
        }

        //Esta función se activa cuanso se pulsa el botón Enviar
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Guarda en la variable cadena el contenido del objeto Texto
            String cadena = Texto.Text;
            int columnas = 0;
            //Comprueba de que el contenido de Texto no esté vacío y que el contenido de columnas sea de tipo int
            if(Int32.TryParse(Columnas.Text, out columnas) == true && String.IsNullOrWhiteSpace(cadena) == false && columnas > 0)
            {
                //Si se cumplen las condiciones, se crea el objeto dividir con el contenido de Texto y Columna
                Dividir c = new Dividir(cadena, columnas);
                //Se utiliza la función analizar para dividir la frase
                c.analizar();
                //Se añade a TextoModificado el resultado de analizar dicha frase
                TextoModificado.Text = c.getCadena();
            //En caso contrario
            } else
            {
                //Se añade a TextoModificado informando al usuario que el formulario ha de estar relleno
                TextoModificado.Text = "Debe de rellenar los campos con una frase y con un número de columnas. El número de columnas ha de ser mayor que 0.";

            }
            //Establece el panel como visible con una animación
            PanelDerecho.Visible = true;
            PanelDerecho.Style.Add("animation", "fadeIn 1s");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Esta función se activa si se pulsa el botón de Guía
        protected void Button2_Click(object sender, EventArgs e)
        {
            //El servidor redirige al usuario a la página correspondiente a la guía
            Server.Transfer("HowToUse.aspx", true);
        }
    }
}