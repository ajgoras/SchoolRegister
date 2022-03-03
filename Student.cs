using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister
{
    public class Student
    {
        string imie, nazwisko, nrIndeksu, wydzial = null;
        public List<Ocena> oceny { get; set; }


        public string Imie { get { return imie; } set { imie = value; } }
        public string Nazwisko { get { return nazwisko; } set { nazwisko = value; } }
        public string NrIndeksu { get { return nrIndeksu; } set { nrIndeksu = value; } }
        public string Wydzial { get { return wydzial; } set { wydzial = value; } }

        public Student (string imie_, string nazwisko_, string nrIndeksu_, string wydzial_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            nrIndeksu = nrIndeksu_;
            wydzial = wydzial_;
            oceny = new List<Ocena>();
        }

        public Student()
        {
            oceny = new List<Ocena>();
        }

    }
}
