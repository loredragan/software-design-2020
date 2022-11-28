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
using Assignment1.DomainLayer.Interfaces;

namespace Assignment1.PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for ListModelsPage.xaml
    /// </summary>
    public partial class ListModelsPage : Page
    {
        private Action<IEnumerable<IModel>> ShowModels { get; set; }
        public ListModelsPage(Action<IEnumerable<IModel>> showModels)
        {
            InitializeComponent();
            ShowModels = showModels;
        }
    }
}
