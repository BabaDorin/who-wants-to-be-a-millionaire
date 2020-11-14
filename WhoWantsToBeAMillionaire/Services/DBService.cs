using System;
using System.Collections.Generic;
using System.Text;
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

        public static List<Question> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public static List<Question> GetTestQuestions()
        {
            List<Question> TestQuestions = new List<Question>();
            for (int i = 0; i < 12; i++)
            {
                Question tq = new Question()
                {
                    CorrectOptionIndex = i,
                    DifficultyLevel = DifficultyLevel.Easy,
                    Explications = "Explanations goes here",
                    Options = new List<string>() { "op1", "op2", "op3", "op4" },
                    QuestionText = "Text intrebare"
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
