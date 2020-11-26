using System;
using System.Collections.Generic;
using System.Text;

namespace WhoWantsToBeAMillionaire.Models
{
    public class Results
    {
        // Numele jucatorului
        public string PlayerName { get; set; }
        
        // Premiul final
        public string FinalPrize { get; set; }
        
        // Numarul de raspunsuri corecte
        public int CorrectAnswers { get; set; }
        
        // Timpul scurs (total)
        public TimeSpan ElapsedTime { get; set; }
        
        // Cat timp s-a scurs in medie pentru fiecare intrebare
        public TimeSpan MediumTimeSpanPerQuestion { get; set; }
    }
}
