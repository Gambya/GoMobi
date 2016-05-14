using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GoMobi.Views
{
    public class MapView : ContentPage
    {
        private Map map;
        private Button btMelhora;
        private Button btPiora;
        private Position posicao = new Position(-14.235004, -51.92528);
        public MapView()
        {
            Title = "Mapa Acessibilidade";
            var icon = "mapaicon32.png";
            NavigationPage.SetTitleIcon(this, icon);
            NavigationPage.SetHasBackButton(this, false);

            //Layout principal
            var relativeLayoutMain = new RelativeLayout();
            //Mapa
            map = new Map(MapSpan.FromCenterAndRadius(posicao, Distance.FromMiles(50)))
            {
                HeightRequest = Width,
                WidthRequest = Height,
                VerticalOptions = LayoutOptions.Fill
            };
            relativeLayoutMain.Children.Add(map, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent((parent) => parent.Width), Constraint.RelativeToParent((parent) => parent.Height));

            var btMira = new Button
            {
                Text = "+",
                TextColor = Color.Gray,
                BackgroundColor = Color.Transparent,
                BorderColor = Color.Black,
                BorderWidth = 1
            };
            relativeLayoutMain.Children.Add(btMira, Constraint.RelativeToParent((parent) => parent.Width - 100), Constraint.Constant(20));
            btMira.Clicked += async (sender, e) =>
            {
                var pos = await GetPosition();
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(pos.Latitude, pos.Longitude), Distance.FromMiles(0.3)));
                map.Pins.Clear();
                var pin = new Pin
                {
                    Type = PinType.SavedPin,
                    Position = pos,
                    Label = "Sua Localização",
                    Address = $"Teste de Localização"
                };
                map.Pins.Add(pin);
            };
            //Botão de adicionar acessibilidade e suas propriedades e funções como alinhamento
            var btPlus = new Button
            {
                Image = "cadeiranteicon32.png",
                BackgroundColor = Color.Accent,//Color.FromHex("#2196F3"),

                HorizontalOptions = LayoutOptions.Center,
                BorderColor = Color.Black,
                BorderWidth = 1
            };
            relativeLayoutMain.Children.Add(btPlus, Constraint.Constant(20), Constraint.RelativeToParent((parent) => parent.Height - 70));
            btPlus.Clicked += (sender, e) =>
            {
                if (btMelhora.IsVisible || btPiora.IsVisible)
                {
                    btPiora.IsVisible = false;
                    btMelhora.IsVisible = false;
                }
                else
                {
                    btPiora.IsVisible = true;
                    btMelhora.IsVisible = true;
                }
            };
            //Botão adicionar melhoria
            btMelhora = new Button
            {
                Image = "pinicon32.png",
                BackgroundColor = Color.Green,
                HorizontalOptions = LayoutOptions.Center,
                BorderColor = Color.Black,
                BorderWidth = 1,
                IsVisible = false
            };
            relativeLayoutMain.Children.Add(btMelhora, Constraint.Constant(20), Constraint.RelativeToParent((parent) => parent.Height - 130));
            btMelhora.Clicked += async (sender, e) =>
            {
                await Navigation.PushModalAsync(new ModalRegistroMelhoria(), true);
            };

            //Botão adicionar piora
            btPiora = new Button
            {
                Image = "pinicon32.png",
                BackgroundColor = Color.Maroon,
                HorizontalOptions = LayoutOptions.Center,
                BorderColor = Color.Black,
                BorderWidth = 1,
                IsVisible = false
            };
            relativeLayoutMain.Children.Add(btPiora, Constraint.Constant(20), Constraint.RelativeToParent((parent) => parent.Height - 190));
            btPiora.Clicked += async (sender, e) =>
            {
                await Navigation.PushModalAsync(new ModalRegistroNegativo(), true);
            };

            //btLocator.Clicked += async (sender, e) =>
            //{
            //    var pos = await GetPosition();
            //    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(pos.Latitude, pos.Longitude), Distance.FromMiles(0.3)));
            //};

            Content = relativeLayoutMain;

            // for debugging output only
            map.PropertyChanged += (sender, e) =>
            {
                Debug.WriteLine(e.PropertyName + " just changed!");
                if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
                    CalculateBoundingCoordinates(map.VisibleRegion);
            };
        }

        private async Task<Position> GetPosition()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var posicion = await locator.GetPositionAsync(1000000000);
            var position = new Position(posicion.Latitude, posicion.Longitude);
            return position;
        }

        /// <summary>
        /// In response to this forum question http://forums.xamarin.com/discussion/22493/maps-visibleregion-bounds
        /// Useful if you need to send the bounds to a web service or otherwise calculate what
        /// pins might need to be drawn inside the currently visible viewport.
        /// </summary>
        private void CalculateBoundingCoordinates(MapSpan region)
        {
            // WARNING: I haven't tested the correctness of this exhaustively!
            var center = region.Center;
            var halfheightDegrees = region.LatitudeDegrees / 2;
            var halfwidthDegrees = region.LongitudeDegrees / 2;

            var left = center.Longitude - halfwidthDegrees;
            var right = center.Longitude + halfwidthDegrees;
            var top = center.Latitude + halfheightDegrees;
            var bottom = center.Latitude - halfheightDegrees;

            // Adjust for Internation Date Line (+/- 180 degrees longitude)
            if (left < -180) left = 180 + (180 + left);
            if (right > 180) right = (right - 180) - 180;
            // I don't wrap around north or south; I don't think the map control allows this anyway

            Debug.WriteLine("Bounding box:");
            Debug.WriteLine("                    " + top);
            Debug.WriteLine("  " + left + "                " + right);
            Debug.WriteLine("                    " + bottom);
        }

        protected override bool OnBackButtonPressed()
        {
            if (!btMelhora.IsVisible && !btPiora.IsVisible) return false;
            btPiora.IsVisible = false;
            btMelhora.IsVisible = false;
            return false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Task<Position> pos = GetPosition();
            //Position position = await pos;
            if (map.Pins.Count > 0) return;
            var position = new Position((double) Application.Current.Properties["latitude"], (double) Application.Current.Properties["longitude"]);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.3)));
            map.Pins.Clear();
            var pin = new Pin
            {
                Type = PinType.SavedPin,
                Position = position,
                Label = "Sua Localização",
                Address = "Teste de Localização"
            };
            map.Pins.Add(pin);
        }
    }
}
