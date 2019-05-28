using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ApiOrientation.Models
{
    public class DAO
    {
        private MySqlConnection conn;
        public DAO()
        {
            string myConnectionString;
            myConnectionString = "server=172.19.0.2;uid=root;pwd=0550002D;database=***";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }
        
        //se connecter
        public int Connexion(int lid)****
        {
          int id = 0;
          string req = "select id from Participant where id = lid";
          MySqlCommand cmd = new MySqlCommand(req, conn);
          MySqlDataReader rdr = cmd.ExecuteReader();
          while (rdr.Read())
          {
            id = Convert.ToInt32(rdr[0]);
          }
          return id;
        }
        
        //nombre de participants par équipe
       public List<Participant> getAllParticipantEquipe(int id_participant)
       {
          
          string req = "SELECT COUNT(*) FROM Participant WHERE id_participant = id";
          MySqlCommand cmd = new MySqlCommand(req, conn);
       
       }
        return getAllParticipantEquipe;
      }
      
      //ajouter participant dans Equipe
      
      
          
       
