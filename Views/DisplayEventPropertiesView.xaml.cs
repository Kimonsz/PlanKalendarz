using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy DisplayEventPropertiesView.xaml
    /// </summary>
    public partial class DisplayEventPropertiesView : UserControl
    {
        public DisplayEventPropertiesView()
        {
            InitializeComponent();
        }
        public DisplayEventPropertiesView(Event choosenEvent)
        {
            InitializeComponent();
            ObservableCollection<ChecklistItem> checklistCollection = new ObservableCollection<ChecklistItem>();
            foreach (ChecklistItem x in choosenEvent.EventChecklist)
                checklistCollection.Add(x);
            Resources["ChecklistCollection"] = checklistCollection;
        }

        private void LabelLoaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
