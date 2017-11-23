using System;

using GroceriesPlatformApp.Models;
using GroceriesPlatformApp.ViewModels;

using Xamarin.Forms;

namespace GroceriesPlatformApp.Views
{
    public partial class GroceriesPage : ContentPage
    {
        internal GroceriesPageViewModel ViewModel;

        public GroceriesPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new GroceriesPageViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = (GroceriesItem)args.SelectedItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new GrocerieDetailPage(new GrocerieDetailPageViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }


        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrocerieAddPage());
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadItemsCommand.Execute(null);
            base.OnAppearing();
        }
    }
}
