using contactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace contactAPI.Controllers
{
    public class ParticipantController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddParticipant([FromBody] Participant p)
        {

            ContactDAO dao = new ContactDAO();
            if (p != null)
            {
                dao.createParticipant(p);
                return Request.CreateResponse(HttpStatusCode.Created, p);
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, p);
        }

       

        [HttpGet]
        public Participant GetById(int id)
        {
            ContactDAO dao = new ContactDAO();
            Participant p = dao.getParticipantById(id);
            return p; 
        }

        [HttpGet]
        public IEnumerable<Participant> GetAll()
        {
            ContactDAO dao = new ContactDAO();
            List<Participant> lesParticipants = dao.getAllParticipants();
            return lesParticipants.ToList();
        }

        [HttpGet]
        public IEnumerable<Participant> GetEquipies(int idEquipe)
        {
            ContactDAO dao = new ContactDAO();
            List<Participant> lesParticipants = dao.getEquipies(idEquipe);
            return lesParticipants.ToList();
        }


        [HttpDelete]
        public string DeleteParticipant(int id)
        {
            ContactDAO dao = new ContactDAO();
            dao.deleteParticipant(id);
            return "Participant supprimé id " + id;

        }

        [HttpPut]
        public string UpdateParticipant(int id, string nom)
        {
            ContactDAO dao = new ContactDAO();
            dao.updateParticipant(id, nom);
            return "Mise à jour du participant avec le nom " + nom + " et l'id " + id;

        }

        [HttpPut]
        public string UpdateParticipant(int id, string nom, string prenom, string email, string numero, string sexe)
        {
            ContactDAO dao = new ContactDAO();
            dao.updateParticipant(id, nom, prenom, email, numero, sexe);
            return "Mise à jour du participant avec le nom " + nom + " et l'id " + id;

        }

        [HttpPut]
        public string AttribuerEquipe(int idParticipant, int idEquipe)
        {
            ContactDAO dao = new ContactDAO();
            dao.attribuerEquipe(idParticipant, idEquipe);
            return "Mise à jour du participant avec l'équipe " + idEquipe;

        }
    }
}
