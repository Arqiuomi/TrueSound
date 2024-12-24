using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TrueSound.model;
using TrueSound.Model;
using TrueSound.view;
using TrueSound.View;

namespace TrueSound.ViewModel
{
    public class OpenViewModel : BaseViewModel
    {
        private OpenWindowModel _open;

        public DelegateCommand CheckRegCommand { get; }
        //public DelegateCommand <object> CheckFocusCommand { get; } 
        public DelegateCommand<object> RegLogMoveCommand { get; }

        public OpenViewModel()
        {
            _open = new OpenWindowModel();
            CheckRegCommand = new DelegateCommand(CheckRegEntrance);
            RegLogMoveCommand = new DelegateCommand<object>(RegLogMove);
            //CheckFocusCommand = new DelegateCommand<object>(IfGotFocus);
        }

        public void CheckRegEntrance()
        {
            if (DB.validUser(Name, Password))
            {
                MainWindow mainWindow = new MainWindow(this);
                mainWindow.Show();
                CloseWindow("OpenW");
            }
            else
            {
                //предупреждение, если введены неверные данные
                MessageBox.Show("Проверьте имя пользователя и пароль", "", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        
        public void RegLogMove(object windowName)
        {
            if (windowName.ToString() == "OpenW")
            {
                RegWindow regWindow = new RegWindow(this);
                regWindow.Show();
                CloseWindow("OpenW");
            }
            else
            {
                OpenWindow openWindow = new OpenWindow(this);
                openWindow.Show();
                CloseWindow("RegW");
            }

        }

        public bool CorrectRegChecker(string password, string passwordCopy)
            {
            return password == passwordCopy;
            }

        private void CloseWindow(string windowName)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Name == windowName)
                {
                    window.Close();
                }
            }
        }

        //public void IfGotFocus(object sender, RoutedEventArgs e)
        //{
        //    var box = sender as TextBox;
        //    if (box.Text == "Имя пользователя")
        //        box.Text = "";
        //}


        public string Email
        {
            get { return _open.Email; }
            set
            {
                _open.Email = value;
                OnPropertyChanged(nameof(Email));
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

        public string PasswordCopy
        {
            get { return _open.PasswordCopy; }

            set
            {
                _open.PasswordCopy = value;
                OnPropertyChanged(nameof(PasswordCopy));
            }
        }
    }
}
