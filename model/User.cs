using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrueSound.model
{
    public class User : DependencyObject
    {
        public static readonly DependencyProperty NameProperty;
        public static readonly DependencyProperty PasswordProperty;

        static User()
        {
            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(User));
            PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(User));
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
    }
}
