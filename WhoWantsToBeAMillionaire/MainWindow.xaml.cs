using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WhoWantsToBeAMillionaire.Services;
using WhoWantsToBeAMillionaire.ViewModels;
using WhoWantsToBeAMillionaire.Views;

namespace WhoWantsToBeAMillionaire
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdateView("Start");
        }

        private void btToggleVolume_Click(object sender, RoutedEventArgs e)
        {
            if (VolumeOff.Visibility == Visibility.Hidden)
                VolumeOff.Visibility = Visibility.Visible;
            else
                VolumeOff.Visibility = Visibility.Hidden;

            AudioService.ToggleVolume();
        }

        private void btAdminPanel_Click(object sender, RoutedEventArgs e)
        {
            AdminView adminView = new AdminView();
            adminView.ShowDialog();
        }

        public void UpdateView(string parameter)
        {
            switch (parameter)
            {
                case "Start":
                    childWindow.Content = new StartView();
                    break;
                case "Game":
                    childWindow.Content = new GameView();
                    break;
                case "Results":
                    childWindow.Content = new ResultsView();
                    break;
                case "Rules":
                    childWindow.Content = new RulesView();
                    break;
                default:
                    childWindow.Content = new StartView();
                    break;
            }
        }

        public void DeactivateAdminPanel()
        {
            btAdminPanel.IsEnabled = false;
        }

        public void ActivateAdminPanel()
        {
            btAdminPanel.IsEnabled = true;
        }
    }
}
