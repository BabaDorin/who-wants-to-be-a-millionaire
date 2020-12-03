using System.Collections.Generic;
using System.Windows;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Views
{
    public partial class AskAudienceView : Window
    {
        public AskAudienceView(List<int> results)
        {
            // Este creata o noua instanta a clasei AskAudienceViewModel ce este atrbuita ca DataContext pentru fereastra.
            DataContext = new AskAudienceViewModel(results);

            InitializeComponent();
        }
    }
}
