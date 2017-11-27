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
        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event             
            ((ListView)sender).SelectedItem = null; // de-select the row       
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
    /// <typeparam name="T"></typeparam>
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}