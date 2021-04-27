using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace TourPlanner.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {

        private string _output = "Not clicked";

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ExecuteCommand { get; }
        public ICommand OpenAddTourView { get; }

        public MainViewModel()
        {
            Debug.Print("ctor MainViewModel");
            this.ExecuteCommand = new ExecuteCommand(this);
            this.OpenAddTourView = new OpenAddTourView(this);

        }

        public string Output
        {
            get
            {
                Debug.Print("read Output");
                return _output;
            }
            set
            {
                Debug.Print("write Output");
                Debug.Print("set Output");
                _output= value;
                Debug.Print("fire propertyChanged: Output");
                OnPropertyChanged();

            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.Print($"propertyChanged \"{propertyName}\"");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
