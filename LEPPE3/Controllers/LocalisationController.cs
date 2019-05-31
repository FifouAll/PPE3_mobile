using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Pozzi;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
//using LEPPE3.Models;
using contactAPI.Models;

namespace API_Pozzi
{
    public class LocalisationController
    {
        //ajout participant
        [HttpPost]
        public HttpResponseMessage AddEquipe([FromBody] Localisation l)
        {
            if (l != null)
                return Request.CreateResponse(HttpStatusCode.Created, l);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, l);
        }

        
        //localisation des participants
        [HttpGet]
        public IEnumerable<Participant> GetAllL()
        {
            ContactDAO dao = new ContactDAO();
            List<Participant> lesParticipants = dao.getAllLocalisation();
            return lesParticipants.ToList();
        }

            //suppression participant

        [HttpDelete]
        public string DeleteLocalisation(string id_localisation)
        {
            return "Equipe supprimée id " + id_localisation;
        }

        //modification participant
        [HttpPut]
        public string UpdateLocalisation(string id_localisation, string date_actuelle, string temps_reel, string longitude, string latitude, string id)
        {
            return "Actuellement on a : la personne " + id + "/n" +
                "se trouve à" + temps_reel + "le" + date_actuelle + "/n" + "." +
                "Longitude: " + longitude + " /n" +
                "Latitude: " + latitude + "/n";
                
        }
    }
}
