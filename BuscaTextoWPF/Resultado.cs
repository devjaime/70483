using System.ComponentModel;

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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Archivo"));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Linea"));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Columna"));
                }
            }
            get
            {
                return laColumna;
            }
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
