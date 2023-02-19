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
using PlanKalendarz.Views;

namespace PlanKalendarz.Views
{
    /// <summary>
    /// Logika interakcji dla klasy KalendarzMain.xaml
    /// </summary>
    public partial class CallendarMain : UserControl
    {
        public CallendarMain()
        {
            InitializeComponent();
        }

        private void DatesChenged(object sender, SelectionChangedEventArgs e)
        {
            AddActiveEvent.IsEnabled = true;
            AddActiveQuickEvent.IsEnabled = true;
            bool contentChanged = false;
            DateTime selectedDate = (DateTime)MainViewCallendar.SelectedDate;

            foreach(Event x in CallendarClass.activeEvents)
            {
                if (selectedDate == x.EventTime)
                {
                    DisplayEventName.Content = x.Name;
                    contentChanged = true;
                }
                    
            }
            if (!contentChanged)
                DisplayEventName.Content = "";
        }

        private void AddActiveEvent_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = (DateTime)MainViewCallendar.SelectedDate;
            Application.Current.MainWindow.DataContext = new AddActiveEventView(selectedDate);
        }

        private void AddActiveQuickEvent_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = (DateTime)MainViewCallendar.SelectedDate;
            Application.Current.MainWindow.DataContext = new AddActiveQuickEventView(selectedDate);
        }
    }
}
