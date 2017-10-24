using System;

using GroceriesPlatformApp.ViewModels;

using Xamarin.Forms;

namespace GroceriesPlatformApp.Views
{
    public partial class GrocerieDetailPage : ContentPage
    {
        GrocerieDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public GrocerieDetailPage()
        {
            InitializeComponent();
        }

        public GrocerieDetailPage(GrocerieDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        void Minus_Clicked(object sender, EventArgs e)
        {
            viewModel.Item.Stock -= 1;
        }
        void Plus_Clicked(object sender, EventArgs e)
        {
            viewModel.Item.Stock += 1;
        }
    }
}
