namespace UseControlTemplate.Controls;

public partial class HeaderFooterPage : ContentPage
{

    ControlTemplate secondaryColorTemplate;
    ControlTemplate tertiaryColorTemplate;

    public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(HeaderFooterPage), default(string));

    public HeaderFooterPage()
	{
		InitializeComponent();
        secondaryColorTemplate = (ControlTemplate)Resources["SecondaryColorTemplate"];
        tertiaryColorTemplate = (ControlTemplate)Resources["TertiaryColorTemplate"];
    }

    public string HeaderText
    {
        get => (string)GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }

    bool originalTemplate = true;
    public bool OriginalTemplate
    {
        get { return originalTemplate; }
    }

    void OnChangeThemeLabelTapped(object sender, EventArgs e)
    {
        originalTemplate = !originalTemplate;
        ControlTemplate = (originalTemplate) ? secondaryColorTemplate : tertiaryColorTemplate;

        
    }

}