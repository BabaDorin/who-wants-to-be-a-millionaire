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
        private Visibility _loginPageVisibility;
        public Visibility LoginPageVisibility
        {
            get { return _loginPageVisibility; }
            set
            {
                _loginPageVisibility = value;
                OnPropertyChanged(nameof(LoginPageVisibility));
            }
        }

        private Visibility _adminPanelVisibility;
        public Visibility AdminPanelVisibility
        {
            get { return _adminPanelVisibility; }
            set
            {
                _adminPanelVisibility = value;
                OnPropertyChanged(nameof(AdminPanelVisibility));
            }
        }

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
        
        public DataGrid QuestionsDataGrid;
        
        public AdminViewModel()
        {
            // Initial este visibila doar pagina de logare.
            LoginPageVisibility = Visibility.Visible;
            AdminPanelVisibility = Visibility.Collapsed;
        }

        public void DeleteSelectedRecord()
        {
            // Verificam daca randul selectat reprezinta o inregistrare reala. In caz afirmativ - o eliminam, dar nu inainte
            // de a afisa un messageBox pentru confirmare.
            int selectedIndex = QuestionsDataGrid.SelectedIndex;
            if (selectedIndex > -1 && selectedIndex <= QuestionsList.Count)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                    "Sunteti siguri ca doriti sa excludeti intrebarea [ID: " + QuestionsList[selectedIndex].QuestionId + "]: "
                    + QuestionsList[selectedIndex].QuestionText + "?", "",
                    MessageBoxButton.YesNoCancel);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (DBService.RemoveQuestion(QuestionsList[selectedIndex].QuestionId))
                        MessageBox.Show("Intrebarea a fost eliminata cu succes.");

                    QuestionsList.RemoveAt(selectedIndex);
                }
            }
        }

        public void Login(string password)
        {
            // Verificam daca parola indicata este valida. In caz afirmativ, pagina de logare este ascunsa, intrebarile sunt extrase
            // din fisierul xml si panoul de administrare devine visibil. 
            if(password == "admin")
            {
                QuestionsList = DBService.GetQuestions();

                AdminPanelVisibility = Visibility.Visible;
                LoginPageVisibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Parola introdusa este invalida.");
            }
        }

        public bool CloseWindow()
        {
            // Aceasta metoda este apelata din code behind atunci cand utilizatorul doreste sa inchida fereastra in timp ce exista
            // unele modificari nesalvate. In acest caz, utilizatorul va fi instiintat printr-un messageBox. El va avea posiblitatea
            // de a salva modificarile, de a nu le salva si de a anula actiunea.
            // Daca functia returneaza true, atunci fereastra se va inchide.

            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Doriti sa salvati modificarile?", "", MessageBoxButton.YesNoCancel);
            
            switch (messageBoxResult)
            {
                case MessageBoxResult.Yes:
                    DBService.WriteQuestionsToXmlFile(QuestionsList);
                    return true;
                case MessageBoxResult.No:
                    return true;
                default:
                    return false;
            }
        }

        public void NewRow()
        {
            // Utilizatorul a creat un nou rand in datgrid, campul pentru Id-ul intrebarii este setat automat
            // Valoarea acestuia este numarul de secunde scurse incepand cu nasterea epocii Unix - January 1st, 1970
            QuestionsList[QuestionsList.Count - 1].QuestionId = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            QuestionsList[QuestionsList.Count - 1].Options = new List<string>() { "", "", "", "" };
        }

        public void Save()
        {
            if (DBService.WriteQuestionsToXmlFile(QuestionsList))
                MessageBox.Show("Modificarile au fost efectuate cu succes!");
            else
                MessageBox.Show("S-au produs erori la salvarea datelor.");
        }
    }
}
