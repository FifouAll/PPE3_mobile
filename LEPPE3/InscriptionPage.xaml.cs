using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LEPPE3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InscriptionPage : ContentPage
	{
		public InscriptionPage ()
		{
			InitializeComponent ();

            //accesView.ItemsSource = MainPage.lesParticipants;

           // accesView.ItemSelected += accesView_ItemSelected;

        }

        void ButtonRetour(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        void ButtonLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}