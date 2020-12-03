using System.Windows;
using System.Windows.Controls;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Views
{
    public partial class PhoneCallView : Window
    {
        private PhoneCallViewModel _viewModel;
        
        public PhoneCallView(Question question, string playerName)
        {
            // Cream o noua instanta a clasei PhoneCallViewModel pe care o atribuim ca Datacontext pentru fereastra
            InitializeComponent();
            DataContext = new PhoneCallViewModel(question, playerName);
            _viewModel = DataContext as PhoneCallViewModel;
        }

        private void tbPlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Activam butonul de telefonare daca a fost indicata vreo valoare in campul pentru indicarea numelui
            if ((sender as TextBox).Text.Length > 0)
                _viewModel.CallButtonIsEnabled = true;
            else
                _viewModel.CallButtonIsEnabled = false;
        }

        private void ButtonCall_Click(object sender, RoutedEventArgs e)
        {
            // Trecem nemijlocit la afisarea dialogului.
            _viewModel.FriendName = tbFriendName.Text;
            _viewModel.DisplayConversation(DialogDockPanel);
        }
    }
}
