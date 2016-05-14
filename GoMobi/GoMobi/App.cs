using GoMobi.Views;
using Xamarin.Forms;

namespace GoMobi
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new SplashScreen());
        }

        protected override void OnStart()
        {
            //var locator = CrossGeolocator.Current;
            //locator.DesiredAccuracy = 50;
            //var posicion = locator.GetPositionAsync(1000000000);
            //Application.Current.Properties["latitude"] = posicion.Result.Latitude;
            //Application.Current.Properties["longitude"] = posicion.Result.Longitude;
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            //var locator = CrossGeolocator.Current;
            //locator.DesiredAccuracy = 50;
            //var position = locator.GetPositionAsync(1000000000);
        }
    }
}
