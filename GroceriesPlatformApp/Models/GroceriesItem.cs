namespace GroceriesPlatformApp.Models
{
    public class GroceriesItem : BaseDataObject
    {
        string product = string.Empty;
        public string Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        int id; 
        public int Id 
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        int stock;
        public int Stock
        {
            get { return stock; }
            set { SetProperty(ref stock, value); }
        }
        string buylocation = string.Empty;
        public string BuyLocation
        {
            get { return buylocation; }
            set { SetProperty(ref buylocation, value); }
        }

        string storename = string.Empty;
        public string StoreName
        {
            get { return storename; }
            set { SetProperty(ref storename, value); }
        }
        
    }
}
