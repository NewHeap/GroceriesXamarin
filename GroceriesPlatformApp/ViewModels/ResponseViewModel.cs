using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GroceriesPlatformApp.ViewModels
{
    public class ResponseViewModel<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Item {get;set;}
        public ValidationObject Validation { get; set; }
    }

    public class ValidationObject
    {
        public List<ValidationItem> Items { get; set; }
    }

    public class ValidationItem
    {
        public string Key { get; set; }
        public string[] Value { get; set; }
    }
}
