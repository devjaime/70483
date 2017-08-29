using System;
using System.IO;

//Realizar un componente.Net que permita buscar un texto contenido en los archivos de un directorio.

//Ejemplo:
//Buscar delegate C:\datos<enter>

//C:\datos\program.cs, linea 23, columna 35
//C:\datos\program.cs, linea 23, columna 55

//Debo poder ver el archivo que contiene el texto y cancelar si ya no quiero continuar la busqueda. 
//Preguntar al usuario si desea continuar despues de haber encontrado un archivo.
//el componente debe de funcionar en una aplicacion de consola y WPF.

//En consola mostrar el resultado en la consola.
//En WPF mostrar el resultado en un grid.



namespace BuscaTextoLib
{

    public class LeeArchivos
    {
        public delegate void Encontrado(object o, EventArgs e);
        public event Encontrado TextoEncontrado ;

        public string DireccionDossier { get; private set; }

        public string TextToMatch { get; private set; }

        public LeeArchivos(string Direccion, string StringToSearch)
        {
            var Uri = new UriBuilder(AppContext.BaseDirectory).Uri.ToString();

            DireccionDossier = Direccion;
            TextToMatch = StringToSearch;
        }

        /// <summary>
        /// Busca el contenido de una string en los ficheros de una carpeta
        /// </summary>
        /// <param name="Direccion">Carpeta donde buscar</param>
        /// <param name="StringToSearch">Texto a buscar dentro de los ficheros</param>
        public void Busca(string Direccion, string StringToSearch)
        {
            var Path = (Direccion == string.Empty) ? new UriBuilder(AppContext.BaseDirectory).Uri.ToString() : Direccion;

            var Ficheros = Directory.GetFileSystemEntries(Path, StringToSearch, SearchOption.AllDirectories);

            foreach (var item in Ficheros)
            {
                StreamReader Reader = File.OpenText(item);
                while (!Reader.EndOfStream)
                {
                    var Linea = Reader.ReadLine();
                    if (Linea.Contains(StringToSearch))
                    {
                        var Columna = Linea.IndexOf(StringToSearch).ToString();

                        EncontradoEventArgs e = new EncontradoEventArgs() { Archivo = item, Line = Linea, Column = Columna, Cancelar=false };
                        if (!e.Cancelar)
                        {
                            TextoEncontrado?.Invoke(this, e);
                        }
                        

                        //var encontrado = $"{item}, linea {Linea} columna {Columna}"; // C:\datos\program.cs, linea 23, columna 35
                    }
                }
            }
        }
    }

    public class EncontradoEventArgs : EventArgs
    {
        public string Archivo { get; set; }
        public string Line { get; set; }
        public string Column { get; set; }
        public bool Cancelar { get; set; } = false;

        public EncontradoEventArgs():base()
        {

        }

        public EncontradoEventArgs(string MiArchivo, bool DeseaCancelar):base()
        {
            this.Archivo = MiArchivo;
            Cancelar = DeseaCancelar;
        }
    }
}
