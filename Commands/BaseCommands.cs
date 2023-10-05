using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LUDO.Commands
{
    internal abstract class BaseCommands : ICommand // ICommand används för att koppla ViewModel metoder och UI med varandra, kan ärvas till flera klasser med tex knappar(button).
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
    }
}
