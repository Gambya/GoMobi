using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace GoMobi.Views
{
    public class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            var relativeLayoutMain = new StackLayout();
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.FromHex("#455A64");
            var aguarde = new Label
            {
                Text = "AGUARDE\n...",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            relativeLayoutMain.Children.Add(aguarde);

            Content = relativeLayoutMain;
        }

        protected override async void OnAppearing()
        {
            var splash = new SplashScreenModal();
            await Navigation.PushModalAsync(splash, true);
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var posicion = await locator.GetPositionAsync(1000000000);
            Application.Current.Properties["latitude"] = posicion.Latitude;
            Application.Current.Properties["longitude"] = posicion.Longitude;
            await Task.Delay(TimeSpan.FromSeconds(5));
            await Navigation.PopModalAsync(true);
            await Navigation.PushAsync(new LoginView(), true);
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            Navigation.RemovePage(this);
            base.OnDisappearing();
        }
    }
}