using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.Models
{
    public class NewsPaperModel
    {
        public string VolNo { get;  set; }
        public string EconomicDataC80 { get; set; }
        public static string EconomicDataSetterC80(double InfaltionRate ,double TreseryYild10yr,double SPY500GrowthLastYear)
        {
            //Latter Can put and if and compare to last year values for active ▽ or △ After MVP TODO...
            return $":U.S. INFLATION:{InfaltionRate:P}▽ U.S.10-YR. TREAS. yield:{TreseryYild10yr:P}△ S&P500(SPY)yr.{SPY500GrowthLastYear:P}△";
        }
        public string Date { get;  set; }
        public string MainHeaderLine1C16 { get;  set; }
        public string MainHeaderLine2C16 { get;  set; }
        public string ImageSource { get; internal set; }
        public string ImageTitleC39 { get; internal set; }
        public string MainSubHeaderC29Cap { get; internal set; }
        public string BodyMidPartC47 { get; internal set; }
        public string BodyOldEngStartingCharC1 { get; internal set; }
        public string BodyEndingPartC615 { get; internal set; }
        public int NewsPaperModelID { get; internal set; }
        public DownTwoPartArticle DownTwoPartArticle { get; internal set; }
        public DoubleArticleTable SmallLeftArticleTable { get; set; }
        public TripleArticleTable RightTopArtilceTable { get; set; }
        public TripleMiniArticleTable RightDownArtilceTable { get; set; }

        public double CPIrate { get;  set; }
        public double TbondRate { get;  set; }
       
        private double spy10yrRate;
        /// <summary>
        /// For Auto Filling EconomicDataC80 :
        /// step1.Fill CPIrate,
        /// step2.Fill TbondRate,
        /// step3.fill this SPY10yrRateUpdater and it will use Economic Data SetterC80 method to Fill (string)EconomicDataC80 Property!
        /// </summary>
        public double SPY10yrRateUpdater
        {
            get { return spy10yrRate; }
            set { spy10yrRate = value;
                try
                {
                    if (CPIrate != 0 && TbondRate != 0 && value != 0)
                    {
                        EconomicDataC80 = EconomicDataSetterC80(CPIrate, TbondRate, value);
                    }
                }
                catch { }
              
            }
        }



    }

}
