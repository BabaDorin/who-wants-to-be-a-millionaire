using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WhoWantsToBeAMillionaire.Commands;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
		private BaseViewModel selectedViewModel;

		public BaseViewModel SelectedViewModel
		{
			get { return selectedViewModel; }
			set { selectedViewModel = value; }
		}

		public ICommand UpdateViewCommand{ get; set; }

		public MainViewModel()
		{
			UpdateViewCommand = new UpdateViewCommand(this);
		}
	}
}
