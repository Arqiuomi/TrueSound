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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrueSound.model;

namespace TrueSound.view
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        
        public UserPage(User user)
        {
            InitializeComponent();
            this.Resources["NewUser"] = user;
            MessageBox.Show($"{user.Name}");
            MessageBox.Show($"{((User)this.Resources["NewUser"]).Name}");
            //NameBox.Text =user.Name;
            NameBox.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow openWindow = new OpenWindow();
            openWindow.Show();
            Application.Current.Windows[0].Close();
        }
    }
}
