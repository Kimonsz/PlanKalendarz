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
    /// Logika interakcji dla klasy AddActiveQuickEventView.xaml
    /// </summary>
    public partial class AddActiveQuickEventView : UserControl
    {
        DateTime pickedDate;
        List<string> checklist;
        public AddActiveQuickEventView()
        {
            InitializeComponent();
        }
        public AddActiveQuickEventView(DateTime pickedDate)
        {
            InitializeComponent();
            this.pickedDate = pickedDate;
            checklist = new();
        }

        private void ConfirmAdd_Click(object sender, RoutedEventArgs e)
        {
            //create event with actualized data
            bool notifyBool = false;
            if (NotifyBool.SelectedIndex == 0)
            {
                notifyBool = false;
            }
            else if (NotifyBool.SelectedIndex == 1)
            {
                notifyBool = true;
            }
            Event addedEvent = new Event(EventNameBox.Text, notifyBool, pickedDate, NotifyDay.Text, NotifyHour.Text, NotifyMinute.Text, checklist, TakeNote.Text);

            //add to activeEvents and actualize View
            CallendarClass.activeEvents.Add(addedEvent);
            Application.Current.MainWindow.DataContext = new CallendarMain();
        }

        private void NumbersOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
