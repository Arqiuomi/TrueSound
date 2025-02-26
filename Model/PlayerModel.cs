using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrueSound.Model
{
    public class PlayerModel
    {
        public string ImageVolSource { get; set; } = Properties.Resources.VolImage;
        public string ImageVolMuteSource { get; set; } = Properties.Resources.VolMuteImage;
        public string ImageLikeSource { get; set; } = Properties.Resources.LikeImage;
        public string ImageFilledLikeSource { get; set; } = Properties.Resources.FilledLikeImage;
        public string? AlbumCover { get; set; }
        public string? TracksDirectory { get; set; } = Properties.Resources.TracksDirectory;
        public List<string> AllTrackPaths { get; set; }
        public int trackNum { get; set; }

        public PlayerModel() 
        {
            AllTrackPaths = GetAllFilePaths(TracksDirectory);
        }

        public PlayerModel(int trackNum)
        {
            AllTrackPaths = GetAllFilePaths(TracksDirectory);
            this.trackNum = trackNum;
        }

        private List<string> GetAllFilePaths(string fileDirectory)
        {
            return Directory.GetFiles(fileDirectory).ToList();
        }

    }
}
