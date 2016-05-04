using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace GoMobi.Views
{
    public class LoginView : ContentPage
    {
        public LoginView()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Login" }
                }
            };
        }
    }
}
