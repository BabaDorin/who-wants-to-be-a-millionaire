using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Views
{
    public partial class AdminView : Window
    {
        private AdminViewModel _viewModel;

        public AdminView()
        {
            // Initializarea ferestrei. Setam o instanta a clasei AdminViewModel ca DataContext pentru aceasta fereastra.
            DataContext = new AdminViewModel();
            _viewModel = DataContext as AdminViewModel;
            
            InitializeComponent();
            
            // Populam dropdown-ul cu nivelurile de dificultate
            DifficultyDropDown.ItemsSource = new List<DifficultyLevel> { DifficultyLevel.Easy, DifficultyLevel.Medium, DifficultyLevel.Hard, DifficultyLevel.Einstein };
            
            _viewModel.QuestionsDataGrid = QuestionsDataGrid;
        }

        private void QuestionsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Daca au fost efectuate unele modificari, butonul pentru salvare a modificarilor devine activ.
            btSave.IsEnabled = true;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Save();
            btSave.IsEnabled = false;
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            // Eliminam inregistrarea selectata si reimprospatam datagrid-ul pentru a vizualiza imediat schimbarile.
            _viewModel.DeleteSelectedRecord();
            CollectionViewSource.GetDefaultView(QuestionsDataGrid.ItemsSource).Refresh();
        }

        private void QuestionsDataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            // Cand este adaugat un nou rand in datagrid apelam metoda NewRow care va seta o valoare unica pentru campul QuestionId
            _viewModel.NewRow();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // Inainte de a inchide fereastra ne asiguram ca nu au ramas modificari nesalvate. 
            if (btSave.IsEnabled)
            {
                if (!_viewModel.CloseWindow())
                    e.Cancel = true;
            }
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Login(passwordBox.Password);
        }
    }
}
