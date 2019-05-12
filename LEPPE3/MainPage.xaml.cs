using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xamarin.Essentials;
using Xamarin.Forms;
using System.Reflection;
using Plugin.Geolocator;
//using System.Diagnostics;
using LEPPE3.Controllers;
//using LEPPE3.classes;
using LEPPE3.Models;

namespace LEPPE3
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<Equipe> lesEquipes;
        public static ObservableCollection<Participant> lesParticipants;
        public static int nbParticipant;
        public static ObservableCollection<Course> lesCourses;
        public MainPage()
        {
            MainPage.nbParticipant = 0;
            InitializeComponent();
           // MainPage.lesEquipes = new ObservableCollection<Equipe>();
            MainPage.lesParticipants = new ObservableCollection<Participant>();
            //MainPage.lesCourses = new ObservableCollection<Course>();
            //creerJeuEssai();
            getLocation();
            //accesView.ItemsSource = MainPage.lesParticipants;

            //accesView.ItemSelected += accesView_ItemSelected;

        }

        void ButtonAccesEquipe(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EquipePage());
        }
        void ButtonInscription(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InscriptionPage());
        }

        public async void getLocation()
        {
            await StartListening();
        }

        private void accesView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           // Participant p = (Participant)e.SelectedItem;
           // DisplayAlert("Détails", p.toString(), "Fermer");
        }

        void creerJeuEssai()
        {


            // Test de relecture des preferences
            try
            {
                //var secureString = Preferences.Get("quisuisje", "inconnue");
                //Debug.WriteLine("Récupéré du secureStorage : " + secureString);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support preferences storage on device.
            }
        }

        private async Task RetreiveLocation()
        {   
           /* locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
            {

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(100));
                if (position == null)
                    return;

                Debug.WriteLine("Position Status: {0}", position.Timestamp);
                Debug.WriteLine("Position Latitude: {0}", position.Latitude.ToString());
                Debug.WriteLine("Position Longitude: {0}", position.Longitude.ToString());

                locator.PositionChanged += (sender, e) => {
                    position = e.Position;

                    Debug.WriteLine("Position Latitude: {0}", position.Latitude.ToString());
                    Debug.WriteLine("Position Longitude: {0}", position.Longitude.ToString());
                };

            }
            else
            {
                await DisplayAlert("Error", "Home", "OK");
            }
           */

        }

        async Task StartListening()
        {
            if (CrossGeolocator.Current.IsListening)
                return;

            ///This logic will run on the background automatically on iOS, however for Android and UWP you must put logic in background services. Else if your app is killed the location updates will be killed.
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10, true, new Plugin.Geolocator.Abstractions.ListenerSettings
            {
                ActivityType = Plugin.Geolocator.Abstractions.ActivityType.AutomotiveNavigation,
                AllowBackgroundUpdates = true,
                DeferLocationUpdates = true,
                DeferralDistanceMeters = 1,
                DeferralTime = TimeSpan.FromSeconds(1),
                ListenForSignificantChanges = true,
                PauseLocationUpdatesAutomatically = false
            });

            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var test = e.Position;
                Debug.WriteLine("Full: Lat: " + test.Latitude.ToString() + " Long: " + test.Longitude.ToString());
                Debug.WriteLine("\n" + $"Time: {test.Timestamp.ToString()})");
                Debug.WriteLine("\n" + $"Heading: {test.Heading.ToString()}");
                Debug.WriteLine("\n" + $"Speed: {test.Speed.ToString()}");
                Debug.WriteLine("\n" + $"Accuracy: {test.Accuracy.ToString()}");
                Debug.WriteLine("\n" + $"Altitude: {test.Altitude.ToString()}");
                Debug.WriteLine("\n" + $"AltitudeAccuracy: {test.AltitudeAccuracy.ToString()}");
            });
        }

        void ajoutBTClicked(object sender, EventArgs e)
        {
            /*string[] coords = emplacementLabel.Text.Split(';');
            double lat = Double.Parse(coords[0]);
            double lon = Double.Parse(coords[1]);
            Participant p = new Participant(nomParticipant.Text, prenomParticipant.Text, mailParticipant.Text,  numeroContact.Text, lat, lon);
            lesContacts.Add(c);
            confirmLabel.Text = String.Format("{0} avec le numéro {1}",
                                       nomContact.Text, numeroContact.Text);
            //this.saveContacts();

            /*
            string line = string.Format("{0};{1}\n", nomContact.Text, numeroContact.Text);
            var document = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(document, "MyContacts.txt");
            File.AppendAllText(filename, line);


        public void saveContacts()
        {
            string toSaveText = "";
            foreach (Contact c in MainPage.lesContacts)
            {
                toSaveText += c.Nom + ";" + c.Prenom + ";" + c.Email + ";" + c.Numero + ";" + c.Latitude + ";" + c.Longitude + "\n";
            }
            DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", toSaveText);
        }

        public void loadContacts()
        {
            String recupere = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");

            String[] lesLignesContact = recupere.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var item in lesLignesContact)
            {
                MainPage.nbContacts++;
                if (item.Length > 0)
                {
                    string[] leContact = item.Split(';');
                    Contact c = new Contact(leContact[0], leContact[1], leContact[2], leContact[3], Double.Parse(leContact[4]), Double.Parse(leContact[5]));
                    lesContacts.Add(c);
                }
            }
        }
            
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Carte.latitude != 0.0)
            {
                emplacementLabel.Text = Carte.latitude + ";" + Carte.longitdude;
                //DisplayAlert("Alerte", "Retour ici", "OK");
            }
            System.Diagnostics.Debug.WriteLine("*****Here*****");

        */
        }
    }
}
