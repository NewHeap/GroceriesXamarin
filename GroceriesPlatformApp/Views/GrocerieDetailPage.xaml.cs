using System;

using GroceriesPlatformApp.ViewModels;

using Xamarin.Forms;
using GroceriesPlatformApp.Models;

namespace GroceriesPlatformApp.Views
{
    public partial class GrocerieDetailPage : ContentPage
    {
        GroceriesViewModel viewModel;
        public GroceriesItem Groceries { get; set; }

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public GrocerieDetailPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new GroceriesViewModel();
        }

        public GrocerieDetailPage(GrocerieDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        void Minus_Clicked(object sender, EventArgs e)
        {
            Groceries.Stock -= 1;
            Groceries = new GroceriesItem
            {
                Id = Groceries.Id,
                Product = viewModel.Item.Product,
                Stock = viewModel.Item.Stock,
                BuyLocation = viewModel.Item.BuyLocation,
                StoreName = viewModel.Item.StoreName
            };
            MessagingCenter.Send(Groceries, "UpdateItem");
        }
        void Plus_Clicked(object sender, EventArgs e)
        {
            viewModel.Item.Stock += 1;
            Groceries = new GroceriesItem
            {
                Id = viewModel.Item.Id,
                Product = viewModel.Item.Product,
                Stock = viewModel.Item.Stock,
                BuyLocation = viewModel.Item.BuyLocation,
                StoreName = viewModel.Item.StoreName
            };
            MessagingCenter.Send(Groceries, "UpdateItem");
        }
    }
}
