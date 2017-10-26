using System;

using GroceriesPlatformApp.Models;
using GroceriesPlatformApp.ViewModels;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace GroceriesPlatformApp.Views
{
    public partial class GroceriesPage : ContentPage
    {
        GroceriesViewModel viewModel;

        public GroceriesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new GroceriesViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = (GroceriesItem)args.SelectedItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new GrocerieDetailPage(new GrocerieDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGroceriePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
