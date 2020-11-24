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
using System.Windows.Shapes;

namespace WhoWantsToBeAMillionaire.Views
{
    /// <summary>
    /// Interaction logic for Alert.xaml
    /// </summary>
    public partial class Alert : Window
    {
        public Alert(string message, string type)
        {
            InitializeComponent();

            Message.Text = message;

            string gridStyle = "DangerAlertGrid";
            if (type.ToLower() == "success")
                gridStyle = "SuccessAlertGrid";

            mainGrid.Style = Application.Current.TryFindResource(gridStyle) as Style;
        }
    }
}
