using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolRegister
{
    public partial class EditStudentWindow : Window
    {

        public Student student;

        public EditStudentWindow(Student student = null)
        {
            InitializeComponent();
            if (student != null)
            {
                tbname.Text = student.Imie;
                tbsurname.Text = student.Nazwisko;
                tbnr.Text = student.NrIndeksu;
                tbfaculty.Text = student.Wydzial;
            }
            this.student = student ?? new Student();

        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbname.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbsurname.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbfaculty.Text, @"[a-zA-Z]+")||
                !Regex.IsMatch(tbnr.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Incorrect data!");
                return;
            }
            student.Imie = tbname.Text;
            student.Nazwisko = tbsurname.Text;
            student.NrIndeksu = tbnr.Text;
            student.Wydzial = tbfaculty.Text;
            this.DialogResult = true;
        }
    }
}
