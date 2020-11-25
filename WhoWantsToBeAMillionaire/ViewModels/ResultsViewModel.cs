using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using WhoWantsToBeAMillionaire.Services;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    class ResultsViewModel : BaseViewModel
    {
        public static GameService _gameService;
        public bool FiftyFiftyUsed { get; set; }
        public bool AskAudienceUsed { get; set; }
        public bool PhoneCallUsed { get; set; }
        public string PrizeWon { get; set; }
        public string TotalEllapsedTime { get; set; }
        public string MediumTimeEllapsedPerQuestion { get; set; }


        public ResultsViewModel()
        {
            _gameService = GameService.GetInstace();

            FiftyFiftyUsed = _gameService.Game.FiftyFiftyUsed;
            AskAudienceUsed = _gameService.Game.AudienceAsked;
            PhoneCallUsed = _gameService.Game.FriendCalled;
            PrizeWon = _gameService.Game.PrizeSoFar;
            if (PrizeWon.Length > 3) PrizeWon += "!";
            TotalEllapsedTime = _gameService.Results.ElapsedTime.ToString(@"mm\:ss");
            MediumTimeEllapsedPerQuestion = _gameService.Results.MediumTimeSpanPerQuestion.ToString(@"mm\:ss");
        }
    }
}
