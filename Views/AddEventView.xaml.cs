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
            bool notesBool;
            if (EventNotesCheckBox.IsChecked == true)
            {
                notesBool = true;
            }
            else
            {
                notesBool = false;
            }

            bool checklistBool;
            if (EventChecklistCheckBox.IsChecked == true)
            {
                checklistBool = true;
            }
            else
            {
                checklistBool = false;
            }

            if (NotifyBool.SelectedIndex==-1)
            {
                CallendarClass.AddEventViewModel(EventNameBox.Text, notesBool, checklistBool);
            }
            else
            {
                bool notifyBool = false;
                if (NotifyBool.SelectedIndex == 0)
                {
                    notifyBool = false;
                }
                else if (NotifyBool.SelectedIndex == 1)
                {
                    notifyBool = true;
                }      

                //string name, bool notes, bool checklist,bool notifybefore,string notifyDay, string notifyHour,string notifyMinute
                CallendarClass.AddEventViewModel(EventNameBox.Text, notesBool, checklistBool, notifyBool, NotifyDay.Text, NotifyHour.Text, NotifyMinute.Text);
            }
            
            
            EventNameBox.Text = null;
            NotifyBool.SelectedIndex = -1;
            EventChecklistCheckBox.IsChecked = false;
            EventNotesCheckBox.IsChecked = false;
            NotifyDay.Text = null;
            NotifyHour.Text = null;
            NotifyMinute.Text = null;

        }

        private void NumbersOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
