using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace AplicatieMobila_MechetiucDenisa.Models
{
    public class ListaApartamente
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(CerinteLista))]
        public int CerinteListaID { get; set; }
        public int ApartamenteID { get; set; }
    }
}
