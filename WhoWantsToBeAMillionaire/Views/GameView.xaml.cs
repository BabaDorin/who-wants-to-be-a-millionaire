using System;
using System.Collections.Generic;
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
    }
}
