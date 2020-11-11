using System;
using System.Collections.Generic;
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
        private void btToggleVolume_Click(object sender, RoutedEventArgs e)
        {
            UpdateView("Start");
        }

        private void btAdminPanel_Click(object sender, RoutedEventArgs e)
        {
            UpdateView("Game");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void StartGame()
        {

        }

        public void UpdateView(string parameter)
        {
            (DataContext as MainViewModel).UpdateViewCommand.Execute(parameter);
        }
    }
}
