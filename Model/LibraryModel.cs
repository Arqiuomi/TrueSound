using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueSound.Model
{
    public class LibraryModel
    {
        public ObservableCollection<Album> AlbumsPanelView { get; set; }
        public string? AlbumsDirectory { get; set; } = Properties.Resources.AlbumsDirectory;
        public string? Search { get; set; }
        public int albumIndex { get; set; } = -1;
        public LibraryModel()
        { 
        
        }
    }
}
