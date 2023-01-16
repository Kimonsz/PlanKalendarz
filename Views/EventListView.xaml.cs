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
    /// Logika interakcji dla klasy EventListView.xaml
    /// </summary>
    public partial class EventListView : UserControl
    {
        public EventListView()
        {
            InitializeComponent();
            ListBoxOfItems.ItemsSource = CallendarClass.GetEventsList();
            DeleteEventButtton.IsEnabled = false;
        }

        private void DeleteEventFromList(object sender, RoutedEventArgs e)
        {
            var toDelete = ListBoxOfItems.SelectedItems;
        }

        private void ListBoxOfItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteEventButtton.IsEnabled = true;
        }
    }
}
