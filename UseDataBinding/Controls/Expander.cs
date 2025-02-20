using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseDataBinding.Controls
{
    public class Expander : Grid
    {
        public static readonly BindableProperty IsExpandedProperty =
             BindableProperty.Create(nameof(IsExpanded), typeof(bool), typeof(Expander), false);

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }
    }
}