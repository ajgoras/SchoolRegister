using System.Text.RegularExpressions;
using System.Windows;
namespace SchoolRegister
{
    public partial class StudentWindow : Window
    {
        public Student student;

        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if (student!=null)
            {
                tbname.Text = student.Imie;
                tbsurname.Text = student.Nazwisko;
                tbnr.Text = student.NrIndeksu;
                tbfaculty.Text = student.Wydzial;
            }
            this.student = student ?? new Student();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbname.Text, @"^\p{Lu}\p{Ll}{1,12}$")||
                !Regex.IsMatch(tbsurname.Text, @"^\p{Lu}\p{Ll}{1,12}$")||
                !Regex.IsMatch(tbfaculty.Text, @"[a-zA-Z]+")||
                !Regex.IsMatch(tbnr.Text, @"^[0-9]{1,10}$"))
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
