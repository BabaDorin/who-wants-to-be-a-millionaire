using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Printing;
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
using System.Windows.Threading;
using WhoWantsToBeAMillionaire.Services;
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
            Debug.WriteLine("tb isEnabled: " + option0.IsEnabled+ ",  btIsEnabled:  " + btOption0.IsEnabled + "    tb name = " + option0.Name);
            Debug.WriteLine("tb isEnabled: " + option1.IsEnabled+ ",  btIsEnabled:  " + btOption1.IsEnabled + "    tb name = " + option1.Name);
            Debug.WriteLine("tb isEnabled: " + option2.IsEnabled+ ",  btIsEnabled:  " + btOption2.IsEnabled + "    tb name = " + option2.Name);
            Debug.WriteLine("tb isEnabled: " + option3.IsEnabled+ ",  btIsEnabled:  " + btOption3.IsEnabled + "    tb name = " + option3.Name);
            Debug.WriteLine("");
            _viewModel.OptionSubmitted(sender as Button);
        }

        private void btGenerateResults_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveAndDisplayResults();
        }
    }
}
