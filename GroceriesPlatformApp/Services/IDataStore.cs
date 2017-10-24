using System.Collections.Generic;
using System.Threading.Tasks;
using GroceriesPlatformApp.Helpers;
using GroceriesPlatformApp.Models;

namespace GroceriesPlatformApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
        Task<T> GetItemAsync(T item);
        Task<IEnumerable<T>> GetItemsAsync();
    }
}
