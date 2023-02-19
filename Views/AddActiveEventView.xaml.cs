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
    /// Logika interakcji dla klasy AddActiveEventView.xaml
    /// </summary>
    public partial class AddActiveEventView : UserControl
    {
        Event choosenEvent;
        DateTime pickedDate;
        List<string> checklistPreview;

        public AddActiveEventView()
        {
            InitializeComponent();
            checklistPreview = new();
        }

        public AddActiveEventView(DateTime pickedDate)
        {
            InitializeComponent();
            this.pickedDate = pickedDate;
            checklistPreview = new();
        }

        private void ComboLoaded(object sender, RoutedEventArgs e)
        {
            foreach (string x in CallendarClass.GetEventsListName())
            {
                EventNameComboBox.Items.Add(x);
            }

        }

        private void ConfirmAdd_Click(object sender, RoutedEventArgs e)
        {
            //create event with actualized data
            Event activeEvent = new Event(choosenEvent, pickedDate);

            //add to activeEvents and actualize View
            CallendarClass.activeEvents.Add(activeEvent);
            Application.Current.MainWindow.DataContext = new CallendarMain(); 
        }

        private void EventChoosen(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                choosenEvent = CallendarClass.GetEventByName(EventNameComboBox.SelectedItem.ToString());
            }catch
            {
                throw;
            }

            // 0=NULL   -1=False=przed     1=True=po
            int notifyInfo = choosenEvent.GetNotifyInfo();
            if (notifyInfo!=0)
            {
                NotificationDateLabel.Content = choosenEvent.GetNotificationDate(pickedDate);
            }

            //clearing form 
            CheckListElement.Text = string.Empty;
            checklistPreview.Clear();
            PreviewOfChecklist.ItemsSource = checklistPreview;
            TakeNote.Text = string.Empty;
        }
    }
} 