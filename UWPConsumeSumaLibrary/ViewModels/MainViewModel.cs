using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SumaLibrary;

namespace UWPConsumeSumaLibrary.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        // Dividendo
        private int Number_A = 0;
        public int NumberA
        {
            get { return Number_A; }
            set
            {
                Number_A = value;
                OnPropertyChanged("NumberA");
            }
        }

        // Divisor
        private int Number_B = 0;
        public int NumberB
        {
            get { return Number_B; }
            set
            {
                Number_B = value;
                OnPropertyChanged("NumberB");
            }
        }

        // Resultado
        private string Number_Resultado = string.Empty;
        public string NumberResultado
        {
            get { return Number_Resultado; }
            set
            {
                Number_Resultado = value;
                OnPropertyChanged("NumberResultado");
            }
        }

        SumaLibrary.MyLib LibreriaSuma = new MyLib();

        public MainViewModel()
        {
            NumberA = 20; //test bindig
            NumberB = 10;

            var result = Convert.ToString(LibreriaSuma.Divide(NumberA, NumberB));

            NumberResultado = $"Cociente resultado : {result}";
        }
    }
}
