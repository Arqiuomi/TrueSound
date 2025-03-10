using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using TrueSound.Model;
using System.Collections.ObjectModel;
using System.IO;
using TrueSound.View;
using MaterialDesignColors;
using System.DirectoryServices.ActiveDirectory;

namespace TrueSound.ViewModel
{
    public class LibraryViewModel: BaseViewModel
    {
        MainViewModel _vm;
        LibraryModel _m;
        BitmapImage AlbumCover;
        public DelegateCommand<object> AlbumPressCommand { get; set; }
        public DelegateCommand SearchCommand { get; }
        public DelegateCommand SearchFocusCommand { get; }

        public LibraryViewModel(MainViewModel vm) 
        { 
            _vm = vm;
            _m = new LibraryModel();
            AlbumsPanelView = new ObservableCollection<Album>(FillAlbum());
            AlbumPressCommand = new DelegateCommand<object>(OnAlbumPressCommand);
            SearchCommand = new DelegateCommand(OnSearchCommand);
            SearchFocusCommand = new DelegateCommand(OnSearchFocusCommand);
        }


        private List<string> CollectAlbumNames(string fileDirectory)
        {
            //Возвращает список имён всех альбомов
                var paths = basicFuncs.GetAllDirectoryPaths(fileDirectory);
            for (int i=0; i < paths.Count; i++)
                paths[i] = paths[i].Remove(0, fileDirectory.Length+1);
            return paths;
        }

        private List<BitmapImage> CollectAlbumCovers(string fileDirectory)
        {
            //fileDirectory - путь на папку со всеми альбомами

            var coverList = new List<BitmapImage>();

            foreach (string AlbumPath in basicFuncs.GetAllDirectoryPaths(fileDirectory))
            {
                //coverList.Add(CreateImageSource("C:/Users/aelis/source/repos/TrueSound/View/image/vinyl.png"));

                foreach (string trackPath in basicFuncs.GetAllFilePaths(AlbumPath))
                {
                    coverList.Add(new BitmapImage(new Uri(Properties.Resources.VinylImage, UriKind.Relative)));

                    var file = TagLib.File.Create(trackPath);
                    if (file.Tag.Pictures.Length > 0)
                    {
                        coverList[coverList.Count - 1] = FindAlbumCover(file);
                        break;
                    }
                }
                return coverList;
            }
        }

        private BitmapImage FindAlbumCover(TagLib.File file)
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
                    return bitmap;
                }

        }


            public List<Album> FillAlbum()
        {
            var albumList = new List<Album>();
            var albumNameList = CollectAlbumNames(_m.AlbumsDirectory);
            var albumCoverList = CollectAlbumCovers(_m.AlbumsDirectory);

            for (int i = 0; i < albumNameList.Count; i++)
            {
                albumList.Add(new Album(albumCoverList[i], albumNameList[i]));
            }
            return albumList;
        }

        private void LoadAlbumCover(string filePath) //пока под вопросом, возможно, из spotify удастся вытащить обложки
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


        private ImageSource CreateImageSource(string path)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path, UriKind.Absolute);
            bitmap.EndInit();
            bitmap.Freeze(); // Опционально, для повышения производительности
            return bitmap;
        }




        //private void FillGenersList()
        ////заполняет ComboBox
        //{
        //    string[] geners = ["классика", "рок", "поп", "фанк", "джаз", "кантри",
        //        "рэп", "шансон", "хип-хоп", "дэнсхолл", "ритм-н-блюз", "народные песни"];

        //    //string[] genre = Properties.Settings.Default.genres.Split(','); //может меняться в коде
        //    string[] genres = Properties.Resources.genre.Split(','); //не меняется и не должно

        //    foreach (string gener in geners)
        //    {
        //        ListBoxItem item = new ListBoxItem() { BorderBrush = Brushes.Wheat, Height = 60, Margin = new Thickness(0, 10, 0, 0), MaxWidth = 300 }; //создали энт листбокса
        //        StackPanel stack = new StackPanel() { Orientation = Orientation.Horizontal, MaxWidth = 200 };
        //        Image image = AddImage("C:\\Users\\aelis\\source\\repos\\TrueSound\\nots.png");
        //        Label label = new Label() { Content = gener, FontSize = 16, Foreground = Brushes.Wheat, VerticalAlignment = VerticalAlignment.Center };  //создали лэйбл
        //        stack.Children.Add(image);
        //        stack.Children.Add(label);
        //        item.Content = stack;
        //        //обратиться к энту фрейма
        //        LibraryListBox.Items.Add(item);
        //    }

        //}
        //private Image AddImage(string source)
        ////возвращает фото по ссылке 
        //{
        //    Image image = new Image() { Height = 60, Width = 60 };
        //    BitmapImage bitmap = new BitmapImage(new Uri(source, UriKind.Absolute));
        //    //BitmapImage bitmap = new BitmapImage(new Uri(source, UriKind.Relative));
        //    image.Source = bitmap;
        //    return image;
        //}


        private void OnAlbumPressCommand(object AlbumNum)
        {
            PlayerViewModel player = new PlayerViewModel(1); //вместо 0 должен быть AlbumNum !!!!
            var pageSwitcher = (Frame)Application.Current.Windows[0].FindName("PageSwitcher");
            PlayerPage playerPage = new PlayerPage(player);
            pageSwitcher.Content = playerPage;
        }

        private void OnSearchCommand()
        {
            Search = "hi"; // тут срабатывает действие поиска - отправка запроса в парсер
        }
        private void OnSearchFocusCommand()
        {
            Search = string.Empty;
        }

        public ObservableCollection<Album> AlbumsPanelView
        {
            get
            { return _m.AlbumsPanelView; }

            set
            {
                _m.AlbumsPanelView = value;
                OnPropertyChanged(nameof(AlbumsPanelView));
            }
        }

        public string Search
        {
            get { return _m.Search; }
            set
            {
                _m.Search = value;
                OnPropertyChanged(nameof(Search));
            }
        }

    }
}
