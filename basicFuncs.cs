using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueSound
{
    public static class basicFuncs
    {
        public static List<string> GetAllFilePaths(string fileDirectory)
        {
            return Directory.GetFiles(fileDirectory).ToList();
        }
        public static List<string> GetAllDirectoryPaths(string fileDirectory)
        {
            Directory.GetDirectories(fileDirectory );
            return Directory.GetDirectories(fileDirectory).ToList();
        }




        }
    }
