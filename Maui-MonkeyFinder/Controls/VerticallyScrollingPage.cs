using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_MonkeyFinder.Controls
{
    [ContentProperty(nameof(Children))]
    public class VerticallyScrollingPage:StandardPage
    {
        private readonly ScrollView _scrollView;
        private readonly VerticalStackLayout _verticalLayout;

        public IList<IView> Children =>_verticalLayout.Children;
        public VerticallyScrollingPage()
        {
            _verticalLayout = new VerticalStackLayout() { Padding=0};
            _scrollView = new ScrollView() { 
            Content=_verticalLayout
            };
            base.Content = _scrollView;
        }
    }
}
