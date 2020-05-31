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

        private ICommand pNextCommand;
        public ICommand NextCommand
        {
            get { return pNextCommand ?? (pNextCommand = new Command(ExecuteNextCommand)); }
        }

        private void ExecuteNextCommand()
        {
            Device.BeginInvokeOnMainThread(() => { App.Current.MainPage = new Views.reviewStageThree(); });
        }

        //Constructor
        public viewmodel_reviewStageTwo()
        {
            var mguns = Models.model_gunownership.GetAll();

            if(mguns.Result.Count == 0)
            {
                // Application.Current.MainPage.DisplayAlert("Warning", "Model empty", null, "Ok");
                Models.model_gunownership mWhite = new Models.model_gunownership();
                Models.model_gunownership mBlack = new Models.model_gunownership();
                Models.model_gunownership mOther = new Models.model_gunownership();


                mWhite.Race = "White";
                mWhite.OwnGunYes = 12448;
                mWhite.OwnGunNo = 15235;
                mWhite.OwnGunRefused = 266;
                mWhite.OwnGunNotAnswered = 18401;
                mWhite.SaveItem();

                mBlack.Race = "Black";
                mBlack.OwnGunYes = 1269;
                mBlack.OwnGunNo = 3586;
                mBlack.OwnGunRefused = 39;
                mBlack.OwnGunNotAnswered = 3032;
                mBlack.SaveItem();

                mOther.Race = "Other";
                mOther.OwnGunYes = 283;
                mOther.OwnGunNo = 1323;
                mOther.OwnGunRefused = 10;
                mOther.OwnGunNotAnswered = 1169;
                mOther.SaveItem();





            }
            else
            {
                //Application.Current.MainPage.DisplayAlert("Warning", "Model has content", null, "Ok");

            }

        }
    }
}
