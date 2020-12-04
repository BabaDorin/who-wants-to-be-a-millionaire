using System.Windows;
using System.Windows.Controls;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Views
{
    public partial class GameView : UserControl
    {
        private GameViewModel _viewModel;

        public GameView()
        {
            // Este creata o instanta a clasei GameViewModel si este setata ca DataContext pentru fereastra GameView
            InitializeComponent();
            DataContext = new GameViewModel(this);
            _viewModel = (DataContext as GameViewModel);
        }

        private void btAskAudience_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AskAudience();
        }

        private void btPhoneCall_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CallFriend();
        }

        private void btFiftyFifty_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.FiftyFifty();
        }

        private void btOption_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OptionSubmitted(sender as Button);
        }

        private void btGenerateResults_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveAndDisplayResults();
        }

        private void btRetreat_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Retreat();
        }
    }
}
