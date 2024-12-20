using Maui_MonkeyFinder.Model;
using Maui_MonkeyFinder.ViewModel;

namespace Maui_MonkeyFinder.View;

public partial class DetailsPage
{
    public DetailsPage(MonkeyDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}