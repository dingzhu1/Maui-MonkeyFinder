﻿using System.Windows.Input;

namespace UseControlTemplate
{
    public partial class MainPage : ContentPage
    {
        public ICommand NavigateCommand { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = Activator.CreateInstance(pageType) as Page;
                await Navigation.PushAsync(page);
            });
            BindingContext = this;
        }
    }
}