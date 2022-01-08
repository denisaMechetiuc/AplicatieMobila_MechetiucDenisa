using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AplicatieMobila_MechetiucDenisa.Models
{
    public class CerinteLista            // este folosita pt. a salva fiecare lista de cerinte in aplicatie 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Descriere { get; set; }
        public DateTime Data { get; set; }
    }
}
