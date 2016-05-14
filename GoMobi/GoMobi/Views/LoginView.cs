using Xamarin.Forms;

namespace GoMobi.Views
{
    public class LoginView : ContentPage
    {
        public LoginView()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Title = "Login";
            Padding = new Thickness(0);
            BackgroundColor = Color.FromHex("#455A64");
            var relLayoutMain = new RelativeLayout();
            var logo = new Image
            {
                Source = "icon.png",
                Aspect = Aspect.AspectFit,
                WidthRequest = 120,
                HeightRequest = 120,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var btnLoginGoogle = new Button
            {
                Text = "Login Google",
                BackgroundColor = Color.Maroon,
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 60
            };
            btnLoginGoogle.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new MapView());
            };
            var btnLoginFacebook = new Button
            {
                Text = "Login Facebook",
                BackgroundColor = Color.Navy,
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 60
            };
            btnLoginFacebook.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new MapView());
            };
            var stack = new StackLayout
            {
                Children = {
                    logo,
                    btnLoginGoogle,
                    btnLoginFacebook
                }
            };
            relLayoutMain.Children.Add(stack, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent((parent) => parent.Width),
                Constraint.RelativeToParent((parent) => parent.Height));
            Content = relLayoutMain;
        }

        protected override void OnDisappearing()
        {
            Navigation.RemovePage(this);
            base.OnDisappearing();
        }
    }
}
