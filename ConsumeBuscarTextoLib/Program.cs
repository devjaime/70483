using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaTextoLib;

namespace ConsumeBuscarTextoLib
{
    public class Program
    {
        static void Main(string[] args)
        {

            Buscar(@"C:\datos", "delegate");


        }

        public static string Buscar(string camino, string cadena)
        {
            Leer leer = new Leer(camino, cadena);

            leer.TextoEncontrado += Leer_TextoEncontrado;

            return string.Empty;
        }

        private static void Leer_TextoEncontrado(object o, EncontradoEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void Buscar(string path, string texto)

            Leer Lectura = new Leer(path, texto);

            //Leer.TextoEncontrado += (object o, EventArgs e) =>
            //{
            //    //var encontrado = $"{e}, linea {Linea} columna {Columna}"; // C:\datos\program.cs, linea 23, columna 35
            //};

            //Leer.Busca(path, texto);

           
        }
    }
}
