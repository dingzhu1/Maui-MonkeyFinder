namespace UseAnimations.Pages;

public partial class ScalePage : ContentPage
{

    public ScalePage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await BotImg.ScaleTo(0, easing: Easing.SpringIn);
        await Task.Delay(1000);
        await BotImg.ScaleTo(1, easing: Easing.SpringOut);
    }
}