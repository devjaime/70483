using System;

/// <summary>
/// Queremos que por cada numero que se esté procesando en el metodo GetNumber de
/// la classe Numero salga por pantalla > $"Procesando {Numero}"
/// </summary>
namespace TrabajoDelegadosMiguelMunoz
{
    class Program
    {
        static Action Fin = () => {
            Console.WriteLine($"key to skip...");
            Console.ReadKey(true);
        };

        static void Main(string[] args)
        {
            Numeros N = new Numeros();

            N.DaElNumerodeTarea += (x) => {
                Console.WriteLine($"Tarea Empezada : {x}"); return x;
            };

            var List = N.GetNumber(10);

            foreach (var item in List)
            {
                Console.WriteLine(item);
            }

            Fin();
        }
    }
}