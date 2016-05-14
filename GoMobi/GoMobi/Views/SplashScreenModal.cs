using Xamarin.Forms;

namespace GoMobi.Views
{
    public class SplashScreenModal : ContentPage
    {
        public SplashScreenModal()
        {
            var relativeLayoutMain = new RelativeLayout();
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.FromHex("#455A64");
            var logo = new Image
            {
                Source = "icon.png",
                Aspect = Aspect.AspectFill,
                HeightRequest = Height / 5,
                WidthRequest = Width / 5
            };
            relativeLayoutMain.Children.Add(logo, Constraint.RelativeToParent((parent) => parent.Width / 2), Constraint.RelativeToParent((parent) => parent.Height / 2));
            Content = relativeLayoutMain;
        }
    }
}
