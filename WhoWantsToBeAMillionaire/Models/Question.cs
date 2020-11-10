using System;
using System.Collections.Generic;
using System.Text;

namespace WhoWantsToBeAMillionaire.Models
{
    enum DifficultyLevel
    {
        Easy, // 100 - 300                  | 3 intrebari
        Medium, // 500 - 2 000              | 3 intrebari
        UpperMedium, // 4 000 - 16 000      | 3 intrebari
        Hard, // 32 000 - 250 000           | 4 intrebari
        Einstein // 500 000 - 1 000 000     | 2 intrebari
    }

    class Question
    {
        // Intrebarea propriu zisa (Textul intrebarii)
        public string QuestionText { get; set; }
        
        // Nivelul de dificultate al intrebarii
        public DifficultyLevel DifficultyLevel { get; set; }
        
        // Optiunile de raspuns
        public List<string> Options { get; set; }
        
        // Indicele raspunsului corect
        public int CorrectOptionIndex { get; set; }
        
        // Explicatii suplimentare (In cazul in care jucatorul alege o optiune gresita,
        // va fi afiat care a fost raspunsul corect, impreuna cu o explicatie)
        // Campul este optional
        public string Explications { get; set; }
    }
}
