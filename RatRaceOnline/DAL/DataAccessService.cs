using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using RatRace3.Models;
using Dapper;

namespace RatRace3.DAL
{
    public class DataAccessService
    {
        private static string dbPath = Path.Combine(FileSystem.AppDataDirectory, "SaveGameData.db");
        SQLiteConnection SQLiteConnection { get; set; }
        public DataAccessService()
        {
            SQLiteConnection = new SQLiteConnection(dbPath);
            InitializeDatabase();
        }

        void InitializeDatabase()
        {
             SQLiteConnection.CreateTable<UIsettingsModel>();
        }

        public void SaveUISettings(UIsettingsModel settings)
        {
            
            var existingSettings = SQLiteConnection.Table<UIsettingsModel>().FirstOrDefault();

            if (existingSettings != null)
            {
                settings.Id = existingSettings.Id;
                SQLiteConnection.Update(settings);
            }
            else
            {
                SQLiteConnection.Insert(settings);
            }
        }

        public UIsettingsModel GetUISettings()
        {

            return SQLiteConnection.Table<UIsettingsModel>().FirstOrDefault() ?? new UIsettingsModel
            {
                IsMusicPlaying = true,
                LastPlayedLevelIndex = 3
            };
        }


        #region DeleteOldLiteDBcodes

        //private readonly string _dbPath;

        //    public DataAccessService(string dbPath)
        //    {
        //        _dbPath = dbPath;
        //    }

        //    private LiteDatabase GetDatabase()
        //    {
        //        return new LiteDatabase(_dbPath);


        //    }

        //    // Genel veri ekleme veya güncelleme
        //    public void SaveData<T>(T data, string collectionName) where T : class
        //    {
        //        using (var db = GetDatabase())
        //        {
        //            var collection = db.GetCollection<T>(collectionName);
        //            collection.Upsert(data);
        //        }
        //    }

        //    public List<LevelModel> GetAllLevelModels()
        //    {
        //        using (var db = GetDatabase())
        //        {
        //            return db.GetCollection("Levels").FindAll<LevelModel>().ToList();

        //        }
        //    }

        //    // Tüm verileri yükleme
        //    public List<T> GetAllData<T>(string collectionName) where T : class
        //    {
        //        using (var db = GetDatabase())
        //        {

        //            var collection = db.GetCollection<T>(collectionName);
        //            return collection.FindAll().ToList();
        //        }
        //    }

        //    // Tek bir veri yükleme
        //    public T GetDataById<T>(int id, string collectionName) where T : class
        //    {
        //        using (var db = GetDatabase())
        //        {
        //            var collection = db.GetCollection<T>(collectionName);
        //            return collection.FindById(id);
        //        }
        //    }

        //    // Veri silme
        //    public void DeleteData<T>(int id, string collectionName) where T : class
        //    {
        //        using (var db = GetDatabase())
        //        {
        //            var collection = db.GetCollection<T>(collectionName);
        //            collection.Delete(id);
        //        }
        //    }
        //
        #endregion
    }
}

