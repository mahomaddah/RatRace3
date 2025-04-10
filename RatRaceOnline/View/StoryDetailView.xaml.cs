using RatRace3.Models;

namespace RatRace3.View;

public partial class StoryDetailView : ContentView
{
    public StoryDetailView()
	{
		InitializeComponent();

     
    }

    private async void FinishGameButton_Clicked(object sender, EventArgs e)
    {
        var appShell = (AppShell)Shell.Current;
        appShell.CurrentLevelModel.IsGameFinished = true;
        //save... data month number ... score etc... TODO..

        appShell.CurrentLevelModel.HighestMounthScore = appShell.GameViewModel.Player.CurrentMonth;
        //unlock next ...

        await Shell.Current.DisplayAlert("Congratulations!", "\"You have successfully achieved all the goals required to complete this level of game. Great job!\"", "Victory, Baby!????");
      //  await Shell.Current.GoToAsync("StoryModeView");
     //   await Shell.Current.GoToAsync("/storymodeview");
      //  var appShell = (AppShell)Shell.Current;
        ((MotherView)(appShell).CurrentPage).Show("storymodeview");


    }

    private async void BackToGameButton_Clicked(object sender, EventArgs e)
    {




        try
        {
            var appShell = (AppShell)Shell.Current;
            appShell.CurrentLevelModel.isStarted = true;
           
         
           //     await appShell.GoToAsync("/gameview");
           //     var appShell = (AppShell)Shell.Current;
                ((MotherView)(appShell).CurrentPage).Show("gameview");
                
          //      AppJustStarted = false;
        
           
                   

         

        }
        catch(Exception ex) { await Shell.Current.DisplayAlert(ex.Message,ex.StackTrace,"OK"); }
      
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        var appShell = (AppShell)Shell.Current;
        this.BindingContext = appShell.CurrentLevelModel;
        GameGoalsListV.ItemsSource = appShell.CurrentLevelModel.StoryGoalModels;


    }

    private async void TryAgainGameButton_Clicked(object sender, EventArgs e)
    {
        bool result = await Shell.Current.DisplayAlert("New Game?", "Are you sure you want to restart? Your old save will be overwritten!", "Yes", "No");

        if (result)
        {


            var appShell = (AppShell)Shell.Current;
            string currentPlayingLevelID = appShell.CurrentLevelModel.StoryLevelID;


            var model = appShell.SelectLevelViewModel.ImageCollection.FirstOrDefault(x => x.StoryLevelID == currentPlayingLevelID);
            if (model != null)
            {
                model.IsNewGameStarted = true;
                appShell.CurrentLevelModel = model;
         
            appShell.GameViewModel.Player = appShell.CurrentLevelModel.Players.First();
            appShell.GameViewModel.LoadPlayerData(appShell.GameViewModel.Player);

            ((MotherView)(appShell).CurrentPage).Show("storydetailview");
            ((MotherView)(appShell).CurrentPage).Show("gameview");
            }
        }
    }
}