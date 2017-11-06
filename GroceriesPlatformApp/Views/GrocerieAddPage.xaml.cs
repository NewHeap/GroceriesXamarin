using System;
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

        void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(ViewModel.Item, "AddItem");
            //await Navigation.PopAsync();
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