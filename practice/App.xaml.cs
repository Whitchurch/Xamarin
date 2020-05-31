using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace practice
{
    public partial class App : Application
    {
        public static string dbpath;
        readonly SQLiteAsyncConnection conn;

        public App()
        {
            InitializeComponent();
            dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PracticeDatabase.db3");
            conn = new SQLiteAsyncConnection(dbpath);

            conn.CreateTableAsync<Models.model_gunownership>().Wait();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
