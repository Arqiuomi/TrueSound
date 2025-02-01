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
using System.Windows.Media.Imaging;
namespace TrueSound.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        private MainWindowModel _main;
        public DelegateCommand ProfileCommand { get; }
        public DelegateCommand LibraryCommand { get; }
        public DelegateCommand PlayerCommand { get; }
        public DelegateCommand MyLikeCommand { get; }
        public DelegateCommand LikePressCommand { get; }  
        public DelegateCommand SearchCommand { get; }
        public DelegateCommand SearchFocusCommand { get; }




        public MainViewModel(OpenViewModel vm) 
        {
            _main = new MainWindowModel(vm);
            ProfileCommand = new DelegateCommand(OnProfileCommand);
            LibraryCommand = new DelegateCommand(OnLibraryCommand);
            PlayerCommand = new DelegateCommand(OnPlayerCommand);
            MyLikeCommand = new DelegateCommand(OnMyLikeCommand);
            LikePressCommand = new DelegateCommand(OnLikePressCommand);
            SearchCommand = new DelegateCommand(OnSearchCommand);
            SearchFocusCommand = new DelegateCommand(OnSearchFocusCommand);
            ImageSource = "image/like.png"; //сюда пойдет метод, есть песня в лайках или нет
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
            LibraryPage libraryPage = new LibraryPage(this);
            pageSwitcher.Content = libraryPage;
        }
        private void OnPlayerCommand()
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            pageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            PlayerPage playerPage = new PlayerPage(this);
            pageSwitcher.Content = playerPage;
        }

        private void OnMyLikeCommand()
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            pageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            MyLikePage myLikePage = new MyLikePage(this);
            pageSwitcher.Content = myLikePage;
        }

        private void OnLikePressCommand()
        {
            if (ImageSource == "image/like.png")
                ImageSource = "image/filledLike.png";
            else
                ImageSource = "image/like.png";
        }

        private void OnSearchCommand()
        {
            Search = "hi"; // тут срабатывает действие поиска - отправка запроса в парсер
        }
        private void OnSearchFocusCommand()
        {
            Search =string.Empty;
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

        public string Search
        {
            get { return _main.Search; }
            set
            {
                _main.Search = value;
                OnPropertyChanged(nameof(Search));
            }
        }

        public string ImageSource
        {
            get { return _main.ImageSource; }
            set
            {
                _main.ImageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

    }
}
