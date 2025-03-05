using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TrueSound;

namespace TrueSound.Model
{
    public class PlayerModel
    {
        public string ImageVolSource { get; set; } = Properties.Resources.VolImage;
        public string ImageVolMuteSource { get; set; } = Properties.Resources.VolMuteImage;
        public string ImageLikeSource { get; set; } = Properties.Resources.LikeImage;
        public string ImageFilledLikeSource { get; set; } = Properties.Resources.FilledLikeImage;
        public string? AlbumCover { get; set; }
        public string? AlbumsDirectory { get; set; } = Properties.Resources.AlbumsDirectory;
        public List<string> AlbumPaths { get; set; }
        public int trackNum { get; set; }

        public PlayerModel() 
        {
            AlbumPaths = basicFuncs.GetAllFilePaths(AlbumsDirectory);
        }

        public PlayerModel(int trackNum)
        {
            AlbumPaths = basicFuncs.GetAllFilePaths(AlbumsDirectory);
            this.trackNum = trackNum;
        }


    }
}
