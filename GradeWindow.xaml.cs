using System.Text.RegularExpressions;
using System.Windows;

namespace SchoolRegister
{
    public partial class GradeWindow : Window
    {
        public Ocena ocena;
        public GradeWindow(Ocena ocena=null)
        {
            InitializeComponent();

            if (ocena!=null)
            {
                tbgrade.Text = ocena.Grade;
                tbsubject.Text = ocena.Subject;
            }
            this.ocena = ocena ?? new Ocena();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbsubject.Text, @"[a-zA-Z]+") ||
                !Regex.IsMatch(tbgrade.Text, @"^[0.0-9]{1,10}$"))
            {
                MessageBox.Show("Incorrect data!");
                return;
            }
            ocena.Subject = tbsubject.Text;
            ocena.Grade = tbgrade.Text;
            this.DialogResult = true;
        }
    }
}
