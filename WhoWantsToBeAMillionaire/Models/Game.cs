using System;
using System.Collections.Generic;
using System.Text;
using WhoWantsToBeAMillionaire.Services;

namespace WhoWantsToBeAMillionaire.Models
{
    class Game
    {
        // Numele jucatorului
        public string PlayerName { get; set; }
        
        // Indicele intrebarii curente
        public int CurrentQuestion { get; set; }
        
        // Lista de premii banesti 
        public List<string> Prizes { get; set; }
        
        // Premiul curent al jucatorului
        public string PrizeSoFar { get; set; }

        // Intrebarile propriu zise
        public List<Question> Questions { get; set; }

        // Disponibilitatea optiunilor ajutatoare (Lifelines)
        public bool AudienceAsked { get; set; }
        public bool FriendCalled { get; set; }
        public bool FiftyFiftyUsed { get; set; }

        // Parametri configurabili
        // Timpul maxim admisibil pentru o intrebare
        public int MaximulAllowedTimePerQuestion { get; set; }

        public Game()
        {
            PrizeSoFar = "0";
            
            Prizes.Add("100");
            Prizes.Add("200");
            Prizes.Add("300");
            Prizes.Add("500");
            Prizes.Add("1 000"); // SafePoint
            Prizes.Add("2 000");
            Prizes.Add("4 000");
            Prizes.Add("8 000");
            Prizes.Add("16 000");
            Prizes.Add("32 000"); // SafePoint
            Prizes.Add("64 000");
            Prizes.Add("125 000");
            Prizes.Add("250 000");
            Prizes.Add("500 000");
            Prizes.Add("1 000 000"); // SafePoint
        }
    }
}
