using RatRace3.Models;

namespace RatRace3.View;

public partial class StoryDetailView : ContentPage
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

        await Shell.Current.DisplayAlert("Congratulations!", "\"You have successfully achieved all the goals required to complete this level of game. Great job!\"", "Victory, Baby!????");
        await Shell.Current.GoToAsync("StoryModeView");
    
    }

    private async void BackToGameButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GameView");
        var appShell = (AppShell)Shell.Current;
        appShell.CurrentLevelModel.isStarted = true;
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        var appShell = (AppShell)Shell.Current;
        this.BindingContext = appShell.CurrentLevelModel;
        GameGoalsListV.ItemsSource = appShell.CurrentLevelModel.StoryGoalModels;
    }
}