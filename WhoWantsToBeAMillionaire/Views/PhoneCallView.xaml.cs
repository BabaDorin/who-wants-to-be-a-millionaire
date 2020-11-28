using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Views
{
    /// <summary>
    /// Interaction logic for PhoneCallView.xaml
    /// </summary>
    public partial class PhoneCallView : UserControl
    {
        private PhoneCallViewModel _viewModel;
        public PhoneCallView(Question question, string playerName)
        {
            InitializeComponent();
            DataContext = new PhoneCallViewModel(question, playerName);
            _viewModel = DataContext as PhoneCallViewModel;
        }

        private void tbPlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
                _viewModel.CallButtonIsEnabled = true;
            else
                _viewModel.CallButtonIsEnabled = false;
        }

        private void ButtonCall_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.FriendName = tbFriendName.Text;
            _viewModel.GridInputVisibility = Visibility.Collapsed;
            _viewModel.GridDialogVisibility = Visibility.Visible;

            _viewModel.DisplayConversation(DialogDockPanel);
        }
    }
}
