using System;
using static System.Console;

namespace ConsoleConsumeSumaLibrary
{
    class Program
    {
        static bool OtraDivision = true;

        static Action Fin = () => {
           
            Write("Hacer otra division ? O/N\n");

            if (ReadKey(true).Key == ConsoleKey.O)
            {
                OtraDivision = true;
            }
            else
            {
                OtraDivision = false;
                WriteLine($"\nPulsa una tecla para salir...");
                ReadKey(true);
            }
        };

        static void Main(string[] args)
        {
            // Consume el método de la Biblioteca de Clases y muestra el resultado de la división. 
            Tarea();
        }

        /// <summary>
        /// Devuelve el entero solicitado.
        /// </summary>
        /// <param name="request">Solicitacion de numero</param>
        /// <returns>Entero entrado por pantalla</returns>
        static int DataInput(string request)
        {
            int Numero = 0;
            bool ok = false;

            while (!ok)
            {
                Write(request);

                try
                {
                    Numero = Convert.ToInt32(ReadLine());
                    ok = true;
                }
                catch (Exception egeneral)
                {
                    WriteLine($"Se te ha dicho que digites un numero !!!\n{egeneral.Message}");
                }
            }
            
            return Numero;
        }

        static void Tarea()
        {
            while (OtraDivision)
            {
                SumaLibrary.MyLib myLib = new SumaLibrary.MyLib();
                myLib.DivisionPorCero += MyLib_DivisionPorCero;

                var A = DataInput("Entra un Dividendo: ");
                var B = DataInput("Entra un Divisor  : ");
                var Resultado = myLib.Divide(A, B);

                WriteLine($"Cociente resultado : {Resultado}");

                myLib.DivisionPorCero -= MyLib_DivisionPorCero;

                // Termina ?
                Fin();
            }
        }

        private static void MyLib_DivisionPorCero(int arg1, int arg2)
        {
            WriteLine($"División por cero ! {arg1} con {arg2} ");
        }
    }
}