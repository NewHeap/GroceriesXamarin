using GroceriesPlatformApp.Models;
using System.Net;
using Xamarin.Forms;
using System.Collections.Generic;

namespace GroceriesPlatformApp.ViewModels
{

    public class GrocerieAddPageViewModel : BaseViewModel<GroceriesItem>
    {
        public GroceriesItem Item { get; set; }

        private Dictionary<string, string[]> _validation = new Dictionary<string, string[]>();

        public Dictionary<string, string[]> Validation
        {
            get { return _validation; }
            set { _validation = value; OnPropertyChanged(nameof(Validation)); }
        }
        
        public GrocerieAddPageViewModel()
        {
            Item = new GroceriesItem
            {
                Product = "",
                Stock = 0,
                BuyLocation = "Zwollestsraat 20",
                StoreName = "Jumbo"
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
                var response = await DataStore.AddItemAsync(grocerie);
                if (response.StatusCode >= (HttpStatusCode)200 && response.StatusCode <= (HttpStatusCode)210)
                {
                    
                }
                else if(response.StatusCode == (HttpStatusCode)400)
                {
                    Validation = response.Validation;
                    Device.BeginInvokeOnMainThread(() => {
                        //?
                    });
                }
                else
                {
                    return;
                }
            });
        }
        public override void Unsubscribe()
        {
            MessagingCenter.Unsubscribe<GroceriesItem>(this, "AddItem");
        }
    }
}