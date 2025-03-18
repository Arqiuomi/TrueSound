using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TrueSound;
using System.Windows.Media;

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
        public List<string> TrackList { get; set; }
        public int TrackNum { get; set; }
        public int AlbumNum { get; set; }
        public MediaPlayer Player { get; set; }

        public PlayerModel() 
        {
            AlbumPaths = basicFuncs.GetAllDirectoryPaths(AlbumsDirectory);
            AlbumNum = 0;
            TrackList = basicFuncs.GetAllFilePaths(AlbumPaths[AlbumNum]);
        }

        public PlayerModel(int albumNum)
        {
            AlbumPaths = basicFuncs.GetAllDirectoryPaths(AlbumsDirectory);
            AlbumNum = albumNum;
            TrackList = basicFuncs.GetAllFilePaths(AlbumPaths[AlbumNum]);

        }

        public PlayerModel(string albumPath)
        {
            TrackList = basicFuncs.GetAllFilePaths(Path.GetDirectoryName(albumPath));

        }

        public PlayerModel(int albumNum, int trackNum)
        {
            AlbumPaths = basicFuncs.GetAllDirectoryPaths(AlbumsDirectory);
            AlbumNum = albumNum;
            TrackList = basicFuncs.GetAllFilePaths(AlbumPaths[AlbumNum]);
            TrackNum = trackNum;

        }
                public PlayerModel(int albumNum, int trackNum, MediaPlayer player)
        {
            AlbumPaths = basicFuncs.GetAllDirectoryPaths(AlbumsDirectory);
            AlbumNum = albumNum;
            TrackList = basicFuncs.GetAllFilePaths(AlbumPaths[AlbumNum]);
            TrackNum = trackNum;
            Player = player;

        }


    }
}
