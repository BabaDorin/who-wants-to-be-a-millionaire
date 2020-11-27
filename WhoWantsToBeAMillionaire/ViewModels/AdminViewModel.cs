using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Services;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    class AdminViewModel : BaseViewModel
    {
        private List<Question> _questionsList;
        public List<Question> QuestionsList 
        {
            get { return _questionsList; }
            set
            {
                _questionsList = value;
                OnPropertyChanged(nameof(QuestionsList));
            }
        }
        public List<DifficultyLevel> DifficultyLevelItems { get; set; }
        public AdminViewModel()
        {
            QuestionsList = DBService.GetQuestions();
            DifficultyLevelItems = new List<DifficultyLevel> { DifficultyLevel.Easy, DifficultyLevel.Medium, DifficultyLevel.Hard, DifficultyLevel.Einstein };
        }

        public void Delete(DataGrid dataGrid)
        {
            int selectedIndex = dataGrid.SelectedIndex;
            if (selectedIndex >-1 && selectedIndex <= QuestionsList.Count)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                    "Sunteti siguri ca doriti sa excludeti intrebarea [ID: " + QuestionsList[selectedIndex].QuestionId + "]: "
                    + QuestionsList[selectedIndex].QuestionText + "?", "",
                    MessageBoxButton.YesNoCancel);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (DBService.RemoveQuestion(QuestionsList[selectedIndex].QuestionId))
                    {
                        MessageBox.Show("Intrebarea a fost eliminata cu succes.");
                    }

                    QuestionsList.RemoveAt(selectedIndex);
                }
            }
        }

        public void NewRow()
        {
            QuestionsList[QuestionsList.Count - 1].QuestionId = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            QuestionsList[QuestionsList.Count - 1].Options = new List<string>() { "", "", "", "" };
        }

        public void Save()
        {
            if (DBService.WriteQuestionsToXmlFile(QuestionsList))
            {
                MessageBox.Show("Modificarile au fost efectuate cu succes!");
            }
            else
            {
                MessageBox.Show("S-au produs erori la salvarea datelor.");
            }
        }
    }
}
