using System;
using System.Diagnostics;
using System.Windows.Input;

namespace TourPlanner.ViewModels
{
    internal class OpenAddTourView : ICommand
    {
        private readonly MainViewModel _mainViewModel;

        public OpenAddTourView(MainViewModel mainViewModel)
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
            Views.AddTour subWindow = new Views.AddTour();
            subWindow.Show();
            Debug.Print("command: execute done");

        }
    }
}