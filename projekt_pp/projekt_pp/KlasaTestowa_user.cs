using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    class KlasaTestowa_user
    {
        private int id;
        private string name;
        private string lastName;
        private string mail;
        private static string editButton = "Edytuj";
        private static string showCalendar = "Wyświetl";

        public KlasaTestowa_user(int _id, string _name, string _lastName, string _mail)
        {
            this.id = _id;
            this.name = _name;
            this.lastName = _lastName;
            this.mail = _mail;
        }

        public string ShowCalendar
        {
            get
            {
                return showCalendar;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string EditButton
        {
            get
            {
                return editButton;
            }

        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
               name = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
            }
        }
    }
}
