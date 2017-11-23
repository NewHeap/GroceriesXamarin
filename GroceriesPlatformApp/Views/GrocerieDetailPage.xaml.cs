using System;

using GroceriesPlatformApp.ViewModels;

using Xamarin.Forms;
using GroceriesPlatformApp.Models;

namespace GroceriesPlatformApp.Views
{
    public partial class GrocerieDetailPage : ContentPage
    {
        internal GrocerieDetailPageViewModel ViewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public GrocerieDetailPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new GrocerieDetailPageViewModel();
        }

        public GrocerieDetailPage(GrocerieDetailPageViewModel ViewModel)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = ViewModel;
        }

        void Minus_Clicked(object sender, EventArgs e)
        {
            var item = new GroceriesItem
            {
                Id = ViewModel.Item.Id,
                Product = ViewModel.Item.Product,
                Stock = --ViewModel.Item.Stock,
                BuyLocation = ViewModel.Item.BuyLocation,
                StoreName = ViewModel.Item.StoreName
            };
            MessagingCenter.Send(item, "UpdateItem");
        }
        void Plus_Clicked(object sender, EventArgs e)
        {
            var item = new GroceriesItem
            {
                Id = ViewModel.Item.Id,
                Product = ViewModel.Item.Product,
                Stock = ++ViewModel.Item.Stock,
                BuyLocation = ViewModel.Item.BuyLocation,
                StoreName = ViewModel.Item.StoreName
            };
            MessagingCenter.Send(item, "UpdateItem");
        }
        async void Delete_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete", $"Would you like to delete {ViewModel.Item.Product}?", "Yes", "No");
            if (answer)
            {
                var item = new GroceriesItem
                {
                    Id = ViewModel.Item.Id
                };
                MessagingCenter.Send(item, "DeleteItem");
                await Navigation.PushAsync(new GroceriesPage());
            }
            else
            {
                return;
            }
        }

        protected override void OnAppearing()
        {
            ViewModel.Subscribe();
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            ViewModel.Unsubscribe();
            base.OnDisappearing();
        }
    }
}
