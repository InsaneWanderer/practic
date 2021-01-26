using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable
{
    //Класс пользователя для передачи данных на форму
    class UserData
    {
        private int id = 0;
        private string surname;
        private string name;
        private string patronymic;
        private string type;
        private string login;

        public UserData(int id, string surname, string name, string patronymic, string type, string login)
        {
            this.id = id;
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic == "NULL" ? "" : patronymic;
            this.type = type;
            this.login = login;
        }

        //public Type Get()
        //{

        //}
    }
}
