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
    public partial class GradeWindow : Window
    {
        public Ocena ocena;
        public GradeWindow(Ocena ocena=null)
        {
            InitializeComponent();

            if (ocena!=null)
            {
                tbgrade.Text = ocena.Ocenaa;
                tbsubject.Text = ocena.Przedmiot;
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
            ocena.Przedmiot = tbsubject.Text;
            ocena.Ocenaa = tbgrade.Text;
            this.DialogResult = true;
        }
    }
}
