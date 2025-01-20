using UseAnimations.Extensions;

namespace UseAnimations.Pages;

public partial class CustomAnimationPage : ContentPage
{
    public CustomAnimationPage()
    {
        InitializeComponent();
    }

    private async void OnClikedAsync(object sender, EventArgs e)
    {
        Color bgColor = this.BackgroundColor;
        await Task.WhenAll(

            this.ColorTo(bgColor, GetRandomColour(), c => this.BackgroundColor = c)
            );
    }

    private static readonly Random random = new();

    private Color GetRandomColour()
    {
        return Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
    }
}