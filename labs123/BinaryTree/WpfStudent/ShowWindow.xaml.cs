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
    /// Логика взаимодействия для ShowWindow.xaml
    /// </summary>
    public partial class ShowWindow : Window
    {
        private int Sign { get; set; }
        public ShowWindow()
        {
            InitializeComponent();
            setDataToGrid();
            sort.SelectedItem = 1;
        }

        private void setDataToGrid()
        {
            students.ItemsSource = App.Provider.Show();
        }

        private void onUpdate(object sender, RoutedEventArgs e)
        {
            int mark;
            App.Provider.Filters = new List<Func<Student, bool>>();
            if (int.TryParse(Mark.Text, out mark))
            {
                switch (Sign)
                {
                    case 0:
                        App.Provider.Filters.Add(student => student.Mark > mark);
                        break;
                    case 1:
                        App.Provider.Filters.Add(student => student.Mark == mark);
                        break;
                    case 2:
                        App.Provider.Filters.Add(student => student.Mark < mark);
                        break;
                }
            }

            setDataToGrid();
        }

        private void onChangeSort(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (sort.SelectedIndex)
            {
                case 0:
                    App.Provider.SortField = "LastName";
                    App.Provider.SortType = "ASC";
                    break;
                case 1:
                    App.Provider.SortField = "LastName";
                    App.Provider.SortType = "DESC";
                    break;
                case 2:
                    App.Provider.SortField = "FirstName";
                    App.Provider.SortType = "ASC";
                    break;
                case 3:
                    App.Provider.SortField = "FirstName";
                    App.Provider.SortType = "DESC";
                    break;
                case 4:
                    App.Provider.SortField = "TestName";
                    App.Provider.SortType = "ASC";
                    break;
                case 5:
                    App.Provider.SortField = "TestName";
                    App.Provider.SortType = "DESC";
                    break;
                case 6:
                    App.Provider.SortField = "Mark";
                    App.Provider.SortType = "ASC";
                    break;
                case 7:
                    App.Provider.SortField = "Mark";
                    App.Provider.SortType = "DESC";
                    break;
            }
        }

        private void onChangeSign(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Sign = sign.SelectedIndex;
        }
    }
}
