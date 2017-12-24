using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfStudent
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void onAdd(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow();
            addWindow.Show();
        }
        private void onShow(object sender, RoutedEventArgs e)
        {
            var showWindow = new ShowWindow();
            showWindow.Show();
        }

        private void onSave(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary File (*.bin)|*.bin";
            saveFileDialog.Title = "Save As...";
            saveFileDialog.InitialDirectory = @"C:\";

            if (saveFileDialog.ShowDialog() == true)
            {
                App.Provider.Save(saveFileDialog.FileName);
            }
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary File (*.bin)|*.bin";
            openFileDialog.Title = "Select a Binary File";

            if (openFileDialog.ShowDialog() == true)
            {
                App.Provider.Load(openFileDialog.FileName);
            }
        }

        private void onExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
