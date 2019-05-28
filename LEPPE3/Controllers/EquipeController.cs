using contactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace contactAPI.Controllers
{
    public class EquipeController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddEquipe([FromBody] Equipe e)
        {

            ContactDAO dao = new ContactDAO();
            if (e != null)
            {
                dao.createEquipe(e);
                return Request.CreateResponse(HttpStatusCode.Created, e);
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
        }
        

        [HttpGet]
        public Equipe GetById(int id)
        {
            ContactDAO dao = new ContactDAO();
            Equipe e = dao.getEquipeById(id);
            return e; 
        }

        [HttpGet]
        public IEnumerable<Equipe> GetAll()
        {
            ContactDAO dao = new ContactDAO();
            List<Equipe> lesParticipants = dao.getAllEquipe();
            return lesParticipants.ToList();
        }


    }
}
