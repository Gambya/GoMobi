using Xamarin.Forms;

namespace GoMobi.Views
{
    public class ModalRegistroMelhoria : ContentPage
    {
        public ModalRegistroMelhoria()
        {
            Title = "Registro Positivo";
            BackgroundColor = Color.FromHex("#455A64");
            var mainLayout = new RelativeLayout();
            var imgPhoto = new Image
            {
                Source = "photoicon.png",
                Aspect = Aspect.AspectFit
            };
            var lblDescricao = new Label
            {
                Text = "Tipo de Acesso:",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            var tipoAcess = new Picker
            {
                Items = { "Rampa de Acesso", "Corrimão", "Rampa Rolante", "Rampa Calçada" }
            };
            var etrDescricao = new Entry
            {
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Start,
                Placeholder = "Descrição da Acessibilidade"
            };
            var btnSalvar = new Button
            {
                Text = "Enviar Dados",
                BackgroundColor = Color.FromHex("#607D8B"),
                BorderColor = Color.Black,
                HorizontalOptions = LayoutOptions.Fill
            };
            var secondLayout = new StackLayout
            {
                Padding = 10,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    imgPhoto,
                    lblDescricao,
                    tipoAcess,
                    etrDescricao,
                    btnSalvar
                }
            };
            mainLayout.Children.Add(secondLayout, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => parent.Width),
                Constraint.RelativeToParent((parent) => parent.Height));
            Content = mainLayout;
        }
    }
}
