using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueSound.Model
{
    public class OpenWindowModel
    {
        public string? Email{ get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? PasswordCopy { get; set; }

        public bool RememberMe { get; set; }

        public OpenWindowModel() 
        { 
        }

        public OpenWindowModel(bool RememberMe) 
        {
            this.RememberMe = RememberMe;
        }

    }
}
