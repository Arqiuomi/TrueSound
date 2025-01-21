using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TrueSound.view;
using TrueSound.View;
using TrueSound.model;
using TrueSound.Model;
namespace TrueSound.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        private MainWindowModel _main;
        public DelegateCommand ProfileCommand { get; }
        public DelegateCommand LibraryCommand { get; }
        public DelegateCommand PlayerCommand { get; }
        public DelegateCommand SettingCommand { get; }


        public MainViewModel(OpenViewModel vm) 
        {
            _main = new MainWindowModel(vm);
            ProfileCommand = new DelegateCommand(OnProfileCommand);
            LibraryCommand = new DelegateCommand(OnLibraryCommand);
            PlayerCommand = new DelegateCommand(OnPlayerCommand);
        }

        private void OnProfileCommand()
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            pageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            UserPage userPage = new UserPage(this); //передали тот самый объект vm из конструктора ; создать конструктор для vm юзера
            pageSwitcher.Content = userPage;
        }

        private void OnLibraryCommand()
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            pageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            LibraryPage libraryPage = new LibraryPage(this); //передали тот самый объект vm из конструктора ; создать конструктор для vm юзера
            pageSwitcher.Content = libraryPage;
        }
        private void OnPlayerCommand()
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            pageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            PlayerPage playerPage = new PlayerPage(this); //передали тот самый объект vm из конструктора ; создать конструктор для vm юзера
            pageSwitcher.Content = playerPage;
        }


        public string Name
        {
            get { return _main.Name; }
            set
            {
                _main.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
