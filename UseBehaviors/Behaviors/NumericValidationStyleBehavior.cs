using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseBehaviors.Behaviors
{
    public class NumericValidationStyleBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty AttachBehaviorProperty =
        BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(NumericValidationStyleBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view) => (bool)view.GetValue(AttachBehaviorProperty);

        public static void SetAttachBehavior(BindableObject view, bool value) => view.SetValue(AttachBehaviorProperty, value);

        private static void OnAttachBehaviorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Entry entry = bindable as Entry;
            if (entry == null)
            {
                return;
            }
            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.Behaviors.Add(new NumericValidationStyleBehavior());
            }
            else
            {
                Behavior toRemove = entry.Behaviors.FirstOrDefault(b => b is NumericValidationStyleBehavior);
                if (toRemove != null)
                {
                    entry.Behaviors.Remove(toRemove);
                }
            }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnEntryTextChanged(object? sender, TextChangedEventArgs e)
        {
            double result;
            bool isValid = double.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Colors.Black : Colors.Red;
        }
    }
}