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
using System.Text.RegularExpressions;

namespace PlanKalendarz.Views
{
    /// <summary>
    /// Logika interakcji dla klasy DodawanieEventu.xaml
    /// </summary>
    public partial class DodawanieEventu : UserControl
    {
        public DodawanieEventu()
        {
            InitializeComponent();
        }

        private void DodajEvent(object sender, RoutedEventArgs e)
        {
            CallendarClass.AddEventViewModel(EventNameBox.Text);
            EventNameBox.Text = null;
        }

        private void NumbersOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
