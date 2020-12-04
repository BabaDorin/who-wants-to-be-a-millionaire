using System.Windows;
using System.Windows.Controls;
using WhoWantsToBeAMillionaire.Services;

namespace WhoWantsToBeAMillionaire.Views
{
    public partial class StartView : UserControl
    {
        private MainWindow _mainWindow;
        private AudioService _audioService;

        public StartView()
        {
            InitializeComponent();
            _mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;

            _mainWindow.ActivateAdminPanel();

            _audioService = AudioService.GetInstace();
            _audioService.PlayAudio(_audioService.MainTheme);
        }

        private void btStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (GameService.GetInstace().Init(tbPlayerName.Text))
            {
                _mainWindow.DeactivateAdminPanel();
                _mainWindow.UpdateView("Game");
            }
        }

        private void btShowRules_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.UpdateView("Rules");
        }

        private void tbPlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            btStartGame.IsEnabled = (tbPlayerName.Text.Trim() != "");
        }
    }
}
