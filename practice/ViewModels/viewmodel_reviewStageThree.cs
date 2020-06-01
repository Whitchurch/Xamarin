using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microcharts;
using SkiaSharp;


namespace practice.ViewModels
{
    public class viewmodel_reviewStageThree : INotifyPropertyChanged
    {

        //Properties
        private string race1 = String.Empty;
        private int race1Total = 0;

        private string race2 = String.Empty;
        private int race2Total = 0;

        private string race3 = String.Empty;
        private int race3Total = 0;

        public string PropertyRace1
        {
            get { return race1; }
            set
            {
                if (race1 == value)
                    return;

                race1 = value;

            }
        }

        public int PropertyTotal1
        {
            get { return race1Total; }
            set
            {
                if (race1Total == value)
                    return;

                race1Total = value;

            }
        }



        public string PropertyRace2
        {
            get { return race2; }
            set
            {
                if (race2 == value)
                    return;

                race2 = value;

            }
        }

        public int PropertyTotal2
        {
            get { return race2Total; }
            set
            {
                if (race2Total == value)
                    return;

                race2Total = value;

            }
        }


        public string PropertyRace3
        {
            get { return race3; }
            set
            {
                if (race3 == value)
                    return;

                race3 = value;

            }
        }

        public int PropertyTotal3
        {
            get { return race3Total; }
            set
            {
                if (race3Total == value)
                    return;

                race3Total = value;

            }
        }


        private Chart pchart;
        public Chart PropertyData
        {
            get { return pchart; }
            set
            {
                if (pchart == value)
                    return;

                pchart = value;
            }
        }

        //Events
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //Commands
        private ICommand pBackCommand;
        public ICommand BackCommand
        {
            get { return pBackCommand ?? (pBackCommand = new Command(ExecuteBackCommand)); }
        }

        private void ExecuteBackCommand()
        {
            Device.BeginInvokeOnMainThread(() => { App.Current.MainPage = new Views.reviewStageTwo(); });
        }

        //Constructor
        public viewmodel_reviewStageThree()
        {
            //Read all items from the table.
            System.Collections.Generic.List < Models.model_gunownership > itemCollection = Models.model_gunownership.GetAll().Result;
         

            //Filter and assign items based on Race, feature.
            Models.model_gunownership item_Black = itemCollection.Find(i => i.Race == "Black");
            Models.model_gunownership item_White = itemCollection.Find(i => i.Race == "White");
            Models.model_gunownership item_Other = itemCollection.Find(i => i.Race == "Other");

            PropertyRace1 = item_White.Race;
            PropertyTotal1 = item_White.OwnGunNo + item_White.OwnGunNotAnswered + item_White.OwnGunRefused + item_White.OwnGunYes;

            PropertyRace2 = item_Black.Race;
            PropertyTotal2 = item_Black.OwnGunNo + item_Black.OwnGunNotAnswered + item_Black.OwnGunRefused + item_Black.OwnGunYes;

            PropertyRace3 = item_Other.Race;
            PropertyTotal3 = item_Other.OwnGunNo + item_Other.OwnGunNotAnswered + item_Other.OwnGunRefused + item_Other.OwnGunYes;

            List<Microcharts.Entry> entries = new List<Microcharts.Entry>
            {
                new Microcharts.Entry(item_White.OwnGunNo)
                {
                    Color = SKColor.Parse("#a83232"),
                    Label = "OwnGun",
                    ValueLabel = "No"
                },

                new Microcharts.Entry(item_White.OwnGunNotAnswered)
                {
                    Color = SKColor.Parse("#9a32a8"),
                    Label = "OwnGun",
                    ValueLabel = "Not Answered"
                },

                new Microcharts.Entry(item_White.OwnGunRefused)
                {
                    Color = SKColor.Parse("#3238a8"),
                    Label = "OwnGun",
                    ValueLabel = "Refused"
                },

                new Microcharts.Entry(item_White.OwnGunYes)
                {
                    Color = SKColor.Parse("#32a842"),
                    Label = "OwnGun",
                    ValueLabel = "Yes"
                }

            };

           PropertyData =  new BarChart()
            {
                Entries = entries,
                BackgroundColor = SKColors.Transparent
            };

        }
    }
}
