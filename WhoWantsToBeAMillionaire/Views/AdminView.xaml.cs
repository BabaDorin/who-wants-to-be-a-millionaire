using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        public List<Question> QuestionsList { get; set; }
        
        public AdminView()
        {
            InitializeComponent();

            QuestionsList = DBService.GetQuestions();
            McDataGrid.ItemsSource = QuestionsList;
            DifficultyDropDown.ItemsSource = new List<string> { "Easy", "Medium", "Hard", "Einstein" };
        }

        private void McDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        //private void InsertIntoList(Question q)
        //{
        //    questionsGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel) });
        //    int currentRowIndex = questionsGrid.RowDefinitions.Count - 1;

        //    Label lbQuestionText = new Label();
        //    lbQuestionText.Content = q.QuestionText + " 333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333";
        //    Grid.SetRow(lbQuestionText, currentRowIndex);
        //    Grid.SetColumn(lbQuestionText, 0);

        //    Button btUpdate = new Button();
        //    btUpdate.Content = "Update";
        //    btUpdate.Tag = q.QuestionId;
        //    Grid.SetRow(btUpdate, currentRowIndex);
        //    Grid.SetColumn(btUpdate, 1);

        //    Button btDelete = new Button();
        //    btDelete.Content = "Delete";
        //    btDelete.Tag = q.QuestionId;
        //    Grid.SetRow(btDelete, currentRowIndex);
        //    Grid.SetColumn(btDelete, 2);

        //    questionsGrid.Children.Add(lbQuestionText);
        //    questionsGrid.Children.Add(btUpdate);
        //    questionsGrid.Children.Add(btDelete);
        //}
    }
}
