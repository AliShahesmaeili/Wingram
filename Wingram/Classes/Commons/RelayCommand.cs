using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wingram.Classes.Commons
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool> canexecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
            _canExecute = canexecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object p = null)
        {
            if (_canExecute != null)
            {
                try
                {
                    return _canExecute();
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public void Execute(object p = null)
        {
            if (!CanExecute(p))
            {
                return;
            }

            try { _execute(); }
            catch { Debugger.Break(); }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute, Func<T, bool> canexecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
            _canExecute = canexecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object p)
        {
            if (_canExecute != null)
            {
                try
                {
                    return _canExecute(ConvertParameterValue(p));
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public void Execute(object p)
        {
            if (!CanExecute(p))
            {
                return;
            }

            _execute(ConvertParameterValue(p));
        }

        private static T ConvertParameterValue(object parameter)
        {
            //parameter = parameter is T ? parameter : Convert.ChangeType(parameter, typeof(T));
            return (T)parameter;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
