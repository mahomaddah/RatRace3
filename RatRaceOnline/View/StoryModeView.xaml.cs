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
}