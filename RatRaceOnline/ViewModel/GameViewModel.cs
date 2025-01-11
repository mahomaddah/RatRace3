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




        public void GenerateStatementData(Models.PlayerModel playerModel)
        {

            ////Use Player Model Instead of Hard Coded VIEWMODEL DATA.... 

            IncomeListViewItemModel = new ObservableCollection<ListViewItemModel>();
            IncomeListViewItemModel.Add(new ListViewItemModel() { ItemText = "Salary", ItemValue = (3500.0).ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) });
            // for each ile tum itemleri topla ve incomeLisview ekle...
            TotalIncome = (3500.0).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

            ExpencesListViewItemModels = new ObservableCollection<ListViewItemModel>();
            ExpencesListViewItemModels.Add(new ListViewItemModel() { ItemText = "Motorcycle Camping gear Debt EMI", ItemValue = (325.0).ToString("C2" , CultureInfo.CreateSpecificCulture("en-US")) });
            ExpencesListViewItemModels.Add(new ListViewItemModel() { ItemText = "Expensive Drone Debt EMI", ItemValue = (216.67).ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) });
            ExpencesListViewItemModels.Add(new ListViewItemModel() { ItemText = "Ducati Bike Debt EMI", ItemValue = (108.333).ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) });

            TotalExpense = (600.211).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

            DebtListViewItemModel = new ObservableCollection<ListViewItemModel>();
            DebtListViewItemModel.Add(new ListViewItemModel() { ItemText = "Motorcycle Camping gear Debt", ItemValue = (4000.12).ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) });
            DebtListViewItemModel.Add(new ListViewItemModel() { ItemText = "Expensive Drone Debt", ItemValue = (3000.67).ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) });
            DebtListViewItemModel.Add(new ListViewItemModel() { ItemText = "Ducati Bike Debt", ItemValue = (1080.333).ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) });

            TotalDebt = (3500.0).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

            AssetsListViewItemModel = new ObservableCollection<ListViewItemModel>();
            AssetsListViewItemModel.Add(new ListViewItemModel() { ItemText = "FD $5020.63 @4.12% Intrest Rate | JP Morgen Bank", ItemValue = (5020.63).ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) });

            NetWorth = (5500.0 - 1300).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

            CashFlowListViewItemModel = new ObservableCollection<ListViewItemModel>();  
            cashFlowListViewItemModel.Add(new ListViewItemModel() { ItemText = "Free cash flow per month", ItemValue = (100.63).ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) });


            TotalCashFlow = (100.63).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));


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

        public ICommand ChangeCardIndexCommand { get; }

        public GameViewModel()
        {
            ChangeCardIndexCommand = new Command<int>(index => VisibleIndex = index);
            //delete me ....
            //TODO: get correct object  from AppSell Or in ctor... and replace null...:
            GenerateStatementData(null);


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
