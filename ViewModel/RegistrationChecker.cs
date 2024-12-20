using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueSound.model;

namespace TrueSound.ViewModel
{
    

    public class RegistrationChecker
    {
        static Config config =new();
        static DB dB = new DB(config);
        public static bool checkReg(string name, string password)
        {
            /* 
               обращается к методу проверки пользователя в БД
               name - имя пользователя
               password - пароль
             */
           return dB.validUser(name, password); //возвращает bool
        }


    }
}
