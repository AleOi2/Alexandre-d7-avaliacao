using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Alexandre_d7_avaliacao.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _username, _password;

        public string username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("username"); }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("password"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //C# 6 null-safe operator. No need to check for event listeners
            //If there are no listeners, this will be a noop
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SubmitCommand { get; set; }

        public MainWindowViewModel()
        {
            SubmitCommand = new RelayCommand(o => MainButtonClick());
        }
        private void MainButtonClick(object sender)
        {
            MessageBox.Show(sender.ToString());
         }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter ?? "<N/A>");
        }

    }
}


