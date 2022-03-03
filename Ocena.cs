using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister
{
    public class Ocena
    {
        string grade=null;
        string subject = null;
        public string Grade { get { return grade; } set { grade = value; } }
        public string Subject { get { return subject; } set { subject = value; } }

        public Ocena() { }

        public Ocena(string grade_, string subject_)
        {
            grade = grade_;
            subject = subject_;
        }


    }
}
