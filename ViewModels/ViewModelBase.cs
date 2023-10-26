using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUDO.ViewModels
{
    /// <summary>
    /// The class that is to be inherited by the other ViewModels classes 
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The method that requires to the different ViewModels to read off if the Property that´s BINDAD has been changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
