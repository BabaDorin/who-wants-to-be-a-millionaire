using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Principal;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Services;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    class GameViewModel : BaseViewModel
    {
        public GameService GameService { get; set; }

        private Question _currentQuestion;
        public Question CurrentQuestion
        {
            get
            {
                return _currentQuestion;
            }
            set
            {
                _currentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        // Lifelines availability
        private bool _audienceAsked;
        public bool AudienceAsked { 
            get { return _audienceAsked; } 
            set 
            {
                _audienceAsked = value;
                OnPropertyChanged(nameof(AudienceAsked));
            } 
        }

        private bool _friendCalled;
        public bool FriendCalled
        {
            get { return _friendCalled; }
            set
            {
                _friendCalled = value;
                OnPropertyChanged(nameof(FriendCalled));
            }
        }

        private bool _fiftyFiftyUsed;
        public bool FiftyFiftyUsed
        {
            get { return _fiftyFiftyUsed; }
            set
            {
                _fiftyFiftyUsed = value;
                OnPropertyChanged(nameof(FiftyFiftyUsed));
            }
        }

        public List<Label> Prizes { get; set; }

        public GameViewModel()
        {
            GameService = GameService.GetInstace();

            CurrentQuestion = GameService.Game.Questions[0];
            AudienceAsked = FriendCalled = FiftyFiftyUsed = false;

            Prizes = new List<Label>();
            foreach (string prize in GameService.Game.Prizes)
            {
                Label lbPrize = new Label { Content = prize };
                Prizes.Add(lbPrize);
            }
            Prizes.Reverse();
            Prizes[Prizes.Count-1].Background = Brushes.Black;
        }

        public string AnswerSubmitted(int optionId)
        {
            // Returneaza "Success!" Daca a fost ales raspunsul corect,
            // Returneaza Game.Explanations Daca a fost ales un raspuns gresit
            // Returneaza "Winner!" Daca a fost ales raspunsul corect pentru ultima intrebare

            if (GameService.CheckAnswer(optionId))
            {
                CurrentQuestion = GameService.PickNext();

                if(CurrentQuestion == null)
                {
                    // Nu mai sunt intrebari. Au fost raspunse toate corect.
                    return "Winner!";
                }

                MarkCurrentPrizeWithinPrizeStack();
                return "Success!";
            }
            else
            {
                GameOver();
                return CurrentQuestion.Explanations;
            }
        }

        public void MarkCurrentPrizeWithinPrizeStack()
        {
            Prizes[Prizes.Count - 1 - GameService.Game.CurrentQuestion].Background = Brushes.Black;
        }

        public void GameOver()
        {
            FiftyFiftyUsed = true;
            FriendCalled = true;
            AudienceAsked = true;

            GameService.GameOver();
        }

        // TODO: Find a way to deal with lifelinesAvailability renundance
        // TODO: Add default style
    }
}
