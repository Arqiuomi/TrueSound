using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TrueSound.ViewModel;


namespace TrueSound.view
{
    /// <summary>
    /// Логика взаимодействия для OpenWindow.xaml
    /// </summary>
    public partial class OpenWindow : Window
    {
        public OpenWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            model.User user = (model.User)this.Resources["NewUser"];
            user.Password=PassBox.Password; //костыль
            if (ViewModel.RegistrationChecker.checkReg(user.Name, user.Password))
            {
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                //предупреждение, если введены неверные данные
                MessageBox.Show("Проверьте имя пользователя и пароль","", MessageBoxButton.OK,MessageBoxImage.Hand);
            }
        }
        
        private void NameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == "Имя пользователя")
                NameBox.Text = "";
        }
        private void NameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == "")
                NameBox.Text = "Имя пользователя";
        }
    }
}
