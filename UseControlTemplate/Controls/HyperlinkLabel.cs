using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseControlTemplate.Controls
{
    public class HyperlinkLabel:Label
    {
        public static readonly BindableProperty UrlProperty =
        BindableProperty.Create(nameof(Url), typeof(string), typeof(HyperlinkLabel), null);

        public string Url
        {
            get => (string)GetValue(UrlProperty);
            set => SetValue(UrlProperty, value);
        }

        public HyperlinkLabel()
        {
            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async() =>
                {
                    await Launcher.OpenAsync(Url);
                })
            });
        }
    }
}
