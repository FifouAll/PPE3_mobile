using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LEPPE3.Models
{
    public class Participant
    {
        int id;
        string nom;
        string pwd;
        string prenom;
        string mail;
        int age;
        string telephone;
        string sexe;
        int id_equipe;

        public Participant(int id, string nom, string pwd, string prenom, string mail, int age, string telephone, string sexe, int id_equipe)
        {
            this.id = id;
            this.nom = nom;
            this.pwd = pwd;
            this.prenom = prenom;
            this.mail = mail;
            this.age = age;
            this.telephone = telephone;
            this.sexe = sexe;
            this.id_equipe = id_equipe;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Mail { get => mail; set => mail = value; }
        public int Age { get => age; set => age = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public int Id_equipe { get => id_equipe; set => id_equipe = value; }

    }
}