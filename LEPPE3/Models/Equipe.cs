using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LEPPE3.Models;

namespace LEPPE3.Models
{
    public class Equipe
    {


        int id_equipe;
        string nom_equipe;
        string couleur_equipe;

        public Equipe(int id_equipe, string nom_equipe, string couleur_equipe)
        {
            this.id_equipe = id_equipe;
            this.nom_equipe = nom_equipe;
            this.couleur_equipe = couleur_equipe;
        }

        public int Id_equipe { get => id_equipe; set => id_equipe = value; }
        public string Nom_equipe { get => nom_equipe; set => nom_equipe = value; }
        public string Couleur_equipe { get => couleur_equipe; set => couleur_equipe = value; }
    }

}