using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using SQLite;
using RatRace3.Models;
using RatRace3.DAL.DbModels;
using System.IO;
using Microsoft.Maui.Storage;

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
            SQLiteConnection.CreateTable<SaveGameData>();
            SQLiteConnection.CreateTable<SaveGameExtendedData>();  // Yeni tablo: Companies ve NewsPaper'ları kaydetmek için
        }

        // === SAVE PLAYER DATA ===
        #region Player Data Service:
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
                SQLiteConnection.Insert(new SaveGameData
                {
                    StoryLevelID = storyLevelID,
                    PlayerJsonData = jsonData,
                    PlayerID = player.PlayerModelID
                });
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
            return null;
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
        #endregion

        // === SAVE & LOAD COMPANIES DATA ===
        #region Companies Data Service :
        public void SaveCompaniesData(List<Company> companies, string storyLevelID)
        {
            var jsonData = JsonSerializer.Serialize(companies);
            var existingSave = SQLiteConnection.Table<SaveGameExtendedData>()
                .FirstOrDefault(s => s.DataType == "Companies" && s.StoryLevelID == storyLevelID);

            if (existingSave != null)
            {
                existingSave.JsonData = jsonData;
                SQLiteConnection.Update(existingSave);
            }
            else
            {
                SQLiteConnection.Insert(new SaveGameExtendedData
                {
                    StoryLevelID = storyLevelID,
                    DataType = "Companies",
                    JsonData = jsonData
                });
            }
        }

        public List<Company> LoadCompaniesData(string storyLevelID)
        {
            var savedData = SQLiteConnection.Table<SaveGameExtendedData>()
                .FirstOrDefault(s => s.DataType == "Companies" && s.StoryLevelID == storyLevelID);

            return savedData != null ? JsonSerializer.Deserialize<List<Company>>(savedData.JsonData) : new List<Company>();
        }
        #endregion

        // === SAVE & LOAD NEWSPAPER DATA ===
        #region NewsPapers Data Service:
        public void SaveNewsPapersData(List<NewsPaperModel> newspapers, string storyLevelID)
        {
            var jsonData = JsonSerializer.Serialize(newspapers);
            var existingSave = SQLiteConnection.Table<SaveGameExtendedData>()
                .FirstOrDefault(s => s.DataType == "NewsPapers" && s.StoryLevelID == storyLevelID);

            if (existingSave != null)
            {
                existingSave.JsonData = jsonData;
                SQLiteConnection.Update(existingSave);
            }
            else
            {
                SQLiteConnection.Insert(new SaveGameExtendedData
                {
                    StoryLevelID = storyLevelID,
                    DataType = "NewsPapers",
                    JsonData = jsonData
                });
            }
        }

        public List<NewsPaperModel> LoadNewsPapersData(string storyLevelID)
        {
            var savedData = SQLiteConnection.Table<SaveGameExtendedData>()
                .FirstOrDefault(s => s.DataType == "NewsPapers" && s.StoryLevelID == storyLevelID);

            return savedData != null ? JsonSerializer.Deserialize<List<NewsPaperModel>>(savedData.JsonData) : new List<NewsPaperModel>();
        }
        #endregion

        // === SAVE & LOAD UI SETTINGS ===
        #region UI settings Data Service:
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
        #endregion
    }
}