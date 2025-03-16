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
        /// <summary>
        /// CurrentLevelModel is Original Data of brand new game which is hard coded ,, Used Saved data will be applied on this on load ...
        /// this usefull for creating a new game ... not for load game...
        /// </summary>
        public LevelModel CurrentLevelModel { get; set; }
       
        public GameViewModel GameViewModel { get; set; }
        public Company CurrentCompany { get; set; }//For Stock Market...
        /// <summary>
        /// For stock market : CurrentCompanyAsset Contain Quantity of stock ,Avreage Purchesed Price and etc... example:StockCompanySymbol = "MSFT",StockQuantity = 1.1,StockAverageBuyCost =100.23, AssetValue = 200.00, 
        /// </summary>
        //public AssetModel CurrentCompanyAsset { get; set; }

        public ObservableCollection<Company> IPOcompanies { get; set; }
        public SelectLevelViewModel SelectLevelViewModel { get; set; }
        public UIsettingsModel UIsettingsModel { get; set; }

        public NewsPaperViewModel CurrentNewsPaperViewModel { get; set; }
      

        private bool isNavigatingBack = false; // Döngüyü önlemek için flag

        private async void Shell_Navigating(object sender, ShellNavigatingEventArgs e)
        {
            //if (e.Source == ShellNavigationSource.Pop) // Geri gitme işlemi mi?
            //{
            //    if (isNavigatingBack) return; // Eğer zaten geri gidiliyorsa, tekrar işlem yapma
            //    isNavigatingBack = true; // Flag'i aktif et

            //    e.Cancel(); // Varsayılan geri gitmeyi engelle

            //    bool shouldGoBack = await Application.Current.MainPage.DisplayAlert(
            //        "Going Back?", "Do you want to return to the last page?", "Yes", "No");
         
            //    if (shouldGoBack)
            //    {
            //        try
            //        {


            //        await MainThread.InvokeOnMainThreadAsync(async () =>
            //        {
            //           
            //        });
            //        }
            //        catch { }
            //    }

            //    await Task.Delay(5); // UI'nin tam güncellenmesi için küçük bir bekleme süresi ekle
            //    isNavigatingBack = false; // Flag'i sıfırla
            //}


        }


        public AppShell()
        {
            //Routing.RegisterRoute("mainpage", typeof(MainPage));
            //Routing.RegisterRoute("marketpage", typeof(MarketPage));
            //Routing.RegisterRoute("storymodeview", typeof(StoryModeView));
            //Routing.RegisterRoute("storydetailview", typeof(StoryDetailView));
            //Routing.RegisterRoute("gameview", typeof(GameView));
            //Routing.RegisterRoute("motherview", typeof(MotherView));

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
                LastPlayedLevelIndex = 2
            };
            try
            {
                var dal = new DataAccessService();
                var data= dal.GetUISettings();
                if(data!=null)
                UIsettingsModel = data;
            }
            catch { }


            SelectLevelViewModel = new SelectLevelViewModel
            {
                ImageCollection = new List<LevelModel>(),

            };
            //dammy data ...
            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                     StoryLevelID = "A",
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
                                                             new IncomeSourceModel { Name = "FD 5020.63 @4.12% Interest Rate | JP Morgan Bank" ,Amount =53.56  ,AssetIncomeSourseRelatingGUID = 2.ToString() } },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "FD 5020.63 @4.12% Interest Rate | JP Morgan Bank", AssetType = AssetTypes.FixedDeposit.ToString(), AssetValue = 1300.00, IntrestRate= 0.0412, IsBankDeposit= true, IsRecursiveDepositRD = false, PassiveIncome = 53.56, AssetModelID = 1 ,AssetIncomeSourseRelatingGUID = 2.ToString()},
                    new AssetModel {AssetName = "MSFT P&L 28%",  AssetType = AssetTypes.Stock.ToString(),StockCompanySymbol = "MSFT",StockQuantity = 1.1,StockAverageBuyCost =888.23, AssetValue = 976.7, IntrestRate= 0.25, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 5.00, AssetModelID = 2}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Ducati Bike Debt EMI", Amount = 300.00, ExpenseModelID = 1 ,RelatedLiabilityID = 1 },
                    new ExpenseModel{ Name = "Expensive Drone Debt EMI", Amount = 200.00, ExpenseModelID = 2  ,RelatedLiabilityID = 2},
                    new ExpenseModel{ Name = "Motorcycle Camping Gear Debt EMI", Amount = 100.00, ExpenseModelID = 3  ,RelatedLiabilityID = 3},
                    new ExpenseModel{ Name = "Minimum Surviving Expenses", Amount = 1072.33, ExpenseModelID = 4, RelatedLiabilityID = -1}
                }
            }},
                StoryLevelID = "A",
                Image = "software_engineer.png",
                Header = "The System Engineer's Breakthrough",
                DetailStory = "Erdem is a Principal System Engineer @ Huawei Tech. Ltd., receives a 100% salary hike and splurges on luxury items such as a brand-new Ducati bike!, an expensive drone, and motorcycle camping gear on EMI. Help him pay off his debts within a year.",
                isStarted = false,


                LearnedByWinMessage = "Mira Learned: A little of Something good is better than all of nothing.. if not have an investing plan and not start with small money. Small money will never become big money!",
                LearnedByLoseMessage = "Mira Learned: Never Never user Debt Or leverage on long term Investing (on trading is ok, never use more than 3% of entire capital on any trade as well) ",


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
                    new ExpenseModel{ Name = "Motorcycle Helmet Debt EMI", Amount = 100.00, ExpenseModelID = 3, RelatedLiabilityID = 3 }
                },
                  StoryLevelID = "2",
            }},
                StoryLevelID = "2",
                Image = "undraw_investing.png",
                Header = "Investing Adventure",


                LearnedByWinMessage = "Mira Learned: A little of Something good is better than all of nothing.. if not have an investing plan and not start with small money. Small money will never become big money!",
                LearnedByLoseMessage = "Mira Learned: Never Never user Debt Or leverage on long term Investing (on trading is ok, never use more than 3% of entire capital on any trade as well) ",


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
                MaximumMonth = 48,
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
                    new ExpenseModel{ Name = "Groceries", Amount = 150.00, ExpenseModelID = 3, RelatedLiabilityID = -1},
                    new ExpenseModel{ Name = "Transportation", Amount = 100.00, ExpenseModelID = 4 , RelatedLiabilityID = -1}
                },   StoryLevelID = "3",
            }},

                StoryLevelID = "3",
                Image = "exams.png",


                LearnedByWinMessage = "Mira Learned: A little of Something good is better than all of nothing.. if not have an investing plan and not start with small money. Small money will never become big money!",
                LearnedByLoseMessage = "Mira Learned: Never Never user Debt Or leverage on long term Investing (on trading is ok, never use more than 3% of entire capital on any trade as well) ",


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
                Balance = 31500.00,
                NetTotalIncome = 0,
                CurrentMonth = 1,
                MaximumMonth = 24,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="Credit Card Debt", TotalAmount = 6000.00, MonthsRemaining = 24, InterestRate = 0.03, LiabilityModelID = 1 , ExpenseModelID =1},
                    new LiabilityModel{LiabilityName="Payday Loan", TotalAmount=4000.00, MonthsRemaining = 12, InterestRate=0.15, LiabilityModelID = 2 , ExpenseModelID = 2}
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Teaching C# on Skype ", Amount = 375.00 },
                                                               new IncomeSourceModel { Name = "FD Retirement deposit", Amount = 25.00 , AssetIncomeSourseRelatingGUID = "947f4fae-0cff-4e61-a7cf-8706b76fd91d" }
                },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Retirement Fund", AssetType = AssetTypes.FixedDeposit.ToString(), AssetValue = 5000.00, IntrestRate= 0.06, IsBankDeposit= true, IsRecursiveDepositRD = false, PassiveIncome = 25.00, AssetModelID = 1 ,AssetIncomeSourseRelatingGUID ="947f4fae-0cff-4e61-a7cf-8706b76fd91d"}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Credit Card Minimum Payment", Amount = 200.00, ExpenseModelID = 1 , RelatedLiabilityID=1},
                    new ExpenseModel{ Name = "Payday Loan EMI", Amount = 500.00, ExpenseModelID = 2, RelatedLiabilityID = 2},

                    new ExpenseModel{ Name = "Rent", Amount = 600.00, ExpenseModelID = 3 , RelatedLiabilityID = -1},
                    new ExpenseModel{ Name = "Utilities and Food", Amount = 300.00, ExpenseModelID = 4 , RelatedLiabilityID = -1}
                }
                ,     StoryLevelID = "4",
            }},
                StoryLevelID = "4",
                Image = "interview.png",


                LearnedByWinMessage = "Mira Learned: A little of Something good is better than all of nothing.. if not have an investing plan and not start with small money. Small money will never become big money!",
                LearnedByLoseMessage = "Mira Learned: Never Never user Debt Or leverage on long term Investing (on trading is ok, never use more than 3% of entire capital on any trade as well) ",


                Header = "Survive to Get a Job!",
                DetailStory = "Alex just graduated with a master's degree as the top foreign student at his university. However, he still has two more years before his citizenship application is processed. Without a work permit, keeping his cash flow positive is a struggle, and most of the companies he interviews with don’t hire employees who require work permit sponsorship.\r\n\r\nDetermined to survive, he decides to borrow 30K from his sister until he secures a job from one of his interviews—giving himself a maximum of two years to pay it back. In the meantime, he realizes he must improve his money management skills, learning to differentiate between good debt and bad debt, and ensure he can repay both his debts and his sister’s 30K before time runs out.\r\n\r\nTo generate some income, Alex starts teaching C# on Skype, earning 375 per session. However, his cash flow is still negative, and he must carefully navigate his financial decisions to survive until he lands a stable job.💼",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = GameGoalTypes.Balance.ToString(), Target = 30000, YouHave = 31500 },
                                                             new StoryGoalModel { Goal = GameGoalTypes.Month.ToString(), Target = 24, YouHave = 1 },
                                                             new StoryGoalModel { Goal = GameGoalTypes.Liabilities.ToString(), Target = 0, YouHave = 2 }
                }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 5000.00, // Increased initial balance to reflect savings & early investment
                NetTotalIncome = 2800, // Adjusted for improved revenue from classes
                CurrentMonth = 1,
                MaximumMonth = 24,

                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName = "Startup Loan", TotalAmount = 12000.00, MonthsRemaining = 24, InterestRate = 0.08, LiabilityModelID = 1, ExpenseModelID = 1 },
                    new LiabilityModel{LiabilityName = "Equipment Lease", TotalAmount = 5000.00, MonthsRemaining = 12, InterestRate = 0.05, LiabilityModelID = 2, ExpenseModelID = 2 }
                },

                IncomeSources = new List<IncomeSourceModel>
                {
                    new IncomeSourceModel { Name = "Patient Treatment Fees", Amount = 1800.00 },
                    new IncomeSourceModel { Name = "Pilates Group Sessions", Amount = 700.00 },
                    new IncomeSourceModel { Name = "Savings Interest", Amount = 300.00, AssetIncomeSourseRelatingGUID = "2" }
                },

                Assets = new List<AssetModel>
                {
                    new AssetModel { AssetName = "Physiotherapy Equipment", AssetType = AssetTypes.Other.ToString(), AssetValue = 10000.00, IntrestRate = 0.02, IsBankDeposit = false, IsRecursiveDepositRD = false, PassiveIncome = 0, AssetModelID = 1 },
                    new AssetModel { AssetName = "Business Bank Account", AssetType = AssetTypes.FixedDeposit.ToString(), AssetValue = 5000.00, IntrestRate = 0.03, IsBankDeposit = true, IsRecursiveDepositRD = false, PassiveIncome = 300.00, AssetModelID = 2, AssetIncomeSourseRelatingGUID = "2" }
                },

                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel { Name = "Studio Rent", Amount = 1000.00, ExpenseModelID = 1, RelatedLiabilityID = -1 },
                    new ExpenseModel { Name = "Medical Equipment Leasing", Amount = 500.00, ExpenseModelID = 2, RelatedLiabilityID = 2 },
                    new ExpenseModel { Name = "Marketing & Advertising", Amount = 300.00, ExpenseModelID = 3, RelatedLiabilityID = -1 },
                    new ExpenseModel { Name = "Startup Loan EMI", Amount = 600.00, ExpenseModelID = 4, RelatedLiabilityID = 1 }
                },

                StoryLevelID = "5",
            }},

                        StoryLevelID = "5",
                Image = "pilates.png",
                Header = "Launching Your Dreams: Reformation",
                DetailStory = "Mira is a physiotherapist who suffered from a herniated disc while in university. Battling through her own recovery made her realize the power of Pilates techniques in physical therapy. Now, she is determined to open her Reformation Fizyopilates Studio, where she can train a skilled team and help patients in their rehabilitation journey.\r\n\r\nTo bring her vision to life, Mira has taken out a 10,000 startup loan, giving herself two years to build a successful business and become financially stable. She currently has 5,000 in savings, with a net income of 2,800 per month, but running the studio comes with significant expenses—including team salaries, rent, and loan repayments.\r\n\r\nMira must carefully manage her finances, balance business growth with sustainability, and ensure that she can eliminate her liabilities while achieving her dream of creating a thriving physiotherapy center. Can she successfully navigate the challenges of entrepreneurship, build a profitable studio, and make a lasting impact on her patients' lives?",
                LearnedByWinMessage = "Mira Learned: A little of Something good is better than all of nothing.. if not have an investing plan and not start with small money. Small money will never become big money!",
                LearnedByLoseMessage = "Mira Learned: Never Never user Debt Or leverage on long term Investing (on trading is ok, never use more than 3% of entire capital on any trade as well) ",


                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> 
                {  new StoryGoalModel { Goal = GameGoalTypes.Balance.ToString(), Target = 55000, YouHave = 5000 },
                   new StoryGoalModel { Goal = GameGoalTypes.Month.ToString(), Target = 24, YouHave = 1 },
                   new StoryGoalModel { Goal = GameGoalTypes.Liabilities.ToString(), Target = 0, YouHave = 2 },
               

                }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 5000.00, // Increased initial balance for better early-stage survival
                NetTotalIncome = 4500, // Increased to reflect higher earnings potential
                CurrentMonth = 1,
                MaximumMonth = 36,

                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName = "Shared Office Loan", TotalAmount = 15000.00, MonthsRemaining = 36, InterestRate = 0.08, LiabilityModelID = 1 ,ExpenseModelID = 1 },
                    new LiabilityModel{LiabilityName = "Initial Tech Investment", TotalAmount = 7000.00, MonthsRemaining = 24, InterestRate = 0.06, LiabilityModelID = 2 ,ExpenseModelID = 2 }
                },

                IncomeSources = new List<IncomeSourceModel>
                {
                    new IncomeSourceModel { Name = "Tech Subscription Revenue", Amount = 2500.00, AssetIncomeSourseRelatingGUID="1" },
                    new IncomeSourceModel { Name = "Consulting Services", Amount = 1200.00 },
                    new IncomeSourceModel { Name = "Freelance Graphic Design", Amount = 800.00 }
                },

                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Shared Office Equipment", AssetType = AssetTypes.Other.ToString(), AssetValue = 8000.00, IntrestRate= 0.00, IsBankDeposit= false, IsRecursiveDepositRD = false, PassiveIncome = 0.00, AssetModelID = 1 ,AssetIncomeSourseRelatingGUID = "1"},
                    new AssetModel {AssetName = "Company Bank Reserve", AssetType = AssetTypes.FixedDeposit.ToString(), AssetValue = 5000.00, IntrestRate= 0.02, IsBankDeposit= true, IsRecursiveDepositRD = false, PassiveIncome = 100.00, AssetModelID = 2}
                },

                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Office Loan EMI", Amount = 500.00, ExpenseModelID = 1, RelatedLiabilityID = 1},
                    new ExpenseModel{ Name = "Tech Investment Loan EMI", Amount = 400.00, ExpenseModelID = 2, RelatedLiabilityID = 2},
                    new ExpenseModel{ Name = "Team Resources", Amount = 1500.00, ExpenseModelID = 3, RelatedLiabilityID = -1},
                    new ExpenseModel{ Name = "Marketing & Outreach", Amount = 700.00, ExpenseModelID = 4, RelatedLiabilityID = -1},
                    new ExpenseModel{ Name = "Miscellaneous Expenses", Amount = 400.00, ExpenseModelID = 5 , RelatedLiabilityID = -1}
                },

                StoryLevelID = "6",
            }},
                StoryLevelID = "6",
                Image = "shared_goals.png",
                Header = "Shared Goals, Shared Dreams, Story of Atlassian",
                DetailStory = "Shared Goals, Shared Dreams\r\nIn the heart of San Francisco, four ambitious entrepreneurs—Alex, Jordan, Taylor, and Morgan—each harbored a vision to revolutionize their respective industries. However, the soaring costs of individual ventures and the competitive startup ecosystem posed significant challenges.\r\n\r\nAlex, a software developer, had conceptualized an innovative project management tool but lacked the funds to bring it to market. Jordan, a graphic designer, sought a professional space to collaborate with clients but was constrained by budget limitations. Taylor, a digital marketer, needed a conducive environment to conduct workshops and strategy sessions, while Morgan, a financial analyst, aimed to develop a fintech platform but faced financial hurdles.\r\n\r\nRecognizing their shared challenges, they decided to collaborate, pooling their resources to establish a shared workspace. This strategic move not only reduced individual expenses but also fostered a synergistic environment where creativity and innovation thrived.\r\n\r\nTo finance this endeavor, they collectively secured a 15,000 loan, agreeing to repay it over 36 months at an 8% interest rate. Their combined monthly income from various projects totaled 3,000, with recurring expenses including:\r\n\r\nOffice Loan EMI: 500\r\nTeam Resources: IPOcompaniesSfCarouselViewModel,000\r\nMiscellaneous Expenses: 300\r\nDespite these financial commitments, their collaborative approach led to increased client acquisition and revenue growth. By leveraging each other's strengths, they transformed their shared workspace into a hub of innovation, attracting attention from investors and industry leaders.\r\n\r\nTheir journey mirrors the experiences of entrepreneurs like Scott Farquhar and Mike Cannon-Brookes, who co-founded Atlassian by bootstrapping their startup with a 10,000 credit card debt. Through collaboration and strategic resource management, they built a multi-billion-dollar enterprise.\r\n\r\nYour Challenge: Step into the shoes of these entrepreneurs. Manage shared resources effectively, ensure timely loan repayments, and navigate the complexities of collaborative business operations. Can you lead the team to financial stability and collective success?\r\n\r\nGame Objectives:\r\n\r\nEliminate Liabilities: Repay the shared office loan within the agreed timeframe.\r\nAchieve Financial Stability: Increase the collective balance to secure future endeavors.\r\nFoster Collaboration: Encourage teamwork to unlock new income opportunities and reduce expenses.\r\nEmbark on this journey of shared goals and dreams, and experience firsthand the power of collaborative entrepreneurship.",
              
                LearnedByWinMessage = "Mira Learned: A little of Something good is better than all of nothing.. if not have an investing plan and not start with small money. Small money will never become big money!",
                LearnedByLoseMessage = "Mira Learned: Never Never user Debt Or leverage on long term Investing (on trading is ok, never use more than 3% of entire capital on any trade as well) ",
               
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> 
                {
                new StoryGoalModel { Goal = GameGoalTypes.Liabilities.ToString(), Target = 1, YouHave = 2 },
                new StoryGoalModel { Goal = GameGoalTypes.Balance.ToString(), Target = 8000, YouHave = 5000 },
                new StoryGoalModel { Goal = GameGoalTypes.Month.ToString(), Target = 36, YouHave = 1 }
                }
            });

            SelectLevelViewModel.ImageCollection.Add(new LevelModel
            {
                Players = new List<PlayerModel> { new PlayerModel{
                Balance = 75500.00,
                NetTotalIncome = 0,
                CurrentMonth = 1,
                MaximumMonth = 720,
                Liabilities = new List<LiabilityModel>
                {
                    new LiabilityModel{LiabilityName ="Credit Card Debt", TotalAmount = 600.00, MonthsRemaining = 24, InterestRate = 0.03, LiabilityModelID = 1 , ExpenseModelID =1},
                   
                },
                IncomeSources = new List<IncomeSourceModel>{ new IncomeSourceModel { Name = "Playing Sax on a Jazz Group", Amount = 675.00 },
                                                               new IncomeSourceModel { Name = "FD Retirement deposit", Amount = 25.00 , AssetIncomeSourseRelatingGUID = "947f4fae-0cff-4e61-a7cf-8706b76fd91d" }
                },
                Assets = new List<AssetModel>
                {
                    new AssetModel {AssetName = "Retirement Fund", AssetType = AssetTypes.FixedDeposit.ToString(), AssetValue = 5000.00, IntrestRate= 0.06, IsBankDeposit= true, IsRecursiveDepositRD = false, PassiveIncome = 25.00, AssetModelID = 1 ,AssetIncomeSourseRelatingGUID ="947f4fae-0cff-4e61-a7cf-8706b76fd91d"}
                },
                Expenses = new List<ExpenseModel>
                {
                    new ExpenseModel{ Name = "Credit Card Minimum Payment", Amount = 200.00, ExpenseModelID = 1 , RelatedLiabilityID=1},
                    

                    new ExpenseModel{ Name = "Painting tools", Amount = 300.00, ExpenseModelID = 3 , RelatedLiabilityID = -1},
                    new ExpenseModel{ Name = "Utilities and Food", Amount = 300.00, ExpenseModelID = 4 , RelatedLiabilityID = -1}
                }
                ,     StoryLevelID = "7",
            }},
                StoryLevelID = "7",
                Image = "fatihpaintssvg.png",
                Header = "Fatih's Dilemma!",

                LearnedByWinMessage = "Mira Learned: A little of Something good is better than all of nothing.. if not have an investing plan and not start with small money. Small money will never become big money!",
                LearnedByLoseMessage = "Mira Learned: Never Never user Debt Or leverage on long term Investing (on trading is ok, never use more than 3% of entire capital on any trade as well) ",

                DetailStory = "Fatih is 42 years old and has recently sold his business for 70K. He lives in his father’s small apartment, so he doesn’t have to pay rent. However, he has a deep passion for painting and spends a significant amount each month on painting tools and supplies.\r\n\r\nNow, he faces a critical financial challenge—he must manage his funds wisely to ensure they last for the next 60 years, covering all his expenses for the rest of his life. His ultimate goal is to grow his savings to 200K, which would allow him to generate 10K per year in passive income by investing in U.S. Treasury Bonds—widely considered the Risk-Free Rate of Return in finance.\r\n\r\nFatih must decide how to invest and allocate his capital. Should he:\r\n\r\nInvest a portion in great U.S. stocks, benefiting from long-term growth?\r\nHold part of his money in cash as insurance against market downturns?\r\nConvert his savings to Turkish Lira, earning a tempting 50% interest per year but exposing himself to 68% inflation and extreme risk?\r\nWhich path should he take to secure his future without running out of money too soon?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0,
                StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel { Goal = GameGoalTypes.Balance.ToString(), Target = 200000, YouHave = 75500 },
                                                             new StoryGoalModel { Goal = GameGoalTypes.Month.ToString(), Target = 720, YouHave = 1 },
                                                             new StoryGoalModel { Goal = GameGoalTypes.Liabilities.ToString(), Target = 0, YouHave = 2 }
                }
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
                            new StockOrder{ StockSymbol="GOOGL" , AmounthOfMoney = 23.56,  Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Requested", Opration = "Sell", ShareHolderID = 2 },
                            new StockOrder{ StockSymbol="GOOGL" , AmounthOfMoney = 43.56,  Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), FillingStatus = "Failed", Opration = "Buy", ShareHolderID = 1 }
                       },

                       PriceCandles = new ObservableCollection<PriceCandleModel>
                       {
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-8).ToString("MM-yyyy"), Value = Math.Abs( 58 + random.Next(-5, 9)*35) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = Math.Abs(  74 + random.Next(-5, 9)*35) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = Math.Abs( 88 + random.Next(-5, 9)*35 )},
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = Math.Abs( 140 + random.Next(-5, 9)*35 )},
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = Math.Abs( 180 + random.Next(-5, 9)*35 )},
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = Math.Abs(  165 + random.Next(-5, 9)*35 )},
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = Math.Abs( 178 + random.Next(-5, 9)*35 )},
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = Math.Abs( 190 + random.Next(-5, 9)*35 )},
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(0).ToString("MM-yyyy"), Value = Math.Abs( 202 + random.Next(-5, 9)*35 )}
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
                                 new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 187 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 200 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 241 + random.Next(-5, 9) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(0).ToString("MM-yyyy"), Value = 232 + random.Next(-5, 9) }
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
                          EPSnext5Y=0.14,

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
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 329 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 360 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 380 + random.Next(-5, 9) },
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 390 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 410 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(0).ToString("MM-yyyy"), Value = 439 + random.Next(-5, 9) }
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
                          EPSnext5Y=0.10,
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
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 77 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 87 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 91 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 100 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 99 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(0).ToString("MM-yyyy"), Value = 102 + random.Next(-5, 9) },
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
                                   new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 200 + random.Next(-15, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 250 + random.Next(-15, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 240 + random.Next(-15, 9) },
                                      new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 200 + random.Next(-15, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 250 + random.Next(-15, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 340 + random.Next(-15, 9) },
                              new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 250 + random.Next(-5, 9) },
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(0).ToString("MM-yyyy"), Value = 328 + random.Next(-15, 9) },
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
                          EPSthisYr= 0.1372, //from Finviz
                          EPSnext5Y=0.1147,//from Finviz

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
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 616.55 + random.Next(-5, 9) },
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
                          EPSnext5Y=0.1181,

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
                            new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 230 + random.Next(-8, 14) },
                          new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 240 + random.Next(-8, 14) },
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 300 + random.Next(-8, 14) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 360 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 390 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 420 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 400 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-0).ToString("MM-yyyy"), Value = 447 + random.Next(-8, 10) },
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
                                       new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-7).ToString("MM-yyyy"), Value = 60 + random.Next(-8, 14) },
                          new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-6).ToString("MM-yyyy"), Value = 85 + random.Next(-8, 14) },
                             new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 91 + random.Next(-8, 14) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 100 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 110 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 125 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 130 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-0).ToString("MM-yyyy"), Value = 140 + random.Next(-8, 10) },
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
                                  new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-5).ToString("MM-yyyy"), Value = 201.05 + random.Next(-8, 14) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-4).ToString("MM-yyyy"), Value = 211.05 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-3).ToString("MM-yyyy"), Value = 222.05 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-2).ToString("MM-yyyy"), Value = 225.65 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-1).ToString("MM-yyyy"), Value = 231.05 + random.Next(-8, 10) },
                                new PriceCandleModel { Date = DateTime.Now.Date.AddMonths(-0).ToString("MM-yyyy"), Value = 229.05 + random.Next(-8, 10) },
                       }


                }
            };

            CurrentCompany = IPOcompanies.First();

            //Loading Data Method...

            //    LoadDataFromLiteDB();

            CurrentLevelModel = SelectLevelViewModel.ImageCollection.FirstOrDefault();//TODO ... DELET ME 

            CurrentNewsPaperViewModel = new NewsPaperViewModel 
            {
                NewsPaperModels = new List<NewsPaperModel>
                {//...C16 means 16 charecter is max lenth of content... Cap means All capital ABCD ...small Mean abcd..
                   new NewsPaperModel
                   {
                        NewsPaperModelID = 1,
                        VolNo="VOL.10, NO.4",
                        EconomicDataC80 = ":U.S. INFLATION:2.7%▽ U.S.10-YR. TREAS. yield:4.232%△ S&P500(SPY)yr.+31.67%△",//Can Keep empty since SPY10yrRateUpdater will Generate it on set (note you need to fill them in order ( CPI and TBond first)

                        CPIrate=0.037,
                        TbondRate=0.05232,
                        SPY10yrRateUpdater=0.3567,

                        Date = DateTime.Now.ToString("dd/MM/yyyy"), //25/01/2025
                        MainHeaderLine1C16 ="RATRACE3 GAME IS",
                        MainHeaderLine2C16="GETTING POPULAR!",
                        MainSubHeaderC29Cap="MORE VC INVESTED VALUEHUNTER!",//MORE VC INVESTED VALUEHUNTER!
                        ImageSource = "mark_zakerberg_news_image.png",
                        ImageTitleC39  = "META'S CEO MARK ZUCKERBERG APOLOGIZED!!",
                        BodyOldEngStartingCharC1 = "B",
                        BodyMidPartC47 = "Born on September 25, 1944, in a small town, Eleanor grew up during",
                        BodyEndingPartC615="of great change. Known for her warmth, resilience, and generosity, she was a caring soul who always put her family first. In her twenties, she married Bartholomew Henderson, and together they raised three children, creating a home filled with love and laughter. Eleanor became a cornerstone of her community, volunteering and offering support to those in need. As a grandmother to five grandchildren, she passed on life lessons, cherished traditions, and endless love. As she turns 80, we joyfully celebrate her life’s journey, the impact she’s made, and the many memories yet to come. Happy 80th Birthday, Eleanor!",


                        DownTwoPartArticle = new DownTwoPartArticle
                        {
                            DownTwoPartArticleID=1,
                            Title2LineC33Cap = "WORLD'S BEST PIE RECIPE REVEALED!" ,
                            LeftBodyPart1C201="Discover Eleanor's legendary pie recipe, cherished for decades and passed down through generations. This culinary masterpiece offers a delightful blend of flavors and love, reflecting her baking skill.",
                            RightBodyPart2C206="Whether it’s for a holiday gathering or a family dinner, this pie never fails to bring joy and create lasting memories. Get ready to bake a pie that’s guaranteed to impress and become a cherished tradition!"
                        },
                        SmallLeftArticleTable = new DoubleArticleTable
                        {
                           DoubleArticleTableID=1,
                           HeaderC19Cap="THIS DAY IN HISTORY",
                           Part1SubHeaderC15="Fashion",
                           Part1BodyC90="The fashion world was adopting new styles that would define the decade in everyday clothing.",
                           Part2SubHeaderC15="Entertainment",
                           Part2BodyC60="The film “The Great Adventure” became a cinematic highlight."
                        },
                        RightTopArtilceTable = new TripleArticleTable
                        {
                            TripleArticleTableID=1,
                            HeaderC19Cap="FAMILY TRIBUTES",
                            Part1SubHeaderC15="From Aaron Loeb",
                            Part1BodyC129="“Mom, your strength and love have been the foundation of our family. I cherish every moment spent with you. Happy 80th birthday!”",
                            Part2SubHeaderC23="From Adeline Palmerston",
                            Part2BodyC129="“Eleanor, your kindness and wisdom have shaped my life in countless ways. Here’s to celebrating you today and always. Love you!”",
                            Part3SubHeaderC20="From Noah Schumacher",
                            part3BodyC120="“Happy 80th, Grandma! Your stories and laughter are the heart of our family. Wishing you a day as wonderful as you are!”"
                        },
                        RightDownArtilceTable = new TripleMiniArticleTable
                        {
                            TripleMiniArticleTableID=2,
                            HeaderC19Cap="FUN FACTS",
                            Part1SubHeaderC15="Favorite Hobby",
                            Part1BodyC90="Eleanor excels at knitting, having made over 100 cozy blankets and scarves for loved ones.",
                            Part2SubHeaderC15="Quirky Habit",
                            Part2BodyC91="Every morning, Eleanor savors tea with lemon and cinnamon, a ritual perfected over decades.",
                            Part3SubHeaderC15="Secret Talent",
                            part3BodyC81="Eleanor excels at gardening, cultivating stunning roses and winning local awards."


                        }



                   },
                   new NewsPaperModel
                   {
                           NewsPaperModelID = 2,
                           VolNo = "VOL.11, NO.1",
                           EconomicDataC80 = ":U.S. INFLATION:3.1%▽ U.S.10-YR. TREAS. yield:4.521%△ S&P500(SPY)yr.+15.45%△",
                           CPIrate = 0.031,
                           TbondRate = 0.04521,
                           SPY10yrRateUpdater = 0.1545,
                           Date = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy"),
                           MainHeaderLine1C16 = "TECH STOCKS SOAR",
                           MainHeaderLine2C16 = "AS AI TRENDS GROW",
                           MainSubHeaderC29Cap = "NVDA AND META LEAD THE PACK!",
                           ImageSource = "ceo_nvidia_holdingchip_news.png",
                           ImageTitleC39 = "NVIDIA AND META DRIVE AI REVOLUTION",
                           BodyOldEngStartingCharC1 = "A",
                           BodyMidPartC47 = "As the world embraces AI, companies like NVIDIA and Meta lead...",
                           BodyEndingPartC615 = "the charge. With groundbreaking innovations, both companies have shown exponential growth in revenue and market share. NVIDIA's advancements in GPU technology and Meta's leap in AI-driven tools have positioned them as industry leaders in the AI race.",
                           DownTwoPartArticle = new DownTwoPartArticle
                           {
                               DownTwoPartArticleID = 2,
                               Title2LineC33Cap = "NVDA GPU SALES SKYROCKET!",
                               LeftBodyPart1C201 = "NVIDIA has reported record-breaking sales, driven by the demand for GPUs in AI applications and gaming platforms. Their newest lineup of chips has been a game-changer in the tech world.",
                               RightBodyPart2C206 = "Experts predict sustained growth for NVIDIA in the coming years, as their innovations set new standards in AI performance and gaming experiences."
                           },
                           SmallLeftArticleTable = new DoubleArticleTable
                           {
                               DoubleArticleTableID = 2,
                               HeaderC19Cap = "MARKET HIGHLIGHTS",
                               Part1SubHeaderC15 = "Tesla Gains",
                               Part1BodyC90 = "Tesla's stock price increased by 12% this month due to strong EV demand.",
                               Part2SubHeaderC15 = "Apple Revenue",
                               Part2BodyC60 = "Apple sees a 5% growth in revenue, led by iPhone sales."
                           },
                           RightTopArtilceTable = new TripleArticleTable
                           {
                               TripleArticleTableID = 2,
                               HeaderC19Cap = "TOP AI COMPANIES",
                               Part1SubHeaderC15 = "NVIDIA Growth",
                               Part1BodyC129 = "NVIDIA's AI advancements boosted its market cap by $200 billion this year.",
                               Part2SubHeaderC23 = "Meta's New Tools",
                               Part2BodyC129 = "Meta launched AI-powered tools that improve social media interactions.",
                               Part3SubHeaderC20 = "Google AI Leap",
                               part3BodyC120 = "Google unveiled its AI search assistant, revolutionizing online searches."
                           },
                           RightDownArtilceTable = new TripleMiniArticleTable
                           {
                               TripleMiniArticleTableID = 3,
                               HeaderC19Cap = "QUICK BITES",
                               Part1SubHeaderC15 = "Amazon Expansion",
                               Part1BodyC90 = "Amazon expands to new markets, enhancing global e-commerce.",
                               Part2SubHeaderC15 = "Adobe AI Tools",
                               Part2BodyC91 = "Adobe's AI-driven design tools gain traction among creatives.",
                               Part3SubHeaderC15 = "Microsoft Cloud",
                               part3BodyC81 = "Microsoft sees strong growth in Azure cloud services this quarter."
                           }
                   },
                   new NewsPaperModel
                   {
                           NewsPaperModelID = 3,
                           VolNo = "VOL.11, NO.2",
                           EconomicDataC80 = ":U.S. INFLATION:2.9%▽ U.S.10-YR. TREAS. yield:4.432%△ S&P500(SPY)yr.+21.45%△",
                           CPIrate = 0.029,
                           TbondRate = 0.04432,
                           SPY10yrRateUpdater = 0.2145,
                           Date = DateTime.Now.AddDays(-60).ToString("dd/MM/yyyy"),
                           MainHeaderLine1C16 = "APPLE SHINES BRIGHT",
                           MainHeaderLine2C16 = "WITH NEW PRODUCT LINE",
                           MainSubHeaderC29Cap = "AAPL LEADS TECH INNOVATION!",
                           ImageSource = "apple_ceo_news.png",
                           ImageTitleC39 = "APPLE'S INNOVATIONS WIN HEARTS",
                           BodyOldEngStartingCharC1 = "I",
                           BodyMidPartC47 = "In its latest event, Apple unveiled groundbreaking products that...",
                           BodyEndingPartC615 = "redefine the tech landscape. From AR glasses to eco-friendly iPhones, Apple continues to set benchmarks in the tech industry. The company also reported significant revenue growth driven by strong product demand.",
                           DownTwoPartArticle = new DownTwoPartArticle
                           {
                               DownTwoPartArticleID = 3,
                               Title2LineC33Cap = "ECO-FRIENDLY TECH RISES!",
                               LeftBodyPart1C201 = "Apple's new iPhones, made from recycled materials, have gained widespread appreciation for their sustainability and design.",
                               RightBodyPart2C206 = "Other companies are following Apple's lead, aiming to create eco-friendly products that cater to the environmentally conscious consumer."
                           },
                           SmallLeftArticleTable = new DoubleArticleTable
                           {
                               DoubleArticleTableID = 3,
                               HeaderC19Cap = "TECH TRENDS",
                               Part1SubHeaderC15 = "AI Integration",
                               Part1BodyC90 = "AI is now integrated into nearly every new tech product launched this year.",
                               Part2SubHeaderC15 = "VR Growth",
                               Part2BodyC60 = "Virtual Reality gains traction in gaming and enterprise solutions."
                           },
                           RightTopArtilceTable = new TripleArticleTable
                           {
                               TripleArticleTableID = 3,
                               HeaderC19Cap = "CONSUMER FAVORITES",
                               Part1SubHeaderC15 = "Apple iPhones",
                               Part1BodyC129 = "Apple's latest models saw record pre-orders in the first week of release.",
                               Part2SubHeaderC23 = "Tesla Model 3",
                               Part2BodyC129 = "Tesla's Model 3 remains the best-selling EV globally.",
                               Part3SubHeaderC20 = "Amazon Prime",
                               part3BodyC120 = "Amazon Prime adds 50 million new users this year, setting a growth milestone."
                           },
                           RightDownArtilceTable = new TripleMiniArticleTable
                           {
                               TripleMiniArticleTableID = 4,
                               HeaderC19Cap = "GLOBAL UPDATES",
                               Part1SubHeaderC15 = "NVIDIA Milestone",
                               Part1BodyC90 = "NVIDIA's GPUs dominate the AI market, achieving record sales.",
                               Part2SubHeaderC15 = "Meta VR Launch",
                               Part2BodyC91 = "Meta's new VR headset brings cutting-edge experiences to users.",
                               Part3SubHeaderC15 = "Google Cloud",
                               part3BodyC81 = "Google Cloud becomes the top choice for enterprise solutions."
                           }
                   },
                   new NewsPaperModel
                   {
                           NewsPaperModelID = 4,
                           VolNo = "VOL.11, NO.3",
                           EconomicDataC80 = ":U.S. INFLATION:4.1%△ U.S.10-YR. TREAS. yield:5.123%△ S&P500(SPY)yr.-12.45%▽",
                           CPIrate = 0.041,
                           TbondRate = 0.05123,
                           SPY10yrRateUpdater = -0.1245,
                           Date = DateTime.Now.AddDays(-90).ToString("dd/MM/yyyy"),
                           MainHeaderLine1C16 = "META USERS DROP",
                           MainHeaderLine2C16 = "FOR THE FIRST TIME!",
                           MainSubHeaderC29Cap = "SOCIAL MEDIA CRISIS UNFOLDS!",
                           ImageSource = "meta_stock_fall.png",
                           ImageTitleC39 = "FACEBOOK SEES DAILY USERS DECLINE!",
                           BodyOldEngStartingCharC1 = "A",
                           BodyMidPartC47 = "Amid growing concerns over privacy and data misuse, Meta...",
                           BodyEndingPartC615 = "reported a significant decline in daily active users for the first time in 10 years. Experts speculate that users are migrating to newer platforms offering better data protection and innovative features.",
                           DownTwoPartArticle = new DownTwoPartArticle
                           {
                               DownTwoPartArticleID = 4,
                               Title2LineC33Cap = "META'S STOCK PLUMMETS!",
                               LeftBodyPart1C201 = "Following the release of their user data report, Meta saw its stock price drop by 15%, wiping $100 billion off its market cap. Analysts predict a tough road ahead as the company battles public distrust.",
                               RightBodyPart2C206 = "Investors are pushing for leadership changes and transparency reforms to restore confidence in the company's long-term vision."
                           },
                           SmallLeftArticleTable = new DoubleArticleTable
                           {
                               DoubleArticleTableID = 4,
                               HeaderC19Cap = "MARKET WATCH",
                               Part1SubHeaderC15 = "Tesla Recall",
                               Part1BodyC90 = "Tesla announced a recall of 50,000 vehicles due to a software glitch affecting autopilot.",
                               Part2SubHeaderC15 = "Crypto Crash",
                               Part2BodyC60 = "Bitcoin and Ethereum fell by 20% amid regulatory crackdowns."
                           },
                           RightTopArtilceTable = new TripleArticleTable
                           {
                               TripleArticleTableID = 4,
                               HeaderC19Cap = "MANIPULATION CLAIMS",
                               Part1SubHeaderC15 = "GOOGL Accused",
                               Part1BodyC129 = "Google faced accusations of manipulating search results to favor its own products, raising antitrust concerns.",
                               Part2SubHeaderC23 = "Amazon Pricing",
                               Part2BodyC129 = "Amazon was criticized for using algorithms to inflate prices on essential goods during peak demand.",
                               Part3SubHeaderC20 = "Apple Backlash",
                               part3BodyC120 = "Apple faced backlash for throttling older devices, leading to user lawsuits globally."
                           },
                           RightDownArtilceTable = new TripleMiniArticleTable
                           {
                               TripleMiniArticleTableID = 5,
                               HeaderC19Cap = "INSIDER INFO",
                               Part1SubHeaderC15 = "Insider Trading",
                               Part1BodyC90 = "Microsoft's execs under scrutiny for pre-announcement stock trades.",
                               Part2SubHeaderC15 = "CEO Resigns",
                               Part2BodyC91 = "Adobe's CEO steps down amid allegations of mismanagement.",
                               Part3SubHeaderC15 = "Fake Reviews",
                               part3BodyC81 = "Amazon battles fake product reviews to protect consumer trust."
                           }
                   },
                   new NewsPaperModel
                   {
                           NewsPaperModelID = 5,
                           VolNo = "VOL.12, NO.1",
                           EconomicDataC80 = ":U.S. INFLATION:3.8%▽ U.S.10-YR. TREAS. yield:4.876%△ S&P500(SPY)yr.+18.32%△",
                           CPIrate = 0.038,
                           TbondRate = 0.04876,
                           SPY10yrRateUpdater = 0.1832,
                           Date = DateTime.Now.AddDays(-120).ToString("dd/MM/yyyy"),
                           MainHeaderLine1C16 = "TESLA HITS TROUBLE",
                           MainHeaderLine2C16 = "WITH AUTOPILOT ISSUES!",
                           MainSubHeaderC29Cap = "GOVERNMENT INVESTIGATION LAUNCHED!",
                           ImageSource = "tesla_underfire_news.png",
                           ImageTitleC39 = "TESLA'S AUTOPILOT UNDER FIRE!",
                           BodyOldEngStartingCharC1 = "T",
                           BodyMidPartC47 = "Tesla's innovative autopilot system faces backlash after a...",
                           BodyEndingPartC615 = "series of high-profile accidents. Federal regulators have launched an investigation, and lawsuits from affected families are piling up. Analysts warn this could impact Tesla's reputation and sales in the short term.",
                           DownTwoPartArticle = new DownTwoPartArticle
                           {
                               DownTwoPartArticleID = 5,
                               Title2LineC33Cap = "EV COMPETITION RISES!",
                               LeftBodyPart1C201 = "As Tesla struggles with legal issues, rivals like Rivian and Lucid Motors are gaining market share, challenging Tesla's dominance in the EV market.",
                               RightBodyPart2C206 = "Consumer trust in Tesla's technology will be a deciding factor in whether the company can maintain its position as the market leader."
                           },
                           SmallLeftArticleTable = new DoubleArticleTable
                           {
                               DoubleArticleTableID = 5,
                               HeaderC19Cap = "STOCK NEWS",
                               Part1SubHeaderC15 = "Meta Recovery",
                               Part1BodyC90 = "Meta's stock shows signs of recovery after the recent user decline.",
                               Part2SubHeaderC15 = "Apple Growth",
                               Part2BodyC60 = "Apple reports higher-than-expected profits this quarter."
                           },
                           RightTopArtilceTable = new TripleArticleTable
                           {
                               TripleArticleTableID = 5,
                               HeaderC19Cap = "INVESTOR UPDATES",
                               Part1SubHeaderC15 = "MSFT Cloud Boom",
                               Part1BodyC129 = "Microsoft's Azure revenue grows by 25%, bolstering investor confidence.",
                               Part2SubHeaderC23 = "Amazon Expansion",
                               Part2BodyC129 = "Amazon continues to expand its global e-commerce reach, entering new markets.",
                               Part3SubHeaderC20 = "Netflix Ads",
                               part3BodyC120 = "Netflix introduces ad-supported tiers, aiming to attract cost-conscious viewers."
                           },
                           RightDownArtilceTable = new TripleMiniArticleTable
                           {
                               TripleMiniArticleTableID = 6,
                               HeaderC19Cap = "MARKET RISKS",
                               Part1SubHeaderC15 = "Rate Hikes",
                               Part1BodyC90 = "Fed rate hikes could impact tech valuations in the coming months.",
                               Part2SubHeaderC15 = "Supply Chain",
                               Part2BodyC91 = "Global supply chain disruptions threaten production timelines.",
                               Part3SubHeaderC15 = "Crypto Volatility",
                               part3BodyC81 = "Bitcoin's price sees wild swings, raising concerns among investors."
                           }
                   }
                }

            };
     

           

          
          
        }

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
