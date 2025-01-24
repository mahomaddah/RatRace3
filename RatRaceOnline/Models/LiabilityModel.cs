using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace RatRace3.Models
{
    public class LiabilityModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _liabilityName;
        private double _totalAmount;
        private double _remainingAmount;
        private int _monthsRemaining;
        private double _emi; 
        private double _interestRate;

        public int LiabilityModelID { get; set; }

        public string LiabilityName
        {
            get => _liabilityName;
            set
            {
                if (_liabilityName != value)
                {
                    _liabilityName = value;
                    OnPropertyChanged();
                }
            }
        }

        public double TotalAmount
        {
            get => _totalAmount;
            set
            {
                if (_totalAmount != value)
                {
                    _totalAmount = value;
                    RemainingAmount = _totalAmount;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalAmountFormatted)); // Notify for dependent properties
                }
            }
        }

        public double RemainingAmount
        {
            get => _remainingAmount;
            set
            {
                if (_remainingAmount != value)
                {
                    _remainingAmount = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(RemainingAmountFormatted)); // Notify for dependent properties
                    OnPropertyChanged(nameof(MaximumPayable)); // Notify for dependent properties
                }
            }
        }

        public int MonthsRemaining
        {
            get => _monthsRemaining;
            set
            {
                if (_monthsRemaining != value)
                {
                    _monthsRemaining = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(MonthsRemainingFormatted)); // Notify for dependent properties
                }
            }
        }

        public double Emi
        {
            get
            {
                if (_monthsRemaining == 0) return 0; // Avoid division by zero
                double monthlyRate = _interestRate / 12; // Convert annual rate to monthly
                double numerator = _totalAmount * monthlyRate * Math.Pow(1 + monthlyRate, _monthsRemaining);
                double denominator = Math.Pow(1 + monthlyRate, _monthsRemaining) - 1;
                return denominator > 0 ? numerator / denominator : _totalAmount / _monthsRemaining;
            }
        }

        public double InterestRate
        {
            get => _interestRate;
            set
            {
                if (_interestRate != value)
                {
                    _interestRate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(InterestRateFormatted)); // Notify for dependent properties
                }
            }
        }


        public LiabilityModel()
        {
            RemainingAmount = TotalAmount;
            
        }

        // Computed Properties
        public string TotalAmountFormatted => "Total Amount: "+TotalAmount.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
        public string RemainingAmountFormatted => "Remaining Amount: "+RemainingAmount.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
        public string MonthsRemainingFormatted => $"Months Remaining: {MonthsRemaining}";
        public string EmiFormatted => "EMI: "+Emi.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
        public string InterestRateFormatted => $"Interest Rate: {InterestRate:P}";
       
        
        public double MaximumPayable => Math.Min(RemainingAmount, ((AppShell)Shell.Current).CurrentLevelModel.Players.First().Balance); // Example max limit

        public int ExpenseModelID { get; internal set; }

        // Property change notification
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
