using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Services
{
    class GameService
    {
        // Singleton pattern: Vom utiliza acest design pattern pentru a avea o singura instanta a clasei
        private static GameService instance;
        private GameService() { }
        public static GameService GetInstace()
        {
            if (instance == null)
                instance = new GameService();

            return instance;
        }

        public Game Game { get; set; }

        public Results Results { get; set; }

        public LifelineService LifelineService { get; set; }

        public int CurrentQuestionId { get; set; }

        public bool Init(string playerName)
        {
            try
            {
                // Initializarea jocului: Este creat un obiect Game. Sunt extrase intrebarile jocului din fisierul XML
                Game = new Game();
                LifelineService = new LifelineService();
                Results = new Results();

                Game.Questions = RetrieveAndSelect15Questions();

                // Este nevoie de minim 15 intrebari pentru a incepe jocul
                if (Game.Questions.Count < 15)
                {
                    MessageBox.Show("Este nevoie de minim 15 intrebari pentru a initia un joc.");
                    return false;
                }

                Game.PlayerName = Results.PlayerName = playerName;
                CurrentQuestionId = 0;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("S-a produs o eroare la initializarea jocului.");
                return false;
            }
        }

        public Question PickNext()
        {
            if (CurrentQuestionId == 14) // Au fost raspunse deja 15 intrebari
                return null;

            return Game.Questions[++CurrentQuestionId];
        }

        public List<Question> RetrieveAndSelect15Questions()
        {
            // Easy, // 100 - 300                  | 4 intrebari
            // Medium, // 500 - 16 000             | 5 intrebari
            // Hard, // 32 000 - 250 000           | 4 intrebari
            // Einstein // 500 000 - 1 000 000     | 2 intrebari

            List<Question> allQuestions = DBService.GetQuestions();
            if (allQuestions.Count < 15)
                return allQuestions;

            List<Question> gameQuestions = new List<Question>();

            // Popularea listei cu intrebari din diferite categorii de dificultate.
            PopulateList(allQuestions, gameQuestions, DifficultyLevel.Easy, 4);
            PopulateList(allQuestions, gameQuestions, DifficultyLevel.Medium, 5);
            PopulateList(allQuestions, gameQuestions, DifficultyLevel.Hard, 4);
            PopulateList(allQuestions, gameQuestions, DifficultyLevel.Einstein, 2);

            // Populam cu intrebari aleatoare daca lista contine mai putin de 15 intrebari,
            Random rnd = new Random();
            while (gameQuestions.Count < 15)
            {
                Question selectedQ = allQuestions[rnd.Next(0, allQuestions.Count)];
                gameQuestions.Add(selectedQ);
                allQuestions.Remove(selectedQ);
            }

            // Sortarea intrebarilor astfel incat primele sa fie mereu cele mai usoare.
            gameQuestions = gameQuestions.OrderBy(q => q.DifficultyLevel).ToList();

            return gameQuestions;
        }

        public void PopulateList(List<Question> AllQuestions, List<Question> FinalQuestionsList, DifficultyLevel difficultyLevel, int maximumQuestions)
        {
            // Populeaza lista 'FinalQuestionsList' cu maxim 'maximumQuestions' intrebari de dificultatea
            // 'difficultyLevel' din lista tuturor intrebarilor 'AllQuestions'

            List<Question> questionsByDiffLevel = AllQuestions.Where(q => q.DifficultyLevel == difficultyLevel).ToList();
            int questionsCount = questionsByDiffLevel.Count;
            if (questionsCount > maximumQuestions)
                questionsCount = maximumQuestions;

            Random rnd = new Random();

            for (int i = 0; i < questionsCount; i++)
            {
                Question selectedQ = questionsByDiffLevel[rnd.Next(0, questionsByDiffLevel.Count)];
                FinalQuestionsList.Add(selectedQ);

                questionsByDiffLevel.Remove(selectedQ);
            }
        }

        public void AddToEllapsedTime(TimeSpan timeSpan)
        {
            Results.ElapsedTime += timeSpan;
            Results.MediumTimeSpanPerQuestion = TimeSpan.FromSeconds(Results.ElapsedTime.Seconds / (CurrentQuestionId + 1));
        }

        public bool CheckOption(int userOptionId, TimeSpan ellapsedTimeForQuestion)
        {
            AddToEllapsedTime(ellapsedTimeForQuestion);
            var isCorrect = Game.Questions[CurrentQuestionId].CorrectOptionIndex == userOptionId;

            // Indicii castigurilor safe: 4 9 14 ($1000, $32000, $1000000).
            if (isCorrect)
            {
                switch (CurrentQuestionId)
                {
                    case 4: Game.PrizeSoFar = Game.PrizeList[4]; break;
                    case 9: Game.PrizeSoFar = Game.PrizeList[9]; break;
                    case 14: Game.PrizeSoFar = Game.PrizeList[14]; break;
                    default: break;
                }
            }

            return isCorrect;
        }

        public List<int> AskAudience()
        {
            // Verifica daca serviciul este disponibil (nu a fost folosit deja).
            // Returneaza o lista cu 4 valori - fiecare numar reprezentand procentajul
            // din aduienta care a indicat anume acea optiune;
            return LifelineService.AskAudience(Game.Questions[CurrentQuestionId]);
        }

        public void SaveResults()
        {
            Results.FinalPrize = Game.PrizeSoFar;
            Results.CorrectAnswers = CurrentQuestionId;
            if (Game.PrizeSoFar == Game.PrizeList[14]) Results.CorrectAnswers = CurrentQuestionId + 1;
            DBService.SaveResults(Results);
        }

        public void Retreat()
        {
            // Daca jucatorul decide sa se retraga din joc, atunci premiul lui final va fi cel al utimei intrebari raspunse corect.
            if (CurrentQuestionId == 0)
                Game.PrizeSoFar = "$ 0";
            else
                Game.PrizeSoFar = Game.PrizeList[CurrentQuestionId - 1];
        }

        public List<string> CallAFriend(string friendName)
        {
            // Verifica daca serviciul este disponibil (nu a fost folosit deja).
            // Returneaza o lista cu replicile prietenului si participantului 
            return LifelineService.CallAFriend(friendName, Results.PlayerName, Game.Questions[CurrentQuestionId]);
        }

        public void FiftyFifty()
        {
            // Verifica daca serviciul este disponibil (nu a fost folosit deja).
            // Exclude 2 raspunsuri incorecte (textul raspunsurilor este marcat ca fiind "", deja 
            // este treaba ViewModel-ului sa dezactiveze butoanele ce contin aceste raspunsuri).

            LifelineService.FiftyFifty(Game.Questions[CurrentQuestionId]);
        }
    }
}
