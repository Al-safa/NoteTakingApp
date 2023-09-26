using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NoteTakingApp
{
    public class database
    {
        private readonly SQLiteAsyncConnection _database;

        public database (String dbPath)
        {
            _database = new SQLiteAsyncConnection (dbPath);
            _database.CreateTableAsync<notes>();
        }
        
        public Task<int> CreateNotes(notes note)
        {
            return _database.InsertAsync(note);
        }
        public Task<List<notes>> ReadNotes()
        {
            return _database.Table<notes>().ToListAsync();
        }
        public Task <int> UpdateNotes(notes note)
        {
            return _database.UpdateAsync(note);
        }

        public Task<int> DeleteNotes(notes note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
