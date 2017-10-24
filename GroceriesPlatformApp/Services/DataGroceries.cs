using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

using GroceriesPlatformApp.Models;

using Xamarin.Forms;

using Newtonsoft.Json;

[assembly: Dependency(typeof(GroceriesPlatformApp.Services.DataGroceries))]
namespace GroceriesPlatformApp.Services
{
    public class DataGroceries : IDataStore<GroceriesItem>
    {
        internal bool isInitialized;
        internal List<GroceriesItem> items;
        internal Uri uri;

        public DataGroceries()
        {
            uri = new Uri("http://192.168.8.100:44351/api/groceriesapi/");
        }

        public async Task<bool> SyncAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        items = JsonConvert.DeserializeObject<List<GroceriesItem>>(content);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> AddItemAsync(GroceriesItem item)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> UpdateItemAsync(GroceriesItem item)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = uri.ToString() + item.Id;
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> DeleteItemAsync(GroceriesItem item)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = uri.ToString() + item.Id;

                    var response = await client.DeleteAsync(uri);
                    if (response.IsSuccessStatusCode)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<GroceriesItem> GetItemAsync(GroceriesItem item)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = uri.ToString() + item.Id;
                    //todo: add item ID to query string
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<GroceriesItem>>(content).FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<IEnumerable<GroceriesItem>> GetItemsAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<GroceriesItem>>(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }



        #region old
        ///afblijven dit doet het normaal
        //      public async Task<bool> AddItemAsync(GroceriesItem grocerie)
        //      {
        //          await InitializeAsync();

        //          items.Add(grocerie);

        //          return await Task.FromResult(true);
        //      }

        //      public async Task<bool> UpdateItemAsync(GroceriesItem grocerie)
        //      {
        //          await InitializeAsync();

        //          var _grocerie = items.Where((GroceriesItem arg) => arg.Id == grocerie.Id).FirstOrDefault();
        //          items.Remove(_grocerie);
        //          items.Add(grocerie);

        //          return await Task.FromResult(true);
        //      }

        //      public async Task<bool> DeleteItemAsync(GroceriesItem item)
        //      {
        //          await InitializeAsync();

        //          var _grocerie = items.Where((GroceriesItem arg) => arg.Id == item.Id).FirstOrDefault();
        //          items.Remove(_grocerie);

        //          return await Task.FromResult(true);
        //      }

        //      public async Task<GroceriesItem> GetItemAsync(string id)
        //      {
        //          await InitializeAsync();

        //          return await Task.FromResult(items.FirstOrDefault(s => s.Id.ToString() == id));
        //      }

        //      public async Task<IEnumerable<GroceriesItem>> GetItemsAsync(bool forceRefresh = false)
        //      {
        //          await InitializeAsync();

        //          return await Task.FromResult(items);
        //      }

        //      public Task<bool> PullLatestAsync()
        //      {
        //          return Task.FromResult(true);
        //      }


        //      public Task<bool> SyncAsync()
        //      {
        //          return Task.FromResult(true);
        //      }

        //      public async Task InitializeAsync()
        //      {
        //          if (isInitialized)
        //		return;

        //          items = new List<GroceriesItem>();
        //	var _groceries = new List<GroceriesItem>
        //	{
        //              new GroceriesItem{Id =  1, Product =  "Zout" , Stock = 1 },
        //              new GroceriesItem{Id =  2, Product =  "Peper", Stock = 4 },
        //              new GroceriesItem{Id =  3, Product =  "Bier" , Stock = 2 },
        //              new GroceriesItem{Id =  4, Product =  "Peer" , Stock = 5 },
        //              new GroceriesItem{Id =  5, Product =  "Kaas" , Stock = 7 },
        //              new GroceriesItem{Id =  6, Product =  "Appel", Stock = 12 },
        //          };

        //	foreach (GroceriesItem grocerie in _groceries)
        //	{
        //              items.Add(grocerie);
        //	}

        //	isInitialized = true;
        //}
        #endregion
    }
}
