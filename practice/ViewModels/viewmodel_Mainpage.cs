using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace practice
{
    public class viewmodel_Mainpage:INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //Properties

        private string boundLabel = string.Empty;

        public string PropertyBoundLabel
        {
            get { return boundLabel; }
            set {
                boundLabel = value;
                OnPropertyChanged();
            }
        }


        private string entryText = string.Empty;

        public string PropertyEntryText
        {
            get { return entryText; }
            set
            {
                if (entryText == value)
                    return;

                entryText = value;
                PropertyBoundLabel = entryText;
                
            }
        }


        //Commands
        private ICommand pNextCommand;
        public ICommand NextCommand
        {
            get
            {
                return pNextCommand ?? (pNextCommand = new Command(ExecuteNextCommand));
            }
        }

        private void ExecuteNextCommand()
        {
            Device.BeginInvokeOnMainThread(() => { App.Current.MainPage = new Views.reviewStageTwo(); });
        }

        //Constructor
        public viewmodel_Mainpage()
        {
            PropertyBoundLabel = "Data Binding successful";
        }


    }
}
