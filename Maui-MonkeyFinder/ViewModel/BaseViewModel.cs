using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui_MonkeyFinder.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        //public event PropertyChangedEventHandler? PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;

        [ObservableProperty]
        private string title;

        //public bool IsBusy
        //{
        //    get => isBusy;
        //    set
        //    {
        //        if (isBusy == value) return;
        //        isBusy = value;
        //        OnPropertyChanged();

        //        // Also raise the IsNotBusy property changed  
        //        // 同时引发更改的 IsNotBusy 属性
        //        OnPropertyChanged(nameof(IsNotBusy));
        //    }
        //}

        //public string Title
        //{
        //    get => title;
        //    set
        //    {
        //        if (title == value) return;
        //        title = value;

        //        OnPropertyChanged();
        //    }
        //}

        public bool IsNotBusy => !IsBusy;
    }
}