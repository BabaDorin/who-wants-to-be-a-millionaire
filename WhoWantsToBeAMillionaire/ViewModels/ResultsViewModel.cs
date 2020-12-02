using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Services;
using WhoWantsToBeAMillionaire.Views;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    class ResultsViewModel : BaseViewModel
    {
        private GameService _gameService;
        private ResultsView _view;
        
        public string PrizeWon { get; set; }
        public string TotalEllapsedTime { get; set; }
        public string MediumTimeEllapsedPerQuestion { get; set; }


        public ResultsViewModel(ResultsView view)
        {
            _view = view;
            _gameService = GameService.GetInstace();

            PrizeWon = _gameService.Results.FinalPrize;
            
            TotalEllapsedTime = _gameService.Results.ElapsedTime.ToString(@"mm\:ss");
            MediumTimeEllapsedPerQuestion = _gameService.Results.MediumTimeSpanPerQuestion.ToString(@"mm\:ss");

            int prizeId = Game.PrizeList.IndexOf(PrizeWon);
            switch (prizeId)
            {
                case -1:
                    _view.mainGrid.Style = Application.Current.TryFindResource("DangerGrid") as Style;
                    _view.mainUserControl.Style = Application.Current.TryFindResource("NoWin") as Style;
                    break;
                case int n when(n >= 0 && n < 14):
                    _view.mainGrid.Style = Application.Current.TryFindResource("SuccessGrid") as Style;
                    _view.mainUserControl.Style = Application.Current.TryFindResource("Win") as Style;
                    break;
                case 14:
                    _view.mainGrid.Style = Application.Current.TryFindResource("SuccessGrid") as Style;
                    _view.mainUserControl.Style = Application.Current.TryFindResource("BigWin") as Style;
                    break;
            }
        }
    }
}
