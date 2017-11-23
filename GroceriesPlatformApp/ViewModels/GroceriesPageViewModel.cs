using System;
using System.Diagnostics;
using System.Threading.Tasks;

using GroceriesPlatformApp.Helpers;
using GroceriesPlatformApp.Models;

using Xamarin.Forms;

namespace GroceriesPlatformApp.ViewModels
{
    public class GroceriesPageViewModel : BaseViewModel<GroceriesItem>
    {
        public ObservableRangeCollection<GroceriesItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public GroceriesPageViewModel()
        {
            Title = "Groceries";
            Items = new ObservableRangeCollection<GroceriesItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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
                Items.ReplaceRange(groceries.Item);
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

        public override void Subscribe()
        {
        }

        public override void Unsubscribe()
        {
        }
    }
}
