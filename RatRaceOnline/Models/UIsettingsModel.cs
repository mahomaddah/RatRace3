using SQLite;

namespace RatRace3.Models
{
    [Table("UISettings")]
    public class UIsettingsModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool IsMusicPlaying { get; set; }
        public int LastPlayedLevelIndex { get; set; }
        public UIsettingsModel()
        {
            IsMusicPlaying = true;
            LastPlayedLevelIndex = 3;
        }
    }
}