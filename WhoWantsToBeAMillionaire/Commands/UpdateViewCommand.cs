using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WhoWantsToBeAMillionaire.ViewModels;
using WhoWantsToBeAMillionaire.Views;

namespace WhoWantsToBeAMillionaire.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BaseViewModel selectedViewModel = null;
            switch (parameter.ToString())
            {
                case "Game": selectedViewModel = new GameViewModel(); break;
                case "Start": selectedViewModel = new StartViewModel(); break;
                case "Rules": selectedViewModel = new RulesViewModel(); break;
                case "Results": selectedViewModel = new ResultsViewModel(); break;
                default: selectedViewModel = new StartViewModel(); break;
            }

            viewModel.SelectedViewModel = selectedViewModel;
        }
    }
}
