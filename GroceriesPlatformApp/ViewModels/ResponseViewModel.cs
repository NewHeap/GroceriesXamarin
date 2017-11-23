using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace GroceriesPlatformApp.ViewModels
{
    public class ResponseViewModel<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Item {get; set; }
        public Dictionary<string, string[]> Validation { get; set; }
    }
}
