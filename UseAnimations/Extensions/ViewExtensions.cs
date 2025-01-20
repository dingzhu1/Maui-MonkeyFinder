using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseAnimations.Extensions
{
    public static class ViewExtensions
    {
        public static Task<bool> ColorTo(this VisualElement self,
            Color fromColor,Color toColor,Action<Color> callBack,uint lenght=250,Easing easing=null)
        {
            
            Func<double,Color> transForm=(t)=>
            {
              return  Color.FromRgb(fromColor.Red+t*(toColor.Red-fromColor.Red),
                    fromColor.Green+t*(toColor.Green-fromColor.Green),
                    fromColor.Blue+t*(toColor.Blue-fromColor.Blue));
            };
            return ColorAnimation(self,"ColorTo",transForm,callBack,lenght,easing);

        }

        public static void CancelAnimation(this VisualElement self)
        {
            self.AbortAnimation("ColorTo");   
        }

        static Task<bool> ColorAnimation(VisualElement element,string name,Func<double,Color> transform,
            Action<Color> callback,uint lenght,Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Color>(name, transform, callback, 16, lenght, easing,
                (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }
    }
}
