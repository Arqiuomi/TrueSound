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
using TrueSound.ViewModel;

namespace TrueSound.view
{
    public partial class UserPage : Page
    {
        public UserPage()
        { 
            InitializeComponent();
        }

            public UserPage(OpenViewModel vm)
        {
            InitializeComponent();
            NameBox.Text = vm.Name;
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
