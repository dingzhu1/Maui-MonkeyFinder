namespace UseAnimations.Pages;

public partial class RotatePage : ContentPage
{
	public RotatePage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Task.WhenAll(
			BotImg.RotateTo(360, 500, Easing.Linear),
			BotImg.TranslateTo(0, -50,250, Easing.CubicInOut)
			);
		await BotImg.TranslateTo(0, 0, 250, Easing.CubicInOut);
		BotImg.Rotation = 0;
    }
}