namespace RatRace3.View;
using RatRace3.View;
using Syncfusion.Maui.Cards;

public partial class GameView : ContentPage
{
    public CardViewModel CardviewModel { get; set; } 
    public GameView()
	{
		InitializeComponent();
        CardviewModel = new CardViewModel();
        BindingContext = CardviewModel;

        // Set default card index to open first 
        CardviewModel.VisibleIndex = 2;
       
    }

    private async void cardNavBtn_Clicked(object sender, EventArgs e)
    {
		if(sender!=null)
		{ 
          CardviewModel.VisibleIndex = Convert.ToInt16(((Button)sender).CommandParameter);
        // BindingContext = CardviewModel;
        // await DisplayAlert("Alert", ((Button)sender).CommandParameter.ToString(), "OK");
        }
    }

    private void GameProgressBtn_Clicked(object sender, EventArgs e)
    {

    }

    private void GameNextTurnBtn_Clicked(object sender, EventArgs e)
    {

    }
}

