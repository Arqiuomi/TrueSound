using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TrueSound.Model
{
    public class Album
    {
        public ImageSource ImageSource { get; set; }
        public string AlbumName { get; set; }

        public Album(ImageSource imageSource, string albumName)
        {
            ImageSource = imageSource;
            AlbumName = albumName;
        }

    }
}
