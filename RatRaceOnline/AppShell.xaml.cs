using RatRace3.View;
using Plugin.Maui.Audio;
using RatRace3.Models;
using System.Collections.ObjectModel;
using RatRace3.ViewModel;
using RatRace3.DAL;
using System;
namespace RatRace3
{
    public partial class AppShell : Shell
    {

        public LevelModel CurrentLevelModel { get; set; }
        public GameViewModel GameViewModel { get; set; }
        public Company CurrentCompany { get; set; }//For Stock Market...
        /// <summary>
        /// For stock market : CurrentCompanyAsset Contain Quantity of stock ,Avreage Purchesed Price and etc... example:StockCompanySymbol = "MSFT",StockQuantity = 1.1,StockAverageBuyCost =100.23, AssetValue = 200.00, 
        /// </summary>
        public AssetModel CurrentCompanyAsset { get; set; }

        public ObservableCollection<Company> IPOcompanies { get; set; }
        public SelectLevelViewModel SelectLevelViewModel { get; set; }
        public UIsettingsModel UIsettingsModel { get; set; }
        public AppShell()
        {

            Routing.RegisterRoute("MarketPage", typeof(MarketPage));
            Routing.RegisterRoute("StoryModeView", typeof(StoryModeView));
            Routing.RegisterRoute("StoryDetailView", typeof(StoryDetailView));
            Routing.RegisterRoute("GameView", typeof(GameView));

            InitializeComponent(); 
            GameViewModel = new GameViewModel();
            getAnewGameData();
        



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
      
     
     
        public void getAnewGameData()
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
                    new LiabilityModel{LiabilityName ="Ducati Bike Debt", RemainingAmount=3600, TotalAmount = 3600.00, MonthsRemaining = 12, InterestRate = 0.02 , LiabilityModelID = 1 ,  ExpenseModelID = 1},
                    new LiabilityModel{LiabilityName="Expensive Drone Debt", TotalAmount=2400.00, MonthsRemaining = 12, InterestRate=0.03, LiabilityModelID = 2 , ExpenseModelID = 2},
                    new LiabilityModel{LiabilityName="Motorcycle Camping Gear Debt", TotalAmount=1200.00, MonthsRemaining = 12, InterestRate=0.01, LiabilityModelID = 3 , ExpenseModelID = 3}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Salary", Amount = 2800.00  } ,
                                                             new IncomeSourceModel { Name = "FD $5020.63 @4.12% Interest Rate | JP Morgan Bank" ,Amount =53.56  ,AssetIncomeSourseRelatingGUID = 2.ToString() } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "FD $5020.63 @4.12% Interest Rate | JP Morgan Bank", AssetType = AssetTypes.FixedDeposit.ToString(), AssetValue = 1300.00, IntrestRate= 0.0412, IsBankDeposit= true, IsRecursiveDepositRD = false, PassiveIncome = 53.56, AssetModelID = 1 ,AssetIncomeSourseRelatingGUID = 2.ToString()},
                    new AssetModel {AssetName = "MSFT P&L 28% @ $128.12",  AssetType = AssetTypes.Stock.ToString(),StockCompanySymbol = "MSFT",StockQuantity = 1.1,StockAverageBuyCost =100.23, AssetValue = 200.00, IntrestRate= 0.25, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 5.00, AssetModelID = 2}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Ducati Bike Debt EMI", Amount = 300.00, ExpenseModelID = 1 ,RelatedLiabilityID = 1 },
                    new ExpenseModel{ Name = "Expensive Drone Debt EMI", Amount = 200.00, ExpenseModelID = 2  ,RelatedLiabilityID = 2},
                    new ExpenseModel{ Name = "Motorcycle Camping Gear Debt EMI", Amount = 100.00, ExpenseModelID = 3  ,RelatedLiabilityID = 3},
                    new ExpenseModel{ Name = "Minimum Surviving Expenses", Amount = 1072.33, ExpenseModelID = 4}
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
                new StoryGoalModel { Goal = GameGoalTypes.Month.ToString(), Target = 24, YouHave = 1 },
                new StoryGoalModel { Goal = GameGoalTypes.Balance.ToString(), Target = 35000, YouHave = 50 }

            }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 400.00,
                NetTotalIncome = 1500,
                CurrentMonth = 1,
                MaximumMonth = 24,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="KUBA TK03 Bike Debt", TotalAmount = 3500.00, MonthsRemaining = 12, InterestRate = 0.02, LiabilityModelID = 1 ,ExpenseModelID =1},
                    new LiabilityModel{LiabilityName="Motorcycle Safe Jacket Debt", TotalAmount=2500.00, MonthsRemaining = 12, InterestRate=0.02, LiabilityModelID = 2 ,ExpenseModelID =2},
                    new LiabilityModel{LiabilityName="Motorcycle Helmet Debt", TotalAmount=1200.00, MonthsRemaining = 12, InterestRate=0.01, LiabilityModelID = 3 ,ExpenseModelID =3}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Salary", Amount = 900.00 } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "GOOGL Stock", AssetType = AssetTypes.Stock.ToString(),StockQuantity=2, StockAverageBuyCost = 101, StockCompanySymbol = "GOOGL" , AssetValue = 1500.00, IntrestRate= 0.05, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 7.50, AssetModelID = 1}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "KUBA TK03 Bike Debt EMI", Amount = 300.00, ExpenseModelID = 1, RelatedLiabilityID = 1},
                    new ExpenseModel{ Name = "Motorcycle Safe Jacket Debt EMI", Amount = 200.00, ExpenseModelID = 2 ,RelatedLiabilityID = 2},
                    new ExpenseModel{ Name = "Motorcycle Helmet Debt EMI", Amount = 100.00, ExpenseModelID = 3, RelatedLiabilityID = 3}
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
                    new LiabilityModel{LiabilityName ="Student Loan", TotalAmount = 5000.00, MonthsRemaining = 24, InterestRate = 0.05, LiabilityModelID = 1 ,ExpenseModelID = 1},
                    new LiabilityModel{LiabilityName="Car Loan", TotalAmount=8000.00, MonthsRemaining = 36, InterestRate=0.03, LiabilityModelID = 2 ,ExpenseModelID =2}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Part-Time Job", Amount = 1200.00 },
                                                            new IncomeSourceModel { Name = "Freelancing", Amount = 900.00},
                                                           new IncomeSourceModel { Name = "Savings Account Passive Income" ,Amount =20 ,AssetIncomeSourseRelatingGUID =3.ToString() }
                },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Savings Account", AssetType = AssetTypes.RecursiveDeposit.ToString() , AssetValue = 1000.00, IntrestRate= 0.02, IsBankDeposit= true, IsRecursiveDepositRD = true, PassiveIncome = 20.00 ,AssetIncomeSourseRelatingGUID=3.ToString() }
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Student Loan EMI", Amount = 220.00, ExpenseModelID = 1, RelatedLiabilityID = 1},
                    new ExpenseModel{ Name = "Car Loan EMI", Amount = 300.00, ExpenseModelID = 2 , RelatedLiabilityID = 2},
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
                NetTotalIncome = 500,
                CurrentMonth = 1,
                MaximumMonth = 24,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="Credit Card Debt", TotalAmount = 7000.00, MonthsRemaining = 12, InterestRate = 0.18, LiabilityModelID = 1 , ExpenseModelID =1},
                    new LiabilityModel{LiabilityName="Payday Loan", TotalAmount=3000.00, MonthsRemaining = 6, InterestRate=0.25, LiabilityModelID = 2 , ExpenseModelID = 2}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Full-Time Job", Amount = 2500.00 } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Retirement Fund", AssetType = AssetTypes.MutualFund.ToString(), AssetValue = 5000.00, IntrestRate= 0.06, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 25.00, AssetModelID = 1}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Credit Card Minimum Payment", Amount = 200.00, ExpenseModelID = 1 , RelatedLiabilityID=1},
                    new ExpenseModel{ Name = "Payday Loan EMI", Amount = 500.00, ExpenseModelID = 2, RelatedLiabilityID = 2},

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
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = GameGoalTypes.Balance.ToString(), Target = 30000, YouHave = 1500 },
                                                             new StoryGoalModel { Goal = GameGoalTypes.Month.ToString(), Target = 24, YouHave = 1 },
                                                             new StoryGoalModel { Goal = GameGoalTypes.Liabilities.ToString(), Target = 0, YouHave = 3 }
                }
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
                    new LiabilityModel{LiabilityName ="Startup Loan", TotalAmount = 10000.00, MonthsRemaining = 24, InterestRate = 0.10, LiabilityModelID = 1 ,ExpenseModelID =1 }
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Side Hustle", Amount = 1000.00 }, new IncomeSourceModel { Name = "Savings Interest", Amount = 200.00, AssetIncomeSourseRelatingGUID="2" } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Startup Equity", AssetType = AssetTypes.Other.ToString(), AssetValue = 20000.00, IntrestRate= 0.01, IsBankDeposit= true, IsRecursiveDepositRD = false, PassiveIncome =200.00, AssetModelID = 1 , AssetIncomeSourseRelatingGUID = "2"}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Startup Loan EMI", Amount = 500.00, ExpenseModelID = 1, RelatedLiabilityID = 1},
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
                new StoryGoalModel { Goal = GameGoalTypes.Month.ToString(), Target = 24, YouHave = 1 },
                new StoryGoalModel { Goal = GameGoalTypes.Liabilities.ToString(), Target = 0, YouHave = 1 }
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
                    new LiabilityModel{LiabilityName ="Shared Office Loan", TotalAmount = 15000.00, MonthsRemaining = 36, InterestRate = 0.08, LiabilityModelID = 1 ,ExpenseModelID =1}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Team Project Revenue", Amount = 3000.00 ,AssetIncomeSourseRelatingGUID="1" } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Shared Project Assets", AssetType = AssetTypes.Other.ToString(), AssetValue = 5000.00, IntrestRate= 0.00, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 0.00, AssetModelID = 1 ,AssetIncomeSourseRelatingGUID = "1"}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Office Loan EMI", Amount = 500.00, ExpenseModelID = 1, RelatedLiabilityID = 1},
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

            var random = new Random();

            IPOcompanies = new ObservableCollection<Company>
            {
                new Company
                {
                    Symbol = "GOOGL",
                    StockPrice = 202.31,
                    StockDetail = "Google LLC - Technology Company. Google is a global leader in online services and search engine technology."
                    ,
                        StockFundementalData = new Models.StockFundementalData
                        {
                          StockSymbol =  "GOOGL",
                          TotalCash=95.657 ,//in Bilion USD
                          TotalDebts=125.172,
                          AnnualIncome= 100.12,

                          EPSpast5Y=0.2630, //48.40%
                          EPSthisYr= 0.1405,//128.05%
                          EPSnext5Y=0.1348,

                          DCFvaluation = 264.34,//Undervalue ...
                          Beta=1,
                          SustainableCompetitiveAdvantage=7//5 of 9 

                        },
                       
                       StockOrders = new List<StockOrder>
                       {
                            new StockOrder{ StockSymbol="GOOGL" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                            new StockOrder{ StockSymbol="GOOGL" , AmounthOfMoney = 103.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Buy", ShareHolderID = 2 },
                            new StockOrder{ StockSymbol="GOOGL" , AmounthOfMoney = 103.56, Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), FillingStatus = "Requested", Opration = "Sell", ShareHolderID = 2 },
                            new StockOrder{ StockSymbol="GOOGL" , AmounthOfMoney = 23.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Requested", Opration = "Sell", ShareHolderID = 2 },
                            new StockOrder{ StockSymbol="GOOGL" , AmounthOfMoney = 43.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles = new ObservableCollection<PriceCandleModel>
                       {
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-8).ToString("MM-yyyy"), Value = 58 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 74 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 88 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 140 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 180 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 200 + random.Next(-5, 9) },
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 300 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 450 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(0).ToString("MM-yyyy"), Value = 500 + random.Next(-5, 9) }
                       },



                },
                new Company
                {
                    Symbol = "AAPL",
                    StockPrice = 232.20,
                    StockDetail = "Apple Inc. - Technology Company. Apple is a Technology and Consumer Electronics leader known for its flagship product, the iPhone."
                      ,
                        StockFundementalData = new Models.StockFundementalData
                        {
                          StockSymbol =  "AAPL",
                          TotalCash=65.171 ,//in Bilion USD
                          TotalDebts=308.030,

                          AnnualIncome=96.15,
                          Beta =1.19,
                          EPSpast5Y=0.14, //48.40%
                          EPSthisYr= 0.13,//128.05%
                          EPSnext5Y=0.15,
                          DCFvaluation = 165.43,//over ...

                          SustainableCompetitiveAdvantage=9//5 of 9 

                        },


                        StockOrders = new List<StockOrder>
                       {
                            new StockOrder{ StockSymbol="AAPL" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                            new StockOrder{ StockSymbol="AAPL" , AmounthOfMoney = 43.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles =  new ObservableCollection<PriceCandleModel>
                       {
                                 new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 100 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 450 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(0).ToString("MM-yyyy"), Value = 888 + random.Next(-5, 9) }
                       }


                },
                new Company
                {
                    Symbol = "MSFT",
                    StockPrice = 439.33,
                    StockDetail = "Microsoft Corporation - Technology Company. Microsoft is a leader in software, cloud computing, and productivity tools."

                      ,
                        StockFundementalData = new Models.StockFundementalData
                        {
                          StockSymbol =  "MSFT",
                          TotalCash=75.543 ,//in Bilion USD
                          TotalDebts=243.686,
                          AnnualIncome= 92.75,

                          EPSpast5Y=0.1840, //48.40%
                          EPSthisYr= 0.1382,//128.05%
                          EPSnext5Y=1.14,

                          DCFvaluation = 370.53,//Undervalue ...
                          	Beta  =  0.91,
                          SustainableCompetitiveAdvantage=9//5 of 9 

                        },


                        StockOrders = new List<StockOrder>
                       {
                            new StockOrder{ StockSymbol="MSFT" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                            new StockOrder{ StockSymbol="MSFT" , AmounthOfMoney = 43.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles =  new ObservableCollection<PriceCandleModel>
                       {
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 300 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 450 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 550 + random.Next(-5, 9) },
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 670 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 700 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(0).ToString("MM-yyyy"), Value = 888 + random.Next(-5, 9) }
                       }


                },
                new Company
                {
                    Symbol = "WMT",
                    StockPrice = 102.47,
                    StockDetail = "Walmart Inc. - Retail Company. Walmart operates retail stores worldwide and is a leader in consumer goods."
                   ,StockExchange = "NYSE"
                     ,
                        StockFundementalData = new Models.StockFundementalData
                        {
                          StockSymbol =  "WMT",
                          TotalCash=9.867 ,//in Bilion USD
                          TotalDebts=161.828,
                          AnnualIncome= 19.68,

                          EPSpast5Y=0.2049, //48.40%
                          EPSthisYr= 0.1216,//128.05%
                          EPSnext5Y=1.12,
                          DCFvaluation = 28.27,//Undervalue ...
                          Beta= 0.53,
                          SustainableCompetitiveAdvantage=1//5 of 9 

                        },


                        StockOrders = new List<StockOrder>
                       {
                            new StockOrder{ StockSymbol="WMT" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                            new StockOrder{ StockSymbol="WMT" , AmounthOfMoney = 43.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles =  new ObservableCollection<PriceCandleModel>
                       {
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 200 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 250 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 240 + random.Next(-5, 9) },
                       }


                },
                new Company
                {
                    Symbol = "TSLA",
                    StockPrice = 328.50,
                    StockDetail = "Tesla, Inc. - Automotive and Energy Company. Tesla is known for its electric vehicles and sustainable energy solutions."

                      ,
                        StockFundementalData = new Models.StockFundementalData
                        {
                          StockSymbol =  "TSLA",
                          //Financal Health
                          TotalCash=36.56 ,//in Bilion USD
                          TotalDebts=48.39,
                          //Porfitebility
                          AnnualIncome=7.13,

                          //GROWTH AND PRIDECTEBILITY >>>
                          EPSpast5Y=0.27, //48.40%
                          EPSthisYr= 0.21,//128.05%
                          EPSnext5Y=0.31,
                          //VALUE to Price
                          DCFvaluation = 54.94,//Undervalue ...
                          //Bussiness quality
                          SustainableCompetitiveAdvantage=3//5 of 9 ,

                          ,Beta=2.47 //How volitate is compare to market (1) 

                        },


                        StockOrders = new List<StockOrder>
                       {
                            new StockOrder{ StockSymbol="TSLA" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                            new StockOrder{ StockSymbol="TSLA" , AmounthOfMoney = 43.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles =  new ObservableCollection<PriceCandleModel>
                       {
                                   new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 200 + random.Next(-50, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 250 + random.Next(-50, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 240 + random.Next(-50, 9) },
                                      new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 200 + random.Next(-50, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 250 + random.Next(-50, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 340 + random.Next(-50, 9) },
                              new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 250 + random.Next(-50, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(0).ToString("MM-yyyy"), Value = 440 + random.Next(-50, 9) },
                       }


                },
                new Company
                {
                    Symbol = "META",
                    StockPrice = 607.75,
                    StockDetail = "Meta Platforms, Inc. - Technology Company. Meta is the parent company of Facebook and a leader in social media and virtual reality."

                      ,
                        StockFundementalData = new Models.StockFundementalData
                        {
                          StockSymbol =  "META",
                          TotalCash=77.815 ,//in Bilion USD 2024:77.815 //grom google finance...
                          TotalDebts=93.417,//93.417 //from google finance

                          AnnualIncome=62.36,//from Finviz or Google Finance or yahoo fin

                          EPSpast5Y=0.30, //30%//from Finviz
                          EPSthisYr= 1.1372, //from Finviz
                          EPSnext5Y=1.1147,//from Finviz

                          DCFvaluation = 746.06,//Undervalue ...// from Gruefocus or 

                          SustainableCompetitiveAdvantage=7//x of 9 
                          ,Beta= 1.22
                        },

                       StockOrders = new List<StockOrder>
                       {
                            new StockOrder{ StockSymbol="META" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                            new StockOrder{ StockSymbol="META" , AmounthOfMoney = 43.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles =  new ObservableCollection<PriceCandleModel>
                       {
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-15).ToString("MM-yyyy"), Value = 325.48 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-14).ToString("MM-yyyy"), Value = 351.61 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-13).ToString("MM-yyyy"), Value = 393.50 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-12).ToString("MM-yyyy"), Value = 492.15 +  random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-11).ToString("MM-yyyy"), Value = 487.74 + random.Next(-5, 9) },
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-10).ToString("MM-yyyy"), Value = 428.60 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-9).ToString("MM-yyyy"), Value = 470.86 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-8).ToString("MM-yyyy"), Value = 504.91 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 521.72 +  random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 519.64 + random.Next(-5, 9) },
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 577.98 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 567.61 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 577.50 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 589.72 +  random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 716.55 + random.Next(-5, 9) },
                       },

                },
                new Company
                {
                    Symbol = "ADBE",
                    StockPrice = 447.94,
                    StockDetail = "Adobe Inc. - Software Company. Adobe specializes in creative software tools such as Photoshop and Acrobat."

                      ,
                        StockFundementalData = new Models.StockFundementalData
                        {
                          StockSymbol =  "ADBE",
                          TotalCash=7.89 ,//in Bilion USD
                          TotalDebts=16.13,
                          AnnualIncome=5.56,

                          EPSpast5Y=0.1554, //48.40%
                          EPSthisYr= 0.1294,//12
                          EPSnext5Y=1.1181,

                          DCFvaluation = 575.63,//Undervalue ...

                          SustainableCompetitiveAdvantage=7//5 of 9 
                          ,Beta= 1.37
                        },

                        StockOrders = new List<StockOrder>
                       {
                            new StockOrder{ StockSymbol="ADBE" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                            new StockOrder{ StockSymbol="ADBE" , AmounthOfMoney = 43.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles =  new ObservableCollection<PriceCandleModel>
                       {
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 100 + random.Next(-8, 14) },
                          new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 200 + random.Next(-8, 14) },
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 300 + random.Next(-8, 14) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 500 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 800 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 1300 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 2100 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-0).ToString("MM-yyyy"), Value = 3400 + random.Next(-8, 10) },
                       }

                },
                new Company
                {
                    Symbol = "NVDA",
                    StockPrice = 140.22,
                    StockDetail = "NVIDIA Corporation - Technology Company. NVIDIA is a leader in GPU technology and artificial intelligence solutions."

                      ,
                        StockFundementalData = new Models.StockFundementalData
                        {
                          StockSymbol =  "NVDA",
                          TotalCash=25.984 ,//in Bilion USD
                          TotalDebts=22.750,
                          AnnualIncome=63.07,

                          EPSpast5Y=0.4840, //48.40%
                          EPSthisYr= 1.2805,//128.05%
                          EPSnext5Y=0.6118,

                          DCFvaluation = 157.21,//Undervalue ...

                          SustainableCompetitiveAdvantage=9//5 of 9 
                          ,Beta = 1.77
                        },


                        StockOrders = new List<StockOrder>
                       {
                            new StockOrder{ StockSymbol="NVDA" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                            new StockOrder{ StockSymbol="NVDA" , AmounthOfMoney = 43.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles =  new ObservableCollection<PriceCandleModel>
                       {
                                       new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 100 + random.Next(-8, 14) },
                          new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 200 + random.Next(-8, 14) },
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 300 + random.Next(-8, 140) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 500 + random.Next(-8, 100) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 800 + random.Next(-8, 100) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 1300 + random.Next(-8, 100) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 2100 + random.Next(-8, 100) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-0).ToString("MM-yyyy"), Value = 3400 + random.Next(-8, 100) },
                       }


                },
                new Company
                {
                    Symbol = "AMZN",
                    StockPrice = 229.05,
                    StockDetail = "Amazon.com, Inc. - Consumer Cyclical. Amazon is a global leader in e-commerce and cloud computing services."

                      ,
                        StockFundementalData = new Models.StockFundementalData
                        {
                          StockSymbol =  "AMZN",
                          TotalCash=104.73 ,//in Bilion USD
                          TotalDebts=338.92,
                          AnnualIncome=59.25,

                          EPSpast5Y=0.2078, //48.40%
                          EPSthisYr= 0.2038,//128.05%
                          EPSnext5Y=0.3638,
                          DCFvaluation = 230.64,//Undervalue ...

                          SustainableCompetitiveAdvantage=8//5 of 9 
                          ,Beta=1.18
                        },


                        StockOrders = new List<StockOrder>
                       {
                            new StockOrder{ StockSymbol="AMZN" , AmounthOfMoney = 123.56, Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), FillingStatus = "Filled", Opration = "Sell", ShareHolderID = 1 },
                            new StockOrder{ StockSymbol="AMZN" , AmounthOfMoney = 43.56, Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles =  new ObservableCollection<PriceCandleModel>
                       {
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 100 + random.Next(-8, 14) },
                                  new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 200 + random.Next(-8, 14) },
                                  new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 300 + random.Next(-8, 14) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 500 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 800 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 1300 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 2100 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-0).ToString("MM-yyyy"), Value = 3400 + random.Next(-8, 10) },
                       }


                }
            };

            CurrentCompany = IPOcompanies.First();

            //Loading Data Method...

            //    LoadDataFromLiteDB();

            CurrentLevelModel = SelectLevelViewModel.ImageCollection.FirstOrDefault();//TODO ... DELET ME 
            CurrentCompanyAsset = new AssetModel { AssetName = "GOOG P&L 31% @ $128.12", AssetType = AssetTypes.Stock.ToString(), StockCompanySymbol = "GOOGL", StockQuantity = 0, StockAverageBuyCost = 100.23, AssetValue = 200.00, IntrestRate = 0.25, IsBankDeposit = false, IsRecursiveDepositRD = false, PassiveIncome = 5.00, AssetModelID = 2 };

            //Saving Data... method...
            //  SaveDataToLiteDB();
            //  LoadDataFromLiteDB();

            var dal = new DataAccessService();
            // dal.SaveUISettings(UIsettingsModel);

            UIsettingsModel = dal.GetUISettings();

        }


        #region Save&LoadPlayerGameData:
        //void LoadDataFromLiteDB()//TODO: load needed to be fixed ... load have problem...
        //{
        //    var dbPath = Path.Combine(FileSystem.AppDataDirectory, "GameData.db");
        //    var localDb = new DataAccessService(dbPath);

        //    // UISettingsModel verisini yükleme
        //    //   UIsettingsModel = localDb.GetDataById<UIsettingsModel>(1, "UISettings");

        //    // Tüm seviyeleri yükleme
        //    SelectLevelViewModel = new SelectLevelViewModel();

        //    SelectLevelViewModel = new SelectLevelViewModel
        //    {
        //        ImageCollection = localDb.GetAllData<LevelModel>("Levels").ToList()
        //    };

        //}
        //void SaveDataToLiteDB()
        //{
        //    var dbPath = Path.Combine(FileSystem.AppDataDirectory, "GameData.db");
        //    var localDb = new DataAccessService(dbPath);
        //    localDb.SaveData(UIsettingsModel, "UISettings");

        //    // SelectLevelViewModel verisini kaydetme
        //    foreach (var level in SelectLevelViewModel.ImageCollection)
        //    {
        //        localDb.SaveData(level, "Levels");
        //    }

        //}
        #endregion

        #region Music Codes

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
               
                UIsettingsModel.IsMusicPlaying = IsMusicPlaying;
                var dal = new DataAccessService();
                dal.SaveUISettings(UIsettingsModel);
            }
            catch (Exception ex)
            {       
                await DisplayAlert("Error playing music:", ex.Message, "Fuck the music! Continue!!");
            }
         

        }

        #endregion
    }
}
