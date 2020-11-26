using System;
using System.Collections.Generic;
using System.Text;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Services;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    class AdminViewModel
    {

        public List<Question> Questions { get; set; }
        public AdminViewModel()
        {
            Questions = DBService.GetQuestions();
        }
    }
}
