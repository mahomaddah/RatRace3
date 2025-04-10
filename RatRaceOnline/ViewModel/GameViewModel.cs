using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RatRace3.Models;
using System.Collections.ObjectModel;
using System.Globalization;
using Microsoft.Maui.Controls.Platform;
using System.Reflection.PortableExecutable;
using RatRace3.ViewModels;
using RatRace3.DAL;
using Syncfusion.Maui.Graphics.Internals;
using System.Runtime.ExceptionServices;
using RatRace3.DAL.DbModels;

namespace RatRace3.ViewModel
{
  
    public class GameViewModel : INotifyPropertyChanged
    {
        #region GameViewModelProperties:
       
        private ObservableCollection<ListViewItemModel> incomeListViewItemModel;

        public ObservableCollection<ListViewItemModel> IncomeListViewItemModel
        {
            get { return incomeListViewItemModel; }
            set { this.incomeListViewItemModel = value; }
        }
        private ObservableCollection<ListViewItemModel> expencesListViewItemModels;

        public ObservableCollection<ListViewItemModel> ExpencesListViewItemModels
        {
            get { return expencesListViewItemModels; }
            set { this.expencesListViewItemModels = value; }
        }

        private ObservableCollection<ListViewItemModel> assetsListViewItemModel;

        public ObservableCollection<ListViewItemModel> AssetsListViewItemModel
        {
            get { return assetsListViewItemModel; }
            set { this.assetsListViewItemModel = value; }
        }

        private ObservableCollection<ListViewItemModel> debtListViewItemModel;

        public ObservableCollection<ListViewItemModel> DebtListViewItemModel
        {
            get { return debtListViewItemModel; }
            set { this.debtListViewItemModel = value; }
        }

        private ObservableCollection<ListViewItemModel> cashFlowListViewItemModel;

        public ObservableCollection<ListViewItemModel> CashFlowListViewItemModel
        {
            get { return cashFlowListViewItemModel; }
            set { this.cashFlowListViewItemModel = value; }
        }

        private ObservableCollection<ListViewItemModel> bankAssetsListViewItemModel;

        public ObservableCollection<ListViewItemModel> BankAssetsListViewItemModel
        {
            get { return bankAssetsListViewItemModel; }
            set { this.bankAssetsListViewItemModel = value; }
        }


        private string totalIncome;

        public string TotalIncome
        {
            get { return totalIncome; }
            set
            {
                totalIncome = value;
                OnPropertyChanged();
            }
        }
        private string totalExpense;

        public string TotalExpense
        {
            get { return totalExpense; }
            set
            {
                totalExpense = value;
                OnPropertyChanged();
            }
        }

        private string totalCashFlow;

        public string TotalCashFlow
        {
            get { return totalCashFlow; }
            set
            {
                totalCashFlow = value;
                OnPropertyChanged();
            }
        }

        private string totalDebt;

        public string TotalDebt
        {
            get { return totalDebt; }
            set
            {
                totalDebt = value;
                OnPropertyChanged();
            }
        }

        private string netWorth;

        public string NetWorth
        {
            get { return netWorth; }
            set
            {
                netWorth = value;
                OnPropertyChanged();
            }
        }

        private string currentMonth;

        public string CurrentMonth
        {
            get { return currentMonth; }
            set
            {
                currentMonth = value;
                OnPropertyChanged();
            }
        }

        private string currentBalance;

        public string CurrentBalance
        {
            get { return currentBalance; }
            set
            {
                currentBalance = value;
                OnPropertyChanged();
            }
        }

        private string bankAccountValue;

        public string TotalBankAccountValue
        {
            get { return bankAccountValue; }
            set
            {
                bankAccountValue = value;
                OnPropertyChanged();
            }
        }

        private string currentBankDepositAmount;

        public string CurrentBankDepositAmount
        {
            get { return currentBankDepositAmount; }
            set
            {

                currentBankDepositAmount = value;

                OnPropertyChanged();
            }
        }


        private double bankDepositMaxLimit;
        public double BankDepositMaxLimit
        {
            get { return bankDepositMaxLimit; }
            set
            {
                bankDepositMaxLimit = value;
                OnPropertyChanged();
            }
        }



        private double bankDepositInterval;
        public double BankDepositInterval
        {
            get { return bankDepositInterval; }
            set
            {
                bankDepositInterval = value;
                OnPropertyChanged();
            }
        }

        private bool isIncomeCollected;

        public bool IsIncomeCollected
        {
            get { return isIncomeCollected; }
            set
            {
                isIncomeCollected = value;
                IncomeButtonEnable = !value;
            }
        }
        private bool incomeButtonEnable;

        public bool IncomeButtonEnable
        {
            get { return incomeButtonEnable; }
            set
            {
                incomeButtonEnable = value;
                OnPropertyChanged();
            }
        }
        #endregion

       // public NewsPaperViewModel CurrentNewsPaperViewModel { get; set; }

        private NewsPaperViewModel currentNewsPaperViewModel;
            
        public NewsPaperViewModel CurrentNewsPaperViewModel
        {
            get { return currentNewsPaperViewModel; }
            set {
                currentNewsPaperViewModel = value;
                OnPropertyChanged();
            }
        }


        public MarketViewModel Market { get; set; }
        public AssetModel GetMarketCurrentStocksAsset()
        {
            return Player.Assets.First(x => x.StockCompanySymbol.Equals(Market.SelectedCompany.Symbol));
        } 

        CultureInfo USD_Formant = CultureInfo.CreateSpecificCulture("en-US"); // for forcing $1,234.56 Money format 

        double totalExpences;
        double totalIncomeSum;
        double totalDebtSum;
        double totalNetworth;
        double totalCashFlowSum;
        Random rand = new Random();
        public async void SavePlayerData(PlayerModel playerModel)
        {
            DataAccessService dal = new DataAccessService();
            dal.SavePlayerData(playerModel,playerModel.StoryLevelID);
            dal.SaveCompaniesData(Market.IPOCompanies.ToList(), playerModel.StoryLevelID);
            dal.SaveNewsPapersData(CurrentNewsPaperViewModel.NewsPaperModels, playerModel.StoryLevelID);
        }

     

        public async void LoadPlayerData(Models.PlayerModel playerModel)
        {
        

            //We can change For MVP news payper to Quaterlly (mevsimde 1 (3 ayda 1 )) ... instead of monthly !...
            //  CurrentNewsPaperViewModel = new NewsPaperViewModel{};
           

        //    int newsPayperRandomseed = random.Next(0, 4);
            //Selecting The News payper for this turn...
       //     var appShell = (AppShell)Shell.Current;
            //CurrentNewsPaperViewModel.CurrentNewsPaperModel = appShell.GameViewModel.CurrentNewsPaperViewModel.NewsPaperModels[newsPayperRandomseed];// [0-4] of 4 index

            //   CurrentNewsPaperViewModel.CurrentNewsPaperModel.ImageSource = CurrentNewsPaperViewModel.NewsPaperModels{ }
            // BringRandomNewsPaper();//TODO : NOT WORKING Well ... 

            //   CurrentNewsPaperViewModel.CurrentNewsPaperModel.EconomicDataSetterC80(0.037 , 0.04232 , 0.3167); //for 2.7% CPI , 4.232% Tbond, 31.67% SPY.Yr.
            //Expecting Result :  ":U.S. INFLATION:2.7%▽ U.S.10-YR. TREAS. yield:4.232%△ S&amp;P500(SPY)yr.+31.67%△",


            CashFlowListViewItemModel.Clear();
            IncomeListViewItemModel.Clear();
            ExpencesListViewItemModels.Clear();
            DebtListViewItemModel.Clear();
            AssetsListViewItemModel.Clear();
            BankAssetsListViewItemModel.Clear();

            totalCashFlowSum = 0;
            totalExpences = 0;

            totalIncomeSum = 0;
            totalDebtSum = 0;
            totalNetworth = 0;
            Player = playerModel;


            ////Use Player Model Instead of Hard Coded VIEWMODEL DATA.... 

            CurrentBankDepositAmount = (0).ToString("C2", USD_Formant);//Set to 0 again on every update...
            double balance = playerModel.Balance;
            CurrentBalance = (balance).ToString("C2", USD_Formant);


            BankDepositMaxLimit = Math.Round(balance, 2); // update every time balance change... TODO ::: maybe in setter ... 

            double magnitude = Math.Pow(10, Math.Floor(Math.Log10(balance)) - 1); // Get the magnitude (e.g., 100 for 2054)
            BankDepositInterval = Math.Round(magnitude);


            CurrentMonth = (playerModel.CurrentMonth + " / " + playerModel.MaximumMonth).ToString();

            //IncomeListViewItemModel = new ObservableCollection<ListViewItemModel>();

            foreach (var income in playerModel.IncomeSources)
            {
                if (income.MonthPeriodOfPayment == 1)
                {

                    totalIncomeSum += income.Amount;
                    IncomeListViewItemModel.Add(new ListViewItemModel() { ItemText = income.Name, ItemValue = (income.Amount).ToString("C2", USD_Formant) });
                }
                else
                {
                    AssetModel IncomeRelatedAsset = playerModel.Assets.FirstOrDefault(t => t.AssetIncomeSourseRelatingGUID == income.AssetIncomeSourseRelatingGUID);
                    if(IncomeRelatedAsset!=null)
                    {
                        if ((playerModel.CurrentMonth - IncomeRelatedAsset.AssetOwnedMonth ) % income.MonthPeriodOfPayment==0) // 6 e bolune bilen aylardan birndeysek.... yani bon odeme aylarindan birindeysek.....
                        {
                            totalIncomeSum += income.Amount;
                            IncomeListViewItemModel.Add(new ListViewItemModel() { ItemText = income.Name, ItemValue = (income.Amount).ToString("C2", USD_Formant) });
                        }
                    }
                }
            }

            // for each ile tum itemleri topla ve incomeLisview ekle...
            TotalIncome = (totalIncomeSum).ToString("C2", USD_Formant);
            Player.NetTotalIncome = totalIncomeSum;
            //  ExpencesListViewItemModels = new ObservableCollection<ListViewItemModel>();

            foreach (var expences in playerModel.Expenses)
            {
                totalExpences += expences.Amount;
                ExpencesListViewItemModels.Add(new ListViewItemModel() { ItemText = expences.Name, ItemValue = (expences.Amount).ToString("C2", USD_Formant) });

            }

            TotalExpense = (totalExpences).ToString("C2", USD_Formant);

            //  DebtListViewItemModel = new ObservableCollection<ListViewItemModel>();

            foreach (var debt in playerModel.Liabilities)
            {
                totalDebtSum += debt.TotalAmount;
                DebtListViewItemModel.Add(new ListViewItemModel() { ItemText = debt.LiabilityName, ItemValue = (debt.TotalAmount).ToString("C2", USD_Formant) });
            }

            TotalDebt = (totalDebtSum).ToString("C2", USD_Formant);

            // AssetsListViewItemModel = new ObservableCollection<ListViewItemModel>();


            double bankAccounttotalValue = 0;

            //Bank assets : FX RD BOND MUTUAL >...
            // BankAssetsListViewItemModel = new ObservableCollection<ListViewItemModel>();
            //Note: Bank asset is Player Assets.find(x=>x.IsBankAsset).ToList()...// LIKE RD FD MF BOND ... 

            //adding user Total cash Blance as user's asset : 
            //updatePlayeBlanceAsAssetObject();


            foreach (var asset in playerModel.Assets)
            {
                totalNetworth += asset.AssetValue;
                AssetsListViewItemModel.Add(new ListViewItemModel() { ItemText = asset.AssetName, ItemValue = (asset.AssetValue).ToString("C2", USD_Formant) });

                if (asset.IsBankDeposit == true || asset.AssetType.ToString().Equals(AssetTypes.FixedDeposit) || asset.AssetType.ToString().Equals(AssetTypes.Bond) || asset.AssetType.ToString().Equals(AssetTypes.RecursiveDeposit))
                {
                    bankAccounttotalValue += asset.AssetValue;
                    BankAssetsListViewItemModel.Add(new ListViewItemModel() { ItemText = asset.AssetName, ItemValue = (asset.AssetValue).ToString("C2", USD_Formant) });

                }

            }
            totalNetworth -= totalDebtSum;

            //note total is sum of all bank asset items list
            TotalBankAccountValue = (bankAccounttotalValue).ToString("C2", USD_Formant);


            NetWorth = (totalNetworth).ToString("C2", USD_Formant);

            //   CashFlowListViewItemModel = new ObservableCollection<ListViewItemModel>();
            //  totalCashFlowSum = totalIncomeSum - totalExpences;// - deprications and amorthisman of assets in the future updates ... :)
            //oprational cash flow , investin and financing cash flow can be added in the futures...
            updateTotalCashFlow();

            cashFlowListViewItemModel.Add(new ListViewItemModel() { ItemText = "Free Cash Flow of month", ItemValue = (totalCashFlowSum).ToString("C2", USD_Formant) });


            //TotalCashFlow = (totalCashFlowSum).ToString("C2", USD_Formant);
            //Player.NetTotalIncome = totalCashFlowSum;

            reCalcluteGameGoals();


        }
        void updateTotalCashFlow()
        {
            totalCashFlowSum = totalIncomeSum - totalExpences;
            TotalCashFlow = (totalCashFlowSum).ToString("C2", USD_Formant);
            Player.NetTotalIncome = totalCashFlowSum;
        }


        private void CollectIncome()
        {
            var USD_Formant = CultureInfo.CreateSpecificCulture("en-US"); // for forcing $1,234.56 Money format 
                                                                          // Logic for collecting income
                                                                          //  CurrentBalance += TotalIncome; //TODO : first chage it to Double and than to string ....
                                                                          //double.TryParse(TotalIncome.Substring(1).ToString(), out double TIncome);
                                                                          //double.TryParse(CurrentBalance.Skip(1).ToString(), out double TBalance);
            if (Player != null && IsIncomeCollected == false)
            {
                Player.Balance += (Player.NetTotalIncome);
                IsIncomeCollected = true;
                CurrentBalance = Player.Balance.ToString("C2", USD_Formant);
                //also if there any debts EMI ( Expance related to debts ) reduce the amounth of Expance model from related debt.RemaingAmounth  object 

                foreach (var debt in Player.Liabilities) // 
                {
                    var relatedExpanceObject = Player.Expenses.Find(x => x.ExpenseModelID.Equals(debt.ExpenseModelID));
                    if (relatedExpanceObject != null)
                    {
                      if(  debt.RemainingAmount >= relatedExpanceObject.Amount)
                      {
                            debt.RemainingAmount -= relatedExpanceObject.Amount;//paid one more EMI 
                      }
                      else
                      {
                            //Above lines breaking the game but latter debug after MVP : feature ... auto remove non_early paid debts... 
                            //Para ustunu ver ozmn
                            // Player.Balance += (relatedExpanceObject.Amount- debt.RemainingAmount); //ve 
                            // Gerekebilir //
                            try
                            {
                                SelectedLiability = debt; // if above goes to null ... 
                                                          //Gerekirse Call
                              //  PayDebt(debt.RemainingAmount); // for removing the debt object automaticlly //breaking when working ..
                            }
                            catch { }
                      }

                    }
                }
            }
            //  IsIncomeCollected = false;
            //  TotalIncome = "0"; // Reset total income after collection
        }

        // Popup Visibility
        private bool _isPopupOpen;
        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set
            {
                _isPopupOpen = value;
                OnPropertyChanged();
                //Call UpdateSelectDebtDetailValueSlider.MaxLimit...
                OnPropertyChanged(nameof(SelectedLiability.MaximumPayable));
                SelectedPayAmount = SelectedLiability.MaximumPayable;
            }
        }




        // Selected Liability
        private LiabilityModel _selectedLiability;
        public LiabilityModel SelectedLiability
        {
            get => _selectedLiability;
            set
            {
                _selectedLiability = value;
                OnPropertyChanged();
            }
        }

        // Amount to Pay
        private double _selectedPayAmount;
        public double SelectedPayAmount
        {
            get => _selectedPayAmount;
            set
            {
                _selectedPayAmount = value;
                OnPropertyChanged();


            }
        }

        Random random = new Random();
    
        void AddNewCandleToStocks()
        {
            var appshell = ((AppShell)Shell.Current);
            var Player = appshell.GameViewModel.Player;

            foreach (var company in appshell.IPOcompanies)
            {
                company.StockLastCandlePrice = company.StockPrice;

                //Profitability , Growth ,dcfValuetion , FinancalStrenght , Momentom ... Price Factors...
                int maxSnP500Effect = Convert.ToInt32(company.StockPrice * (+0.1)); //0.1 for 10% S&P 500 effect ...
                int minSnP500Effect = Convert.ToInt32(company.StockPrice * (-0.1));
                double voletility = company.StockFundementalData.Beta * random.Next(minSnP500Effect,maxSnP500Effect);//Tesla Beta and month tested with real data...
                double valueInvestorsEfect = company.StockPrice/9;// /12 vardi eski dan daha cok yukselen bir sey yaptik ...
                if (company.StockFundementalData.DCFvaluation > company.StockPrice)
                {
                    // UnderValue...

                    var fundementalComboHit = company.StockFundementalData.SustainableCompetitiveAdvantage*random.Next(1, 9); //1.1% ve 1.81% arasinda bir rastgele bir growth olur ...  1 ve 81 arasinda bir sayi cikar 

                    valueInvestorsEfect *= (1+ fundementalComboHit);
                    voletility += valueInvestorsEfect;
                }
                else
                {
                    var bolunen = 1;
                    if(company.StockFundementalData.SustainableCompetitiveAdvantage!=0)
                    {
                        bolunen = company.StockFundementalData.SustainableCompetitiveAdvantage;
                    }   

                    var zararlisayi =  random.Next(1, 9)/ bolunen; //1% ve 1.81% arasinda bir rastgele bir growth olur ... 

                    //overValue...
                    valueInvestorsEfect *= (1 + zararlisayi);
                    voletility -= valueInvestorsEfect;
                }

                double price = Math.Abs(Math.Round(
                    (company.StockPrice * (1 + (company.StockFundementalData.EPSnext5Y / 12))) + voletility
                    , 2));

                var newMonthCandle = new PriceCandleModel { Date = (DateTime.Now.AddMonths(Player.CurrentMonth-1).Date.ToString("MM-yyyy")), Value = price };//u can use also company.StockFundementalData.DCFvaluation for value investors and a part for news.. 
                company.PriceCandles.Add( newMonthCandle);
                company.StockPrice = newMonthCandle.Value;

                
                var existingStock = Player.Assets.FirstOrDefault(a => a.StockCompanySymbol == company.Symbol);

                if (existingStock != null && existingStock.StockQuantity > 0)
                {
                    //Update... 
                     existingStock.AssetValue = company.StockPrice * existingStock.StockQuantity;
                     //update gamview.listofAssets...
                }
                //test if this code helps gui to update or delete it if not ...
                Market.SelectedCompany = (company);
           
               
            }
            //try saving company...
            //   DAL.DataAccessService dataAccessService = new DAL.DataAccessService();
            //  dataAccessService.SaveCompaniesData(Market.IPOCompanies.ToList(),Player.StoryLevelID);




        }


        private async void PayDebt(double amount)
        {
            //  await Shell.Current.DisplayAlert("Debt", "Debt Payment Successful.", "OK");

            if (SelectedLiability != null && SelectedLiability.RemainingAmount > 0 && amount > 0 && Player.Balance > 0 && amount <= Player.Balance)
            {
                SelectedLiability.RemainingAmount -= amount;
                Player.Balance -= amount;
                var balance = Player.Balance;
                CurrentBalance = (balance).ToString("C2", USD_Formant);
                // Update remaining months dynamically
                SelectedLiability.MonthsRemaining = (int)Math.Ceiling(SelectedLiability.RemainingAmount / SelectedLiability.Emi);

                try
                {//bu kisim calismiyor cokuyor bir sekilde ...

                    double newTotalDebts = Convert.ToDouble(TotalDebt.Substring(1)); //get total debt value ...
                                                                                     // Close Popup
                    newTotalDebts -= amount;
                    IsPopupOpen = false;
                    TotalDebt = (newTotalDebts.ToString("C2", USD_Formant));
                }
                catch
                {

                }


                //   Networth
                // Notify changes
                OnPropertyChanged(nameof(SelectedLiability));
                DebtListViewItemModel.First(x => x.ItemText.Contains(SelectedLiability.LiabilityName)).ItemValue = SelectedLiability.RemainingAmountFormatted;

            }

            if (SelectedLiability != null && SelectedLiability.RemainingAmount <= 0.009)
            {
                //Debt payment Complated...
                try
                {

              
                //  var appShell = (AppShell)Shell.Current;

                var RelatedExpenceOnject = Player.Expenses.First(x => x.RelatedLiabilityID.Equals(SelectedLiability.LiabilityModelID) );
                if (RelatedExpenceOnject != null)
                {  //Delete Expences related to that liability if there is any ....
                    var item = ExpencesListViewItemModels.First(x => x.ItemText.Equals(RelatedExpenceOnject.Name));

                    ExpencesListViewItemModels.Remove(item);
                    Player.Expenses.Remove(RelatedExpenceOnject);

                }
                    var debtItem = DebtListViewItemModel.FirstOrDefault(x => x.ItemText.ToLower().Contains(SelectedLiability.LiabilityName.ToLower()));
                    if (debtItem != null) DebtListViewItemModel.Remove(debtItem);
                 //DebtListViewItemModel.Remove(DebtListViewItemModel.First(x => x.ItemText.Contains(SelectedLiability.LiabilityName)));
                 
                 Player.Liabilities.Remove(SelectedLiability);


                IsPopupOpen = false;
                await Shell.Current.DisplayAlert(SelectedLiability.LiabilityName.ToString(), "Debt Payments successful!!", "Cool");


                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Issue Paying Debt:"+ex.Message, ex.StackTrace, "Ok");
                }

            }

            LoadPlayerData(Player);
        }

        async void NextTurn()
        {
            if (Player != null)
            {

                if (Player.CurrentMonth < Player.MaximumMonth)
                {
                    if (isIncomeCollected == false)
                    {
                        CollectIncome();
                    }

                    //NEW TURN :...
                    //Pass one month... Update Debts , assets ,income, expences... moves... 
                    Player.CurrentMonth++;
                    CurrentMonth = (Player.CurrentMonth + " / " + Player.MaximumMonth).ToString();

                    //Bring Random NewsPaper: //TODO.. improvemnts...
                     BringRandomNewsPaper();
                  
                


                    IsIncomeCollected = false;//for new turn...
                    updateRDassetsValue();
                    AddNewCandleToStocks();
                    CheckIfBondMaturityRecher();

                    //Checking Game Goals:
                    reCalcluteGameGoals();

                    //Auto-Saving Game : 
                    SavePlayerData(Player);

                }
                else //finishing mounth... Checking game goals...
                {
                    reCalcluteGameGoals();
                    LastMonthCame(); // maybe don't need ...
                }
            }
        }

        private void CheckIfBondMaturityRecher()
        {
            if(Player.Assets.Any(x => x.IsBankDeposit && x.AssetType.ToString().Equals(AssetTypes.Bond.ToString())))
            {
                foreach (var bond in Player.Assets.FindAll(x => x.IsBankDeposit && x.AssetType.ToString().Equals(AssetTypes.Bond.ToString())))
                {
                    if (bond.BondMonthLeftToMaturity > 1)
                    {
                        //Every month... 
                        bond.BondMonthLeftToMaturity--;
                    }
                    else if (bond.BondMonthLeftToMaturity == 1)
                    {//nothing left // On month matured..
                        //Withdraw it ...
                        Player.Balance += bond.AssetValue;
                        Player.Assets.Remove(bond);

                    }
                    
                }
            }

        }

        void updateRDassetsValue()
        {
            //Recursive Deposit settings: 
            //1:Find all Recursive Deposit Asset and growth each by i'ts Defult Interest DONE...
            //2:find Each related Expance by RDrelatedAssetGUID and sum expance value to the Asset... DONE
            //3:if asset.Age was 12 mounth widraw the asset to balance and delete the realated expances..
            foreach(var recursiveAsset in Player.Assets.FindAll(x=>x.IsRecursiveDepositRD && x.IsBankDeposit))
            {
                recursiveAsset.GrowthBy(recursiveAsset.IntrestRate);
                var expance =Player.Expenses.Find(y => y.RDrelatedAssetGUID == recursiveAsset.AssetRelatedExpanceGUID);
                if(expance!=null)
                recursiveAsset.AssetValue += expance.Amount;

                if(recursiveAsset.AssetOwnedMonth + 12 <= Player.CurrentMonth)
                {
                    //Withdraw it ...
                     Player.Balance+= recursiveAsset.AssetValue;
                     Player.Expenses.Remove(expance);
                     Player.Assets.Remove(recursiveAsset);
                }
            }
            LoadPlayerData(Player);//for updating GUI...
            // Expence Should be deleleted after 12 month !!! OK
            // Expence amount should be added to the Asset every month !... OK
            // How should we calclute Quaterly ? yearly ? monthly ? or what ?!... for now Mounthly ... OK..

        }

         
        void BringRandomNewsPaper()
        {
            int seed = rand.Next(0, 4);

            CurrentNewsPaperViewModel.CurrentNewsPaperModel = CurrentNewsPaperViewModel.NewsPaperModels[seed];
           // OnPropertyChanged(nameof(CurrentNewsPaperViewModel.CurrentNewsPaperModel));
        }

        async void LastMonthCame()
        {
            var appShell = (AppShell)Shell.Current;
            //Check if game finishing ...
       


            await Shell.Current.DisplayAlert("Game Over", "Month is " + Player.CurrentMonth + ". Unfortunately, Fund Manager! You couldn’t achieve all the goals needed to win!", "Not Again!");

            string randomQuote = ValueInvestorQuotes.GetRandomQuote();

            await Shell.Current.DisplayAlert("\"" + randomQuote + "\"", appShell.CurrentLevelModel.LearnedByLoseMessage,
          
           "Our greatest glory is not in never falling, but in rising every time we fall!");

            //   await Shell.Current.GoToAsync("StoryDetailView");
            //    await Shell.Current.GoToAsync("/storydetailview");

            ((MotherView)(appShell).CurrentPage).Show("storydetailview");


        }
        async void reCalcluteGameGoals()
        {
            //Calcluting goals...
            var appShell = (AppShell)Shell.Current;
            //if Goal met win ...
            bool isAllGoalsMet = true;
            foreach (StoryGoalModel LevelGoal in appShell.CurrentLevelModel.StoryGoalModels)
            {
                //if(goal.Goal.Contains(GameGoalTypes.) // for goal type ...
                //1# check and update you haves to new values...
                if (LevelGoal.Goal == GameGoalTypes.Balance.ToString())
                {//>=
                    LevelGoal.YouHave = Player.Balance;
                }
                else if (LevelGoal.Goal == GameGoalTypes.RealEstate.ToString())
                {//>=
                    LevelGoal.YouHave = Player.RealStateS.Count;
                }
                else if (LevelGoal.Goal == GameGoalTypes.Cashflow.ToString())
                {//>=
                    LevelGoal.YouHave = Player.NetTotalIncome;
                }
                else if (LevelGoal.Goal == GameGoalTypes.Month.ToString())
                {//>=
                    LevelGoal.YouHave = Player.CurrentMonth;
                }
                else if (LevelGoal.Goal == GameGoalTypes.Liabilities.ToString())
                {//<=
                    LevelGoal.YouHave = Player.Liabilities.Count;
                }

                //update the appShell.CurrentLevelModel.StoryGoalModels; 

                //check if he Met all goal ... or not and change IsAllGoalMet....


                if (LevelGoal.Goal == GameGoalTypes.Liabilities.ToString() && LevelGoal.YouHave > LevelGoal.Target)//bad things..
                {
                    isAllGoalsMet = false;
                }
                else if (LevelGoal.YouHave < LevelGoal.Target) //good things..
                {
                    //if even one gaol is not met means still finish game button false...
                    isAllGoalsMet = false;
                }

            }

            //finishing game ....

            if (isAllGoalsMet)
            {
                //game won...
                appShell.CurrentLevelModel.IsGameFinishable = true;
                try
                {
                    await Shell.Current.DisplayAlert("Let's Review Your Victory!",
                    "\"Before we celebrate, let's check how you played this level! We'll review your achievements, see how well you performed!\"",
                    "Show My Progress!");
                    //    await Shell.Current.GoToAsync("StoryDetailView");
                    //  await Shell.Current.GoToAsync("/storydetailview");


                    string randomQuote = ValueInvestorQuotes.GetRandomQuote();
                    // appShell.CurrentLevelModel.LearnedByWinMessage;
                    await Shell.Current.DisplayAlert("\"" + randomQuote + "\"", appShell.CurrentLevelModel.LearnedByWinMessage,
                 
                   "$$$");

                    ((MotherView)(appShell).CurrentPage).Show("storydetailview");

                }
                catch { }
            }
        }

        private PlayerModel _currentLevelPlayer;
        public PlayerModel Player
        {
            get => _currentLevelPlayer;
            set
            {
                if (_currentLevelPlayer != value)
                {
                    _currentLevelPlayer = value;
                    OnPropertyChanged(); // Notify binding system of property change
                   
                }
            }
        }
        public ICommand PayDebtCommand { get; }
        public ICommand NextTurnCommand { get; }
        public ICommand CollectIncomeCommand { get; }
        public ICommand ChangeCardIndexCommand { get; }
        // public ICommand MarkerValueChangedCommand { get; }

        public IPOcompaniesRotatorViewModel IpoCompaniesVM { get; set; }
        public IPOcompaniesSfCarouselViewModel IPOcompaniesSfCarouselViewModel { get; set; }
        public GameViewModel()
        {
            //  MarkerValueChangedCommand = new Command<ValueChangedEventArgs>(OnMarkerValueChanged);
            ChangeCardIndexCommand = new Command<int>(index => VisibleIndex = index);
            CollectIncomeCommand = new Command(CollectIncome);
            NextTurnCommand = new Command(NextTurn);
            PayDebtCommand = new Command<double>(PayDebt);
         //   BuyStockCommand = new Command(BuyStock);
           // SellStockCommand = new Command(SellStock);
            //delete me ....
            //TODO: get correct object  from AppSell Or in ctor... and replace null...:
            CashFlowListViewItemModel = new ObservableCollection<ListViewItemModel>();
            BankAssetsListViewItemModel = new ObservableCollection<ListViewItemModel>();
            AssetsListViewItemModel = new ObservableCollection<ListViewItemModel>();
            DebtListViewItemModel = new ObservableCollection<ListViewItemModel>();
            ExpencesListViewItemModels = new ObservableCollection<ListViewItemModel>();
            IncomeListViewItemModel = new ObservableCollection<ListViewItemModel>();

           // IPOCompanies = new ObservableCollection<Company> { };
            //ChartData = new ObservableCollection<PriceCandleModel> { };
            if(Market==null)
            Market = new MarketViewModel();

            var appShell = (AppShell)Shell.Current;
            if(appShell != null)
            {
                if (CurrentNewsPaperViewModel == null)
                {
                CurrentNewsPaperViewModel = new NewsPaperViewModel();
                CurrentNewsPaperViewModel.NewsPaperModels = appShell.CurrentNewsPaperViewModel.NewsPaperModels;
                }
                // currentNewsPayperSeed = random.Next(0, 4);
                if (CurrentNewsPaperViewModel.CurrentNewsPaperModel==null)
                CurrentNewsPaperViewModel.CurrentNewsPaperModel = CurrentNewsPaperViewModel.NewsPaperModels[random.Next(0, 4)];
                //TODO : Code duplication with BringRandomNewsPaper() replace and reuse same function ... in top ...
                // OnPropertyChanged(nameof(CurrentNewsPaperViewModel.CurrentNewsPaperModel));

                if (IpoCompaniesVM == null)
                {
                    IpoCompaniesVM = new IPOcompaniesRotatorViewModel();
                }

                if (IPOcompaniesSfCarouselViewModel == null)
                    IPOcompaniesSfCarouselViewModel = new IPOcompaniesSfCarouselViewModel();
            }

            // CurrentNewsPaperViewModel.CurrentNewsPaperModel
        }

        private int _visibleIndex;
        public int VisibleIndex
        {
            get => _visibleIndex;
            set
            {
                if (_visibleIndex != value)
                {
                    _visibleIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
