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
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        private GameViewModel _viewModel;
        DispatcherTimer ellapsedTime;
        DateTime start;

        public GameView()
        {
            DataContext = new GameViewModel();
            _viewModel = (DataContext as GameViewModel);

            InitializeComponent();

            foreach (Label lbPrize in _viewModel.PrizeLabels)
            {
                prizeStack.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(lbPrize, prizeStack.RowDefinitions.Count - 1);
                lbPrize.HorizontalContentAlignment = HorizontalAlignment.Center;
                lbPrize.VerticalAlignment = VerticalAlignment.Stretch;
                prizeStack.Children.Add(lbPrize);
            }

            ellapsedTime = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Background,
                    t_Tick, Dispatcher.CurrentDispatcher); ellapsedTime.IsEnabled = true;
            start = DateTime.Now;
        }

        private void t_Tick(object sender, EventArgs e)
        {
            var difference = DateTime.Now.Subtract(start);
            string seconds = difference.Seconds.ToString();

            if (seconds.Length == 1)
                seconds = "0" + seconds;
            timer.Content = String.Format($"0{difference.Minutes}:{seconds}");

            if (difference.Seconds > _viewModel.SecondsPerQuestion - 5)
                timer.Foreground = Brushes.Red;
            else if (difference.Seconds > _viewModel.SecondsPerQuestion - 30)
                timer.Foreground = Brushes.Yellow;

            if (difference > TimeSpan.FromSeconds(_viewModel.SecondsPerQuestion))
            {
                ellapsedTime.Stop();
                _viewModel.GameService.AddToEllapsedTime(DateTime.Now.Subtract(start));
                GameOver();
                return;
            }
        }

        private void btAskAudience_Click(object sender, RoutedEventArgs e)
        {
            start = DateTime.Now;
            _viewModel.AskAudience();

            AskAudienceUsed.Visibility = Visibility.Visible;
            btAskAudience.IsEnabled = false;
        }

        private void btPhoneCall_Click(object sender, RoutedEventArgs e)
        {
            start = DateTime.Now;
            PhoneCallUsed.Visibility = Visibility.Visible;
            btPhoneCall.IsEnabled = false;
        }

        private void btFiftyFifty_Click(object sender, RoutedEventArgs e)
        {
            start = DateTime.Now;
            _viewModel.FiftyFifty();
            FiftyFiftyUsed.Visibility = Visibility.Visible;



            btFiftyFifty.IsEnabled = false;
        }

        private async void btOption_Click(object sender, RoutedEventArgs e)
        {
            ellapsedTime.Stop();
            var btOption = sender as Button;
            btOption.Style = Application.Current.TryFindResource("OptionSelected") as Style;

            OptionsAndLifelinesSetIsEnabledPropertyTo(false);

            await Task.Delay(2);
            string feedBack = _viewModel.AnswerSubmitted(int.Parse(btOption.Tag.ToString()), DateTime.Now.Subtract(start));
            switch (feedBack)
            {
                case "Success!":
                    // Raspuns corect
                    btOption.Style = Application.Current.TryFindResource("RightOptionSelected") as Style;
                    break;

                default:
                    // Raspuns gresit
                    btOption.Style = Application.Current.TryFindResource("WrongOptionSelected") as Style;
                    GameOver();
                    return;
            }

            await Task.Delay(2);

            if (!_viewModel.PickNextQuestion())
            {
                SaveAndDisplayResults();
            }
            else
            {
                btOption.Style = Application.Current.TryFindResource("OptionPolygon") as Style;
                OptionsAndLifelinesSetIsEnabledPropertyTo(true);
                start = DateTime.Now;
                timer.Content = "00:00";
                ellapsedTime.Start();
            }
        }

        private void SaveAndDisplayResults()
        {
            _viewModel.SaveResults();
            ((MainWindow)System.Windows.Application.Current.MainWindow).UpdateView("Results");
        }

        private void GameOver()
        {
            OptionsAndLifelinesSetIsEnabledPropertyTo(false);

            RowForAdditionalInformation.Height = GridLength.Auto;
            panelExplications.Visibility = Visibility.Visible;
            string explanations = _viewModel.CurrentQuestion.Explanations;

            if (explanations != null && explanations.Length > 0)
                tbExplications.Text = explanations;

            MarkCorrectOption();
            ellapsedTime.Stop();
        }

        private void OptionsAndLifelinesSetIsEnabledPropertyTo(bool flag)
        {
            foreach (var grid in optionsGrid.Children)
                (grid as Grid).Children[0].IsEnabled = flag;

            for (int i = 0; i < 3; i++)
                (lifeLinesGrid.Children[i] as Button).IsEnabled = flag;
        }

        private void MarkCorrectOption()
        {
            var btCorrectOption = (optionsGrid.Children[_viewModel.CurrentQuestion.CorrectOptionIndex] as Grid).Children[0] as Button;
            btCorrectOption.Style = Application.Current.TryFindResource("RightOptionSelected") as Style;
        }

        private void btGenerateResults_Click(object sender, RoutedEventArgs e)
        {
            SaveAndDisplayResults();
        }
    }
}
