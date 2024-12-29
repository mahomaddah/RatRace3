using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace3.ViewModel
{
    public class CarouselViewModel
    {
        public CarouselViewModel()
        {


            ImageCollection.Add(new CarouselModel
            {
                StoryLevelID = "A",
                Image = "undraw_investing.png",
                Header = "Investing Adventure",
                DetailStory = "You start your journey as a novice investor, barely making ends meet. One day, you stumble upon a hidden gem in the stock market that others have overlooked. Will you risk your savings on this company, or play it safe with traditional investments? Your choices will decide if you break free from the rat race or fall further into it.",
                isStarted = false,
                isUnlocked = true,
                HighestMounthScore = 0
            });

            ImageCollection.Add(new CarouselModel
            {
                StoryLevelID = "2",
                Image = "software_engineer.png",
                Header = "The Software Engineer's Breakthrough",
                DetailStory = "As a budding software engineer, you're stuck in a low-paying job with no prospects of promotion. But one day, you're inspired to create a groundbreaking app. The only question is: do you have the grit to see your idea through, or will the challenges of the tech world overwhelm you? Build, fail, and try again to see where your code takes you.",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0
            });

            ImageCollection.Add(new CarouselModel
            {
                StoryLevelID = "3",
                Image = "exams.png",
                Header = "The Exam Hustle",
                DetailStory = "You're back in school, juggling part-time jobs while preparing for the toughest exams of your life. Your goal? A scholarship that could open doors to a better life. But the stress of it all threatens to derail you. Can you manage your time and mental health, or will you succumb to burnout?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0
            });

            ImageCollection.Add(new CarouselModel
            {
                StoryLevelID = "4",
                Image = "interview.png",
                Header = "The Interview Gauntlet",
                DetailStory = "You've landed a series of interviews for your dream job, but the competition is fierce. Each question tests not only your knowledge but also your ability to think on your feet. Nail the interviews and secure a position that will change your financial future forever.",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0
            });

            ImageCollection.Add(new CarouselModel
            {
                StoryLevelID = "5",
                Image = "dotnet_bot.png",
                Header = "Launching Your Dreams",
                DetailStory = "After years of planning, you're ready to launch your startup, a metaphorical rocket aimed at financial freedom. But the launch is risky—your team is depending on you, and any miscalculation could lead to failure. Will you soar to new heights, or will gravity pull you back into the rat race?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0
            });

            ImageCollection.Add(new CarouselModel
            {
                StoryLevelID = "6",
                Image = "shared_goals.png",
                Header = "Shared Goals, Shared Dreams",
                DetailStory = "You team up with like-minded individuals who share your vision for escaping the rat race. Together, you pool resources, divide tasks, and strategize your next big move. Can you unite to achieve greatness, or will the team fall apart under pressure?",
                isStarted = false,
                isUnlocked = false,
                HighestMounthScore = 0
            });

        }
        private List<CarouselModel> imageCollection = new List<CarouselModel>();
        public List<CarouselModel> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }
    }

    public class CarouselModel
    {
        public string StoryLevelID { get; set; }
        public short HighestMounthScore { get; set; }
        public string Header { get; set; }
        public string DetailStory { get; set; }
        public bool isStarted { get; set; }
        public bool isUnlocked { get; set; }
        public CarouselModel()
        {

        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
