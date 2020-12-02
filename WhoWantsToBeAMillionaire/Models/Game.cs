using System;
using System.Collections.Generic;
using System.Text;
using WhoWantsToBeAMillionaire.Services;

namespace WhoWantsToBeAMillionaire.Models
{
    class Game
    {
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

        public static List<string> PrizeList { get; set; } = new List<string>
            {
                "$ 100", "$ 200", "$ 300", "$ 500",
                "$ 1 000", "$ 2 000", "$ 4 000", "$ 8 000",
                "$ 16 000", "$ 32 000", "$ 64 000", "$ 125 000",
                "$ 250 000", "$ 500 000", "$ 1 000 000"
            };

        public static List<string> SafePoints = new List<String>
            {
                "$ 1 000", "$ 32 000", "$ 1 000 000"
            };

        public Game()
        {
            PrizeSoFar = "$ 0";

            //PrizeList = new List<string>
            //{
            //    "$ 100", "$ 200", "$ 300", "$ 500",
            //    "$ 1 000", "$ 2 000", "$ 4 000", "$ 8 000",
            //    "$ 16 000", "$ 32 000", "$ 64 000", "$ 125 000",
            //    "$ 250 000", "$ 500 000", "$ 1 000 000"
            //};

            //SafePoints = new List<String>
            //{
            //    "$ 1 000", "$ 32 000", "$ 1 000 000"
            //};

            TotalEllapsedTime = TimeSpan.FromSeconds(0);
        }
    }
}
