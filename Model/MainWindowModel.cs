﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueSound.Model
{
    public class MainWindowModel
    {
        public string? Name { get; set; }
        public string? Password { get; set; }


        public MainWindowModel() { }
        public MainWindowModel(string Name, string Password) 
        {
        }


    }
}
