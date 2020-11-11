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

        public static bool RemoveQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public static bool UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
