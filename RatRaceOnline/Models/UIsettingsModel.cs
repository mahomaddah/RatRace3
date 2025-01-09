namespace RatRace3.Models
{
    public class UIsettingsModel
    {
        public bool IsMusicPlaying { get; set; }
        public int LastPlayedLevelIndex { get; set; }
        public UIsettingsModel()
        {
            IsMusicPlaying = true;
            LastPlayedLevelIndex = 3;
        }
    }
}