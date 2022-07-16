using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Ejercicio2.Models;
using System.Threading.Tasks;

namespace Ejercicio2.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Firma>().Wait();
        }

        public Task<int> SaveFirmaAsync(Firma firma)
        {
            if (firma.Id == 0)
            {
                return db.InsertAsync(firma);
            }
            else
            {
                return null;
            }
        }

        public Task<List<Firma>> GetFirmasAsync()
        {
            return db.Table<Firma>().ToListAsync();
        }
    }
}
