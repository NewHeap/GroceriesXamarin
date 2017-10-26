using System;
using System.Diagnostics;
using System.Threading.Tasks;

using GroceriesPlatformApp.Helpers;
using GroceriesPlatformApp.Models;
using GroceriesPlatformApp.Views;

using Xamarin.Forms;

namespace GroceriesPlatformApp.ViewModels
{
    public class GroceriesViewModel : BaseViewModel<GroceriesItem>
    {
        public ObservableRangeCollection<GroceriesItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public GroceriesViewModel()
        {
            Title = "Groceries";
            Items = new ObservableRangeCollection<GroceriesItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<GroceriesItem>(this, "AddItem", async (grocerie) =>
            {
                await DataStore.AddItemAsync(grocerie);
            });
            MessagingCenter.Subscribe<GroceriesItem>(this, "UpdateItem", async (grocerie) =>
            {
                await DataStore.AddItemAsync(grocerie);
            });
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Items.Clear();
                var groceries = await DataStore.GetItemsAsync();
                Items.ReplaceRange(groceries);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
