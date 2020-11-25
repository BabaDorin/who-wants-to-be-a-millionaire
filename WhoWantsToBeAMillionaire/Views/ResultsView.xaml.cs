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
    /// Interaction logic for ResultsView.xaml
    /// </summary>
    public partial class ResultsView : UserControl
    {
        private static ResultsViewModel _viewModel;
        public ResultsView()
        {
            InitializeComponent();
            DataContext = new ResultsViewModel();
            _viewModel = DataContext as ResultsViewModel;
            Debug.Write(_viewModel.PrizeWon);

            switch (_viewModel.PrizeWon)
            {
                case "$ 0": 
                    mainGrid.Style = Application.Current.TryFindResource("DangerGrid") as Style; 
                    mainUserControl.Style = Application.Current.TryFindResource("NoWin") as Style; 
                    break;
                case "$ 1 000!":
                case "$ 32 000!":
                    mainGrid.Style = Application.Current.TryFindResource("SuccessGrid") as Style;
                    mainUserControl.Style = Application.Current.TryFindResource("Win") as Style;
                    break;
                case "$ 1 000 000!":
                    mainGrid.Style = Application.Current.TryFindResource("SuccessGrid") as Style;
                    mainUserControl.Style = Application.Current.TryFindResource("BigWin") as Style;
                    break;
            }
        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).UpdateView("Start");
        }
    }
}
