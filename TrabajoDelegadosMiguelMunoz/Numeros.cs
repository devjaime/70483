using System.Collections.Generic;
using static System.Console;

namespace TrabajoDelegadosMiguelMunoz
{
    public class Numeros
    {
        delegate void Rien(int z);

        /// <summary>
        /// Retorna una lista de n enteros pares comprendida entre 0 y n.
        /// </summary>
        /// <param name="Max">Valor entero maximo</param>
        /// <returns>Lista de enteros pares.</returns>
        public List<int> GetNumber(int Max)
        {
            Rien R = Tarea;

            List<int> ListaNumeros = new List<int>();
            for (int i = 0; i < Max; i++)
            {
                R?.Invoke(i);

                if (i % 2 == 0)
                {
                    ListaNumeros.Add(i);
                    System.Threading.Thread.Sleep(10000);
                }
            }
            return ListaNumeros;
        }

        /// <summary>
        /// Pasa por pantalla la tarea empezada.
        /// </summary>
        /// <param name="i">Numero de tarea</param>
        void Tarea(int i)
        {
            WriteLine($" Procesando {i}");
        }
    }
}