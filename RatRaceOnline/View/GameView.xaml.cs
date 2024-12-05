namespace RatRace3.View;
using RatRace3.View;
using Syncfusion.Maui.Cards;

public partial class GameView : ContentPage
{
	public GameView()
	{
		InitializeComponent();
        var viewModel = new CardViewModel();
        BindingContext = viewModel;

        // Example: Set default index
        viewModel.VisibleIndex = 2;

        // Attach event handler for the navigation bar buttons
        paymentPageNavBtn.Clicked += (s, e) =>
        {
            viewModel.VisibleIndex = 0; // Example: Set index for the first card
        };
    }

    private async void paymentPageNavBtn_Clicked(object sender, EventArgs e)
    {
		if(sender!=null)
		{
            await DisplayAlert("Alert", "Payments clicked...(GameView class)", "OK");
        }
    }
}

