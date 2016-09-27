using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_pp
{
    class KlasaTestowa_kurs_nazwy
    {
        private int nrKursu;
        private string subject;
        private static string showCalendar = "Wyświetl";

        public KlasaTestowa_kurs_nazwy(int _nrKursu, string _subject)
        {
            this.nrKursu = _nrKursu;
            this.subject = _subject;
         
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
    }
}
