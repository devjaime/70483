using System.Windows;
using BuscaTextoLib;
using System.Collections.ObjectModel;
using System.Threading;

namespace BuscaTextoWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window 
    {
        ObservableCollection<Resultado> ResultadosBusqueda;

        public MainWindow()
        {
            InitializeComponent();
            ResultadosBusqueda = new ObservableCollection<Resultado>();
            DataContext = this;
        }

        private void Buscar(string pathFolder, string texto)
        {
            Leer Lectura = new Leer(pathFolder, texto);

            Lectura.TextoEncontrado += (o, e) =>
            {
                Thread.Sleep(1000); // Espera 1 segundo !

                var Result = new Resultado { Archivo = e.Archivo, Linea = e.Line, Columna = e.Column };

                ResultadosBusqueda.Add(Result);

                MiDataGrid.ItemsSource = ResultadosBusqueda;

                NumeroResultados.Content = $"Resultados : {e.OcurrenciasEncontradas.ToString()}";
                
                var result = MessageBox.Show("Seguir buscando ?","Buscar...",MessageBoxButton.YesNo);

                if (MessageBoxResult.Yes == result)
                {
                    e.Cancelar = false;
                }
                else
                {
                    e.Cancelar = true;
                }
            };

            Lectura.Busca(pathFolder, texto);
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            NumeroResultados.Content = $"Resultados : 0";
            ResultadosBusqueda.Clear();
            Buscar(TxtDirectorio.Text, TxtABuscar.Text);
        }
    }
}