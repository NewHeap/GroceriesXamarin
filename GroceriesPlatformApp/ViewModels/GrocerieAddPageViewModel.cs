using GroceriesPlatformApp.Models;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;

namespace GroceriesPlatformApp.ViewModels
{
    public class GrocerieAddPageViewModel : BaseViewModel<GroceriesItem>
    {
        public GroceriesItem Item { get; set; }
        public ValidationObject Validation { get; set; }

        public GrocerieAddPageViewModel()
        {
            Item = new GroceriesItem
            {
                Id = 0,
                Stock = 1,
                BuyLocation = "Zwollestsraat 20",
                StoreName = "Jumbo",
                Product = "Boter"
            };
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        public override void Subscribe()
        {
            MessagingCenter.Subscribe<GroceriesItem>(this, "AddItem", async (grocerie) =>
            {
                ResponseViewModel<HttpContent> response = await DataStore.AddItemAsync(grocerie);
                if(response.StatusCode >= (HttpStatusCode)200 && response.StatusCode <= (HttpStatusCode)210)
                {
                    this.Validation = response.Validation;
                }
            });
        }

        public override void Unsubscribe()
        {
            MessagingCenter.Unsubscribe<GroceriesItem>(this, "AddItem");
        }
    }
}