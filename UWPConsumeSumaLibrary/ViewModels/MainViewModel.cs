using System;
using SumaLibrary;
using System.Windows.Input;

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

        public ICommand CalculaCommand { get; private set; }

        public MainViewModel()
        {
            CalculaCommand = new Commands.RelayCommand(CalcularOperacion);
        }

        string R = string.Empty;

        private void CalcularOperacion()
        {
            SumaLibrary.MyLib Calculador = new MyLib();
            Calculador.DivisionPorCero = DivididoPorCero;

            NumberResultado = Calculador.Divide(NumberA, NumberB).ToString();

            NumberResultado = (NumberResultado != "0") ? NumberResultado : R;
        }

        private void DivididoPorCero(int A, int B)
        {
            R = $"Division por 0 : {A} / {B}";
        }
    }
}
