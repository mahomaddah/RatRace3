using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.DAL.DbModels
{
    [Table("SaveGameData")]
    public class SaveGameData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string StoryLevelID { get; set; } // Hangi seviyeye ait olduğunu belirler
        public int PlayerID { get; set; }
        public string PlayerJsonData { get; set; } // JSON string olarak kaydedilecek


    }
}
