using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView()
        {
            DataContext = new GameViewModel();
            //(DataContext as GameViewModel).CurrentQuestion = "cf sarak";
            InitializeComponent();

            foreach(Label lbPrize in (DataContext as GameViewModel).Prizes)
            {
                prizeStack.Children.Add(lbPrize);
                lbPrize.HorizontalContentAlignment = HorizontalAlignment.Center;
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
        }

        private void btPhoneCall_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btFiftyFifty_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btOption_Click(object sender, RoutedEventArgs e)
        {
            string feedBack = (DataContext as GameViewModel).AnswerSubmitted(int.Parse((sender as Button).Tag.ToString()));

            switch (feedBack)
            {
                case "Success!": break;
                case "Winner": break;
                case null: break;
                default: lbExplications.Content = feedBack;
                    lbExplications.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
