using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace TourPlanner.ViewModels
{
    class ExecuteCommand : ICommand
    {
        private readonly MainViewModel _mainViewModel;

        public ExecuteCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _mainViewModel.PropertyChanged += (sender, args) =>
            {
                Debug.Print("command: reveived prop changed");
                if (args.PropertyName == "Input")
                {
                    Debug.Print("command: reveived prop changed of Input");
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            Debug.Print("command: can execute");
            return true;
        }

        public void Execute(object parameter)
        {
            Debug.Print("command: execute");
            _mainViewModel.Output = "Command executed!!";
            Debug.Print("command: execute done");
        }
    }
}
