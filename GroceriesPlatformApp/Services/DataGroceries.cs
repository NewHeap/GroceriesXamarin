using System;
using System.Text;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

using GroceriesPlatformApp.Models;

using Xamarin.Forms;

using Newtonsoft.Json;
using GroceriesPlatformApp.ViewModels;

[assembly: Dependency(typeof(GroceriesPlatformApp.Services.DataGroceries))]
namespace GroceriesPlatformApp.Services
{
    public class DataGroceries : IDataStore<GroceriesItem>
    {
        public bool isInitialized;
        public List<GroceriesItem> items;
        public Uri uri;

        public DataGroceries()
        {
            uri = new Uri("http://192.168.1.10:44351/api/groceriesapi/");
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

        public async Task<ResponseViewModel<GroceriesItem>> AddItemAsync(GroceriesItem item)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri.ToString(), content);
                    var readAsString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        GroceriesItem responseObject = JsonConvert.DeserializeObject<GroceriesItem>(readAsString);
                        return new ResponseViewModel<GroceriesItem> { StatusCode = response.StatusCode, Item = responseObject };

                    }
                    else
                    {
                        
                        return new ResponseViewModel<GroceriesItem> { StatusCode = response.StatusCode, Item = null, Validation = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(readAsString)};
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
#if DEBUG
                throw ex;
#endif
            }
        }

        public async Task<ResponseViewModel<HttpContent>> UpdateItemAsync(GroceriesItem item)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = uri.ToString() + item.Id;
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return new ResponseViewModel<HttpContent> { StatusCode = response.StatusCode, Item = response.Content };
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        return new ResponseViewModel<HttpContent> { StatusCode = response.StatusCode, Item = response.Content, Validation = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(response.Content.ToString()) };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            return null;
        }

        public async Task<ResponseViewModel<HttpContent>> DeleteItemAsync(GroceriesItem item)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = uri.ToString() + item.Id;

                    var response = await client.DeleteAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        return new ResponseViewModel<HttpContent> { StatusCode = response.StatusCode, Item = response.Content };
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        return new ResponseViewModel<HttpContent> { StatusCode = response.StatusCode, Item = response.Content, Validation = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(response.Content.ToString()) };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<ResponseViewModel<GroceriesItem>> GetItemAsync(GroceriesItem item)
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
                        var JsonItem = JsonConvert.DeserializeObject<GroceriesItem>(response.Content.ToString());
                        return new ResponseViewModel<GroceriesItem> { StatusCode = response.StatusCode, Item = JsonItem };
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var JsonItem = JsonConvert.DeserializeObject<GroceriesItem>(response.Content.ToString());
                        return new ResponseViewModel<GroceriesItem> { StatusCode = response.StatusCode, Item = JsonItem, Validation = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(response.Content.ToString()) };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            return null;
        }

        public async Task<ResponseViewModel<IEnumerable<GroceriesItem>>> GetItemsAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri.ToString());
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonItem = JsonConvert.DeserializeObject<IEnumerable<GroceriesItem>>(await response.Content.ReadAsStringAsync());
                        return new ResponseViewModel<IEnumerable<GroceriesItem>> { StatusCode = response.StatusCode, Item = JsonItem };
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var JsonItem = JsonConvert.DeserializeObject<IEnumerable<GroceriesItem>>(await response.Content.ReadAsStringAsync());
                        return new ResponseViewModel<IEnumerable<GroceriesItem>> { StatusCode = response.StatusCode, Item = JsonItem, Validation = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(response.Content.ToString()) };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            return null;
        }
    }
}
