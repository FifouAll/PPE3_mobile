using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LEPPE3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carte : ContentPage
    {
        public static double latitude = 0.0;
        public static double longitude = 0.0;
        public Carte()
        {
            InitializeComponent();
        }

        void OnButtonValiderClicked(object sender, EventArgs e)
        {
            MyMap.Pins.Clear();

            Carte.latitude = MyMap.VisibleRegion.Center.Latitude;
            Carte.longitude = MyMap.VisibleRegion.Center.Longitude;


            var position = new Position(Carte.latitude, Carte.longitude); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Ami",
                Address = "Habite ici !"
            };
            MyMap.Pins.Add(pin);


        }
    }

}