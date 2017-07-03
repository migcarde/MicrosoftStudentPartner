using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Practica_1
{
    public class Dividir
    {
        //Variables
        String cadena;
        int columnas;
        int ultimaSilaba;

        public Dividir(String cadena, int columnas) //Constructor de la clase Dividir
        {
            this.cadena = cadena;
            this.columnas = columnas;
        }

        //Getters
        public String getCadena()
        {
            return this.cadena;
        }

        public int getColumnas()
        {
            return this.columnas;
        }

        public int getUltimaSilaba()
        {
            return this.ultimaSilaba;
        }

        //Setters
        public void setCadena(String cadena)
        {
            this.cadena = cadena;
        }

        public void setColumnas(int columnas)
        {
            this.columnas = columnas;
        }

        public void setUltimaSilaba(int silaba)
        {
            this.ultimaSilaba = silaba;
        }

        //En éste método se analiza la frase completa y se le añade los separadores a partir de las columnas definidas por el usuario
        public void analizar()
        {
            //c se usa como contador
            int c = 0;
            //aux se usa como nuevo valor para la cambiar el valor de i sin necesidad de modificar el mismo
            int aux = 0;
            //Utilizamos StringBuilder para tener una cadena que se pueda modificar
            StringBuilder frase = new StringBuilder(getCadena());
            //Recorremos la variable frase
            for (int i = 0; i < frase.Length - 1; i++)
            {
                //Si c es distinto que las columnas definidas por el usuario
                if (c != getColumnas())
                {
                    //y no es un salto de línea un signo de puntuación
                    if (!(frase[i].Equals('\n')) || esSignoDePuntuacion(frase[i]) == true) //No pasa bien el método
                    {
                        //Se actualiza el contador
                        c = c + 1;
                        //En el caso de que sea una vocal
                        if (esVocal(frase[i]) == true)
                        {
                            //Se guarda
                            setUltimaSilaba(i);
                        }
                    }
                //Si c es igual al número de culumnas definidas por el usuario
                }
                else
                {

                    //Si el carácter es un espacio
                    if (frase[i].Equals(' '))
                    {
                        //Se inserta un salto de línea
                        frase.Insert(i, "\n");
                        frase.Remove(i + 1, 1);
                    }
                    //Si el caracter no es un separador ni un signo de puntuación
                    else if (!(frase[i].Equals('\n')) || esSignoDePuntuacion(frase[i]) == false)
                    {
                        //En el caso de que el caracter siguiente es un espacio, independendientemente de si es una consonante o una vocal
                        if (frase[i + 1].Equals(' ') && i < frase.Length - 1)
                        {
                            //Insertamos el salto de línea y eliminamos el espacio
                            frase.Insert(i + 1, "\n");
                            frase.Remove(i + 2, 1);
                        //Si el próximo carácter es un signo de putuación y no excede la longitud de la frase
                        } else if (esSignoDePuntuacion(frase[i + 1]) == true && i < frase.Length - 2)
                        {
                            //Se elimina el espacio y se inserta un salto de línea
                            frase.Insert(i + 2, "\n");
                            frase.Remove(i + 3, 1);
                        }
                        //En caso de que sea un carácter que no sea un separador
                        else
                        {
                            //Si es una vocal
                            if (esVocal(frase[i]) == true)
                            {
                                //Analizamos la palabra a partir de dicha vocal
                                aux = analizarVocal(frase, i);
                            }
                            //Si es una consonante

                            else if (esVocal(frase[i]) == false)
                            {
                                //Analizamos la palabra a partir de dicha consonante
                                aux = analizarConsonante(frase, i);
                            }
                            //Se inserta un guión y un salto de línea con el valor de aux
                            frase.Insert(aux + 1, "-");
                            frase.Insert(aux + 2, "\n");
                            //Si los dos carácteres anteriores a aux son un espacio y un salto de línea
                            if (aux >= 1 && frase[aux - 1].Equals(' ') && frase[i - 2].Equals('\n'))
                            {
                                //Se elimina el espacio
                                frase.Remove(aux - 1, 1);
                            }
                        }
                        c = 0;
                    }
                    //El contador se establece como 0

                    
                }
            }
            //Se adapta la frase y se modifica el valor de cadena
            setCadena(transformar(frase));
        }

        //Éste método sirve para comprobar si el carácter es un signo se puntuación
        public Boolean esSignoDePuntuacion(Char c)
        {
            //El valor por defecto es false
            Boolean res = false;
            //Si el carácter es un signo de puntuación
            if(c.Equals(',') || c.Equals(';') || c.Equals('.') || c.Equals(':') || c.Equals('-') || c.Equals('_')
                || c.Equals('(') || c.Equals(')') || c.Equals('{') || c.Equals('}') || c.Equals('}') || c.Equals('[') || c.Equals(']') 
                || c.Equals('¿') || c.Equals('?') || c.Equals('¡') || c.Equals('!') || c.Equals('\'') || c.Equals('\"'))
            {
                //Cambiamos el valor de res a true
                res = true;
            }
            //Devolvemos la comprobación
            return res;
        }

        //Éste método sirve para comprobar si un carácter es un salto de línea, un guión o un espacio
        public Boolean esSeparador(Char c)
        {
            //El valor por defecto es false
            Boolean res = false;
            //Forzamos a que el caracter esté en minúsculas
            String caracter = c.ToString().ToLower();
            //Si el caracter es un separador
            if (caracter.Equals("\n") || caracter.Equals("-") || caracter.Equals(" "))
            {
                //Cambiamos el valor de res a true
                res = true;
            }
            //Devolvemos la comprobación
            return res;
        }

        //Éste método sirve para comprobar si un carácter es vocal
        public Boolean esVocal(char caracter)
        {
            //El valor por defecto es false
            Boolean res = false;
            //Comprueba que es una vocal abierta o una vocal cerrada
            if (esVocalAbierta(caracter) == true || esVocalCerrada(caracter) == true)
            {
                //Si es una vocal abierta o una cerrada se cambia el valor a true
                res = true;
            }
            //Se devuelve la comprobación
            return res;
        }

        //Éste método sirve para analizar la palabra en el caso de que el índice acabe en vocal
        public int analizarVocal(StringBuilder frase, int i)
        {
            int res = i;
            //Si las columnas definidas por el usuario es 1
            if (getColumnas() == 1)
            {
                //la variable res es igual a i
                res = i;
            }
            //En el caso de que la palabra contenga vocal-consonante-vocal
            else if ((i < frase.Length - 2 && esVocal(frase[i + 1]) == false && esVocal(frase[i + 2]) == true && esSeparador(frase[i + 1]) == false && esSignoDePuntuacion(frase[i + 1]) == false)
                //ó es vocal-consonante-consonante-vocal
                || (i < frase.Length - 3 && esConsonanteDoble(frase, i + 1) == true && esVocal(frase[i + 3]) == true))
            {
                //la variable res es igual a i
                res = i;
            }
            //En el caso de que la palabra contenga vocal-consonante-consonante-vocal
            else if ((i >= 3 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == true 
                && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false 
                && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false)
              //ó es vocal-consonante-consonante-consonante-vocal
              || (i >= 4 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == false && esVocal(frase[i - 4]) == true 
              && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false && esSeparador(frase[i - 3]) == false)
              && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false && esSignoDePuntuacion(frase[i - 3]) == false)
            {
                //la variable res es igual a i - 2 
                res = i - 2;
                //En el caso de que la consonante anterior se r, l o consonante doble
                if (frase[i - 1].Equals('r') || frase[i - 1].Equals('l') || esConsonanteDoble(frase, i - 1))
                {
                    //la variable res es igual a i - 3
                    res = i - 3;
                }
            }
            //En el caso de que sea vocal-consonante-consonante-consonante-consonante-vocal
            else if (i >= 5 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == false && esVocal(frase[i - 4]) == false && esVocal(frase[i - 5]) == true
                && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false && esSeparador(frase[i - 3]) == false && esSeparador(frase[i - 4]) == false
                && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false && esSignoDePuntuacion(frase[i - 3]) == false && esSignoDePuntuacion(frase[i - 4]) == false)
            {
                //la variable res es igual a i - 3
                res = i - 3;
            }
            //En el caso de que sean dos vocales consecutivas, siendo una cerrada y otra abierta o las dos cerradas
            else if (i < frase.Length && esVocal(frase[i + 1]) == true && (esVocalAbierta(frase[i]) == false || esVocalAbierta(frase[i + 1]) == false))
            {
                //la variable res es igual a i - 1
                res = i - 1;
                //si alguna de esas vocales son acentuadas
                if (esAcentuada(frase[i]) == true || esAcentuada(frase[i + 1]) == true)
                {
                    //res es igual a i
                    res = i;                    
                }
                //Si se vocal cerrada-vocal abierta-vocal cerrada
                else if (i > 0 && esVocalAbierta(frase[i]) == true && esVocalCerrada(frase[i + 1]) == true && esVocalCerrada(frase[i - 1]) == true)
                {
                    //el valor de res es igual a i - 2
                    res = i - 2;
                }
            }
            //En el caso de que sean dos vocales abiertas consecutivas
            else if (i >= 2 && esVocalAbierta(frase[i]) == true && esVocalAbierta(frase[i - 1]) == true)
            {
                //res es igual a i - 1
                res = i - 1;
            }
            //En el caso de que esté finalizando la frase y las columnas definidas por el usuario sea distinto de 1
            if (res == frase.Length - 2 && getColumnas() != 1)
            {
                //Utilizo recursividad para volver a la silaba anterior y así realizar un análisis
                res = analizarVocal(frase, getUltimaSilaba());
                //Si resulta que la diferencia entre i y res es mayor que las columnas definidas por le usuario
                if (i - res > getColumnas())
                {
                    //El valor de res es igual a i
                    res = i;
                }
            }
            //Se devuelve el número tipo int escogido
            return res;
        }

        //Éste método sirve para analizar la palabra en el caso de que el índice acabe en una consonante
        public int analizarConsonante(StringBuilder frase, int i)
        {
            //El valor por defecto de res es igual a i
            int res = i;
            //En el caso de que las columnas definidas por el usuario es 1
            if (getColumnas() == 1)
            {
                //El valor de res es igual a i
                res = i;
            }
            //En el caso de que sea consonante-vocal
            else if (i < frase.Length - 1 && esVocal(frase[i + 1]) == true)
            {
                //Si es vocal-consonante-vocal
                if (i >= 1 && esVocal(frase[i - 1]) == true)
                {
                    //El valor de res es igual a i - 1
                    res = i - 1;
                }
                //En el caso de que sea vocal-consonante-vocal
                else if ((i >= 2 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == true 
                    && esSeparador(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 1]) == false)
                  //o vocal-consonante-consonante-vocal
                  || (i >= 3 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == true 
                  && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false)
                  && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false)
                {
                    //El valor de res es igual a i - 1
                    res = i - 1;
                    //En el caso de que i sea r, l o consonante doble

                    if (frase[i].Equals('r') || frase[i].Equals('l') || esConsonanteDoble(frase, i))
                    {
                        //El valor de res es igual a i - 2
                        res = i - 2;
                    }
                }
                //En el caso de que sea vocal-consonante-consonante-consonante-vocal
                else if (i >= 4 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == false && esVocal(frase[i - 4]) == true 
                    && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false && esSeparador(frase[i - 3]) == false
                    && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false && esSignoDePuntuacion(frase[i - 3]) == false)
                {
                    //El valor de res es igual a i - 2
                    res = i - 2;
                }
            }
            //En el caso de que sea consonante-consonante-vocal
            else if (i < frase.Length - 2 && esVocal(frase[i + 1]) == false && esVocal(frase[i + 2]) == true 
                && esSeparador(frase[i + 1]) == false && esSignoDePuntuacion(frase[i - 1]) == false)
            {
                //Si es vocal-consonante-consonante-vocal
                if ((i >= 1 && esVocal(frase[i - 1]) == true)
                    //o es vocal-consonante-consonante-consonante-vocal
                    || (i >= 2 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == true 
                    && esSeparador(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 1]) == false))
                {
                    //El valor de res es i
                    res = i;
                    //Si i + 1 es r o l, o i es consonante doble
                    if (frase[i + 1].Equals('r') || frase[i + 1].Equals('l') || esConsonanteDoble(frase, i))
                    {
                        //El valor de res es igual a i - 1
                        res = i - 1;
                    }
                }
                //En el caso de que sea vocal-consonante-consonante-consonante-consonante-vocal
                else if (i >= 3 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == true 
                    && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false
                    && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false)
                {
                    //El valor de res es igual a i - 1
                    res = i - 1;
                }
            }
            //En el caso de que llegue esté finalizando la frase y las columnas definidas por el usuario sea distinto de 1
            if (res == frase.Length - 2 && getColumnas() != 1)
            {
                //Utilizo recursividad para volver a la sílaba anterior y así realizar un análisis
                res = analizarVocal(frase, getUltimaSilaba());
                //Si la diferencia entre i y res es mayor que las columnas definidas por el usuario
                if (i - res > getColumnas())
                {
                    //El valor de res es igual a i
                    res = i;
                }
            }
            //Se devuelve el número tipo int escogido
            return res;
        }

        //Este método comprueba si existe una consonante doble
        public Boolean esConsonanteDoble(StringBuilder frase, int i)
        {
            //Su valor por defecto es false
            Boolean res = false;
            //Se comprueba si es ch y se cambia el valor a true
            if (frase[i].Equals('c'))
            {
                if (frase[i + 1].Equals('h'))
                {
                    res = true;
                }
            }
            else if (frase[i].Equals('h'))
            {
                if (frase[i - 1].Equals('c'))
                {
                    res = true;
                }
            }
            //Se comprueba si es ll y se cambia el valor a true
            else if (frase[i].Equals('l'))
            {
                if (frase[i - 1].Equals('l') || frase[i + 1].Equals('l'))
                {
                    res = true;
                }
            }
            //Se comprueba si es rr y se cambia el valor a true
            else if (frase[i].Equals('r'))
            {
                if (frase[i - 1].Equals('r') || frase[i + 1].Equals('r'))
                {
                    res = true;
                }
            }
            //Se devuelve la comprobación
            return res;
        }

        //Éste método sirve para comprobar si un carácter es vocal abierta
        public Boolean esVocalAbierta(char c)
        {
            //Se inicializa como falso
            Boolean res = false;
            //Forzamos a que el carácter esté en minúsculas
            String caracter = c.ToString().ToLower();
            //Comprobamos que es una vocal abierta, incluyendo vocales abiertas y acentuadas
            if (caracter.Equals("a") || caracter.Equals("e") || caracter.Equals("o") || caracter.Equals("á") || caracter.Equals("é") || caracter.Equals("ó"))
            {
                //En el caso de que sea una vocal abierta se cambia el valor a true
                res = true;
            }
            //Se devuelve la comprobación
            return res;
        }

        //Éste método sirve para comprobar si un carácter es vocal cerrada
        public Boolean esVocalCerrada(char c)
        {
            //Se inicializa como falso
            Boolean res = false;
            //Forzamos a que el carácter esté en minúsculas
            String caracter = c.ToString().ToLower();
            //Comprobamos que es una vocal cerrada, incluyendo vocales cerradas y acentuadas
            if (caracter.Equals("u") || caracter.Equals("i") || caracter.Equals("ú") || caracter.Equals("í"))
            {
                //En caso de que sea una vocal cerrada se cambia el valor a true
                res = true;
            }
            //Se devuelve la comprobación
            return res;
        }

        //Este método comprueba si el carácter es acentuado
        public Boolean esAcentuada(char c)
        {
            //Su valor por defecto es false
            Boolean res = false;
            //Forzamos a que el carácter sea minúscula
            String caracter = c.ToString().ToLower();
            //Se compruba que es acentuada
            if (caracter.Equals("á") || caracter.Equals("é") || caracter.Equals("í") || caracter.Equals("ó") || caracter.Equals("ú"))
            {
                //Si lo es se cambia el valor a true
                res = true;
            }
            //Se devuelve la comprobación
            return res;
        }

        //Este método se utiliza para adaptar la frase dividida a los carácteres de html
        public String transformar(StringBuilder frase)
        {
            //Creamos un array de String a partir de la cadena, dividiendo por cada carácter '\n' encontrado
            String[] palabras = frase.ToString().Split('\n');
            String res = "";
            //Recorremos el contenido del array
            foreach (String i in palabras)
            {
                //Formamos la frase sustituyendo '\n' por '<br>', el cual es el salto de línea de html
                res = res + "<br>" + i;
            }
            //Devolvemos la frase reconstruida
            return res;
        }
    }
}