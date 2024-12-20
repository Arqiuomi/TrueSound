using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrueSound.model;
using TrueSound.Model;

namespace TrueSound.ViewModel
{
    public class OpenViewModel : BaseViewModel
    {
        private OpenWindowModel _open;

        public DelegateCommand CheckRegCommand { get; }


        public OpenViewModel()
        {
            _open = new OpenWindowModel();
            CheckRegCommand = new DelegateCommand(CheckReg);
        }
        public void CheckReg()
        {
            if (ViewModel.RegistrationChecker.checkReg(Name, Password))
            {
                MainWindowModel mainWindowModel = new MainWindowModel();
                //mainWindow.Show();
                //this.Close();
            }
            else
            {
                //предупреждение, если введены неверные данные
                MessageBox.Show("Проверьте имя пользователя и пароль", "", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        public string Name
        {
            get { return _open.Name; }
            set
            {
                _open.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Password
        {
            get { return _open.Password; }

            set 
            {
                _open.Password = value; 
                OnPropertyChanged(nameof(Password)); 
            }
        }
    }
}
