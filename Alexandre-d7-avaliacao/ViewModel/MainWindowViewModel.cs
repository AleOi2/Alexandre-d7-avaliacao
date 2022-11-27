using Alexandre_d7_avaliacao.Model;
using Alexandre_d7_avaliacao.Services;
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
            SubmitCommand = new RelayCommand(o => MainButtonClick("SubmitCommand"));
        }

        private readonly Context context;

        public MainWindowViewModel(Context context)
        {
            SubmitCommand = new RelayCommand(o => MainButtonClick("SubmitCommand"));
            this.context = context;
        }

        private void MainButtonClick(object sender)
        {
            var retrivedUser= context.Users.Where(u => u.username == username && u.password == password).FirstOrDefault<User>();
            if (retrivedUser?.username == username)
            {
                MessageBox.Show("Usuário autenticado");
            } else
            {
                MessageBox.Show("Credenciais inválidas");
            }

        }
    }


}


