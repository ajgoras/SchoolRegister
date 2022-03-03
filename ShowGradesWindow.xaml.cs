using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// Logika interakcji dla klasy ShowGradesWindow.xaml
    /// </summary>
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
