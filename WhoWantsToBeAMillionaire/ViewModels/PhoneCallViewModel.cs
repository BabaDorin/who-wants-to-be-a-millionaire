using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Services;

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

        public string FriendName { get; set; }
        
        public string PlayerName { get; set; }

        public List<string> Conversation { get; set; }

        public Question CurrentQuestion{ get; set; }

        private AudioService _audioService;

        public PhoneCallViewModel(Question question, string playerName)
        {
            PlayerName = playerName;
            CurrentQuestion = question;
            _audioService = AudioService.GetInstace();

            GridInputVisibility = Visibility.Visible;
            GridDialogVisibility = Visibility.Collapsed;
        }

        public async void DisplayConversation(DockPanel parent)
        {
            GridInputVisibility = Visibility.Collapsed;
            GridDialogVisibility = Visibility.Visible;

            _audioService.PlayAudio(_audioService.PhoneAFriend);

            // Facem rost de lista de replici
            Conversation = LifelineService.CallAFriend(FriendName, PlayerName, CurrentQuestion);

            // Pentru fiecare replica este creat un textblock.
            // care este adaugat in mod programat in lista dockpanel-ul pentru replici.
            // Va fi un delay de 2 secunde inainte de a aparea urmatoarea replica.
            for (int i = 0; i < Conversation.Count; i++)
            {
                TextBlock tbReply = new TextBlock();
                if (i % 2 == 1)
                {
                    tbReply.Style = Application.Current.TryFindResource("playerReply") as Style;
                    tbReply.Text = Conversation[i];
                }
                else
                {
                    tbReply.Style = Application.Current.TryFindResource("friendReply") as Style;
                    tbReply.Text = $"{FriendName}: {Conversation[i]}";
                }
                parent.Children.Add(tbReply);
                await Task.Delay(2000);
            }
        }
    }
}
