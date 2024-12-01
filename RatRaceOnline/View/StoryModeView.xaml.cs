namespace RatRace3;

using Microsoft.Maui.Graphics;

public partial class StoryModeView : ContentPage
{
	public StoryModeView()
	{
		InitializeComponent();



    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        this.BindingContext = new CarouselViewModel();
    }

    private async void StartGameClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("StoryDetailView");
    }

    private async void RestartGameClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("StoryDetailView");
    }
}

