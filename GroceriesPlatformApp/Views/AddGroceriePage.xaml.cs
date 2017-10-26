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
                Product = "test",
                Stock = 0,
                BuyLocation = "Zwolle",
                StoreName = "Jumbo"
            };
            BindingContext = this;
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            //base.AddItem(BindingBase.AddItem.NotifyOnSourceUpdated);
            MessagingCenter.Send<GroceriesItem>(Groceries, "AddItem");
        }
    }
}