using Android.Graphics;
using Android.Widget;
using Microsoft.Maui.Platform;
using Color = Microsoft.Maui.Graphics.Color;

namespace UseBehaviors.Behaviors
{
    public partial class TintColorBehavior : PlatformBehavior<Image, ImageView>
    {
        protected override void OnAttachedTo(Image bindable, ImageView platformView)
        {
            base.OnAttachedTo(bindable, platformView);

            if (bindable is null)
                return;

            if (TintColor is null)
                ClearColor(platformView);
            else
                ApplyColor(platformView, TintColor);
        }

        protected override void OnDetachedFrom(Image bindable, ImageView platformView)
        {
            base.OnDetachedFrom(bindable, platformView);

            if (bindable is null)
                return;
            ClearColor(platformView);
        }

        private void ApplyColor(ImageView platformView, Color tintColor)
        {
            platformView.SetColorFilter(new PorterDuffColorFilter(tintColor.ToPlatform(),
                PorterDuff.Mode.SrcIn ?? throw new NullReferenceException()));
        }

        private void ClearColor(ImageView platformView)
        {
            platformView.ClearColorFilter();
        }
    }
}