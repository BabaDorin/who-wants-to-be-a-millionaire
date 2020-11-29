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
