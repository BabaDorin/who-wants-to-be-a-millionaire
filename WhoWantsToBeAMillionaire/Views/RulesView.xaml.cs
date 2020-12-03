using System.Windows;
using System.Windows.Controls;

namespace WhoWantsToBeAMillionaire.Views
{
    public partial class RulesView : UserControl
    {
        public RulesView()
        {
            InitializeComponent();
        }

        private void btInapoi_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).UpdateView("Start");
        }
    }
}
