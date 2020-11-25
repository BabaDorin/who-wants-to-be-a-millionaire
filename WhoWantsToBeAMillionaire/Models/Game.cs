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
        
        // Premiul curent al jucatorului
        public string PrizeSoFar { get; set; }

        // Intrebarile propriu zise
        public List<Question> Questions { get; set; }

        // Disponibilitatea optiunilor ajutatoare (Lifelines)
        public bool AudienceAsked { get; set; }
        public bool FriendCalled { get; set; }
        public bool FiftyFiftyUsed { get; set; }

        // Timpul maxim admisibil pentru o intrebare
        public int MaximulAllowedTimePerQuestion { get; set; }

        // Timpul total scurs
        public TimeSpan TotalEllapsedTime { get; set; }

        public Game()
        {
            PrizeSoFar = "0";
            TotalEllapsedTime = TimeSpan.FromSeconds(0);
        }
    }
}
