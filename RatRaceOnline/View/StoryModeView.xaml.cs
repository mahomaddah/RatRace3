namespace RatRace3;

using Microsoft.Maui.Graphics;
using RatRace3.ViewModel;

public partial class StoryModeView : ContentPage
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
    }

    private async void StartGameClicked(object sender, EventArgs e)
    {
       var appShell = (AppShell)Shell.Current;
       var model= appShell.SelectLevelViewModel.ImageCollection.ElementAtOrDefault(storyLevelsCarousel.SelectedIndex);
        if (model != null)
        {
            model.IsNewGameStarted = false;
            appShell.CurrentLevelModel = model;
         // await Shell.Current.DisplayAlert("Delete me ", model.StoryLevelID.ToString(),"OK" );//textcode...
        }
        await Shell.Current.GoToAsync("StoryDetailView");
    }

    private async void RestartGameClicked(object sender, EventArgs e)
    {
        var appShell = (AppShell)Shell.Current;
        var model = appShell.SelectLevelViewModel.ImageCollection.ElementAtOrDefault(storyLevelsCarousel.SelectedIndex);
        if (model != null)
        {
            model.IsNewGameStarted = true;
            appShell.CurrentLevelModel = model;
        }
        await Shell.Current.GoToAsync("StoryDetailView");
    }
}

