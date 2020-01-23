using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace artem_database
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "friends.db";
        public static FriendRepository database;
        public static FriendRepository Database {
            get {
                if (database == null)
                {
                    database = new FriendRepository(DATABASE_NAME);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() {}

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
