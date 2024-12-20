using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_MonkeyFinder.Controls
{
    public class StandardPage:ContentPage
    {
        public StandardPage()
        {
            App.Current.Resources.TryGetValue(AppColors.LightBackground, out object lightColor);
            App.Current.Resources.TryGetValue(AppColors.DarkBackground, out object darkColor);

            this.SetAppTheme(ContentPage.BackgroundColorProperty,lightColor, darkColor);
        }
    }
}
