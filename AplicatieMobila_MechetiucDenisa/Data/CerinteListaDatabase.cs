using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using AplicatieMobila_MechetiucDenisa.Models;


namespace AplicatieMobila_MechetiucDenisa.Data
{
    public class CerinteListaDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public CerinteListaDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CerinteLista>().Wait();   // se creeaza tabelul CerinteLista
            _database.CreateTableAsync<Apartamente>().Wait();    // se creeaza tabelul Apartamente
            _database.CreateTableAsync<ListaApartamente>().Wait();  // se creeaza tabelul ListaApartamente
        }
        public Task<List<CerinteLista>> GetCerinteListasAsync()
        {
            return _database.Table<CerinteLista>().ToListAsync();
        }
        public Task<CerinteLista> GetCerinteListaAsync(int id)
        {
            return _database.Table<CerinteLista>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveCerinteListaAsync(CerinteLista clista)  // se salveaza lista de cerinte
        {
            if (clista.ID != 0)
            {
                return _database.UpdateAsync(clista);  // se actualizeaza lista de cerinte
            }
            else
            {
                return _database.InsertAsync(clista);  // se insereaza o lista de cerinte
            }
        }
        public Task<int> DeleteCerinteListaAsync(CerinteLista clista)  // se sterge lista de cerinte  
        {
            return _database.DeleteAsync(clista);
        }
        public Task<int> SaveApartamenteAsync(Apartamente apartamente)  // se salveaza cerintele pt. un apartament 
        {
            if (apartamente.ID != 0)
            {
                return _database.UpdateAsync(apartamente);  // se actualizeaza cerintele pt. un apartament 
            }
            else
            {
                return _database.InsertAsync(apartamente);  // se insereaza cerintele pt. un apartament
            }
        }
        public Task<int> DeleteApartamenteAsync(Apartamente apartamente)  // se sterg cerintele pt. un apartament
        {
            return _database.DeleteAsync(apartamente);
        }
        public Task<List<Apartamente>> GetApartamentesAsync()
        {
            return _database.Table<Apartamente>().ToListAsync();
        }
        public Task<int> SaveListaApartamenteAsync(ListaApartamente lista) // se salveaza lista de cerinte predefinite 
        {
            if (lista.ID != 0)
            {
                return _database.UpdateAsync(lista);  // se actualizeaza lista de cerinte predefinite
            }
            else
            {
                return _database.InsertAsync(lista);  // se insereaza lista de cerinte predefinite 
            }
        }
        public Task<List<Apartamente>> GetListaApartamentesAsync(int cerintelistaid)
        {
            return _database.QueryAsync<Apartamente>(
            "select A.ID, A.Cartier, A.Descriere from Apartamente A"
            + " inner join ListaApartamente LA"
            + " on A.ID = LA.ApartamenteID where LA.CerinteListaID = ?",
            cerintelistaid);
        }
    }
}
