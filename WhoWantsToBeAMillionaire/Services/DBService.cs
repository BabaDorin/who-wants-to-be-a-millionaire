using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Services
{
    class DBService
    {
        public string XMLResultsPath { get; set; }
        public string XMLQuestionsPath { get; set; }

        // Metodele ce definesc operatiile CRUD: Create, Read, Update, Delete
        
        public static bool AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public static void SaveResults(Results results)
        {
            MessageBox.Show("Implement");
        }

        public static List<Question> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public static List<Question> GetTestQuestions()
        {
            List<Question> TestQuestions = new List<Question>();
            for (int i = 0; i < 15; i++)
            {
                Question tq = new Question()
                {
                    CorrectOptionIndex = 1,
                    DifficultyLevel = DifficultyLevel.Easy,
                    Explanations = "The quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphs grab quick-jived waltz. Brick quiz whangs jumpy veldt fox. Bright vixens jump; dozy fowl quack. Quick wafting zephyrs vex bold",
                    Options = new List<string>() { "op1", "op2", "op3", "op4" },
                    QuestionText = "Text intrebare " + i
                };
                TestQuestions.Add(tq);
            }

            return TestQuestions;
        }

        public static bool RemoveQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public static bool UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        // TODO: Encryption and decryption of XML files
    }
}
