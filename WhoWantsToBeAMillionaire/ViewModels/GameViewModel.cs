using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private Style lastItemStyle = null;

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
        //public int CurrentQuestion { get; set; }

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

        private int _secondsPerQuestion;
        public int SecondsPerQuestion
        {
            get { return _secondsPerQuestion; }
            set
            {
                _secondsPerQuestion = value;
                OnPropertyChanged(nameof(SecondsPerQuestion));
            }
        }
        public List<Label> PrizeLabels { get; set; }

        public GameViewModel()
        {
            GameService = GameService.GetInstace();
            SecondsPerQuestion = 20;

            CurrentQuestion = GameService.Game.Questions[0];
            AudienceAsked = FriendCalled = FiftyFiftyUsed = false;

            var Prizes = new List<string>
            {
                "$ 100", "$ 200", "$ 300", "$ 500",
                "$ 1 000", "$ 2 000", "$ 4 000", "$ 8 000",
                "$ 16 000", "$ 32 000", "$ 64 000", "$ 125 000",
                "$ 250 000", "$ 500 000", "$ 1 000 000"
            };

            var SafePoints = new List<String> { "$ 1 000", "$ 32 000", "$ 1 000 000" };
            PrizeLabels = new List<Label>();

            foreach (string prize in Prizes)
            {
                Label lbPrize = new Label { Content = prize };

                string styleIdentifier = "PrizeItemStyle";
                if (SafePoints.Contains(lbPrize.Content.ToString()))
                    styleIdentifier = "SafePrizeItemStyle";
                
                lbPrize.Style = Application.Current.TryFindResource(styleIdentifier) as Style;
                PrizeLabels.Add(lbPrize);
            }

            PrizeLabels.Reverse();

            lastItemStyle = PrizeLabels[PrizeLabels.Count - 1].Style;
            PrizeLabels[PrizeLabels.Count-1].Style = Application.Current.TryFindResource("CurrentPrize") as Style;
        }

        public string AnswerSubmitted(int optionId, TimeSpan ellapsedTimeForQuestion)
        {
            // Returneaza "Success!" Daca a fost ales raspunsul corect,
            // Returneaza Game.Explanations Daca a fost ales un raspuns gresit
            // Returneaza "Winner!" Daca a fost ales raspunsul corect pentru ultima intrebare

            if (GameService.CheckAnswer(optionId, ellapsedTimeForQuestion))
            {
                return "Success!";
            }
            else
            {
                return "NotSuccess";
            }
        }

        public void SaveResults()
        {
            GameService.SaveResults();
        }

        public bool PickNextQuestion()
        {
            CurrentQuestion = GameService.PickNext();

            if (CurrentQuestion == null)
            {
                return false; // Nu mai sunt intrebari
            }

            MarkCurrentPrizeWithinPrizeStack();
            return true;
        }

        public void MarkCurrentPrizeWithinPrizeStack()
        {
            PrizeLabels[PrizeLabels.Count - GameService.CurrentQuestionId].Style = lastItemStyle;

            lastItemStyle = PrizeLabels[PrizeLabels.Count - 1 - GameService.CurrentQuestionId].Style;

            PrizeLabels[PrizeLabels.Count - 1 - GameService.CurrentQuestionId].Style 
                = Application.Current.TryFindResource("CurrentPrize") as Style;
        }

        public void GameOver()
        {
            FiftyFiftyUsed = true;
            FriendCalled = true;
            AudienceAsked = true;

            GameService.GameOver();
        }

        public void FiftyFifty()
        {
            GameService.FiftyFifty();
            OnPropertyChanged(nameof(CurrentQuestion));
        }


        // TODO: Find a way to deal with lifelinesAvailability renundance
        // TODO: Add default style
    }
}
