using GroceriesPlatformApp.Helpers;
using GroceriesPlatformApp.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GroceriesPlatformApp.ViewModels
{
    public abstract class BaseViewModel<T> : ObservableObject where T : class, INotifyPropertyChanged
    {
		/// <summary>
		/// Get the azure service instance
		/// </summary>
		public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();

		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}
		/// <summary>
		/// Private backing field to hold the title
		/// </summary>
		string title = string.Empty;
		/// <summary>
		/// Public property to set and get the title of the item
		/// </summary>
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}
        public abstract void Subscribe();
        public abstract void Unsubscribe();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
    new PropertyChangedEventArgs(propertyName));
        }
    }
}

