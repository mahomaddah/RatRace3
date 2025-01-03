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
        await Shell.Current.GoToAsync("StoryModeView");
    }

    private async void BackToGameButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GameView");
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        var appShell = (AppShell)Shell.Current;
        this.BindingContext = appShell.CurrentLevelModel;
        GameGoalsListV.ItemsSource = appShell.CurrentLevelModel.StoryGoalModels;
    }
}