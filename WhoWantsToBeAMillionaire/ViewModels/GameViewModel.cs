using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public List<Label> Prizes { get; set; }

        public GameViewModel()
        {
            GameService = GameService.GetInstace();
            SecondsPerQuestion = 4;

            CurrentQuestion = GameService.Game.Questions[0];
            AudienceAsked = FriendCalled = FiftyFiftyUsed = false;

            Prizes = new List<Label>();
            var SafePoints = new List<String> { "$ 1 000", "$ 32 000", "$ 1 000 000" };
            foreach (string prize in GameService.Game.Prizes)
            {
                Label lbPrize = new Label { Content = "$ " + prize };
                string styleIdentifier = "PrizeItemStyle";
                if (SafePoints.Contains(lbPrize.Content.ToString()))
                    styleIdentifier = "SafePrizeItemStyle";
                
                lbPrize.Style = Application.Current.TryFindResource(styleIdentifier) as Style;
                Prizes.Add(lbPrize);
            }
            Prizes.Reverse();

            lastItemStyle = Prizes[Prizes.Count - 1].Style;
            Prizes[Prizes.Count-1].Style = Application.Current.TryFindResource("CurrentPrize") as Style;
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
            Prizes[Prizes.Count - GameService.Game.CurrentQuestion].Style = lastItemStyle;

            lastItemStyle = Prizes[Prizes.Count - 1 - GameService.Game.CurrentQuestion].Style;

            Prizes[Prizes.Count - 1 - GameService.Game.CurrentQuestion].Style 
                = Application.Current.TryFindResource("CurrentPrize") as Style;
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
