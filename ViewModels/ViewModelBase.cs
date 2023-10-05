using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged // Denna kod behöver man inte kunna ingående
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) // Denna metod behövs i olika ViewModels för att känna av om Propertyn ändras (Propertyn som har Bindats)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
