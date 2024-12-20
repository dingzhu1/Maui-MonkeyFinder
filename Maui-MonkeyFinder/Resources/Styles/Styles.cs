using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_MonkeyFinder
{
    public class BaseLabel : Label
    {
        public BaseLabel()
        {
            if (App.Current.Resources.TryGetValue("BaseLabel", out object result))
            {
                this.Style = result as Style;
            }
        }
    }

    public class AdditionalInformation : Label
    {
        public AdditionalInformation()
        {
            if (App.Current.Resources.TryGetValue("AdditionalInformation", out object result))
            {
                this.Style = result as Style;
            }
        }
    }

    public class ListDetails : Label
    {
        public ListDetails()
        {
            if (App.Current.Resources.TryGetValue("ListDetails", out object result))
            {
                this.Style = result as Style;
            }
        }
    }

    public class BodyText : Label
    {
        public BodyText()
        {
            if (App.Current.Resources.TryGetValue("BodyText", out object result))
            {
                this.Style = result as Style;
            }
        }
    }

    public class Heading : Label
    {
        public Heading()
        {
            if (App.Current.Resources.TryGetValue("Heading", out object result))
            {
                this.Style = result as Style;
            }
        }
    }

    public class StandardButton : Button
    {
        public StandardButton()
        {
            if (App.Current.Resources.TryGetValue("StandardButton", out object result))
            {
                this.Style = result as Style;
            }
        }
    }

    public class CardView : Border
    {
        public CardView()
        {
            if (App.Current.Resources.TryGetValue("CardView", out object result))
            {
                this.Style = result as Style;
            }
        }
    }

}
