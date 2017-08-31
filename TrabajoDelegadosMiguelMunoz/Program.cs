using System;

/// <summary>
/// Queremos que por cada numero que se esté procesando en el metodo GetNumber de
/// la classe Numero salga por pantalla > $"Procesando {Numero}"
/// </summary>
namespace TrabajoDelegadosMiguelMunoz
{
    class Program
    {
        // Declaration del delegado (ici Action delegue propose par le .net framework)
        static Action Fin = () => {
            Console.WriteLine($"<Enter> para salir...");
            Console.ReadLine();
        };

        // Punto de entrada 
        static void Main(string[] args)
        {
            Numeros N = new Numeros();
            var List = N.GetNumber(10);

            foreach (var item in List)
            {
                Console.WriteLine(item);
            }

            // Appel du delegué (pas de paramettres)
            Fin();
        }
    }
}