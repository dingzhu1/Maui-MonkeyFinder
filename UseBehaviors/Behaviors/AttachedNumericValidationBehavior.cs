﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseBehaviors.Behaviors
{
    public static class AttachedNumericValidationBehavior
    {
        public static readonly BindableProperty AttachBehaviorProperty =
           BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(AttachedNumericValidationBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        private static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            Entry entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        private static void OnEntryTextChanged(object? sender, TextChangedEventArgs args)
        {
            double result;
            bool isValid = double.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Colors.Black : Colors.Red;
        }
    }
}
