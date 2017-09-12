using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BuscaTextoWPF
{
    public class Resultado : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string elArchivo;
        public string Archivo
        {
            set
            {
                if (elArchivo != value)
                {
                    elArchivo = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return elArchivo;
            }
        }

        private string laLinea;
        public string Linea
        {
            set
            {
                if (laLinea != value)
                {
                    laLinea = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return laLinea;
            }
        }

        private string laColumna;
        public string Columna
        {
            set
            {
                if (laColumna != value)
                {
                    laColumna = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return laColumna;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Resultado()
        {
        }

        public override string ToString()
        {
            return $"{Archivo}, linea {Linea} columna {Columna}";
        }
    }
}