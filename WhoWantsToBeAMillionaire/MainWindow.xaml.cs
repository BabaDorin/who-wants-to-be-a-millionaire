using System.Windows;
using WhoWantsToBeAMillionaire.Services;
using WhoWantsToBeAMillionaire.Views;

namespace WhoWantsToBeAMillionaire
{
    public partial class MainWindow : Window
    {
        private AudioService _audioService;

        public MainWindow()
        {
            InitializeComponent();
            UpdateView("Start");

            _audioService = AudioService.GetInstace();
        }

        private void btToggleVolume_Click(object sender, RoutedEventArgs e)
        {
            if (VolumeOff.Visibility == Visibility.Hidden)
                VolumeOff.Visibility = Visibility.Visible;
            else
                VolumeOff.Visibility = Visibility.Hidden;

            _audioService.ToggleVolume();
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
