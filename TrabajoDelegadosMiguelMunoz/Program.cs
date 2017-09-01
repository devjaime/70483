using System;

/// <summary>
/// Queremos que por cada numero que se esté procesando en el metodo GetNumber de
/// la classe Numero salga por pantalla > $"Procesando {Numero}"
/// </summary>
namespace TrabajoDelegadosMiguelMunoz
{
    class Program
    {
        // Declaracion del delegado Action es un delegado predefinido por el .net framework
        // al igual que Func y Predicate.
        // Aqui > Declaracion + instantiacion ! (ejemplo pequeño utilizado al terminar el programa)
        static Action Fin = () => {
            Console.WriteLine($" <Enter> para salir...");
            Console.ReadLine();
        };

        static void Main(string[] args)
        {
            // Creacion del delegado.
            Action<int> TareaEmpezada = MuestraTareaEmpezada; 

            Numeros N = new Numeros();

            // Pasando el delegado a la funcion.
            var List = N.GetNumber(10, TareaEmpezada); 

            // Muestra los resultados de N.Getnumber.
            foreach (var item in List)
            {
                Console.WriteLine($" {item}");
            }

            // LLama al delegado de fin de programa.
            Fin();
        }

        /// <summary>
        /// Muestra la tarea que se empezo a procesar.
        /// </summary>
        /// <param name="numeroTarea">Entero de 1 a n devuelto por GetNumber</param>
        private static void MuestraTareaEmpezada(int numeroTarea)
        {
            Console.WriteLine($" Procesando {numeroTarea}");
        }
    }
}