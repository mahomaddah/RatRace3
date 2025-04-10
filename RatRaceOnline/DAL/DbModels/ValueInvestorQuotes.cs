using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.DAL.DbModels
{
    public static class ValueInvestorQuotes
    {
        private static readonly List<string> quotes = new List<string>
    {
        "Price is what you pay. Value is what you get. — Warren Buffett",
        "The intelligent investor is a realist who sells to optimists and buys from pessimists. — Benjamin Graham",
        "Be fearful when others are greedy, and greedy when others are fearful. — Warren Buffett",
        "In the short run, the market is a voting machine but in the long run, it is a weighing machine. — Benjamin Graham",
        "It’s far better to buy a wonderful company at a fair price than a fair company at a wonderful price. — Warren Buffett",
        "Know what you own, and know why you own it. — Peter Lynch",
        "The stock market is filled with individuals who know the price of everything, but the value of nothing. — Philip Fisher",
        "You don’t have to be smarter than the rest. You have to be more disciplined than the rest. — Warren Buffett",
        "The big money is not in the buying and selling, but in the waiting. — Charlie Munger",
        "Wide diversification is only required when investors do not understand what they are doing. — Warren Buffett",
        "Investment is most intelligent when it is most businesslike. — Benjamin Graham",
        "All intelligent investing is value investing — acquiring more than you are paying for. — Charlie Munger",
        "Never invest in a business you cannot understand. — Warren Buffett",
        "Time is the friend of the wonderful company, the enemy of the mediocre. — Warren Buffett",
        "To achieve satisfactory investment results is easier than most people realize; to achieve superior results is harder than it looks. — Benjamin Graham",
        "Spend each day trying to be a little wiser than you were when you woke up. — Charlie Munger",
        "Behind every stock is a company. Find out what it’s doing. — Peter Lynch",
        "If you are not willing to own a stock for 10 years, do not even think about owning it for 10 minutes. — Warren Buffett",
        "The most important quality for an investor is temperament, not intellect. — Warren Buffett",
        "A great business at a fair price is superior to a fair business at a great price. — Charlie Munger",
        "Risk comes from not knowing what you are doing. — Warren Buffett",
        "You make most of your money in a bear market, you just don’t realize it at the time. — Shelby Davis",
        "Buy not on optimism, but on arithmetic. — Benjamin Graham",
        "Opportunities come infrequently. When it rains gold, put out the bucket, not the thimble. — Warren Buffett",
        "The best investment you can make is in yourself. — Warren Buffett",
        "Patience is the key to long-term wealth. — Charlie Munger",
        "Markets can remain irrational longer than you can remain solvent. — John Maynard Keynes",
        "Great investors are not unemotional, but are inversely emotional. — Howard Marks",
        "Successful investing takes time, discipline and patience. — Warren Buffett",
        "Do not save what is left after spending, but spend what is left after saving. — Warren Buffett"
    };

        private static readonly Random rng = new Random();

        public static string GetRandomQuote()
        {
            int index = rng.Next(quotes.Count); // Random index
            return quotes[index];
        }
        /// <summary>
        /// For main page (day-based)
        /// </summary>
        /// <returns></returns>
        public static string GetDailyQuote()
        {
            int day = DateTime.Today.Day;
            int index = (day - 1) % quotes.Count; // Adjusted for 0-based indexing
            return quotes[index];
        }
    }
}
