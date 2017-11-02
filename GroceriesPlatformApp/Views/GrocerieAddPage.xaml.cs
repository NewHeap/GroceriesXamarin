using System;
using GroceriesPlatformApp.Models;
using Xamarin.Forms;
using GroceriesPlatformApp.ViewModels;

namespace GroceriesPlatformApp.Views
{
    public partial class GrocerieAddPage : ContentPage
    {
        internal GrocerieAddPageViewModel ViewModel { get; set; }

        public GrocerieAddPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new GrocerieAddPageViewModel();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<GroceriesItem>(ViewModel.Item, "AddItem");
            await Navigation.PushAsync(new GroceriesPage());
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