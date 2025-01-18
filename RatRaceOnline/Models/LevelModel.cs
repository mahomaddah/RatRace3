using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.Models
{
    //public class LevelModel
    //{
    //    public string StoryLevelID { get; set; }
    //    public string Header { get; set; }
    //    public string Description { get; set; }
    //    public string ImagePath { get; set; }
    //    public int HighestMounthScore { get; set; }
    //    public bool isStarted { get; set; }
    //    public bool isUnlocked { get; set; }

    //    public List<PlayerModel> Players { get; set; }

    //    public LevelModel()
    //    {
    //        Players = new List<PlayerModel> { new PlayerModel {PlayerModelID = 1 , Balance = 1.1 , TotalIncome =1.1 , TotalExpences = 1.1  } };
    //    }
    //}



    public class LevelModel
    {
        /// <summary>
        /// is IsGameFinishable means if the use won the game or reached all the levels's list of goals:  StoryGoalModels
        /// </summary>
        public bool IsGameFinishable { get; set; }
        /// <summary>
        /// Players.first is always the user himself and other can be multiplayer or bots to simulate real economy ...
        /// </summary>
        public List<PlayerModel> Players { get; set; }
        public bool IsNewGameStarted { get; set; }
        /// <summary>
        ///IsGameFinished: for records and etc...and next level unlocks.. get True after Finish game button of taht level clicked...
        /// </summary>
        public bool IsGameFinished{ get; set; }
        public string StoryLevelID { get; set; }
        public int HighestMounthScore { get; set; }
        public string Header { get; set; }
        public string DetailStory { get; set; }
        public bool isStarted { get; set; }
        public bool isUnlocked { get; set; }
        public List<StoryGoalModel> StoryGoalModels { get; set; }
        public LevelModel()
        {
            IsGameFinishable=false;

            Players = new List<PlayerModel> { new PlayerModel { PlayerModelID = 1, Balance = 1.1, TotalExpences = 1.1 } };
            
            StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = "Liabilities", Target = 0, YouHave = 3 } };

        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
