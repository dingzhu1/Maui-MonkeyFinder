using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseAnimations.Pages.Controls
{
    public class EasingCard : ContentView
    {
        public static readonly BindableProperty CardTitleProperty =
        BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(EasingCard), string.Empty);

        public static readonly BindableProperty CardDescriptionProperty =
        BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(EasingCard), string.Empty);

        public static readonly BindableProperty EasingStyleProperty =
        BindableProperty.Create(nameof(EasingStyle), typeof(Easing), typeof(EasingCard), Easing.Linear);

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

        public Easing EasingStyle
        {
            get => (Easing)GetValue(EasingStyleProperty);
            set => SetValue(EasingStyleProperty, value);
        }

        public EasingCard()
        {
            this.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                NumberOfTapsRequired = 2,
                Command = new Command(OnDblTap)
            });
            this.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                NumberOfTapsRequired = 1,
                Command = new Command(OnTap)
            });
        }

        private async void OnDblTap(object obj)
        {
            _cancelTapToken.Cancel();
            Debug.WriteLine("You Double Tapped");
            var navigationParameter=new Dictionary<string, object>() {

                {"card",this }
            };
            
        }

        private async void OnTap(object obj)
        {
            await DebouncedTap().ConfigureAwait(false);
        }

        private CancellationTokenSource _cancelTapToken=new CancellationTokenSource();

        private async Task DebouncedTap()
        {
            try
            {
                Interlocked.Exchange(ref _cancelTapToken, new CancellationTokenSource()).Cancel();
                //NOTE THE 500 HERE - WHICH IS THE TIME TO WAIT
                await Task.Delay(300, _cancelTapToken.Token)
                    .ContinueWith(async task =>
                    {

                        Debug.WriteLine("You Tapped");
                        var ag = (Grid)this.GetTemplateChild("AxisGrid");
                        ag.Opacity = (ag.Opacity == 0) ? 1 : 0;
                        if (ag.Opacity != 0)
                        {
                            var b = (BoxView)this.GetTemplateChild("Box");
                            b.TranslationY = 0;
                            await Task.Delay(500);
                            await b.TranslateTo(b.TranslationY, ag.Height * -1, 1000, EasingStyle);
                        }
                    },
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.FromCurrentSynchronizationContext()
                    );
            }
            catch  
            {

                //Ignore any Threading errors
            }
        }
    }
}