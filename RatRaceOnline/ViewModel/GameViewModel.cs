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

        private bool isIncomeNotCollected;

        public bool IsIncomeNotCollected
        {
            get { return isIncomeNotCollected; }
            set { isIncomeNotCollected = value;
                OnPropertyChanged();
            }
        }




        public void LoadPlayerData(Models.PlayerModel playerModel)
        {
             var USD_Formant = CultureInfo.CreateSpecificCulture("en-US"); // for forcing $1,234.56 Money format 

            ////Use Player Model Instead of Hard Coded VIEWMODEL DATA.... 

            CurrentBankDepositAmount = (0).ToString("C2",USD_Formant);
            double balance = 2054.782;
            CurrentBalance = (balance).ToString("C2", USD_Formant);
         
            BankDepositMaxLimit = Math.Round(balance, 2);

            double magnitude = Math.Pow(10, Math.Floor(Math.Log10(balance)) - 1); // Get the magnitude (e.g., 100 for 2054)
            BankDepositInterval = Math.Round(magnitude);
       
            
            CurrentMonth = (1 + " / " + 36).ToString();

            IncomeListViewItemModel = new ObservableCollection<ListViewItemModel>();
            IncomeListViewItemModel.Add(new ListViewItemModel() { ItemText = "Salary", ItemValue = (3500.0).ToString("C2", USD_Formant) });
            // for each ile tum itemleri topla ve incomeLisview ekle...
            TotalIncome = (3500.0).ToString("C2", USD_Formant);

            ExpencesListViewItemModels = new ObservableCollection<ListViewItemModel>();
            ExpencesListViewItemModels.Add(new ListViewItemModel() { ItemText = "Motorcycle Camping gear Debt EMI", ItemValue = (325.0).ToString("C2" , USD_Formant) });
            ExpencesListViewItemModels.Add(new ListViewItemModel() { ItemText = "Expensive Drone Debt EMI", ItemValue = (216.67).ToString("C2", USD_Formant) });
            ExpencesListViewItemModels.Add(new ListViewItemModel() { ItemText = "Ducati Bike Debt EMI", ItemValue = (108.333).ToString("C2", USD_Formant) });

            TotalExpense = (600.211).ToString("C2", USD_Formant);

            DebtListViewItemModel = new ObservableCollection<ListViewItemModel>();
            DebtListViewItemModel.Add(new ListViewItemModel() { ItemText = "Motorcycle Camping gear Debt", ItemValue = (4000.12).ToString("C2", USD_Formant) });
            DebtListViewItemModel.Add(new ListViewItemModel() { ItemText = "Expensive Drone Debt", ItemValue = (3000.67).ToString("C2", USD_Formant) });
            DebtListViewItemModel.Add(new ListViewItemModel() { ItemText = "Ducati Bike Debt", ItemValue = (1080.333).ToString("C2", USD_Formant) });

            TotalDebt = (3500.0).ToString("C2", USD_Formant);

            AssetsListViewItemModel = new ObservableCollection<ListViewItemModel>();
            AssetsListViewItemModel.Add(new ListViewItemModel() { ItemText = "FD $5020.63 @4.12% Intrest Rate | JP Morgen Bank", ItemValue = (5020.63).ToString("C2", USD_Formant) });
            AssetsListViewItemModel.Add(new ListViewItemModel() { ItemText = "10.12 * GOOGL @ $125.51 Open P&L: +265.21 +25.36%", ItemValue = (1265.233).ToString("C2", USD_Formant) });

            NetWorth = (5500.0 - 1300).ToString("C2", USD_Formant);

            CashFlowListViewItemModel = new ObservableCollection<ListViewItemModel>();  
            cashFlowListViewItemModel.Add(new ListViewItemModel() { ItemText = "Free cash flow per month", ItemValue = (100.63).ToString("C2", USD_Formant) });


            TotalCashFlow = (100.63).ToString("C2", USD_Formant);

            //Bank assets : FX RD BOND MUTUAL >...
            BankAssetsListViewItemModel = new ObservableCollection<ListViewItemModel>();
            //Note: Bank asset is Player Assets.find(x=>x.IsBankAsset).ToList()...// LIKE RD FD MF BOND ... 
            BankAssetsListViewItemModel.Add(new ListViewItemModel() { ItemText = "FD $0.21 @4.12% Intrest Rate | JP Morgen Bank", ItemValue = (0.21).ToString("C2", USD_Formant) });
            
            //note total is sum of all bank asset items list
            TotalBankAccountValue = (0.210).ToString("C2", USD_Formant);

           
        }

        private  void CollectIncome()
        {
            var USD_Formant = CultureInfo.CreateSpecificCulture("en-US"); // for forcing $1,234.56 Money format 
                                                                          // Logic for collecting income
                                                                          //  CurrentBalance += TotalIncome; //TODO : first chage it to Double and than to string ....
            //double.TryParse(TotalIncome.Substring(1).ToString(), out double TIncome);
            //double.TryParse(CurrentBalance.Skip(1).ToString(), out double TBalance);
            CurrentBalance = (2000+1000).ToString("C2", USD_Formant);

          //  IsIncomeNotCollected = false;
            //   TotalIncome = "0"; // Reset total income after collection
        }




        private PlayerModel _currentLevelPlayer;
        public PlayerModel CurrentLevelPlayer
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
        public ICommand CollectIncomeCommand { get; }
        public ICommand ChangeCardIndexCommand { get; }
       // public ICommand MarkerValueChangedCommand { get; }
        public GameViewModel()
        {
          //  MarkerValueChangedCommand = new Command<ValueChangedEventArgs>(OnMarkerValueChanged);
            ChangeCardIndexCommand = new Command<int>(index => VisibleIndex = index);
            CollectIncomeCommand = new Command(CollectIncome);
            //delete me ....
            //TODO: get correct object  from AppSell Or in ctor... and replace null...:
            LoadPlayerData(null);


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
