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
    public partial class StartView : UserControl
    {
        private MainWindow _mainWindow;
        public StartView()
        {
            InitializeComponent();
            _mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;

            _mainWindow.ActivateAdminPanel();
        }

        private void btStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (GameService.GetInstace().Init(tbPlayerName.Text))
            {
                _mainWindow.DeactivateAdminPanel();
                _mainWindow.UpdateView("Game");
            }
        }

        private void btShowRules_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.UpdateView("Rules");
        }

        private void tbPlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbPlayerName.IsEnabled = (tbPlayerName.Text.Trim() != "");
        }
    }
}
