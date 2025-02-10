using System.Windows.Input;

namespace UseBehaviors
{
    public partial class MainPage : ContentPage
    {
        public ICommand NavigateCommand => new Command<Type>(async (Type pageType) =>
        {
            Page page = Activator.CreateInstance(pageType) as Page;
           await Navigation.PushAsync(page);
        });

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

      
    }

}
