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
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    ///

    //public class DisplayQuestion
    //{
    //    public string QuestionId { get; set; }

    //    public string QuestionText { get; set; }

    //    public DifficultyLevel DifficultyLevel { get; set; }

    //    public List<string> Options { get; set; }

    //    public int CorrectOptionIndex { get; set; }

    //    public string Explanations { get; set; }
    //}

    public partial class AdminView : Window
    {
        
        private AdminViewModel _viewModel;

        public AdminView()
        {
            DataContext = new AdminViewModel();
            _viewModel = DataContext as AdminViewModel;
            
            InitializeComponent();
            //McDataGrid.ItemsSource = _viewModel.QuestionsList;
            DifficultyDropDown.ItemsSource = new List<string> { "Easy", "Medium", "Hard", "Einstein" };
        }

        private void McDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            btSave.IsEnabled = true;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_viewModel.QuestionsList.Count.ToString());
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Delete(McDataGrid);
            CollectionViewSource.GetDefaultView(McDataGrid.ItemsSource).Refresh();
        }

        private void McDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            //_viewModel.NewRow();
            //CollectionViewSource.GetDefaultView(McDataGrid.ItemsSource).Refresh();
        }

        private void McDataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            _viewModel.NewRow();
        }
    }
}
