using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.DAL.DbModels
{

    /// <summary>
    /// === NEW DATABASE TABLE FOR EXTENDED OBJECTS : DataType for "Companies", "NewsPapers"
    /// </summary>
    public class SaveGameExtendedData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string DataType { get; set; }  // "Companies", "NewsPapers"
        public string JsonData { get; set; }
        /// <summary>
        /// forgin key to khow which level's Company or newspaper data...
        /// </summary>
        public string StoryLevelID { get; set; }


    }
}
