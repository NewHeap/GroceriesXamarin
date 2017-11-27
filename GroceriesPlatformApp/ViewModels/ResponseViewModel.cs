using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;

namespace GroceriesPlatformApp.ViewModels
{
    public class ResponseViewModel<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Item { get; set; }
        public Dictionary<string, ValidationViewModel> Validation { get; set; }
    }

    public class ValidationViewModel
    {
        public string Field { get; set; }
        public string[] Errors { get; set; }
        public int Height
        {
            get
            {
                return Errors.Count() * 10;
            }
        }
    }
}
