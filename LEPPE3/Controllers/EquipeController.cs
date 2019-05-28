using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LEPPE3.Models;
using Newtonsoft.Json;
//using API_Pozzi;
using MySql.Data.MySqlClient;

namespace API_Pozzi.controller
{
    public class EquipeController
    {
        [HttpPost]
        public HttpResponseMessage AddEquipe([FromBody] Equipe e)
        {
            if (e != null)
                return Request.CreateResponse(HttpStatusCode.Created, e);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
        }

        [HttpGet]
        public Equipe GetById(long id_equipe)
        {
            ContactDAO dao = new ContactDAO();
            List<Equipe> lesEquipes = dao.getAllEquipe();
            return lesEquipes.ElementAt(0);
        }

        [HttpGet]
        public IEnumerable<Equipe> GetAllE()
        {
            ContactDAO dao = new ContactDAO();
            List<Equipe> lesEquipes = dao.getAllEquipe();
            return lesEquipes.ToList();
        }


        [HttpDelete]
        public string DeleteEquipe(string id_equipe)
        {
            return "Equipe supprimée id " + id_equipe;
        }

        [HttpPut]
        public string UpdateEquipe(string id_equipe, string nom_equipe, string couleur_equipe)
        {
            return "Mise à jour de l'équipe avec l'id " + id_equipe + " , le nom " + nom_equipe + "et la couleur" + couleur_equipe;
        }


    }
}
