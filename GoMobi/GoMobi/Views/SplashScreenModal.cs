using Xamarin.Forms;

namespace GoMobi.Views
{
    public class SplashScreenModal : ContentPage
    {
        public SplashScreenModal()
        {
            var mainLayout = new StackLayout();
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.FromHex("#455A64");
            var backTop = new Image
            {
                Source = "backTop.png",
                Aspect = Aspect.AspectFit,
                HeightRequest = 100,
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.End
            };
            var logo = new Image
            {
                Source = "LogoGoMobi.png",
                Aspect = Aspect.AspectFit,
                HeightRequest = 200,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var backBottom = new Image
            {
                Source = "backBottom.png",
                Aspect = Aspect.AspectFit,
                HeightRequest = 100,
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.Start
            };
            mainLayout.Children.Add(backTop);
            mainLayout.Children.Add(logo);
            mainLayout.Children.Add(backBottom);
            Content = mainLayout;
        }
    }
}
