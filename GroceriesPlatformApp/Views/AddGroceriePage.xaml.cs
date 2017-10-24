using System;

using GroceriesPlatformApp.Models;

using Xamarin.Forms;

namespace GroceriesPlatformApp.Views
{
    public partial class AddGroceriePage : ContentPage
    {
        public GroceriesItem Groceries { get; set; }

        public AddGroceriePage()
        {
            InitializeComponent();

            Groceries = new GroceriesItem
            {
                Product = "teeeeeeeeeeeeeeeeeeeeest",
                Stock = 3,
                BuyLocation = "Zwolle",
                StoreName = "Lidel"
            };
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Groceries);
            await Navigation.PopToRootAsync();
        }
    }
}