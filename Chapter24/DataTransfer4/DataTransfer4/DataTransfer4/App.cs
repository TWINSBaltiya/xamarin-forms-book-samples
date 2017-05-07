using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DataTransfer4
{
    public class App : Application
    {
        public App()
        {
            // Create the ObservableCollection for the Information items.
            InfoCollection = new ObservableCollection<Information>();
            
            DataTransferHomePage = new DataTransfer4.DataTransfer4HomePage();

            MainPage = new NavigationPage(DataTransferHomePage);
        }
        
        public DataTransfer4HomePage DataTransferHomePage { private set; get; }

        public IList<Information> InfoCollection { private set; get; }

        public Information CurrentInfoItem { set; get; }
        
        internal void SetListViewMainPage()
        {
            DataTransferHomePage.FindByName<ListView>("listView").ItemsSource = null;
            DataTransferHomePage.FindByName<ListView>("listView").ItemsSource = InfoCollection;
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
