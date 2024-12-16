namespace RatRace3.View;

public partial class StoryDetailView : ContentPage
{
    public List<StoryGoalModel> StoryGoalModels{ get; set; }
    public StoryDetailView()
	{
		InitializeComponent();
		this.StoryGoalModels = new List<StoryGoalModel> { new StoryGoalModel {Goal = "Liabilities" , Target = 0 , YouHave = 3 } };
        GameGoalsListV.ItemsSource = this.StoryGoalModels;

    }

    private async void FinishGameButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("StoryModeView");
    }

    private async void BackToGameButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GameView");
    }
}