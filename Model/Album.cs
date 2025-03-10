using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TrueSound.Model
{
    public class Album
    {
        public BitmapImage ImageSource { get; set; }
        public string AlbumName { get; set; }

        public Album(BitmapImage imageSource, string albumName)
        {
            ImageSource = imageSource;
            AlbumName = albumName;
        }

    }
}
