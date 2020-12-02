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
    public partial class ResultsView : UserControl
    {
        private static ResultsViewModel _viewModel;
        public ResultsView()
        {
            InitializeComponent();
            DataContext = new ResultsViewModel(this);
            _viewModel = DataContext as ResultsViewModel;
        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).UpdateView("Start");
        }
    }
}
