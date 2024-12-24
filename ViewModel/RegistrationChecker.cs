using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueSound.model;

namespace TrueSound.ViewModel
{
    

    public static class RegistrationChecker
    {
        public static bool checkReg(string name, string password)
        {
            /* 
               обращается к методу проверки пользователя в БД
               name - имя пользователя
               password - пароль
             */
           return DB.validUser(name, password); //возвращает bool
        }


    }
}
