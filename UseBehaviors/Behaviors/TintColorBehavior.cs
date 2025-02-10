using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseBehaviors.Behaviors
{
    public partial class TintColorBehavior
    {
        public static readonly BindableProperty TintColorProperty =
        BindableProperty.Create("TintColor", typeof(Color), typeof(TintColorBehavior));

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }
    }
}
