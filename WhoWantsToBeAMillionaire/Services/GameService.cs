using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Services
{
    class GameService
    {
        // Singleton pattern: Vom utiliza acest design pattern pentru a avea o singura instanta
        // a acestei clase.
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

        public void Init(string playerName)
        {
            // Initializarea jocului: Este creat un obiect Game. Sunt extrase intrebarile jocului din fisierul XML
            Game = new Game();
            Results = new Results();
            Game.Questions = DBService.GetTestQuestions();
            Game.PlayerName = playerName;
            CurrentQuestionId = 0;
        }

        public Question PickNext()
        {
            // In dependenta de numarul intrebarii, vom extrage o intrebare de dificultatea corespunzatoare
            if (CurrentQuestionId == 14)
                return null;

            return Game.Questions[++CurrentQuestionId];
        }

        public void GameOver()
        {

        }

        public bool CheckAnswer(int userOptionId, TimeSpan ellapsedTimeForQuestion)
        {
            Results.ElapsedTime += ellapsedTimeForQuestion;
            Results.MediumTimeSpanPerQuestion = TimeSpan.FromSeconds(Results.ElapsedTime.Seconds / (CurrentQuestionId + 1));

            var isCorrect = Game.Questions[CurrentQuestionId].CorrectOptionIndex == userOptionId;

            // Indicii castigurilor safe: 4 9 14 ($1000, $32000, $1000000).
            if (isCorrect)
            {
                switch (CurrentQuestionId)
                {
                    case 4: Game.PrizeSoFar = "$ 1 000"; break;
                    case 9: Game.PrizeSoFar = "$ 32 000"; break;
                    case 14: Game.PrizeSoFar = "$ 1 000 000";break;
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
            return LifelineService.AskAudience();
        }

        public List<string> CallAFriend(string friendName)
        {
            // Verifica daca serviciul este disponibil (nu a fost folosit deja).
            // Returneaza o lista cu replicile prietenului si participantului 
            return LifelineService.CallAFriend(friendName);
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
