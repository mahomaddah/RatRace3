namespace RatRace3;

using Microsoft.Maui.Graphics;
using RatRace3.DAL;
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
            appShell.CurrentLevelModel = model;
         // await Shell.Current.DisplayAlert("Delete me ", model.StoryLevelID.ToString(),"OK" );//textcode...
        }
        await Shell.Current.GoToAsync("StoryDetailView");
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
            var model = appShell.SelectLevelViewModel.ImageCollection.ElementAtOrDefault(playingLevelIndex);
            if (model != null)
        {
            model.IsNewGameStarted = true;
            appShell.CurrentLevelModel = model;
        }
        await Shell.Current.GoToAsync("StoryDetailView");

        }
    }
}

