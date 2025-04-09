namespace RatRace3;

using Microsoft.Maui.Graphics;
using RatRace3.DAL;
using RatRace3.Models;
using RatRace3.ViewModel;
using System.Collections.ObjectModel;

public partial class StoryModeView : ContentView
{
	public StoryModeView()
	{
		InitializeComponent();



    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        var appShell = (AppShell)Shell.Current;
        SelectLevelViewModel SelectedObject = appShell.SelectLevelViewModel;
        this.BindingContext = SelectedObject;

        storyLevelsCarousel.SelectedIndex = appShell.UIsettingsModel.LastPlayedLevelIndex;
 
    }

    private async void StartGameClicked(object sender, EventArgs e)
    {
       var appShell = (AppShell)Shell.Current;
        int playingLevelIndex = storyLevelsCarousel.SelectedIndex;
        //try to save last played index...
        SaveLastPlayedIndexD(playingLevelIndex);
       var model= appShell.SelectLevelViewModel.ImageCollection.ElementAtOrDefault(playingLevelIndex);
        if (model != null)
        {
            model.IsNewGameStarted = false;
            var levelPlayer1 = model.Players.First();
             //Load Saved game ... 
             //Note: you can call auto-save function every turn on nextTurn()
             var dal = new DataAccessService();
            appShell.getAnewGameData();
            var savedPlayer = dal.LoadPlayerData(levelPlayer1.StoryLevelID, levelPlayer1.PlayerModelID);
            var savedNews = dal.LoadNewsPapersData(levelPlayer1.StoryLevelID);
            var savedCompanies = dal.LoadCompaniesData(levelPlayer1.StoryLevelID);

            if (savedPlayer != null) levelPlayer1 = savedPlayer;
            if (savedNews != null) appShell.CurrentNewsPaperViewModel = new NewsPaperViewModel { NewsPaperModels = savedNews, CurrentNewsPaperModel = savedNews.LastOrDefault() };
            if (savedCompanies != null)
            {
                if(savedCompanies.Count!=0)
                appShell.IPOcompanies = new ObservableCollection<Company>(savedCompanies);
            }
            //    appShell.CurrentLevelModel.Players[0] = savedPlayer;//if needed (search for appShell.CurrentLevelModel.Players.First() uses)
           appShell.GameViewModel.LoadPlayerData(levelPlayer1);//secound // TODO : after MVP can refactor it with one if No IS game started and one LoadPlayerData()...
            model.Players[0] = levelPlayer1;

            appShell.CurrentLevelModel = model;
         // await Shell.Current.DisplayAlert("Delete me ", model.StoryLevelID.ToString(),"OK" );//textcode...
        }
      



         ((MotherView)(appShell).CurrentPage).Show("storydetailview");
    }
    private void SaveLastPlayedIndexD(int index)
    {
        //try to save last played index...
        try
        {
            var appShell = (AppShell)Shell.Current;
            appShell.UIsettingsModel.LastPlayedLevelIndex = index;
            var dal = new DataAccessService();
            dal.SaveUISettings(appShell.UIsettingsModel);
        }
        catch { }
    }
    private async void RestartGameClicked(object sender, EventArgs e)
    {
        bool result =  await Shell.Current.DisplayAlert("New Game?", "Are you sure you want to restart? Your old save will be overwritten!", "Yes" , "No" );

        if (result)
        {


        var appShell = (AppShell)Shell.Current;
            int playingLevelIndex = storyLevelsCarousel.SelectedIndex;
            SaveLastPlayedIndexD(playingLevelIndex);
            appShell.getAnewGameData();
            var model = appShell.SelectLevelViewModel.ImageCollection.ElementAtOrDefault(playingLevelIndex);
            if (model != null)
        {
            model.IsNewGameStarted = true;
            appShell.CurrentLevelModel = model;
        }
            //  await Shell.Current.GoToAsync("StoryDetailView");
            //  await Shell.Current.GoToAsync("storydetailview");
       
            appShell.GameViewModel.Player = appShell.CurrentLevelModel.Players.First();
            appShell.GameViewModel.LoadPlayerData(appShell.GameViewModel.Player);

            ((MotherView)(appShell).CurrentPage).Show("storydetailview");

        }
    }
}

