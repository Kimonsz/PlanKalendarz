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
using PlanKalendarz.ViewModels;

namespace PlanKalendarz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CallendarMainViewModel CallendarView = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = CallendarView;
        }

        public void ChangeView<T>(T view)       //changes view from another views 
        {
            DataContext = view;
        }

        private void EventCick(object sender, RoutedEventArgs e)
        {
            DataContext = new AddQuickEventViewModel();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            DataContext = CallendarView;
        }

        private void EventListClick(object sender, RoutedEventArgs e)
        {
            DataContext = new EventListViewModel();
        }

        private void NotificationsClick(object sender, RoutedEventArgs e)
        {
            DataContext = new NotificationsViewModel();
        }

        private void MenuHideButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainMenu.Width.Value == 180)
            {
                MainMenu.Width = new GridLength(30);
                AddEventViewButton.Content = "E";
                CallendarViewButton.Content = "C";
                EventListViewButton.Content = "L";
                NotifyViewButton.Content = "P";             
            }  
            else
            {
                MainMenu.Width = new GridLength(180);
                AddEventViewButton.Content = "Dodaj quick event";
                CallendarViewButton.Content = "Kalendarz";
                EventListViewButton.Content = "Lista Eventów";
                NotifyViewButton.Content = "Powiadomienia";
            }
                

        }
    }
}
