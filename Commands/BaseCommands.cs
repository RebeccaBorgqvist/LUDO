using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LUDO.Commands
{
    /// <summary>
    /// A class to be inherited by another command-classes. The commands are used for navigating in the game (buttons for example)
    /// ICommand is inherited to be able to connect ViewModel-methods with UI. 
    /// </summary>
    internal abstract class BaseCommands : ICommand 
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in itss current state
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>true if this command can be executed; otherwise, false</returns>
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object parameter);
    }
}
