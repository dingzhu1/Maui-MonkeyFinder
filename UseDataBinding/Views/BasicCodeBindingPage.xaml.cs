namespace UseDataBinding.Views;

public partial class BasicCodeBindingPage : ContentPage
{
	public BasicCodeBindingPage()
	{
		InitializeComponent();
		label.BindingContext = slider;
		label.SetBinding(Label.RotationProperty, "Value");
    }
}