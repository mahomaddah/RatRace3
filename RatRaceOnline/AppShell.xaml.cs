using RatRace3.View;
using Plugin.Maui.Audio;
using RatRace3.Models;
using System.Collections.ObjectModel;
namespace RatRace3
{
    public partial class AppShell : Shell
    {
        public Company CurrentCompany { get; set; }
        public ObservableCollection<Company> IPOcompanies { get; set; }
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
          
            IPOcompanies = new ObservableCollection<Company>
            {
                new Company
                {
                    Symbol = "GOOGL",
                    StockPrice = 125.51,
                    StockDetail = "Google LLC - Technology Company. Google is a global leader in online services and search engine technology."
                },
                new Company
                {
                    Symbol = "AAPL",
                    StockPrice = 258.20,
                    StockDetail = "Apple Inc. - Technology Company. Apple is a Technology and Consumer Electronics leader known for its flagship product, the iPhone."
                },
                new Company
                {
                    Symbol = "MSFT",
                    StockPrice = 439.33,
                    StockDetail = "Microsoft Corporation - Technology Company. Microsoft is a leader in software, cloud computing, and productivity tools."
                },
                new Company
                {
                    Symbol = "WMT",
                    StockPrice = 92.68,
                    StockDetail = "Walmart Inc. - Retail Company. Walmart operates retail stores worldwide and is a leader in consumer goods."
                   ,StockExchange = "NYSE"
                },
                new Company
                {
                    Symbol = "TSLA",
                    StockPrice = 462.25,
                    StockDetail = "Tesla, Inc. - Automotive and Energy Company. Tesla is known for its electric vehicles and sustainable energy solutions."
                },
                new Company
                {
                    Symbol = "META",
                    StockPrice = 607.75,
                    StockDetail = "Meta Platforms, Inc. - Technology Company. Meta is the parent company of Facebook and a leader in social media and virtual reality."
                },
                new Company
                {
                    Symbol = "ADBE",
                    StockPrice = 447.94,
                    StockDetail = "Adobe Inc. - Software Company. Adobe specializes in creative software tools such as Photoshop and Acrobat."
                },
                new Company
                {
                    Symbol = "NVDA",
                    StockPrice = 140.22,
                    StockDetail = "NVIDIA Corporation - Technology Company. NVIDIA is a leader in GPU technology and artificial intelligence solutions."
                },
                new Company
                {
                    Symbol = "AMZN",
                    StockPrice = 229.05,
                    StockDetail = "Amazon.com, Inc. - Consumer Cyclical. Amazon is a global leader in e-commerce and cloud computing services."
                }
            };

            CurrentCompany = IPOcompanies.First();        
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
