using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace practice.ViewModels
{
    public class viewmodel_reviewStageTwo
    {
        //Command
        private ICommand pBackCommand;
        public ICommand BackCommand
        {
            get { return pBackCommand ?? (pBackCommand = new Command(ExecuteBackCommand));}
        }

        private void ExecuteBackCommand()
        {
            Device.BeginInvokeOnMainThread(() => { App.Current.MainPage = new MainPage();});
        }

        //Constructor
        public viewmodel_reviewStageTwo()
        {
        }
    }
}
