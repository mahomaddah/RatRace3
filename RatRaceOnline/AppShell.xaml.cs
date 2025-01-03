using RatRace3.View;
using Plugin.Maui.Audio;
using RatRace3.Models;
using System.Collections.ObjectModel;
using RatRace3.ViewModel;
namespace RatRace3
{
    public partial class AppShell : Shell
    {
        public LevelModel CurrentLevelModel { get; set; }
        public Company CurrentCompany { get; set; }
        public ObservableCollection<Company> IPOcompanies { get; set; }
        public SelectLevelViewModel SelectLevelViewModel { get; set; }

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

            SelectLevelViewModel = new SelectLevelViewModel
            {
                ImageCollection = new List<LevelModel>()
            };
            //dammy data ...


            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                StoryLevelID = "A",
                Image = "undraw_investing.png",
                Header = "Investing Adventure",
                DetailStory = "You start your journey as a novice investor, barely making ends meet. One day, you stumble upon a hidden gem in the stock market that others have overlooked. Will you risk your savings on this company, or play it safe with traditional investments? Your choices will decide if you break free from the rat race or fall further into it.",
                isStarted = false,
                isUnlocked = true,
                HighestMounthScore = 0,
                StoryGoalModels=new List<StoryGoalModel> { new StoryGoalModel { Goal = "Liabilities", Target = 0, YouHave = 3 } }

            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                StoryLevelID = "2",
                Image = "software_engineer.png",
                Header = "The Software Engineer's Breakthrough",
                DetailStory = "As a budding software engineer, you're stuck in a low-paying job with no prospects of promotion. But one day, you're inspired to create a groundbreaking app. The only question is: do you have the grit to see your idea through, or will the challenges of the tech world overwhelm you? Build, fail, and try again to see where your code takes you.",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = "Liabilities", Target = 0, YouHave = 3 } }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                StoryLevelID = "3",
                Image = "exams.png",
                Header = "The Exam Hustle",
                DetailStory = "You're back in school, juggling part-time jobs while preparing for the toughest exams of your life. Your goal? A scholarship that could open doors to a better life. But the stress of it all threatens to derail you. Can you manage your time and mental health, or will you succumb to burnout?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = "Liabilities", Target = 0, YouHave = 3 } }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                StoryLevelID = "4",
                Image = "interview.png",
                Header = "The Interview Gauntlet",
                DetailStory = "You've landed a series of interviews for your dream job, but the competition is fierce. Each question tests not only your knowledge but also your ability to think on your feet. Nail the interviews and secure a position that will change your financial future forever.",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = "Liabilities", Target = 0, YouHave = 3 } }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                StoryLevelID = "5",
                Image = "dotnet_bot.png",
                Header = "Launching Your Dreams",
                DetailStory = "After years of planning, you're ready to launch your startup, a metaphorical rocket aimed at financial freedom. But the launch is risky—your team is depending on you, and any miscalculation could lead to failure. Will you soar to new heights, or will gravity pull you back into the rat race?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = "Liabilities", Target = 0, YouHave = 3 } }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                StoryLevelID = "6",
                Image = "shared_goals.png",
                Header = "Shared Goals, Shared Dreams",
                DetailStory = "You team up with like-minded individuals who share your vision for escaping the rat race. Together, you pool resources, divide tasks, and strategize your next big move. Can you unite to achieve greatness, or will the team fall apart under pressure?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = "Liabilities", Target = 0, YouHave = 3 } }
            });

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
