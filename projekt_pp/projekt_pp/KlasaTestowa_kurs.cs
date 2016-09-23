using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    class KlasaTestowa_kurs
    {
        private int nrKursu;
        private string subject;
        private int members;
        private string teacher;
        private static string editButton = "Edytuj";
        private static string showCalendar = "Wyświetl";

        public KlasaTestowa_kurs(int _nrKursu, string _subject, int _members, string _teacher)
        {
            this.nrKursu = _nrKursu;
            this.subject = _subject;
            this.members = _members;
            this.teacher = _teacher;
        }

        public string ShowCalendar
        {
            get
            {
                return showCalendar;
            }
        }

        public int NrKursu
        {
            get
            {
                return nrKursu;
            }
            set
            {
                nrKursu = value;
            }
        }

        public string EditButton
        {
            get
            {
                return editButton;
            }
          
        }
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        public int Members
        {
            get
            {
                return members;
            }
            set
            {
                members = value;
            }
        }

        public string Teacher
        {
            get
            {
                return teacher;
            }
            set
            {
                teacher = value;
            }
        }
    }
}
