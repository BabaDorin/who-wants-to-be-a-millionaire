using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoWantsToBeAMillionaire.Models
{
    public enum DifficultyLevel
    {
        Easy = 0, // 100 - 300                  | 4 intrebari
        Medium = 1, // 500 - 16 000             | 5 intrebari
        Hard = 2, // 32 000 - 250 000           | 4 intrebari
        Einstein = 3 // 500 000 - 1 000 000     | 2 intrebari
    }

    public class Question
    {
        public string QuestionId { get; set; }

        // Intrebarea propriu zisa (Textul intrebarii)
        [Required]
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
        public string Explanations { get; set; }
    }
}
