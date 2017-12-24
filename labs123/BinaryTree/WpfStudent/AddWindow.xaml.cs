using Substance;
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

namespace WpfStudent
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void onAdd(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.FirstName = FirstName.Text;
            student.LastName = LastName.Text;
            student.TestName = TestName.Text;
            student.Mark = Int32.Parse(Mark.Text);
            student.TestDay = DateTime.Now;
            App.Provider.Add(student);

            MessageBox.Show("Студент успешно добавлен");
            this.Close();
        }

        private void onExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
