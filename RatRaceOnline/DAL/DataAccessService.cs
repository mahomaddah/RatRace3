using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Dapper;

namespace RatRace3.DAL
{
    public class DataAccessService
    {
        
    private readonly string _dbPath;

        public DataAccessService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private LiteDatabase GetDatabase()
        {
            return new LiteDatabase(_dbPath);
        }

        // Genel veri ekleme veya güncelleme
        public void SaveData<T>(T data, string collectionName) where T : class
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<T>(collectionName);
                collection.Upsert(data);
            }
        }

        // Tüm verileri yükleme
        public IEnumerable<T> GetAllData<T>(string collectionName) where T : class
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<T>(collectionName);
                return collection.FindAll();
            }
        }

        // Tek bir veri yükleme
        public T GetDataById<T>(int id, string collectionName) where T : class
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<T>(collectionName);
                return collection.FindById(id);
            }
        }

        // Veri silme
        public void DeleteData<T>(int id, string collectionName) where T : class
        {
            using (var db = GetDatabase())
            {
                var collection = db.GetCollection<T>(collectionName);
                collection.Delete(id);
            }
        }
    }

}
