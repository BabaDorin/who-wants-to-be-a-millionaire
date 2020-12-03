using System.Windows;
using System.Windows.Controls;
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
