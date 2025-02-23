using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueSound.Model
{
    public class AudioFile
    {

        public string? Source {  get; set; }

        public AudioFile() { }
        public AudioFile(string source) 
        {
        
            Source = source;
        }
    }
}
