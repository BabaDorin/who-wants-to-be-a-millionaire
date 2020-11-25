using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using WhoWantsToBeAMillionaire.ViewModels;
using WhoWantsToBeAMillionaire.Views;

namespace WhoWantsToBeAMillionaire
{
    public partial class MainWindow : Window
    {
        private static MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
            _viewModel = (DataContext as MainViewModel);
            UpdateView("Start");
        }

        private void btToggleVolume_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btAdminPanel_Click(object sender, RoutedEventArgs e)
        {

        }

        public void UpdateView(string parameter)
        {
            _viewModel.UpdateViewCommand.Execute(parameter);
        }

        private void UpperMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
