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
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace TrueSound.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private MainWindowModel _main;
        public DelegateCommand ProfileCommand { get; }
        public DelegateCommand LibraryCommand { get; }
        public DelegateCommand PlayerCommand { get; }
        public DelegateCommand MyLikeCommand { get; }
        public MediaPlayer player = new MediaPlayer(); //честно пытался вынести в модель



        public MainViewModel(OpenViewModel vm)
        {
            _main = new MainWindowModel(vm);
            ProfileCommand = new DelegateCommand(OnProfileCommand);
            LibraryCommand = new DelegateCommand(OnLibraryCommand);
            PlayerCommand = new DelegateCommand(OnPlayerCommand);
            MyLikeCommand = new DelegateCommand(OnMyLikeCommand);
            //UserImage = "View/image/user.png";
            
        }


        private void OnProfileCommand()
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            UserPage userPage = new UserPage(this); //передали тот самый объект vm из конструктора ; создать конструктор для vm юзера
            pageSwitcher.Content = userPage;
        }
        private void OnLibraryCommand()
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            //pageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden; 
            LibraryPage libraryPage = new LibraryPage(new LibraryViewModel(this));
            pageSwitcher.Content = libraryPage;
        }
        private void OnPlayerCommand()

        {
            PlayerViewModel playerVM;
            if (player.Source != null)
            {
                 playerVM = new PlayerViewModel(ref player, player.Position);
            } 
            else
            {
                 playerVM = new PlayerViewModel(ref player, 0, 0);
            }
                var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
                PlayerPage playerPage = new PlayerPage(playerVM);
                pageSwitcher.Content = playerPage;

        }

        private void OnMyLikeCommand()
        {
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            MyLikePage myLikePage = new MyLikePage(this);
            pageSwitcher.Content = myLikePage;
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

        public string UserImage
        {
            get
            { return _main.ImageUserSource; }
         
            set 
            {_main.ImageUserSource = value;
                OnPropertyChanged(nameof(UserImage));
            }
        }
    }
}
