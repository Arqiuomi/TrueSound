using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TrueSound.ViewModel;

namespace TrueSound.Model
{
    public class MainWindowModel
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? ImageUserSource { get; set; } = Properties.Settings.Default.UserImage;
        public MediaPlayer Player { get; set; }



        public string? AlbumsDirectory { get; set; } = Properties.Resources.AlbumsDirectory;

        public MainWindowModel() { }
        public MainWindowModel(OpenViewModel vm) 
        {
            Name = vm.Name;
            Password = vm.Password;
        }


    }
}
