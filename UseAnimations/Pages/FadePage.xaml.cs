namespace UseAnimations.Pages;

public partial class FadePage : ContentPage
{
	public FadePage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await BotImg.FadeTo(0);
		await Task.Delay(1000);
		await BotImg.FadeTo(1);
    }
}