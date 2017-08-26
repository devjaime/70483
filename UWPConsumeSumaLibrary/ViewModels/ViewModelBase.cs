using System.ComponentModel;

namespace UWPConsumeSumaLibrary.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region -Implementation INotifyPropertyChanged-
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
