using RatRace3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace3.Models;


namespace RatRace3.ViewModel
{
    public class RealestateMallViewModel
    {
        public ObservableCollection<RealEstateModel> DataSource { get; set; }

        public RealestateMallViewModel()
        {
            this.DataSource = new ObservableCollection<RealEstateModel>
            {
                new RealEstateModel {Sector= "Energy", LandType = "Sales",RealStateName = "EXON MOBILE", Rent = 50 },
                new RealEstateModel {Sector= "Materials", LandType =  "Sales",RealStateName = "DOW",   Rent =40 },
                new RealEstateModel {Sector= "Utilities", LandType =  "Marketing",   Rent =40 ,RealStateName = "NextEra Energy, Inc." },
                new RealEstateModel {Sector= "Healthcare", LandType =  "Technical", RealStateName ="United Health",   Rent =35 },
                new RealEstateModel {Sector= "Financials", LandType =  "Technical",RealStateName = "ME",  Rent = 175 },
                new RealEstateModel {Sector= "Financials", LandType =  "Technical",RealStateName = "VISA",  Rent = 70 },
                new RealEstateModel {Sector= "Financials", LandType =  "Management",  RealStateName = "BTC" , Rent =40 },
                new RealEstateModel {Sector= "Consumer Staples", LandType =  "Accounts",  Rent = 60 ,RealStateName="Walmart" },
                new RealEstateModel {Sector= "Consumer Discretionary", LandType =  "Technical",RealStateName = "Amazon (retail)",  Rent = 33 },
                new RealEstateModel {Sector= "Information Technology", LandType =  "Technical",RealStateName = "Apple",  Rent = 125 },
                new RealEstateModel {Sector= "Communication Services", LandType =  "Technical",RealStateName = "GOOGL (YouTube)", Rent =  60 },
                new RealEstateModel {Sector= "Communication Services",  LandType = "HR Executives",RealStateName="META",  Rent = 70 },
                new RealEstateModel {Sector= "Information Technology", LandType =  "Accounts", RealStateName="ADOBE", Rent = 45 },
                new RealEstateModel {Sector= "Information Technology", LandType =  "Technical", RealStateName ="NVIDIA",  Rent = 30 },
                new RealEstateModel {Sector= "Consumer Discretionary", LandType =  "Sales",RealStateName = "MCD",  Rent = 40 },
                new RealEstateModel {Sector= "Consumer Discretionary", LandType =  "Marketing",  Rent = 50 },
                new RealEstateModel {Sector= "Industrials", LandType =  "Technical", RealStateName ="Tesla",  Rent = 40 },
                new RealEstateModel {Sector= "Real Estate", LandType =  "Technical", RealStateName ="Prologis, Inc. REITs",  Rent = 60 },
                new RealEstateModel {Sector= "Utilities", LandType =  "Technical", RealStateName ="NextEra Energy (NNE)",  Rent = 27 },
                new RealEstateModel {Sector= "Information Technology", LandType =  "Management", RealStateName = "MSFT",  Rent = 40 },
                new RealEstateModel {Sector= "Information Technology", LandType =  "Technical",RealStateName = "GOOGL (Google Cloud)", Rent =  60 },
                new RealEstateModel {Sector= "Information Technology", LandType =  "Technical",RealStateName = "Amazon (AWS)", Rent =  60 },
                new RealEstateModel {Sector= "Communication Services", LandType =  "Technical",RealStateName = "Amazon (Prime Video)",  Rent = 33 }



            };
        }
    }
}
