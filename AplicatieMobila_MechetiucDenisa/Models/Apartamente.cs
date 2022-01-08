using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AplicatieMobila_MechetiucDenisa.Models
{
    public class Apartamente         // tabelul Apartamente, folosit pt. a adauga cerinte in lista de cerinte creata de catre client
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Cartier  { get; set; }
        public string Descriere { get; set; }
        [OneToMany]
        public List<ListaApartamente> ListaApartamente { get; set; }
    }

}
