using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace contactAPI.Models
{
    public class Contact
    {
        private int id;
        private string nom;
        private string prenom;
        private string email;
        private string numero;
        private double latitude;
        private double longitude;

        public Contact(int unId, string unNom, string unPrenom, string unEmail, string unNumero, double uneLatitude, double uneLongitude)
        {
            this.id = unId;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.email = unEmail;
            this.numero = unNumero;
            this.latitude = uneLatitude;
            this.longitude = uneLongitude;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
    }
}