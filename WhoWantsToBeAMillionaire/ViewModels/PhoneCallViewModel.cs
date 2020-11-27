using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    class PhoneCallViewModel : BaseViewModel
    {
        private bool _callButtonIsEnabled;
        public bool CallButtonIsEnabled
        {
            get
            {
                return _callButtonIsEnabled;
            }
            set
            {
                _callButtonIsEnabled = value;
                OnPropertyChanged(nameof(CallButtonIsEnabled));
            }
        }

        private Visibility _gridInputVisibility;
        public Visibility GridInputVisibility
        {
            get
            {
                return _gridInputVisibility;
            }
            set
            {
                _gridInputVisibility = value;
                OnPropertyChanged(nameof(GridInputVisibility));
            }
        }
        
        private Visibility _gridDialogVisibility;
        public Visibility GridDialogVisibility
        {
            get
            {
                return _gridDialogVisibility;
            }
            set
            {
                _gridDialogVisibility = value;
                OnPropertyChanged(nameof(GridDialogVisibility));
            }
        }

        public PhoneCallViewModel()
        {
            GridInputVisibility = Visibility.Visible;
            GridDialogVisibility = Visibility.Collapsed;
        }
    }
}
