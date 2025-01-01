using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.Models
{
    public class LevelModel
    {
        public string StoryLevelID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int HighestMounthScore { get; set; }
        public bool isStarted { get; set; }
        public bool isUnlocked { get; set; }

        public List<PlayerModel> Players { get; set; }

        public LevelModel()
        {
            Players = new List<PlayerModel> { new PlayerModel {PlayerModelID = 1 , Balance = 1.1 , Income =1.1 , TotalExpences = 1.1  } };
        }
    }
}
