using System;
using System.Collections.Generic;
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
        public LifelineService LifelineService { get; set; }

        public void Init(string playerName)
        {
            // Initializarea jocului: Este creat un obiect Game. Sunt extrase intrebarile jocului din fisierul XML
            Game = new Game();
            Game.Questions = DBService.GetQuestions();
            Game.PlayerName = playerName;
        }

        public Question PickAQuestion()
        {
            // In dependenta de numarul intrebarii, vom extrage o intrebare de dificultatea corespunzatoare
            throw new NotImplementedException();
        }

        public bool CheckAnswer(int userAnswerId)
        {
            // Verifica corectitudinea raspunsului utilizatorului.
            throw new NotImplementedException();
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
            LifelineService.FiftyFifty(Game.Questions[Game.CurrentQuestion]);
        }
    }
}
