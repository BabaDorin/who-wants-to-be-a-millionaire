using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

            foreach(Label lbPrize in _viewModel.Prizes)
            {
                prizeStack.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(lbPrize, prizeStack.RowDefinitions.Count - 1);
                lbPrize.HorizontalContentAlignment = HorizontalAlignment.Center;
                lbPrize.VerticalAlignment= VerticalAlignment.Stretch;
                prizeStack.Children.Add(lbPrize);
            }

            ellapsedTime = new DispatcherTimer(new TimeSpan(0, 0, 0, 1), DispatcherPriority.Background,
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

            if (difference.Seconds == _viewModel.SecondsPerQuestion)
            {
                MessageBox.Show("gata!");
                ellapsedTime.Stop();
            }
        }

        private void btAskAudience_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Content = new AskAudienceView()
            };
            window.Height = 400;
            window.Width = 400;
            window.ShowDialog();

            AskAudienceUsed.Visibility = Visibility.Visible;
            btAskAudience.IsEnabled = false;
        }

        private void btPhoneCall_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallUsed.Visibility = Visibility.Visible;
            btPhoneCall.IsEnabled = false;
        }

        private void btFiftyFifty_Click(object sender, RoutedEventArgs e)
        {
            start = DateTime.Now;
            FiftyFiftyUsed.Visibility = Visibility.Visible;
            btFiftyFifty.IsEnabled = false;
        }

        private async void btOption_Click(object sender, RoutedEventArgs e)
        {
            (sender as Polygon).Style = Application.Current.TryFindResource("OptionSelected") as Style;
            await Task.Delay(2000);
            string feedBack = _viewModel.AnswerSubmitted(int.Parse((sender as FrameworkElement).Tag.ToString()));

            switch (feedBack)
            {
                case "Success!": (sender as Polygon).Style = Application.Current.TryFindResource("RightOptionSelected") as Style;
                    break;
                case "Winner": break;
                case null: break;
                default: lbExplications.Content = feedBack;
                    (sender as Polygon).Style = Application.Current.TryFindResource("WrongOptionSelected") as Style;
                    MarkCorrectOption();
                    await Task.Delay(2000);
                    Alert alert = new Alert("Game over, pleci acas cu putini bani", "danger");
                    alert.ShowDialog();
                    lbExplications.Visibility = Visibility.Visible; // afiseaza rezultatele
                    return;
            }

            await Task.Delay(2000);
            _viewModel.PickNextQuestion();
            (sender as Polygon).Style = Application.Current.TryFindResource("OptionPolygon") as Style;
        }

        private void MarkCorrectOption()
        {
            //throw new NotImplementedException();
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
