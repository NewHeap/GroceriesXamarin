using GroceriesPlatformApp.Models;
using Xamarin.Forms;

namespace GroceriesPlatformApp.ViewModels
{
    public class GrocerieDetailPageViewModel : BaseViewModel<GroceriesItem>
    {
        public GroceriesItem Item { get; set; }
        public GrocerieDetailPageViewModel(GroceriesItem item = null)
        {
            Title = item.Product;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        public override void Subscribe()
        {
            MessagingCenter.Subscribe<GroceriesItem>(this, "UpdateItem", async (grocerie) =>
            {
                await DataStore.UpdateItemAsync(grocerie);
            });
            MessagingCenter.Subscribe<GroceriesItem>(this, "DeleteItem", async (grocerie) =>
            {
                await DataStore.DeleteItemAsync(grocerie);
            });
        }

        public override void Unsubscribe()
        {
            MessagingCenter.Unsubscribe<GroceriesItem>(this, "UpdateItem");
            MessagingCenter.Unsubscribe<GroceriesItem>(this, "DeleteItem");
        }
    }
}