namespace RatRace3.View;
using RatRace3.View;
using Syncfusion.Maui.Cards;

public partial class GameView : ContentPage
{
	public GameView()
	{
		InitializeComponent();
        
    }

    private async void paymentPageNavBtn_Clicked(object sender, EventArgs e)
    {
		if(sender!=null)
		{
            await DisplayAlert("Alert", "Payments clicked...(GameView class)", "OK");
        }
    }
}

