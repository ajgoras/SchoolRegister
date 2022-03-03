using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;

namespace SchoolRegister
{
    public partial class MainWindow : Window
    {

        public List<Student> list { get; set; }


        public MainWindow()
        {

            list = new List<Student>()
            {
                new Student(){Imie="Jan",Nazwisko="Kowalski",NrIndeksu="1001",Wydzial="Informatyka"},
                new Student("Mateusz", "Nowak", "1002","Budownictwo")
            };

            InitializeComponent();

            dg.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new Binding("Imie") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Surname", Binding = new Binding("Nazwisko") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Index Number", Binding = new Binding("NrIndeksu") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Faculty", Binding = new Binding("Wydzial") });
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;
        }


        void Save<T>(T ob, StreamWriter sw)
        {
            Type t = ob.GetType();
            sw.WriteLine($"[[{t.FullName}]]");
            foreach (var p in t.GetProperties())
            {
                sw.WriteLine($"{p.Name}]");
                sw.WriteLine(p.GetValue(ob));
            }
            sw.WriteLine($"[[]]");
        }


        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog()==true)
            {
                list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void ButtonRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                list.Remove((Student)dg.SelectedItem);
                dg.Items.Refresh();
            }
        }

        private void ButtonAddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                var dialog = new GradeWindow();
                if (dialog.ShowDialog() == true)
                {
                    Student s = (Student)dg.SelectedItem;
                    s.oceny.Add(dialog.ocena);
                    dg.Items.Refresh();
                }
            }
        }

        private void ButtonShowGrade_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                Student s = (Student)dg.SelectedItem;
                var dialog = new ShowGradesWindow(s);
                if (dialog.ShowDialog()==true)
                {
                    dg.Items.Refresh();
                }
                dg.Items.Refresh();
            }
        }

        private void ButtonEditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is Student)
            {
                Student s = (Student)dg.SelectedItem;
                var dialog = new EditStudentWindow(s);
                if (dialog.ShowDialog()==true)
                {
                    dg.Items.Refresh();
                }
                dg.Items.Refresh();

            }
        }

        private void ButtonSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            if (list.Count>0)
            {
                FileStream fs = new FileStream("data.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                foreach (Student item in list)
                {
                    sw.WriteLine("[[Student]]");
                    sw.WriteLine("[FirstName]");
                    sw.WriteLine(item.Imie);
                    sw.WriteLine("[SurName]");
                    sw.WriteLine(item.Nazwisko);
                    sw.WriteLine("[StudentNo]");
                    sw.WriteLine(item.NrIndeksu);
                    sw.WriteLine("[Faculty]");
                    sw.WriteLine(item.Wydzial);
                    sw.WriteLine("[[]]");
                }
                sw.Close();
                MessageBox.Show("Saved student list to file data.txt in application folder");
            }
            else {MessageBox.Show("No students, nothing to save");}
        }

        private void ButtonLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            if(File.Exists("data.txt"))
            {
                FileStream fs = new FileStream("data.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                list.Clear();
                while (!sr.EndOfStream)
                {
                    var ln = sr.ReadLine();
                    if (ln.Contains("[[Student]]"))
                    {
                        string tempname, tempsurname, tempnumber, tempfaculty = null;
                        sr.ReadLine();
                        tempname = sr.ReadLine();
                        sr.ReadLine();
                        tempsurname = sr.ReadLine();
                        sr.ReadLine();
                        tempnumber = sr.ReadLine();
                        sr.ReadLine();
                        tempfaculty = sr.ReadLine();
                        list.Add(new Student(tempname, tempsurname, tempnumber, tempfaculty));
                    }
                }
                sr.Close();
                dg.Items.Refresh();
                MessageBox.Show("Students loaded from file!");
            }
            else { MessageBox.Show("No file! Data not loaded."); }
        }

        private void ButtonDynamicSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
