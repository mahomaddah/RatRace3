
using RatRace3.View;

namespace RatRace3
{
    public partial class MotherView : ContentPage
    {

        public GameView GameView { get; set; }
      
        private readonly MarketPage _marketPage;
        private readonly StoryDetailView _storyDetailView;
        private readonly StoryModeView _storyModeView;
        private readonly MainPage _mainPage;
        public MotherView()
        {
            InitializeComponent();

            GameView = new GameView();
            _marketPage = new MarketPage();
            _storyDetailView = new StoryDetailView();
            _storyModeView = new StoryModeView();
            _mainPage = new MainPage();

          //  İlk açılışta MainPage göster
            MainContainer.Content = _mainPage;
         
        }

        /// <summary>
        /// PAGE NAMES: 
        /// gameview,
        /// marketpage,
        /// storydetailview,
        /// storymodeview,
        /// mainpage
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="pageName"></param>
        public void Show(string pageName)
        {
            switch (pageName)
            {
                case "gameview":
                    MainContainer.Content = GameView;
                    break;
                case "marketpage":
                    MainContainer.Content = _marketPage;
                    break;
                case "storydetailview":
                    MainContainer.Content = _storyDetailView;
                    break;
                case "storymodeview":
                    MainContainer.Content = _storyModeView;
                    break;
                case "mainpage":
                    MainContainer.Content = _mainPage;
                    break;
            }
        }
        public enum PageNames
        {
            gameview,
            marketpage,
            storydetailview,
            storymodeview,
            mainpage
        }
    }


}
