using RatRace3.View;
using Plugin.Maui.Audio;
using RatRace3.Models;
namespace RatRace3
{
    public partial class AppShell : Shell
    {
        public Company CurrentCompany { get; set; }
        public AppShell()
        {
            Routing.RegisterRoute("MarketPage", typeof(MarketPage));
            Routing.RegisterRoute("StoryModeView", typeof(StoryModeView));
            Routing.RegisterRoute("StoryDetailView", typeof(StoryDetailView));
            Routing.RegisterRoute("GameView", typeof(GameView));

            getData();

            InitializeComponent();
            PlayBackgroundMusic();
        }
        void getData()
        {
            CurrentCompany = new Company
            {
                Symbol = "AAPL",
                StockPrice = 150.25,
                StockDetail = "Apple Inc. - Technology Company"
            };


        }

        private void TurnMusicBtn_Clicked(object sender, EventArgs e)
        {
            PlayBackgroundMusic();
        }

        public bool IsMusicPlaying { get; set; }
        public IAudioPlayer BackgroudMusic { get; set; }
        private async void PlayBackgroundMusic()
        {
            try
            {
                if (IsMusicPlaying != true)
                {
                    // Set the media file to play
                    string musicFilePath = "night_jazz.mp3";
                    BackgroudMusic = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(musicFilePath));
                    BackgroudMusic.Loop = true;
                    BackgroudMusic.Play();
                    IsMusicPlaying = true;
                    TurnMusicBtn.IconImageSource = "music_off.png";
                }
                else
                {
                    BackgroudMusic.Stop();
                    IsMusicPlaying = false;
                 
                    TurnMusicBtn.IconImageSource = "music_on.png";
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"Error playing music: {ex.Message}");
                await DisplayAlert("Error playing music:", ex.Message, "Fuck the music! Continue!!");
            }
        }
    }
}
