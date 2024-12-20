using Maui_MonkeyFinder.View;

namespace Maui_MonkeyFinder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DetailsPage),typeof(DetailsPage));

        }
    }
}
