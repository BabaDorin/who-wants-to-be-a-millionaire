using System;
using System.Collections.Generic;

namespace WhoWantsToBeAMillionaire.Models
{
    class Game
    {
        public string PlayerName { get; set; }

        // Premiul curent al jucatorului
        public string PrizeSoFar { get; set; } = "$ 0";

        // Intrebarile propriu zise
        public List<Question> Questions { get; set; }

        // Disponibilitatea optiunilor ajutatoare (Lifelines)
        public bool AudienceAsked { get; set; }
        public bool FriendCalled { get; set; }
        public bool FiftyFiftyUsed { get; set; }

        // Timpul total scurs
        public TimeSpan TotalEllapsedTime { get; set; } = TimeSpan.FromSeconds(0);

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
    }
}
