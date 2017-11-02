using GroceriesPlatformApp.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroceriesPlatformApp.Services
{
    public interface IDataStore<T> where T : class
    {
        Task<ResponseViewModel<HttpContent>> AddItemAsync(T item);
        Task<ResponseViewModel<HttpContent>> UpdateItemAsync(T item);
        Task<ResponseViewModel<HttpContent>> DeleteItemAsync(T item);
        Task<ResponseViewModel<T>> GetItemAsync(T item);
        Task<ResponseViewModel<IEnumerable<T>>> GetItemsAsync();
    }
}
