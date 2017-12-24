using Provider;
using Substance;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Comparer;

namespace WpfStudent
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SubstanceProvider<Student> Provider = new SubstanceProvider<Student>(new StudentComparer());
    }
}
