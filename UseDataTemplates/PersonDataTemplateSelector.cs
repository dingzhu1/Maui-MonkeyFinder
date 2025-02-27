﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseDataTemplates
{
    public class PersonDataTemplateSelector : DataTemplateSelector
    {

        public DataTemplate ValidTemplate { get; set; }

        public DataTemplate InvalidTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Person)item).DateOfBirth.Year >= 1980 ? ValidTemplate : InvalidTemplate;
        }
    }
}
