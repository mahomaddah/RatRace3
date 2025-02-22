using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using RatRace3.Models;
using Dapper;
using RatRace3.DAL.DbModels;
using System.Text.Json;


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
            //      SQLiteConnection.DropTable<PlayerModel>();
            //      SQLiteConnection.CreateTable<PlayerModel>();
            //      SQLiteConnection.CreateTable<LevelModel>();
            SQLiteConnection.CreateTable<SaveGameData>();


        }


        public void SavePlayerData(PlayerModel player, string storyLevelID)
        {
            var jsonData = JsonSerializer.Serialize(player);

            var existingSave = SQLiteConnection.Table<SaveGameData>()
                .FirstOrDefault(s => s.StoryLevelID == storyLevelID && s.PlayerID == player.PlayerModelID);

            if (existingSave != null)
            {
                existingSave.PlayerJsonData = jsonData;
                SQLiteConnection.Update(existingSave);
            }
            else
            {
                SQLiteConnection.Insert(new SaveGameData { StoryLevelID = storyLevelID, PlayerJsonData = jsonData ,PlayerID =player.PlayerModelID});
            }
        }

        public PlayerModel LoadPlayerData(string storyLevelID, int playerID)
        {
            var savedGame = SQLiteConnection.Table<SaveGameData>()
                .FirstOrDefault(s => s.StoryLevelID == storyLevelID && s.PlayerID == playerID);

            if (savedGame != null)
            {
                return JsonSerializer.Deserialize<PlayerModel>(savedGame.PlayerJsonData);
            }
            return null; // Kayıt yoksa null dön
        }

        public void DeletePlayerData(string storyLevelID, int playerID)
        {
            var existingSave = SQLiteConnection.Table<SaveGameData>()
                .FirstOrDefault(s => s.StoryLevelID == storyLevelID && s.PlayerID == playerID);

            if (existingSave != null)
            {
                SQLiteConnection.Delete(existingSave);
            }
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
     
    }
}

