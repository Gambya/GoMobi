using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace GoMobi.Views
{
    public class ModalRegistroNegativo : ContentPage
    {
        public ModalRegistroNegativo()
        {
            Title = "Registro Negativo";
            var lblDescricao = new Label
            {
                Text = "Descrição:",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Accent
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
