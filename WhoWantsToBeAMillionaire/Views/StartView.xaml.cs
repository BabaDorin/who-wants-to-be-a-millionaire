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
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Services;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Views
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : UserControl
    {
        public StartView()
        {
            InitializeComponent();
            DataContext = new StartViewModel();
            ((MainWindow)System.Windows.Application.Current.MainWindow).ActivateAdminPanel();

        }

        private void btStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (GameService.GetInstace().Init(tbPlayerName.Text))
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).DeactivateAdminPanel();
                ((MainWindow)System.Windows.Application.Current.MainWindow).UpdateView("Game");
            }
        }

        private void btShowRules_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).UpdateView("Rules");
        }

        private void tbPlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            (DataContext as StartViewModel).PlayerNameNotEmpty = (tbPlayerName.Text.Trim() != "");
        }
    }
}
