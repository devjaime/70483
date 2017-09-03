using System;

namespace SumaLibrary
{
    public class MyLib
    {
        public Action<int,int> DivisionPorCero;

        /// <summary>
        /// Devuelve el resultado de la división de A por B.
        /// </summary>
        /// <param name="A">Dividendo</param>
        /// <param name="B">Divisor</param>
        /// <returns>Cociente de la division, cero si el divisor es 0</returns>
        public int Divide(int A, int B)
        {
            int Resultado = 0;

            if (B != 0)
            {
                Resultado =  A / B;
            }
            else
            {
                DivisionPorCero?.Invoke(A, B);
            }
                
            return Resultado;
        }
    }
}