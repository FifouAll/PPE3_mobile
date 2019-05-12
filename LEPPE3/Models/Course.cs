using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEPPE3.Models
{
    public class Course
    {
        string depart_course;
        string fin_course;
        string lieu_course;
        string nom_course;

        public Course(string depart_course, string fin_course, string lieu_course, string nom_course)
        {
            this.depart_course = depart_course;
            this.fin_course = fin_course;
            this.lieu_course = lieu_course;
            this.nom_course = nom_course;
        }

        public string Depart_course { get => depart_course; set => depart_course = value; }
        public string Fin_course { get => fin_course; set => fin_course = value; }
        public string Lieu_course { get => lieu_course; set => lieu_course = value; }
        public string Nom_course { get => nom_course; set => nom_course = value; }
    }
}