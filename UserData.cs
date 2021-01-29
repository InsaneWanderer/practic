using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable
{
    //Класс пользователя для передачи данных на форму
    public class UserData
    {
        private string id = "0";
        private string surname;
        private string name;
        private string patronymic;
        private string type;
        private string login;

        public UserData(string id, string surname, string name, string patronymic, string type, string login)
        {
            this.id = id;
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic == "NULL" ? "" : patronymic;
            this.type = type;
            this.login = login;
        }

        public string Get(string field)
        {
            switch(field)
            {
                case "id":
                    return id;
                case "surname":
                    return surname;
                case "name":
                    return name;
                case "patronymic":
                    return patronymic;
                case "type":
                    return type;
                case "login":
                    return login;
                default:
                    return "0";
            }
        }
    }
}
