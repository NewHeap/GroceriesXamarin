using System;

using GroceriesPlatformApp.ViewModels;

using Xamarin.Forms;
using GroceriesPlatformApp.Models;

namespace GroceriesPlatformApp.Views
{
    public partial class GrocerieDetailPage : ContentPage
    {
        GrocerieDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public GrocerieDetailPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new GrocerieDetailViewModel();
        }

        public GrocerieDetailPage(GrocerieDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        void Minus_Clicked(object sender, EventArgs e)
        {
            var item = new GroceriesItem
            {
                Id = viewModel.Item.Id,
                Product = viewModel.Item.Product,
                Stock = --viewModel.Item.Stock,
                BuyLocation = viewModel.Item.BuyLocation,
                StoreName = viewModel.Item.StoreName
            };
            MessagingCenter.Send(item, "UpdateItem");
        }
        void Plus_Clicked(object sender, EventArgs e)
        {
            var item = new GroceriesItem
            {
                Id = viewModel.Item.Id,
                Product = viewModel.Item.Product,
                Stock = ++viewModel.Item.Stock,
                BuyLocation = viewModel.Item.BuyLocation,
                StoreName = viewModel.Item.StoreName
            };
            MessagingCenter.Send(item, "UpdateItem");
        }
    }
}
