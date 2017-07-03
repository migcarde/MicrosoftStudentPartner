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
        long columnas;
        int ultimaSilaba;

        public Dividir(String cadena, long columnas) //Constructor de la clase Dividir
        {
            this.cadena = cadena; //Texto introducido por el usuario
            this.columnas = columnas; //Columnas introducidas por el usuario
        }

        //Getters
        public String getCadena() //Sirve para obtener el texto introducido por el usuario
        {
            return this.cadena;
        }

        public long getColumnas() //Sirve para obtener las columnas introducidas por el usuario
        {
            return this.columnas;
        }

        public int getUltimaSilaba() //Sirve para obtener la última sílaba recorrida
        {
            return this.ultimaSilaba;
        }

        //Setters
        public void setCadena(String cadena) //Sirve para sustituir la frase introducida por le usuario por otra nueva
        {
            this.cadena = cadena;
        }

        public void setUltimaSilaba(int silaba) //Sirve para sustituir la última sílaba recorrida por otra
        {
            this.ultimaSilaba = silaba;
        }

        //Éste método se analiza la frase completa y se le añade los separadores a partir de las columnas definidas por el usuario
        public void analizar()
        {
            int c = 0; //Contador
            int aux = 0; //Valor auxiliar para cambiar el valor de i sin necesidad de modifcarlo
            StringBuilder frase = new StringBuilder(getCadena().Trim()); //Se utiliza StringBuilder para tener una cadena que se pueda modificar y se les quita los espacios iniciales y finales
            char l = frase[frase.Length - 1]; //Último carácter de la cadena
            for (int i = 0; i < frase.Length - 1; i++) //Se recorre la variable frase
            {
                if (c != getColumnas() - 1 )//Si c es distinto que las columnas definidas por el usuario
                {
                    if (!(frase[i].Equals('\n')) && esSignoDePuntuacion(frase[i]) == false) //y no es un salto de línea ni un signo de puntuación
                    {
                        c = c + 1; //Se actualiza el contador
                        if (esVocal(frase[i]) == true) //En el caso de que sea una vocal
                        {
                            setUltimaSilaba(i); //Se guarda
                        }
                    }                }
                else //Si c es igual al número de culumnas definidas por el usuario
                {
                    if (esSignoDePuntuacion(frase[i]) == false) //Se comprueba que que el carácter no es un signo de puntuación
                    {
                        if (!(frase.ToString().LastIndexOf(l) - i == 1 && esSignoDePuntuacion(l) == true)) //y que no sea el penúltimo carácter y el último no sea un signo de puntuación
                        {
                            if (frase[i].Equals(' ')) //Si el carácter es un espacio
                            {
                                frase.Insert(i, "\n"); //Se inserta un salto de línea
                                frase.Remove(i + 1, 1); // y se elimina el espacio
                            }
                            else if (!(frase[i].Equals('\n')) && esSignoDePuntuacion(frase[i]) == false) //Si el caracter no es un salto de línea ni un signo de puntuación
                            {
                                if (frase[i + 1].Equals(' ') && i < frase.Length - 1) //En el caso de que el caracter siguiente es un espacio, independendientemente de si es una consonante o una vocal
                                {
                                    //Insertamos el salto de línea y eliminamos el espacio
                                    frase.Insert(i + 1, "\n");
                                    frase.Remove(i + 2, 1);
                                    
                                }
                                else if (esSignoDePuntuacion(frase[i + 1]) == true && i < frase.Length - 2) //Si el próximo carácter es un signo de putuación y no excede la longitud de la frase
                                {
                                    //Se elimina el espacio y se inserta un salto de línea
                                    frase.Insert(i + 2, "\n");
                                    frase.Remove(i + 3, 1);
                                }

                                else //En caso de que sea un carácter que no sea un salto de línea o un signo de puntuación
                                {
                                    if (esVocal(frase[i]) == true) //Si es una vocal
                                    {
                                        aux = analizarVocal(frase, i); //Analizamos la palabra a partir de dicha vocal
                                    }
                                    else if (esVocal(frase[i]) == false) //Si es una consonante
                                    {
                                        aux = analizarConsonante(frase, i); //Analizamos la palabra a partir de dicha consonante
                                    }
                                    //Se inserta un guión y un salto de línea con el valor de aux
                                    frase.Insert(aux + 1, "-");
                                    frase.Insert(aux + 2, "\n");
                                    if (aux >= 1 && frase[aux - 1].Equals(' ') && frase[i - 2].Equals('\n')) //Si los dos carácteres anteriores a aux son un espacio y un salto de línea
                                    {
                                        frase.Remove(aux - 1, 1); //Se elimina el espacio
                                    }
                                }
                            }
                            c = 0; //El contador se establece como 0
                        }
                    }
                }
            }
            setCadena(transformar(frase)); //Se adapta la frase y se modifica el valor de cadena
        }

        public Boolean esSignoDePuntuacion(Char c) //Éste método sirve para comprobar si el carácter es un signo se puntuación
        {
            
            Boolean res = false; //El valor por defecto es false
            //Si el carácter es un signo de puntuación
            if (c.Equals(',') || c.Equals(';') || c.Equals('.') || c.Equals(':') || c.Equals('-') || c.Equals('_')
                || c.Equals('(') || c.Equals(')') || c.Equals('{') || c.Equals('}') || c.Equals('}') || c.Equals('[') || c.Equals(']') 
                || c.Equals('¿') || c.Equals('?') || c.Equals('¡') || c.Equals('!') || c.Equals('\'') || c.Equals('\"'))
            {
                res = true; //Cambiamos el valor de res a true
            }
            return res; //Devolvemos la comprobación
        }
        public Boolean esSeparador(Char c) //Éste método sirve para comprobar si un carácter es un salto de línea, un guión o un espacio
        {
            Boolean res = false; //El valor por defecto es false
            String caracter = c.ToString().ToLower(); //Forzamos a que el caracter esté en minúsculas
            if (caracter.Equals("\n") || caracter.Equals("-") || caracter.Equals(" ")) //Si el caracter es un separador
            {
                res = true; //Cambiamos el valor de res a true
            }
            return res; //Devolvemos la comprobación
        }
        
        public Boolean esVocal(char caracter) //Éste método sirve para comprobar si un carácter es vocal
        {
            Boolean res = false; //El valor por defecto es false
            if (esVocalAbierta(caracter) == true || esVocalCerrada(caracter) == true) //Comprueba que es una vocal abierta o una vocal cerrada
            {
                res = true; //Si es una vocal abierta o una cerrada se cambia el valor a true
            }
            return res; //Se devuelve la comprobación
        }
        
        public int analizarVocal(StringBuilder frase, int i) //Éste método sirve para analizar la palabra en el caso de que el índice acabe en vocal
        {
            int res = i;
            if (getColumnas() == 1) //Si las columnas definidas por el usuario es 1
            {
                res = i; //la variable res es igual a i
            }
            //En el caso de que la palabra contenga vocal-consonante-vocal ó es vocal-consonante-consonante-vocal
            else if ((i < frase.Length - 2 && esVocal(frase[i + 1]) == false && esVocal(frase[i + 2]) == true && esSeparador(frase[i + 1]) == false && esSignoDePuntuacion(frase[i + 1]) == false)
                || (i < frase.Length - 3 && esConsonanteDoble(frase, i + 1) == true && esVocal(frase[i + 3]) == true))
            {
                res = i; //la variable res es igual a i
            }
            //En el caso de que la palabra contenga vocal-consonante-consonante-vocal ó es vocal-consonante-consonante-consonante-vocal
            else if ((i >= 3 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == true 
                && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false 
                && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false)
              || (i >= 4 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == false && esVocal(frase[i - 4]) == true 
              && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false && esSeparador(frase[i - 3]) == false)
              && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false && esSignoDePuntuacion(frase[i - 3]) == false)
            {
                res = i - 2; //la variable res es igual a i - 2 
                if (frase[i - 1].Equals('r') || frase[i - 1].Equals('l') || esConsonanteDoble(frase, i - 1)) //En el caso de que la consonante anterior se r, l o consonante doble
                {
                    res = i - 3; //la variable res es igual a i - 3
                }
            }
            //En el caso de que sea vocal-consonante-consonante-consonante-consonante-vocal
            else if (i >= 5 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == false && esVocal(frase[i - 4]) == false && esVocal(frase[i - 5]) == true
                && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false && esSeparador(frase[i - 3]) == false && esSeparador(frase[i - 4]) == false
                && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false && esSignoDePuntuacion(frase[i - 3]) == false && esSignoDePuntuacion(frase[i - 4]) == false)
            {
                res = i - 3; //la variable res es igual a i - 3
            }
            else if (i < frase.Length && esVocal(frase[i + 1]) == true && (esVocalAbierta(frase[i]) == false || esVocalAbierta(frase[i + 1]) == false)) //En el caso de que sean dos vocales consecutivas, siendo una cerrada y otra abierta o las dos cerradas
            {
                res = i - 1; //la variable res es igual a i - 1
                
                if (esAcentuada(frase[i]) == true || esAcentuada(frase[i + 1]) == true) //Si alguna de esas vocales son acentuadas
                {
                    res = i; //res es igual a i   
                }
                else if (i > 0 && esVocalAbierta(frase[i]) == true && esVocalCerrada(frase[i + 1]) == true && esVocalCerrada(frase[i - 1]) == true) //Si se vocal cerrada-vocal abierta-vocal cerrada
                {
                    res = i - 2; //el valor de res es igual a i - 2
                }
            }
            else if (i >= 2 && esVocalAbierta(frase[i]) == true && esVocalAbierta(frase[i - 1]) == true) //En el caso de que sean dos vocales abiertas consecutivas
            {
                res = i - 1; //res es igual a i - 1
            }
            if (res == frase.Length - 2 && getColumnas() != 1) //En el caso de que esté finalizando la frase y las columnas definidas por el usuario sea distinto de 1
            {
                res = analizarVocal(frase, getUltimaSilaba()); //Se hace uso de la recursividad para volver a la silaba anterior y así realizar un análisis
                if (i - res > getColumnas()) //Si resulta que la diferencia entre i y res es mayor que las columnas definidas por le usuario
                {
                    res = i; //El valor de res es igual a i
                }
            }
            return res; //Se devuelve el número tipo int escogido
        }
        
        public int analizarConsonante(StringBuilder frase, int i) //Éste método sirve para analizar la palabra en el caso de que el índice acabe en una consonante
        {
            int res = i; //El valor por defecto de res es igual a i
            if (getColumnas() == 1) //En el caso de que las columnas definidas por el usuario es 1
            {
                res = i; //el valor de res es igual a i
            }
            else if (i < frase.Length - 1 && esVocal(frase[i + 1]) == true)//En el caso de que sea consonante-vocal
            {
                if (i >= 1 && esVocal(frase[i - 1]) == true) //Si es vocal-consonante-vocal
                {
                    res = i - 1; //el valor de res es igual a i - 1
                }
                //En el caso de que sea vocal-consonante-vocal ó vocal-consonante-consonante-vocal
                else if ((i >= 2 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == true 
                    && esSeparador(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 1]) == false)
                  || (i >= 3 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == true 
                  && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false)
                  && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false)
                {
                    res = i - 1; //el valor de res es igual a i - 1
                    if (frase[i].Equals('r') || frase[i].Equals('l') || esConsonanteDoble(frase, i)) //En el caso de que i sea r, l o consonante doble
                    {
                        res = i - 2; //el valor de res es igual a i - 2
                    }
                }
                //En el caso de que sea vocal-consonante-consonante-consonante-vocal
                else if (i >= 4 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == false && esVocal(frase[i - 4]) == true 
                    && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false && esSeparador(frase[i - 3]) == false
                    && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false && esSignoDePuntuacion(frase[i - 3]) == false)
                {
                    
                    res = i - 2; //el valor de res es igual a i - 2
                }
            }
            //En el caso de que sea consonante-consonante-vocal
            else if (i < frase.Length - 2 && esVocal(frase[i + 1]) == false && esVocal(frase[i + 2]) == true 
                && esSeparador(frase[i + 1]) == false && esSignoDePuntuacion(frase[i - 1]) == false)
            {
                //Si es vocal-consonante-consonante-vocal ó vocal-consonante-consonante-consonante-vocal
                if ((i >= 1 && esVocal(frase[i - 1]) == true)
                    || (i >= 2 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == true 
                    && esSeparador(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 1]) == false))
                {
                    res = i; //el valor de res es i
                    if (frase[i + 1].Equals('r') || frase[i + 1].Equals('l') || esConsonanteDoble(frase, i)) //Si i + 1 es r o l, o i es consonante doble
                    {
                        res = i - 1; //el valor de res es igual a i - 1
                    }
                }
                //En el caso de que sea vocal-consonante-consonante-consonante-consonante-vocal
                else if (i >= 3 && esVocal(frase[i - 1]) == false && esVocal(frase[i - 2]) == false && esVocal(frase[i - 3]) == true 
                    && esSeparador(frase[i - 1]) == false && esSeparador(frase[i - 2]) == false
                    && esSignoDePuntuacion(frase[i - 1]) == false && esSignoDePuntuacion(frase[i - 2]) == false)
                {
                    res = i - 1; //el valor de res es igual a i - 1
                }
            }
            if (res == frase.Length - 2 && getColumnas() != 1) //En el caso de que llegue esté finalizando la frase y las columnas definidas por el usuario sea distinto de 1
            {
                
                res = analizarVocal(frase, getUltimaSilaba()); //utilizo recursividad para volver a la sílaba anterior y así realizar un análisis
                if (i - res > getColumnas()) //Si la diferencia entre i y res es mayor que las columnas definidas por el usuario
                {
                    res = i; //el valor de res es igual a i
                }
            }
            return res; //se devuelve el número tipo int escogido
        }
        
        public Boolean esConsonanteDoble(StringBuilder frase, int i) //Este método comprueba si existe una consonante doble
        {
            Boolean res = false; //Su valor por defecto es false
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
            return res; //Se devuelve la comprobación
        }
        
        public Boolean esVocalAbierta(char c) //Éste método sirve para comprobar si un carácter es vocal abierta
        {
            Boolean res = false; //Se inicializa como falso
            String caracter = c.ToString().ToLower(); //Forzamos a que el carácter esté en minúsculas
            if (caracter.Equals("a") || caracter.Equals("e") || caracter.Equals("o") || caracter.Equals("á") || caracter.Equals("é") || caracter.Equals("ó")) //Comprobamos que es una vocal abierta, incluyendo vocales abiertas y acentuadas
            {
                res = true; //en el caso de que sea una vocal abierta se cambia el valor a true
            }
            return res; //Se devuelve la comprobación
        }
        
        public Boolean esVocalCerrada(char c) //Éste método sirve para comprobar si un carácter es vocal cerrada
        {
            Boolean res = false; //Se inicializa como falso
            String caracter = c.ToString().ToLower(); //Forzamos a que el carácter esté en minúsculas
            if (caracter.Equals("u") || caracter.Equals("i") || caracter.Equals("ú") || caracter.Equals("í")) //Comprobamos que es una vocal cerrada, incluyendo vocales cerradas y acentuadas
            {
                res = true; //en caso de que sea una vocal cerrada se cambia el valor a true
            }
            return res; //Se devuelve la comprobación
        }
        public Boolean esAcentuada(char c) //Este método comprueba si el carácter es acentuado
        {
            Boolean res = false; //Su valor por defecto es false
            String caracter = c.ToString().ToLower();  //Forzamos a que el carácter sea minúscula
            if (caracter.Equals("á") || caracter.Equals("é") || caracter.Equals("í") || caracter.Equals("ó") || caracter.Equals("ú")) //Se compruba que es acentuada
            {
                res = true; //si lo es se cambia el valor a true
            }
            return res; //Se devuelve la comprobación
        }
        
        public String transformar(StringBuilder frase) //Este método se utiliza para adaptar la frase dividida a los carácteres de html
        {
            //Creamos un array de String a partir de la cadena, dividiendo por cada carácter '\n' encontrado
            String[] palabras = frase.ToString().Split('\n');
            String res = "";
            foreach (String i in palabras) //Recorremos el contenido del array
            {
                res = res + "<br>" + i; //y formamos la frase sustituyendo '\n' por '<br>', el cual es el salto de línea de html
            }
            return res; //Devolvemos la frase reconstruida
        }
    }
}