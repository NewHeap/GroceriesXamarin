using GroceriesPlatformApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GroceriesPlatformApp
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new GroceriesPage())
                    {
                        Title = "Groceries",
                        #pragma warning disable CS0618 // Type or member is obsolete
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                        #pragma warning restore CS0618 // Type or member is obsolete
                    },
                }
            };
        }
	}
}
