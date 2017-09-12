using System;
using System.IO;

#region [Specifications]

/*
Realizar un componente.Net que permita buscar un texto contenido 
en los archivos de un directorio.

Ejemplo:
Buscar delegate C:\datos<enter>

C:\datos\program.cs, linea 23, columna 35
C:\datos\program.cs, linea 23, columna 55

Debo poder ver el archivo que contiene el texto y cancelar si ya no quiero continuar la busqueda. 
Preguntar al usuario si desea continuar despues de haber encontrado un archivo.
La busqueda debe hacerse en el directorio y sub-directorios.
el componente debe de funcionar en una aplicacion de consola y WPF.

En consola: mostrar el resultado en la consola.
En WPF    : mostrar el resultado en un grid.
*/

#endregion

namespace BuscaTextoLib
{
    public class Leer
    {
        public delegate void EventHandler(object o, EncontradoEventArgs e);
        // event + tipo de delegado + nombre del evento
        public event EventHandler TextoEncontrado ;

        EncontradoEventArgs e = new EncontradoEventArgs();

        static int ocurrencias = 0;

        public int OcurrenciasEncontradas { get {return ocurrencias; } private set { } }

        /// <summary>
        /// Directorio de busqueda.
        /// </summary>
        public string PathDirectorio { get; private set; }

        /// <summary>
        /// Texto a buscar dentro de los archivos.
        /// </summary>
        public string TextToMatch { get; private set; }

        public Leer(string Direccion, string StringToSearch)
        {
            // Aqui hacer test para cadenas vacias y datos incorrectos !!!
            PathDirectorio = Direccion;

            if (!string.IsNullOrWhiteSpace(StringToSearch))
            {
                TextToMatch = StringToSearch;
                ocurrencias = 0;
            }
        }

        /// <summary>
        /// Busca un texto en el contenido de los archivos de un directorio
        /// </summary>
        /// <param name="Direccion">Directorio donde buscar</param>
        /// <param name="StringToSearch">Texto a buscar dentro de los archivos</param>
        public void Busca(string Direccion, string StringToSearch)
        {
            if (!string.IsNullOrEmpty(Direccion) && Directory.Exists(Direccion))
            {
                // Leo en los archivos.
                LeerEnArchivos(Direccion);

                // Buscando Sub-directorios.
                var CuantosSubDirrectorios = Directory.GetDirectories(Direccion);

                // Si encuentro.
                if (CuantosSubDirrectorios.Length > 0)
                {
                    // Iterando y buscando.
                    foreach (var directorio in CuantosSubDirrectorios)
                    {
                        Busca(directorio, StringToSearch);
                    }
                }
            }
        }

        /// <summary>
        /// Busqueda de texto en los archivos de un directorio.
        /// </summary>
        /// <param name="directorio"></param>
        void LeerEnArchivos(string directorio)
        {
            var ficheros = Directory.GetFiles(directorio);
            foreach (var fichero in ficheros)
            {
                var lineas = File.ReadAllLines(fichero);
                int i = 0;
                foreach (var line in lineas)
                {
                    i++;
                    if (line.Contains(TextToMatch))
                    {
                        e.OcurrenciasEncontradas = ++ocurrencias;
                        var Columna = line.IndexOf(TextToMatch).ToString();
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
        }
    }

    public class EncontradoEventArgs : EventArgs
    {
        public string Archivo { get; set; }
        public string Line { get; set; }
        public string Column { get; set; }
        public int OcurrenciasEncontradas { get; set; }
        public bool Cancelar { get; set; } = false;
    }
}