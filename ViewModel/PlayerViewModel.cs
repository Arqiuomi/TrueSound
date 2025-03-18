using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueSound.Model;
using TrueSound.view;
using System.Windows;
using System.Windows.Controls;
using TrueSound.View;
using TrueSound.model;
using System.Windows.Media;
using TagLib;
using System.IO;
using System.Windows.Media.Imaging;
using TagLib.Mpeg;
using System.Windows.Threading;
using System.Numerics;

namespace TrueSound.ViewModel
{
    public class PlayerViewModel: BaseViewModel
    {
        private PlayerModel _m;
        private MediaPlayer _player;
        private BitmapImage albumCover;
        public DelegateCommand LikePressCommand { get; }
        public DelegateCommand VolPressCommand { get; }
        public DelegateCommand PlayPauseCommand { get; }
        public DelegateCommand ForwardCommand { get; }
        public DelegateCommand BackCommand { get; }
        private bool _playStatus { get; set; }=false;
        private double _sliderValue;
        private double _maxSliderValue;
        private DispatcherTimer _timer;

        public PlayerViewModel() 
        {
            _m = new PlayerModel();
            _player = new MediaPlayer();
            LikePressCommand = new DelegateCommand(OnLikePressCommand);
            VolPressCommand = new DelegateCommand(OnVolPressCommand);
            PlayPauseCommand = new DelegateCommand(OnPlayPauseCommand);
        }
     
        public PlayerViewModel(int albumNum = 0) //конструктор, если трек не играет
        {
            _m = new PlayerModel(albumNum);
            _player = new MediaPlayer();
            SetPlayer(trackNum);
            //_player.Play();
            LikePressCommand = new DelegateCommand(OnLikePressCommand);
            VolPressCommand = new DelegateCommand(OnVolPressCommand);
            PlayPauseCommand = new DelegateCommand(OnPlayPauseCommand);
            ForwardCommand = new DelegateCommand(OnForwardCommand);
            BackCommand = new DelegateCommand(OnBackCommand);
        }
        public PlayerViewModel(ref MediaPlayer player, int albumNum = 0, int trackNum = 0) //конструктор, если трек играет
        {
            _m = new PlayerModel(albumNum, trackNum);
            _player = player;
            SetPlayer(albumNum);
            //_player.Play();
            LikePressCommand = new DelegateCommand(OnLikePressCommand);
            VolPressCommand = new DelegateCommand(OnVolPressCommand);
            PlayPauseCommand = new DelegateCommand(OnPlayPauseCommand);
            ForwardCommand = new DelegateCommand(OnForwardCommand);
            BackCommand = new DelegateCommand(OnBackCommand);
        }

        public PlayerViewModel(ref MediaPlayer player, TimeSpan time) //конструктор, если трек играет
        {
            _player = player;
            _m = new PlayerModel(_player.Source.ToString());
            UpdatePlayer(time);
            LikePressCommand = new DelegateCommand(OnLikePressCommand);
            VolPressCommand = new DelegateCommand(OnVolPressCommand);
            PlayPauseCommand = new DelegateCommand(OnPlayPauseCommand);
            ForwardCommand = new DelegateCommand(OnForwardCommand);
            BackCommand = new DelegateCommand(OnBackCommand);
        }



        //public PlayerViewModel(int trackNum, DispatcherTimer timer) //конструктор, если трек играет
        //{
        //    _m = new PlayerModel();
        //    _player = new MediaPlayer();
        //    LikePressCommand = new DelegateCommand(OnLikePressCommand);
        //    VolPressCommand = new DelegateCommand(OnVolPressCommand);
        //    PlayPauseCommand = new DelegateCommand(OnPlayPauseCommand);
        //}



        private void SetPlayer(int albumNum)
        {
            _player.Open(new Uri(TrackList[trackNum], UriKind.Relative));
            //var t = _player;
            IsMax();
            CreateTimer();
            LoadAlbumCover(TrackList[trackNum]);
        }
        private void UpdatePlayer(TimeSpan time)
        {
            LoadAlbumCover(_player.Source.ToString());
            UpdateTimer(time);
            IsMax(); 
        }

        private void LoadAlbumCover(string filePath)
        {

            var file = TagLib.File.Create(filePath);
            if (file.Tag.Pictures.Length > 0)
            {
                var picture = file.Tag.Pictures[0];
                using (var stream = new MemoryStream(picture.Data.Data))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    bitmap.Freeze(); 
                    AlbumCover = bitmap;
                }
            }
            else 
            {
                AlbumCover = new BitmapImage(new Uri("image/vinyl.png", UriKind.Relative));
            }
        }        
        public void IsMax()
        {
            //Обработчик, проверяющий, открыт ли файл
            //_player.MediaOpened += (s, e) =>
            //var t = _player.NaturalDuration;
            //var ht = t.TimeSpan;
            //MaxSliderValue = ht.TotalSeconds;
            MaxSliderValue = _player.NaturalDuration.TimeSpan.TotalSeconds;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            SliderValue = _player.Position.TotalSeconds; // Обновляем значение слайдера
            OnPropertyChanged(nameof(SliderTime)); // Уведомляем об изменении времени
            OnPropertyChanged(nameof(SliderLastTime)); // Уведомляем об изменении времени
        }
        private void CreateTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
        }

        private void UpdateTimer(TimeSpan time)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(time.TotalSeconds);
            _timer.Tick += Timer_Tick;
        }

        private void OnBackCommand()
        {
            _player.Close();
            if (trackNum>0)
                trackNum--;
            else
                trackNum = TrackList.Count()-1;
            SetPlayer(trackNum);
            _player.Play();
        }
        private void OnPlayPauseCommand() 
        {
            if (!_playStatus)
            {
                _player.Play();
                _playStatus = true;
                _timer.Start();
            }
            else
            {
                _player.Pause();
               _playStatus = false;
                _timer.Stop();
            }
        }
        private void OnForwardCommand()
        {
            _player.Close();
            if (TrackList.Count - 1 > trackNum)
                trackNum++;
            else
                trackNum = 0;
            SetPlayer(trackNum);
            _player.Play();
        }
        private void OnLikePressCommand()
        {
            if (ImageLikeSource == "image/like.png")
                ImageLikeSource = "image/filledlike.png";
            else
                ImageLikeSource = "image/like.png";
        }
        private void OnVolPressCommand()
        {
            if (ImageVolSource == "image/vol.png")
            {
                _player.IsMuted = true;
                ImageVolSource = "image/volmute.png";
            }
            else
            {
                _player.IsMuted = false;
                ImageVolSource = "image/vol.png";
            }
        }
        //private void OnProfileCommand()
        //{
        //    var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
        //    pageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        //    UserPage userPage = new UserPage(_mainViewModel); //передали тот самый объект vm из конструктора ; создать конструктор для vm юзера
        //    pageSwitcher.Content = userPage;
        //}
        //private void OnLibraryCommand()
        //{
        //    var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
        //    pageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        //    LibraryPage libraryPage = new LibraryPage(_mainViewModel);
        //    pageSwitcher.Content = libraryPage;
        //}
        //private void OnMyLikeCommand()
        //{
        //    var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
        //    pageSwitcher.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        //    MyLikePage myLikePage = new MyLikePage(_mainViewModel);
        //    pageSwitcher.Content = myLikePage;
        //}

        public int trackNum
        {

            get => _m.TrackNum;

            set => _m.TrackNum = value;
        }
        public List<string> TrackList
        {
            get => _m.TrackList;

            set => _m.TrackList = value;

        }
        public BitmapImage AlbumCover
        {
            get => albumCover;
            set
            {
                albumCover = value;
                OnPropertyChanged(nameof(AlbumCover));
            }
        }
        public string ImageLikeSource
        {
            get { return _m.ImageLikeSource; }
            set
            {
                _m.ImageLikeSource = value;
                OnPropertyChanged(nameof(ImageLikeSource));
            }
        }
        public string ImageVolSource
        {
            get { return _m.ImageVolSource; }
            set
            {
                _m.ImageVolSource = value;
                OnPropertyChanged(nameof(ImageVolSource));
            }
        }
        public decimal Volume
        {
            get { return (decimal)_player.Volume; }
            set
            {
                _player.Volume = (double)value;
                OnPropertyChanged(nameof(Volume));
                //автоматическое возвращение звука
                if (value == 0)
                {
                    _player.IsMuted = true;
                    ImageVolSource = _m.ImageVolMuteSource;
                }
                else
                {
                    _player.IsMuted = false;
                    ImageVolSource = _m.ImageVolSource;
                }
            }
        }
        public double MaxSliderValue
        {
            get => _maxSliderValue;
            set
            {
                _maxSliderValue = value;
                OnPropertyChanged(nameof(MaxSliderValue));
            }
        }
        public double SliderValue
        {
            get
            {
                return _sliderValue;
            }

            set
            {
                if (_sliderValue != value)
                {
                    _sliderValue = value;
                    OnPropertyChanged(nameof(SliderValue));
                    _player.Position = TimeSpan.FromSeconds(_sliderValue);
                }

            }
        }
        public string SliderTime
        {
            get
            {
                int minutes = (int)(SliderValue / 60);
                int seconds = (int)(SliderValue % 60);
                return $"{minutes:D2}:{seconds:D2}"; // Форматируем как "мм:сс"
            }
        }
        public string SliderLastTime
        {
            get
            {
                double time = (MaxSliderValue - SliderValue);
                int minutes = (int)(time / 60);
                int seconds = (int)(time % 60);
                return $"{minutes:D2}:{seconds:D2}"; // Форматируем как "мм:сс"
            }
        }

    }
}
