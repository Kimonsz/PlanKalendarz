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

namespace PlanKalendarz.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddActiveEventView.xaml
    /// </summary>
    public partial class AddActiveEventView : UserControl
    {
        public AddActiveEventView()
        {
            InitializeComponent();
        }

        private void ComboLoaded(object sender, RoutedEventArgs e)
        {
            foreach(string x in CallendarClass.GetEventsList())
            {
                EventNameComboBox.Items.Add(x);
            }
            
        }
    }
}
