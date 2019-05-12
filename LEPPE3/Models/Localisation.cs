using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace LEPPE3.Models
{
    public class Localisation
    {
        int id_localisation;
        string date_actuelle;
        string temps_reel;
        string longitude;
        string latitude;
        int id;

        public Localisation(int id_localisation, string date_actuelle, string temps_reel, string longitude, string latitude, int id)
        {
            this.id_localisation = id_localisation;
            this.date_actuelle = date_actuelle;
            this.temps_reel = temps_reel;
            this.longitude = longitude;
            this.latitude = latitude;
            this.id = id;
        }

        public int Id_localisation { get => id_localisation; set => id_localisation = value; }
        public string Date_actuelle { get => date_actuelle; set => date_actuelle = value; }
        public string Temps_reel { get => temps_reel; set => temps_reel = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public int Id { get => id; set => id = value; }

        public string getLocalisation()
        {
            return Longitude;
        }
    }

    
}