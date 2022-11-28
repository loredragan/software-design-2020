using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Assignment1.DomainLayer.Models;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// //localhost\SQLEXPRESS
    public partial class MainWindow : Window
    {
        public Employee Employee { get; set; }
        public MainWindow(Employee employee)
        {
            Employee = employee;
            InitializeComponent();
        }
    }
}
