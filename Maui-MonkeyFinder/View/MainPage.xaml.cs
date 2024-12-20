using Maui_MonkeyFinder.Controls;
using Maui_MonkeyFinder.ViewModel;

namespace Maui_MonkeyFinder.View;

public partial class MainPage  :StandardPage
{
	public MainPage(MonkeysViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}