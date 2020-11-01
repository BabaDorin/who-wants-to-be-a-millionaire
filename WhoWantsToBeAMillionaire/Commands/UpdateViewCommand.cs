using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WhoWantsToBeAMillionaire.ViewModels;

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
            if(parameter.ToString() == "Game")
            {
                viewModel.SelectedViewModel = new GameViewModel();
            }else if(parameter.ToString() == "Start")
            {
                viewModel.SelectedViewModel = new StartViewModel();
            }
        }
    }
}
