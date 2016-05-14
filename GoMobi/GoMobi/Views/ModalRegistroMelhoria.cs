using Xamarin.Forms;

namespace GoMobi.Views
{
    public class ModalRegistroMelhoria : ContentPage
    {
        public ModalRegistroMelhoria()
        {
            Title = "Registro Positivo";
            BackgroundColor = Color.FromHex("#455A64");
            var lblDescricao = new Label
            {
                Text = "Descrição:",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            var etrDescricao = new Entry
            {
                HorizontalOptions = LayoutOptions.Fill,
                HeightRequest = 300,
                HorizontalTextAlignment = TextAlignment.Start
            };
            Content = new StackLayout
            {
                Children = {
                    lblDescricao,
                    etrDescricao
                }
            };
        }
    }
}
