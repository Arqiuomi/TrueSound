using System.Text;
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
using TrueSound.view;
using TrueSound.ViewModel;

namespace TrueSound
{

    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }


        public MainWindow(OpenViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void LibraryBtn_Click(object sender, RoutedEventArgs e)
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            PageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden; //убираем стрелочки-навигации между страницами свитчера
            LibraryPage buttonFrame = new ();
            pageSwitcher.Content = buttonFrame;

        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            PageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden; //убираем стрелочки-навигации между страницами свитчера
            UserPage userPage = new UserPage((OpenViewModel)this.DataContext); //передали тот самый объект vm из конструктора
            pageSwitcher.Content=userPage;
        }
    }
}