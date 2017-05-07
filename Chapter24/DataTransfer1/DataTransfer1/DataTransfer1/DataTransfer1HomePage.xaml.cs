using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DataTransfer1
{
    public partial class DataTransfer1HomePage : ContentPage
    {
        ObservableCollection<Information> list = new ObservableCollection<Information>();

        public DataTransfer1HomePage()
        {
            InitializeComponent();

            // Set collection to ListView - don't work for Win!!! (07 May 2017)
            // listView.ItemsSource = list;
        }

        // Button Clicked handler.
        async void OnGetInfoButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DataTransfer1InfoPage());
        }

        // ListView ItemSelected handler.
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                // De-select the item.
                listView.SelectedItem = null;

                DataTransfer1InfoPage infoPage = new DataTransfer1InfoPage();
                await Navigation.PushAsync(infoPage);
                infoPage.InitializeInfo((Information)args.SelectedItem);
            }
        }

        // Called from InfoPage.
        public void InformationReady(Information info)
        {
            // To work for Win it need. (07 May 2017)
            listView.ItemsSource = null;
            listView.ItemsSource = list;
            
            // If the object has already been added, replace it.
            int index = list.IndexOf(info);

            if (index != -1)
            {
                list[index] = info;
            }
            // Otherwise, add it.
            else
            {
                list.Add(info);
            }
        }
    }
}
