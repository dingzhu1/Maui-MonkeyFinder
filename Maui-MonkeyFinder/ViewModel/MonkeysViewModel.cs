using Maui_MonkeyFinder.Model;
using System.Collections.ObjectModel;
using Maui_MonkeyFinder.Services;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Maui_MonkeyFinder.View;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Maui_MonkeyFinder.ViewModel
{
    public partial class MonkeysViewModel : BaseViewModel
    {
        public ObservableCollection<Monkey> Monkeys { get; } = new ObservableCollection<Monkey>();
        private MonkeyService monkeyService { get; }
        public IConnectivity Connectivity { get; }
        public IGeolocation Geolocation { get; }

        public MonkeysViewModel(MonkeyService monkeyService,
            IConnectivity connectivity,
            IGeolocation geolocation)
        {
            Title = "Monkey Finder";
            this.monkeyService = monkeyService;
            Connectivity = connectivity;
            Geolocation = geolocation;
        }

        [ObservableProperty]
        private bool isRefreshing;

        [RelayCommand]
        private async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!", $"Please check internet and try again.", "OK");
            }

            try
            {
                IsBusy = true;
                var monkeys = await monkeyService.GetMonkeys();

                if (Monkeys.Count != 0)
                    Monkeys.Clear();

                foreach (var monkey in monkeys)
                {
                    Monkeys.Add(monkey);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys:{ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");

                var monkeys = await monkeyService.ReadJson();

                if (Monkeys.Count != 0)
                    Monkeys.Clear();

                foreach (var monkey in monkeys)
                {
                    Monkeys.Add(monkey);
                }
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        private async Task GoToDetails(Monkey monkey)
        {
            if (monkey == null) return;

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object> {
                {"Monkey",monkey }
            });
        }

        [RelayCommand]
        private async Task GetClosestMonkey()
        {
            if (IsBusy || Monkeys.Count == 0) return;

            try
            {
                //Get cached location,else get real location.
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                //Find closest monkey to us.
                var first = Monkeys.OrderBy(m => location.CalculateDistance(

                    new Location(m.Latitude, m.Longitude), DistanceUnits.Miles
                    )).FirstOrDefault();

                await Shell.Current.DisplayAlert("", first.Name + "" + first.Location, "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to query locaiton:{ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            
        }
    }
}