using System;
using System.Windows.Input;

namespace StudentInfoSystem
{
    public class RelayCommand<T> : ICommand
    {
        private Action<T> _action;

        public RelayCommand(Action<T> action)
        {
            _action = action;
        }

        public bool CanExecute(object param)
        {
            return true;
        }

        public void Execute(object param)
        {
            _action((T)param);
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 67
    }
}
