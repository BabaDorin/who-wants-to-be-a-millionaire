using System;
using System.Collections.Generic;
using System.Text;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    class StartViewModel : BaseViewModel
    {
        private bool _playerNameNotEmpty;
        public bool PlayerNameNotEmpty
        {
            get
            {
                return _playerNameNotEmpty;
            }
            set
            {
                _playerNameNotEmpty = value;
                OnPropertyChanged(nameof(PlayerNameNotEmpty));
            }
        }
    }
}
