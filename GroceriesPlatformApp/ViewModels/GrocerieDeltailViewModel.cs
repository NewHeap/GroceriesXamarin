using GroceriesPlatformApp.Models;

namespace GroceriesPlatformApp.ViewModels
{
    public class GrocerieDetailViewModel : BaseViewModel<GroceriesItem>
    {
        public GroceriesItem Item { get; set; }
        public GrocerieDetailViewModel(GroceriesItem item = null)
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
    }
}