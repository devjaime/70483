using System;
using System.IO;

/*Realizar un componente.Net que permita buscar un texto contenido en los archivos de un directorio.

//Ejemplo:
//Buscar delegate C:\datos<enter>

//C:\datos\program.cs, linea 23, columna 35
//C:\datos\program.cs, linea 23, columna 55

//Debo poder ver el archivo que contiene el texto y cancelar si ya no quiero continuar la busqueda. 
//Preguntar al usuario si desea continuar despues de haber encontrado un archivo.
//el componente debe de funcionar en una aplicacion de consola y WPF.

//En consola mostrar el resultado en la consola.
//En WPF mostrar el resultado en un grid.*/

namespace BuscaTextoLib
{
    public class Leer
    {
        public delegate void EventHandler(object o, EncontradoEventArgs e);

        // event + tipo de delegado + nombre del evento
        public event EventHandler TextoEncontrado ;

        EncontradoEventArgs e = new EncontradoEventArgs();

        public string DireccionDossier { get; private set; }

        public string TextToMatch { get; private set; }

        public Leer(string Direccion, string StringToSearch)
        {
            DireccionDossier = Direccion;
            TextToMatch = StringToSearch;
        }

        /// <summary>
        /// Busca el contenido de una string en los ficheros de una carpeta
        /// </summary>
        /// <param name="Direccion">Carpeta donde buscar</param>
        /// <param name="StringToSearch">Texto a buscar dentro de los ficheros</param>
        public  void Busca(string Direccion, string StringToSearch)
        {
            var ficheros = Directory.GetFiles(Direccion);

            foreach (var fichero in ficheros)
            {
                var lineas = File.ReadAllLines(fichero);

                int i = 0;

                foreach (var line in lineas)
                {
                    i++;
                    if (line.Contains(StringToSearch))
                    {
                        var Columna = line.IndexOf(StringToSearch).ToString();

                        e.Archivo = fichero;
                        e.Line = i.ToString();
                        e.Column = Columna;
                        
                        if (!e.Cancelar)
                        {
                            TextoEncontrado?.Invoke(this, e);
                        }
                    }
                }
            }

            // TODO: Hacer una funcion con recursividad para que tome en cuenta los ficheros de los directorios anidados.
            //foreach (var directorio in Directory.GetDirectories(Direccion))
            //{

            //}

        }
    }

    public class EncontradoEventArgs : EventArgs
    {
        public string Archivo { get; set; }
        public string Line { get; set; }
        public string Column { get; set; }
        public bool Cancelar { get; set; } = false;

        public EncontradoEventArgs()
        {

        }
    }
}