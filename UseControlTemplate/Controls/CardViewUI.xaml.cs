namespace UseControlTemplate.Controls;

public partial class CardViewUI : ContentView
{
	public CardViewUI()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty CardTitleProperty =
        BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardViewUI), string.Empty);

    public static readonly BindableProperty CardDescriptionProperty =
        BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(CardViewUI), string.Empty);

    public static readonly BindableProperty BorderColorProperty = 
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CardViewUI), Colors.DarkGray);

    public static readonly BindableProperty CardColorProperty = 
        BindableProperty.Create(nameof(CardColor), typeof(Color), typeof(CardViewUI), Colors.White);

    public static readonly BindableProperty IconImageSourceProperty = 
        BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(CardViewUI), default(ImageSource));

    public static readonly BindableProperty IconBackgroundColorProperty =
        BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(CardViewUI), Colors.LightGray);

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public string CardDescription
    {
        get => (string)GetValue(CardDescriptionProperty);
        set => SetValue(CardDescriptionProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public Color CardColor
    {
        get => (Color)GetValue(CardColorProperty);
        set => SetValue(CardColorProperty, value);
    }

    public ImageSource IconImageSource
    {
        get => (ImageSource)GetValue(IconImageSourceProperty);
        set => SetValue(IconImageSourceProperty, value);
    }

    public Color IconBackgroundColor
    {
        get => (Color)GetValue(IconBackgroundColorProperty);
        set => SetValue(IconBackgroundColorProperty, value);
    }
}