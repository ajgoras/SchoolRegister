using System.Windows;

namespace SchoolRegister
{
    public partial class ShowGradesWindow : Window
    {
        public Student student;
        public ShowGradesWindow(Student student = null)
        {
            InitializeComponent();
            this.student = student ?? new Student();
            dgoceny.ItemsSource=student.oceny;
            LabelStudentInfo.Content = student.Imie+ " "+student.Nazwisko;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dgoceny.SelectedItem is Ocena)
            {
                student.oceny.Remove((Ocena)dgoceny.SelectedItem);
                dgoceny.Items.Refresh();
            }
        }
    }
}
