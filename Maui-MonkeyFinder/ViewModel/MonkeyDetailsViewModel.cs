using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui_MonkeyFinder.Model;
using System.Diagnostics;

namespace Maui_MonkeyFinder.ViewModel
{
    [QueryProperty(nameof(Model.Monkey), "Monkey")]
    public partial class MonkeyDetailsViewModel : BaseViewModel
    {
        public MonkeyDetailsViewModel(IMap map)
        {
            Map = map;
        }

        [ObservableProperty]
        Monkey monkey;

        public IMap Map { get; }

        [RelayCommand]
        async Task OpenMap()
        {
            try
            {
                await Map.OpenAsync(monkey.Latitude, monkey.Longitude,new MapLaunchOptions { 
                
                Name=monkey.Name,
                NavigationMode=NavigationMode.None
                });
            }
            catch (Exception ex)
            {

               Debug.WriteLine($"Unable to launch maps:{ex.Message}");
                await Shell.Current.DisplayAlert("Error,no Maps app!", ex.Message, "OK");
            }
        }
    }
}