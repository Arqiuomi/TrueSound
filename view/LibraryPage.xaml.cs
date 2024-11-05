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

namespace TrueSound.view
{
    /// <summary>
    /// Логика взаимодействия для LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        public LibraryPage()
        {
            InitializeComponent();
            FillGenersList();

        }

        private void FillGenersList()
        //заполняет ComboBox
        {
            string[] geners = ["классика", "рок", "поп", "фанк", "джаз", "кантри",
                "рэп", "шансон", "хип-хоп", "дэнсхолл", "ритм-н-блюз", "народные песни"];

 


            foreach (string gener in geners)
            {
                ListBoxItem item = new ListBoxItem() { BorderBrush = Brushes.Wheat, Height=60, Margin= new Thickness(0, 10, 0, 0), MaxWidth=300}; //создали энт листбокса
                StackPanel stack = new StackPanel() { Orientation = Orientation.Horizontal, MaxWidth=200 }; //создали стэк
                Image image = AddImage("C:\\Users\\aelis\\source\\repos\\TrueSound\\nots.png");
                Label label = new Label() { Content = gener, FontSize=16, Foreground = Brushes.Wheat, VerticalAlignment = VerticalAlignment.Center};  //создали лэйбл
                stack.Children.Add(image);
                stack.Children.Add(label); //добавили дочернии энты в стэк
                item.Content = stack; //передали стэк в энт листбокса
                LibraryListBox.Items.Add(item); //добавили энт листбокса к листбоксу
            }

        }
        private Image AddImage(string source)
        //возвращает фото по ссылке 
        {
                Image image = new Image() { Height = 60, Width = 60};
                BitmapImage bitmap = new BitmapImage(new Uri(source, UriKind.Absolute));
                //BitmapImage bitmap = new BitmapImage(new Uri(source, UriKind.Relative));
                image.Source = bitmap;
                return image;
        }


    }
}
