using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Services;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Views
{
    public partial class AdminView : Window
    {
        
        private AdminViewModel _viewModel;

        public AdminView()
        {
            DataContext = new AdminViewModel();
            _viewModel = DataContext as AdminViewModel;
            
            InitializeComponent();
            DifficultyDropDown.ItemsSource = new List<DifficultyLevel> { DifficultyLevel.Easy, DifficultyLevel.Medium, DifficultyLevel.Hard, DifficultyLevel.Einstein };
        }

        private void McDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            btSave.IsEnabled = true;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Save();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Delete(McDataGrid);
            CollectionViewSource.GetDefaultView(McDataGrid.ItemsSource).Refresh();
        }

        private void McDataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            _viewModel.NewRow();
        }
    }
}
