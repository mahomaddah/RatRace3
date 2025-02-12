using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatRace3.Models;

namespace RatRace3.ViewModel
{
    public class NewsPaperViewModel
    {
        public NewsPaperModel CurrentNewsPaperModel { get; set; }

        public List<NewsPaperModel> NewsPaperModels { get; set; }

        public NewsPaperViewModel()
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
             };
        }

    }
}
