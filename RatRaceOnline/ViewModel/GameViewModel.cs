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

namespace RatRace3.ViewModel
{
    public class ListViewItemModel : INotifyPropertyChanged
    {
        private string itemText;
        private string itemValue;

        public string ItemText
        {
            get { return itemText; }
            set
            {
                itemText = value;
                OnPropertyChanged("ItemText");
            }
        }

        public string ItemValue
        {
            get { return itemValue; }
            set
            {
                itemValue = value;
                OnPropertyChanged("ItemValue");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
    public class GameViewModel : INotifyPropertyChanged
    {

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
            set { totalIncome = value;
                OnPropertyChanged();
            }
        }
        private string totalExpense;

        public string TotalExpense
        {
            get { return totalExpense; }
            set { totalExpense = value;
                OnPropertyChanged();
            }
        }

        private string totalCashFlow;

        public string TotalCashFlow
        {
            get { return totalCashFlow; }
            set { totalCashFlow = value;
                OnPropertyChanged();
            }
        }

        private string totalDebt;

        public string TotalDebt
        {
            get { return totalDebt; }
            set { totalDebt = value;
                OnPropertyChanged();
            }
        }

        private string netWorth;

        public string NetWorth
        {
            get { return netWorth; }
            set { netWorth = value;
                OnPropertyChanged();
            }
        }

        private string currentMonth;

        public string CurrentMonth
        {
            get { return currentMonth; }
            set { currentMonth = value;
                OnPropertyChanged();
            }
        }

        private string currentBalance;

        public string CurrentBalance
        {
            get { return currentBalance; }
            set { currentBalance = value;
                OnPropertyChanged();
            }
        }

        private string bankAccountValue;

        public string TotalBankAccountValue
        {
            get { return bankAccountValue; }
            set { bankAccountValue = value;
                OnPropertyChanged();
            }
        }

        private string currentBankDepositAmount;

        public string CurrentBankDepositAmount
        {
            get { return currentBankDepositAmount; }
            set {

                currentBankDepositAmount = value;

                OnPropertyChanged();
            }
        }


        private double bankDepositMaxLimit;
        public double BankDepositMaxLimit
        {
            get { return bankDepositMaxLimit; }
            set { bankDepositMaxLimit = value;
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

        private bool IsIncomeCollected
        {
            get { return isIncomeCollected; }
            set { isIncomeCollected = value;
                IncomeButtonEnable = !value;
            }
        }
        private bool incomeButtonEnable;

        public bool IncomeButtonEnable
        {
            get { return incomeButtonEnable; }
            set { incomeButtonEnable = value;
                OnPropertyChanged();
            }
        }




        CultureInfo USD_Formant = CultureInfo.CreateSpecificCulture("en-US"); // for forcing $1,234.56 Money format 

        double totalExpences ;

        double totalIncomeSum ;
        double totalDebtSum;
        double totalNetworth;
        double totalCashFlowSum;
        public void LoadPlayerData(Models.PlayerModel playerModel)
        {
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

            IsIncomeCollected = false;

            ////Use Player Model Instead of Hard Coded VIEWMODEL DATA.... 

            CurrentBankDepositAmount = (0).ToString("C2",USD_Formant);
            double balance = playerModel.Balance;
            CurrentBalance = (balance).ToString("C2", USD_Formant);
         

            BankDepositMaxLimit = Math.Round(balance, 2); // update ever time balance change... TODO ::: maybe in setter ... 

            double magnitude = Math.Pow(10, Math.Floor(Math.Log10(balance)) - 1); // Get the magnitude (e.g., 100 for 2054)
            BankDepositInterval = Math.Round(magnitude);
       
            
            CurrentMonth = (playerModel.CurrentMonth + " / " + playerModel.MaximumMonth).ToString();

            //IncomeListViewItemModel = new ObservableCollection<ListViewItemModel>();
          
            foreach (var income in playerModel.IncomeSources)
            {
                totalIncomeSum += income.Amount;
                IncomeListViewItemModel.Add(new ListViewItemModel() { ItemText = income.Name, ItemValue = (income.Amount).ToString("C2", USD_Formant) });
            }

            // for each ile tum itemleri topla ve incomeLisview ekle...
            TotalIncome = (totalIncomeSum).ToString("C2", USD_Formant);
            Player.NetTotalIncome = totalIncomeSum;
          //  ExpencesListViewItemModels = new ObservableCollection<ListViewItemModel>();
           
            foreach(var expences in playerModel.Expenses)
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

                if (asset.IsBankDeposit == true ||asset.AssetType.ToString().Equals(AssetTypes.FixedDeposit) || asset.AssetType.ToString().Equals(AssetTypes.Bond) || asset.AssetType.ToString().Equals(AssetTypes.RecursiveDeposit))
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

           


        }
        void updateTotalCashFlow()
        {
            totalCashFlowSum = totalIncomeSum - totalExpences;
            TotalCashFlow = (totalCashFlowSum).ToString("C2", USD_Formant);
            Player.NetTotalIncome = totalCashFlowSum;
        }

        /// <summary>
        /// game Brock when calling this line so i removed the future
        /// </summary>
        void updatePlayeBlanceAsAssetObject()
        {
            var toRemove = Player.Assets.Find(x => x.AssetName.Equals("Cash Balance"));
            if (toRemove != null)
                Player.Assets.Remove(toRemove);
            Player.Assets.Add(new AssetModel { AssetName = "Cash Balance", AssetValue = Player.Balance });

           // AssetsListViewItemModel.First(x => x.ItemText.Equals("Cash Balance")).ItemValue = Player.Balance.ToString(); //shity brocking line...

         
        }

        private  void CollectIncome()
        {
            var USD_Formant = CultureInfo.CreateSpecificCulture("en-US"); // for forcing $1,234.56 Money format 
                                                                          // Logic for collecting income
                                                                          //  CurrentBalance += TotalIncome; //TODO : first chage it to Double and than to string ....
            //double.TryParse(TotalIncome.Substring(1).ToString(), out double TIncome);
            //double.TryParse(CurrentBalance.Skip(1).ToString(), out double TBalance);
            if(Player!=null && IsIncomeCollected == false)
            {
                Player.Balance += (Player.NetTotalIncome);
                IsIncomeCollected = true;
                CurrentBalance = Player.Balance.ToString("C2", USD_Formant);

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

        void updateStatmentsdataFromPlayerObject()
        {
            //up
           
            LoadPlayerData(Player);

        }

      

        private async void PayDebt(double amount)
        {
          //  await Shell.Current.DisplayAlert("Debt", "Debt Payment Successful.", "OK");

            if (SelectedLiability != null && SelectedLiability.RemainingAmount>0 && amount > 0 && Player.Balance>0 && amount<= Player.Balance)
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

            if(SelectedLiability!=null && SelectedLiability.RemainingAmount<=0.009)
            {
                //Debt payment Complated...
               
                DebtListViewItemModel.Remove(DebtListViewItemModel.First(x => x.ItemText.Equals(SelectedLiability.LiabilityName)));
              //  var appShell = (AppShell)Shell.Current;
               
                var RelatedExpenceOnject = Player.Expenses.First(x=>x.RelatedLiabilityID.Equals(SelectedLiability.LiabilityModelID) || x.ExpenseModelID.Equals(SelectedLiability.ExpenseModelID));
                if (RelatedExpenceOnject != null)
                {  //Delete Expences related to that liability if there is any ....
                    var item = ExpencesListViewItemModels.First(x => x.ItemText.Equals(RelatedExpenceOnject.Name));

                   ExpencesListViewItemModels.Remove(item);
                   Player.Expenses.Remove(RelatedExpenceOnject);

                }
                Player.Liabilities.Remove(SelectedLiability);


                IsPopupOpen = false;
                await Shell.Current.DisplayAlert(SelectedLiability.LiabilityName.ToString(), "Debt Payments successful!!", "Cool");
            }

            //     LoadPlayerData(Player);// for updating Gui from data 
            updateStatmentsdataFromPlayerObject();
        }

        void NextTurn()
        {
            if (Player != null) 
            {         
    
                if(Player.CurrentMonth < Player.MaximumMonth)
                { 
                        if (isIncomeCollected == false)
                        {
                            CollectIncome();
                        }
                
                        //NEW TURN :...
                   //Pass one month... Update Debts , assets ,income, expences... moves... 
                   Player.CurrentMonth++;
                   CurrentMonth = (Player.CurrentMonth + " / " + Player.MaximumMonth).ToString();

                   IsIncomeCollected = false;//for new turn...

                    //Checking Game Goals:
                    reCalcluteGameGoals();

                }
                else //finishing mounth... Checking game goals...
                {
                    LastMonthCame(); // maybe don't need ...
                }
           }
        }

        async void LastMonthCame()
        {
            //Check if game finishing ...
          
            await Shell.Current.DisplayAlert("Game Over", "Month is " + Player.CurrentMonth + ". Unfortunately, Fund Manager! You couldn’t achieve all the goals needed to win!", "Not Again!");
         
            await Shell.Current.GoToAsync("StoryDetailView");

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
                if (LevelGoal.Goal== GameGoalTypes.Balance.ToString())
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
                await Shell.Current.GoToAsync("StoryDetailView");
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
        public GameViewModel()
        {
          //  MarkerValueChangedCommand = new Command<ValueChangedEventArgs>(OnMarkerValueChanged);
            ChangeCardIndexCommand = new Command<int>(index => VisibleIndex = index);
            CollectIncomeCommand = new Command(CollectIncome);
            NextTurnCommand = new Command(NextTurn);
            PayDebtCommand = new Command<double>(PayDebt);
            //delete me ....
            //TODO: get correct object  from AppSell Or in ctor... and replace null...:
            CashFlowListViewItemModel = new ObservableCollection<ListViewItemModel>();
            BankAssetsListViewItemModel = new ObservableCollection<ListViewItemModel>();
            AssetsListViewItemModel = new ObservableCollection<ListViewItemModel>();
            DebtListViewItemModel = new ObservableCollection<ListViewItemModel>();
            ExpencesListViewItemModels = new ObservableCollection<ListViewItemModel>();
            IncomeListViewItemModel = new ObservableCollection<ListViewItemModel>();









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
