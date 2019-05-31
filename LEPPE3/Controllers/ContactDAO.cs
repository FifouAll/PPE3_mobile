using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using contactAPI.Models;
using Newtonsoft.Json;

namespace contactAPI
{
    public class ContactDAO
    {
        private MySqlConnection conn;
        public ContactDAO()
        {
            string myConnectionString;
            //myConnectionString = "server=172.19.0.27;uid=sio;pwd=0550002D;database=ContactAPI;";
            myConnectionString = "server=172.19.0.2;uid=sio;pwd=0550002D;database=ContactAPI;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }


        /******Participant********/
        public List<Participant> getAllParticipants()
        {
            List<Participant> lesParticipants = new List<Participant>();
            string requete = "select nom, prenom, email, motDePasse, numero, sexe, idEquipe from Participant";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Participant p = new Participant(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), Convert.ToInt16(rdr[6].ToString()));

                lesParticipants.Add(p);
            }
            rdr.Close();

            return lesParticipants;
        }

        public Participant getParticipantById(int id)
        {
            string requete = "select nom, prenom, email, motDePasse, numero, sexe, idEquipe from Participant Where id = " + id;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Participant p = new Participant(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), Convert.ToInt16(rdr[6].ToString()));

            return p;

        }

        public List<Participant> getEquipies(int idEquipe)
        {
            List<Participant> lesParticipants = new List<Participant>();
            string requete = "select nom, prenom, email, motDePasse, numero, sexe, idEquipe from Participant where idEquipe = " + idEquipe;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Participant p = new Participant(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), Convert.ToInt16(rdr[6].ToString()));

                lesParticipants.Add(p);
            }
            rdr.Close();

            return lesParticipants;
        }

        public void deleteParticipant(int id)
        {
            string requete = "delete from Participant Where id = " + id;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public void updateParticipant(int id, string nom)
        {
            string requete = "UPDATE Participant SET nom = '" + nom + "' WHERE id =" + id;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }
        public void updateParticipant(int id, string nom, string prenom, string email, string numero, string sexe)
        {
            string requete = "UPDATE Participant SET nom = '" + nom + "', prenom='" + prenom + "',email = '" + email + "',numero = " + numero + "',sexe = '" + sexe + "' WHERE id =" + id;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }
        public void createParticipant(Participant p)
        {
            string requete = "Insert into Participant(nom, prenom, email, motDePasse, numero, sexe, idEquipe) Values ('" + p.MotDePasse + "','" + p.Nom + "','" + p.Prenom + "','" + p.Email + "','" + p.Numero + "','" + p.Sexe + "'," + p.IdEquipe + ")";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public void attribuerEquipe(int idParticipant, int idEquipe)
        {
            string requete = "UPDATE Participant SET idEquipe = '" + idEquipe + "' WHERE id =" + idParticipant;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        /****Equipe*****/
        public List<Equipe> getAllEquipe()
        {
            List<Equipe> lesEquipes = new List<Equipe>();
            string requete = "select nom_equipe, couleur_equipe from Equipe";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Equipe e = new Equipe(rdr[0].ToString(), rdr[1].ToString());

                lesEquipes.Add(e);
            }
            rdr.Close();

            return lesEquipes;
        }

        public Equipe getEquipeById(int id)
        {
            string requete = "select nom_equipe, couleur_equipe from Equipe Where id_equipe = " + id;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Equipe e = new Equipe(rdr[0].ToString(), rdr[1].ToString());

            return e;
        }


        /*
         public void deleteEquipe(int id)
         {
             string requete = "delete from Equipe Where id = " + id;
             MySqlCommand cmd = new MySqlCommand(requete, conn);
             cmd.ExecuteNonQuery();
         }*/


        /*****Localisation******/
        public void createLocalisation(Localisation l)
        {
            string requete = "Insert into Localisation (date_actuelle, longitude, latitude, idParticipant) Values( '" + l.Date_actuelle + "'," + l.Longitude + "," + l.Latitude + "," + l.IdParticipant + ")";

            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public Localisation getDernierLocalisation(int idParticipant)
        {
            string requete = "Select * from Localisation WHERE idParticipant =" + idParticipant + " And date_actuelle = (Select Max(date_actuelle) From Localisation Where idParticipant = " + idParticipant + ")";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Localisation l = new Localisation(rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), Convert.ToInt16(rdr[5].ToString()));

            return l;
        }

        public List<Localisation> getAllLocalisations(int idParticipant)
        {
            List<Localisation> lesLocalisations = new List<Localisation>();
            string requete = "Select * from Localisation WHERE idParticipant =" + idParticipant;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Localisation l = new Localisation(rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), Convert.ToInt16(rdr[5].ToString()));
                lesLocalisations.Add(l);
            }
            rdr.Close();

            return lesLocalisations;
        }

        public void createCourse(Course c)
        {
            string requete = "Insert into Course(depart_course, fin_course, lieu_course, nom_course) Values ('" + c.Depart_course + "','" + c.Fin_course + "','" + c.Lieu_course + "','" + c.Nom_course + ")";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }

        public void createEquipe(Equipe e)
        {
            string requete = "Insert into Equipe(nom_equipe, couleur_equipe) Values ('" + e.Nom_equipe + "','" + e.Couleur_equipe + ")";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }
        public Course getCourseById(int id)
        {
            string requete = "select depart_course, fin_course, lieu_course, nom_course from Course Where id = " + id;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Course c = new Course(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString());

            return c;
        }

    }
}
