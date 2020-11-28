﻿using System;
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
    /// <summary>
    /// Interaction logic for AskAudienceView.xaml
    /// </summary>
    public partial class AskAudienceView : Window
    {
        public AskAudienceViewModel _viewModel;
        public AskAudienceView(List<int> results)
        {
            DataContext = new AskAudienceViewModel(results);
            _viewModel = DataContext as AskAudienceViewModel;

            InitializeComponent();
        }
    }
}
