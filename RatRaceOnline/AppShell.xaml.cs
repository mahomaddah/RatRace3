using RatRace3.View;
using Plugin.Maui.Audio;
using RatRace3.Models;
using System.Collections.ObjectModel;
using RatRace3.ViewModel;
using RatRace3.DAL;
namespace RatRace3
{
    public partial class AppShell : Shell
    {

        public LevelModel CurrentLevelModel { get; set; }
        public Company CurrentCompany { get; set; }
        public ObservableCollection<Company> IPOcompanies { get; set; }
        public SelectLevelViewModel SelectLevelViewModel { get; set; }
        public UIsettingsModel UIsettingsModel { get; set; }
        public AppShell()
        {

            Routing.RegisterRoute("MarketPage", typeof(MarketPage));
            Routing.RegisterRoute("StoryModeView", typeof(StoryModeView));
            Routing.RegisterRoute("StoryDetailView", typeof(StoryDetailView));
            Routing.RegisterRoute("GameView", typeof(GameView));

        
            getData();

            InitializeComponent();
            if (UIsettingsModel.IsMusicPlaying)
            {
                PlayBackgroundMusic();
            }
            else
            {
                IsMusicPlaying = false;

                TurnMusicBtn.IconImageSource = "music_on.png";
            }

        }
        void getData()
        {
  
           

            UIsettingsModel = new Models.UIsettingsModel
            {
                IsMusicPlaying = false, //TODO : return to true befroe MVP releseing ....
                LastPlayedLevelIndex = 1
            };

            SelectLevelViewModel = new SelectLevelViewModel
            {
                ImageCollection = new List<LevelModel>()
            };
            //dammy data ...
            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 50.00,
                NetTotalIncome = 2200,
                CurrentMonth = 1,
                MaximumMonth = 24,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="Ducati Bike Debt", Totalamount = 3600.00, MounthRemaining = 12, IntrestRate = 0.02, LiabilityModelID = 1},
                    new LiabilityModel{LiabilityName="Expensive Drone Debt", Totalamount=2400.00, MounthRemaining = 12, IntrestRate=0.03, LiabilityModelID = 2},
                    new LiabilityModel{LiabilityName="Motorcycle Camping Gear Debt", Totalamount=1200.00, MounthRemaining = 12, IntrestRate=0.01, LiabilityModelID = 3}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Salary", Amount = 2800.00, IncomeSourceID=1 } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "FD $5020.63 @4.12% Interest Rate | JP Morgan Bank", AssetType = AssetTypes.FixedDeposit.ToString(), AssetValue = 1300.00, IntrestRate= 0.04, IsBankDeposit= true, IsRecursiveDepositRD = false, PassiveIncome = 4.33, AssetModelID = 1},
                    new AssetModel {AssetName = "MSFT P&L 28% @ $128.12", AssetType = AssetTypes.Stock.ToString(), AssetValue = 200.00, IntrestRate= 0.10, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 5.00, AssetModelID = 2}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Ducati Bike Debt EMI", Amount = 300.00, ExpenseModelID = 1},
                    new ExpenseModel{ Name = "Expensive Drone Debt EMI", Amount = 200.00, ExpenseModelID = 2},
                    new ExpenseModel{ Name = "Motorcycle Camping Gear Debt EMI", Amount = 100.00, ExpenseModelID = 3}
                }
            }},
                StoryLevelID = "A",
                Image = "software_engineer.png",
                Header = "The System Engineer's Breakthrough",
                DetailStory = "Erdem is a Principal System Engineer @ Huawei Tech. Ltd., receives a 100% salary hike and splurges on luxury items such as a brand-new Ducati bike!, an expensive drone, and motorcycle camping gear on EMI. Help him pay off his debts within a year.",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = GameGoalTypes.Liabilities.ToString(), Target = 0, YouHave = 3 },
                new StoryGoalModel { Goal = GameGoalTypes.Month.ToString(), Target = 24, YouHave = 1 }}
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 400.00,
                NetTotalIncome = 2400,
                CurrentMonth = 1,
                MaximumMonth = 24,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="KUBA TK03 Bike Debt", Totalamount = 3500.00, MounthRemaining = 12, IntrestRate = 0.02, LiabilityModelID = 1},
                    new LiabilityModel{LiabilityName="Motorcycle Safe Jacket Debt", Totalamount=2500.00, MounthRemaining = 12, IntrestRate=0.02, LiabilityModelID = 2},
                    new LiabilityModel{LiabilityName="Motorcycle Helmet Debt", Totalamount=1200.00, MounthRemaining = 12, IntrestRate=0.01, LiabilityModelID = 3}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Salary", Amount = 2800.00, IncomeSourceID=1 } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "GOOGL Stock", AssetType = AssetTypes.Stock.ToString(), AssetValue = 1500.00, IntrestRate= 0.05, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 7.50, AssetModelID = 1}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "KUBA TK03 Bike Debt EMI", Amount = 300.00, ExpenseModelID = 1},
                    new ExpenseModel{ Name = "Motorcycle Safe Jacket Debt EMI", Amount = 200.00, ExpenseModelID = 2},
                    new ExpenseModel{ Name = "Motorcycle Helmet Debt EMI", Amount = 100.00, ExpenseModelID = 3}
                }
            }},
                StoryLevelID = "2",
                Image = "undraw_investing.png",
                Header = "Investing Adventure",
                DetailStory = "You start your journey as a novice investor, barely making ends meet. One day, you stumble upon a hidden gem in the stock market that others have overlooked. Will you risk your savings on this company, or play it safe with traditional investments? Your choices will decide if you break free from the rat race or fall further into it.You also bought your friend Erdem's old Motorcycle with debt so you need to handle them.",
                isStarted = false,
                isUnlocked = true,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = GameGoalTypes.Balance.ToString(), Target = 10000, YouHave = 400 } }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 2000.00,
                NetTotalIncome = 2100,
                CurrentMonth = 1,
                MaximumMonth = 12,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="Student Loan", Totalamount = 5000.00, MounthRemaining = 24, IntrestRate = 0.05, LiabilityModelID = 1},
                    new LiabilityModel{LiabilityName="Car Loan", Totalamount=8000.00, MounthRemaining = 36, IntrestRate=0.03, LiabilityModelID = 2}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Part-Time Job", Amount = 1200.00, IncomeSourceID=1 }, new IncomeSourceModel { Name = "Freelancing", Amount = 900.00, IncomeSourceID=2 } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Savings Account", AssetType = AssetTypes.RecursiveDeposit.ToString(), AssetValue = 1000.00, IntrestRate= 0.02, IsBankDeposit= true, IsRecursiveDepositRD = true, PassiveIncome = 1.67, AssetModelID = 1}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Student Loan EMI", Amount = 220.00, ExpenseModelID = 1},
                    new ExpenseModel{ Name = "Car Loan EMI", Amount = 300.00, ExpenseModelID = 2},
                    new ExpenseModel{ Name = "Groceries", Amount = 150.00, ExpenseModelID = 3},
                    new ExpenseModel{ Name = "Transportation", Amount = 100.00, ExpenseModelID = 4}
                }
            }},

                StoryLevelID = "3",
                Image = "exams.png",
                Header = "The Exam Hustle",
                DetailStory = "You're back in school, juggling part-time jobs while preparing for the toughest exams of your life. Your goal? A scholarship that could open doors to a better life. But the stress of it all threatens to derail you. Can you manage your time and mental health, or will you succumb to burnout?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = GameGoalTypes.Cashflow.ToString(), Target = 2400, YouHave = 2100 } }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 1500.00,
                NetTotalIncome = 2500,
                CurrentMonth = 1,
                MaximumMonth = 18,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="Credit Card Debt", Totalamount = 7000.00, MounthRemaining = 12, IntrestRate = 0.18, LiabilityModelID = 1},
                    new LiabilityModel{LiabilityName="Payday Loan", Totalamount=3000.00, MounthRemaining = 6, IntrestRate=0.25, LiabilityModelID = 2}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Full-Time Job", Amount = 2500.00, IncomeSourceID=1 } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Retirement Fund", AssetType = AssetTypes.MutualFund.ToString(), AssetValue = 5000.00, IntrestRate= 0.06, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 25.00, AssetModelID = 1}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Credit Card Minimum Payment", Amount = 200.00, ExpenseModelID = 1},
                    new ExpenseModel{ Name = "Payday Loan EMI", Amount = 500.00, ExpenseModelID = 2},
                    new ExpenseModel{ Name = "Rent", Amount = 800.00, ExpenseModelID = 3},
                    new ExpenseModel{ Name = "Utilities", Amount = 200.00, ExpenseModelID = 4}
                }
            }},
                StoryLevelID = "4",
                Image = "interview.png",
                Header = "The Interview Gauntlet",
                DetailStory = "You've landed a series of interviews for your dream job, but the competition is fierce. Each question tests not only your knowledge but also your ability to think on your feet. Nail the interviews and secure a position that will change your financial future forever.",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = GameGoalTypes.Balance.ToString(), Target = 3000, YouHave = 1500 } }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 1000.00,
                NetTotalIncome = 2000,
                CurrentMonth = 1,
                MaximumMonth = 24,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="Startup Loan", Totalamount = 10000.00, MounthRemaining = 24, IntrestRate = 0.10, LiabilityModelID = 1}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Side Hustle", Amount = 1000.00, IncomeSourceID=1 }, new IncomeSourceModel { Name = "Savings Interest", Amount = 50.00, IncomeSourceID=2 } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Startup Equity", AssetType = AssetTypes.Stock.ToString(), AssetValue = 20000.00, IntrestRate= 0.00, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 0.00, AssetModelID = 1}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Startup Loan EMI", Amount = 500.00, ExpenseModelID = 1},
                    new ExpenseModel{ Name = "Team Salaries", Amount = 1000.00, ExpenseModelID = 2},
                    new ExpenseModel{ Name = "Office Rent", Amount = 800.00, ExpenseModelID = 3}
                }
            }},
                StoryLevelID = "5",
                Image = "dotnet_bot.png",
                Header = "Launching Your Dreams",
                DetailStory = "After years of planning, you're ready to launch your startup, a metaphorical rocket aimed at financial freedom. But the launch is risky—your team is depending on you, and any miscalculation could lead to failure. Will you soar to new heights, or will gravity pull you back into the rat race?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> {
                new StoryGoalModel { Goal = GameGoalTypes.Balance.ToString(), Target = 4000, YouHave = 1000 },
                new StoryGoalModel { Goal = GameGoalTypes.Month.ToString(), Target = 24, YouHave = 1 }
            }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 3000.00,
                NetTotalIncome = 3000,
                CurrentMonth = 1,
                MaximumMonth = 36,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="Shared Office Loan", Totalamount = 15000.00, MounthRemaining = 36, IntrestRate = 0.08, LiabilityModelID = 1}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Team Project Revenue", Amount = 3000.00, IncomeSourceID=1 } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Shared Project Assets", AssetType = AssetTypes.Stock.ToString(), AssetValue = 5000.00, IntrestRate= 0.00, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 0.00, AssetModelID = 1}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Office Loan EMI", Amount = 500.00, ExpenseModelID = 1},
                    new ExpenseModel{ Name = "Team Resources", Amount = 1000.00, ExpenseModelID = 2},
                    new ExpenseModel{ Name = "Miscellaneous Expenses", Amount = 300.00, ExpenseModelID = 3}
                }
            }},
                StoryLevelID = "6",
                Image = "shared_goals.png",
                Header = "Shared Goals, Shared Dreams",
                DetailStory = "You team up with like-minded individuals who share your vision for escaping the rat race. Together, you pool resources, divide tasks, and strategize your next big move. Can you unite to achieve greatness, or will the team fall apart under pressure?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = "Liabilities", Target = 0, YouHave = 1 } }
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

            //Loading Data Method...
       //     LoadDataFromLiteDB();

               CurrentLevelModel = SelectLevelViewModel.ImageCollection.FirstOrDefault();//TODO ... DELET ME 

            //Saving Data... method...
          //  SaveDataToLiteDB();



        }

        void LoadDataFromLiteDB()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "GameData.db");
            var localDb = new DataAccessService(dbPath);

            // UISettingsModel verisini yükleme
            UIsettingsModel = localDb.GetDataById<UIsettingsModel>(1, "UISettings");

            // Tüm seviyeleri yükleme


            SelectLevelViewModel = new SelectLevelViewModel
            {
                ImageCollection = localDb.GetAllData<LevelModel>("Levels").ToList()
            };

        }
        void SaveDataToLiteDB()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "GameData.db");
            var localDb = new DataAccessService(dbPath);
            localDb.SaveData(UIsettingsModel, "UISettings");

            // SelectLevelViewModel verisini kaydetme
            foreach (var level in SelectLevelViewModel.ImageCollection)
            {
                localDb.SaveData(level, "Levels");
            }

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
