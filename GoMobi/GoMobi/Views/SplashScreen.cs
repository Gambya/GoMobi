using Plugin.Geolocator;
using Xamarin.Forms;

namespace GoMobi.Views
{
    public class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            var relativeLayoutMain = new RelativeLayout();
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.FromHex("#455A64");
            var aguarde = new Label
            {
                Text = "AGUARDE\n...",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center
            };
            relativeLayoutMain.Children.Add(aguarde, Constraint.RelativeToParent((parent) => (parent.Width / 2) - (aguarde.Width / 2)), Constraint.RelativeToParent((parent) => parent.Height / 2));

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
            //Task.Delay(TimeSpan.FromSeconds(5));
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
