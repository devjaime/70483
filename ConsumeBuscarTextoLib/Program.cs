using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaTextoLib;
using static System.Console;

namespace ConsumeBuscarTextoLib
{
    public class Program
    {
        private const string PathFolder = "C:\\datos";
        private const string TextoToMatch = "delegado";

        static Action Fin = () => {
                WriteLine($"\nPresiona una tecla para salir...");
                ReadKey(true);
        };

        static void Main(string[] args)
        {
            Buscar(PathFolder, TextoToMatch);

            Fin();
        }

        static void Buscar(string pathFolder, string texto)
        { 
            Leer Lectura = new Leer(pathFolder, texto);

            Lectura.TextoEncontrado += (o, e) =>
            {
                var encontrado = $"{e.Archivo}, linea {e.Line} columna {e.Column}"; // C:\datos\program.cs, linea 23, columna 35
                WriteLine(encontrado);

                Write("Seguir buscando ? O/N\n");

                if (ReadKey(true).Key == ConsoleKey.O)
                {
                    // Retornar el parametro del eventargs a true y continuar.
                    
                    e.Cancelar = false;
                }
                else
                {
                    e.Cancelar = true;
                }
                
            };

            Lectura.Busca(PathFolder, TextoToMatch);
        }
    }
}