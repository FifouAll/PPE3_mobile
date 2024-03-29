﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using LePPE3.Models;
//using contactAPI.Models;
//using API_Pozzi;
//using MySql.Data.MySqlClient;

namespace LEPPE3.Controllers
{
    public class CourseController
    {
        
        //création course
        [HttpPost]
        public HttpResponseMessage AddCourse([FromBody] Course c)
        {
            if (c != null)
                return Request.CreateResponse(HttpStatusCode.Created, c);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, c);
        }

        //affichage de toutes les courses
        [HttpGet]
        public IEnumerable<Course> GetAllC()
        {
            ContactDAO dao = new ContactDAO();
            List<Course> lesCourses = dao.getAllCourse();
            return lesCourses.ToList();
        }

        //mise à jour des courses
        [HttpPut]
        public string UpdateCourse(string depart_course, string fin_course, string lieu_course, string nom_course)
        {
            return "Mise à jour de la course : /n" + "Début de course le : " + depart_course + ". /n La fin est prévue le : " + fin_course + "/n" +
                "Lieu : " + lieu_course + " /n" +
                "Nom de la course" + nom_course;

        }

        //effacement des courses
        [HttpDelete]
        public string DeleteCourse(string nom_course)
        {
            return "Course effacée :  " + nom_course;
        }

    }
}
