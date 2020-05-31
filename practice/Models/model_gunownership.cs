using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using practice.Interfaces;
using System.Threading.Tasks;
using SQLite;
using System.Linq;

namespace practice.Models
{
    [Table("tblGunOwnership")]
    public class model_gunownership:ISQLUtility<model_gunownership>
    {
        [PrimaryKey,NotNull]
        private string ID { get; set; }
        public string Race { get; set; }
        public int OwnGunYes { get; set; }
        public int OwnGunNo { get; set; }
        public int OwnGunRefused { get; set; }
        public int OwnGunNotAnswered { get; set; }

        
        
        public model_gunownership()
        {
            this.ID = Guid.NewGuid().ToString();
        }

        public static Task<List<model_gunownership>> GetAll()
        {
            var database = new SQLiteAsyncConnection(App.dbpath);
            return database.Table<model_gunownership>().ToListAsync();

        }
            public void DeleteItem(model_gunownership item)
        {
            var database = new SQLiteAsyncConnection(App.dbpath);
            database.DeleteAsync(item.Race);
        }

        public Task<model_gunownership> GetItem(string race)
        {
            var database = new SQLiteAsyncConnection(App.dbpath);
            return database.Table<model_gunownership>().Where(i => i.Race == race).FirstOrDefaultAsync();
        }
        public Task<List<model_gunownership>> GetItems()
        {
            var database = new SQLiteAsyncConnection(App.dbpath);
            return database.Table<model_gunownership>().ToListAsync();
        }

        public void SaveItem()
        {
            var database = new SQLiteAsyncConnection(App.dbpath);
            database.InsertAsync(this);
        }
    
    }
}
