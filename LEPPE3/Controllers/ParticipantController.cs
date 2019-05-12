using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Pozzi;
using contactAPI;
using API_Pozzi.controller;
using MySql.Data.MySqlClient;


namespace API_Pozzi.controller
{
    public class ParticipantController
        [HttpPost]
        public HttpResponseMessage AddParticipant([FromBody] Participant p)
        {
            if (p != null)
                return Request.CreateResponse(HttpStatusCode.Created, p);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, p);
        }

        [HttpGet]
        public Participant GetById(long id)
        {
            ContactDAO dao = new ContactDAO();
            List<Participant> lesParticipants = dao.getAllParticipants();
            return lesParticipants.ElementAt(0);
        }

        [HttpGet]
        public IEnumerable<Participant> GetAllP()
        {
            ContactDAO dao = new ContactDAO();
            List<Participant> lesParticipants = dao.getAllParticipants();
            return lesParticipants.ToList();
        }


        [HttpDelete]
        public string DeleteParticipants(string id)
        {
            return "Participant supprimé id " + id;
        }

        [HttpPut]
        public string UpdateParticipant(string id, string pwd, string nom, string prenom, string mail, int age, string telephone, string sexe, string id_equipe)
        {
            return "Mise à jour de l'équipe avec l'id " + id + " , le nom" + nom + " ,le prénom" + prenom + " /n " + " , l'email" + mail + " ,l'age : " + age + " /n" + "le numéro de téléphone:" + telephone +
                " le sexe: " + sexe + "et l'id de l'équipe est :" + id_equipe;
        }

        //se loguer
        /*[HttpPost]
        public HttpResponseMessage LoguerParticipant(string nom2, string pwd2)
        {
            if(nom2 == Nom && pwd == PWD)
            {
                return " page suivante";
            }
            else
            {
                return "Erreur, ressaisir vos informations";
        }*/

        /*localisation
        [HttpPost]
        public HttpResponseMessage LocaliserParticipants(string longitude, string latitude)
        {

        }*/

    }
}
