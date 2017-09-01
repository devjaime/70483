using System;
using System.Collections.Generic;

namespace TrabajoDelegadosMiguelMunoz
{
    public class Numeros
    {
        /// <summary>
        /// Retorna una lista de n enteros pares comprendida entre 0 y n.
        /// </summary>
        /// <param name="Max">Valor entero maximo</param>
        /// <returns>Lista de enteros pares.</returns>
        public List<int> GetNumber(int Max , Action<int> TareaEmpezada)
        {
            List<int> ListaNumeros = new List<int>();
            for (int i = 0; i < Max; i++)
            {
                TareaEmpezada?.Invoke(i);

                if (i % 2 == 0)
                {
                    ListaNumeros.Add(i);
                    System.Threading.Thread.Sleep(2000);
                }
            }
            return ListaNumeros;
        }
    }
}