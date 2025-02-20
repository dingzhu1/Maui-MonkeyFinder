using System.Collections.ObjectModel;
using UseDataBinding.Models;
using UseDataBinding.ViewModels;

namespace UseDataBinding.Views;

public partial class RelativeSourceFindAncestorPage : ContentPage
{

    public PeopleViewModel DefaultViewModel { get; } = new PeopleViewModel
    {
        Employees = new ObservableCollection<Person>
            {
                new Person
                {
                    Forename = "John",
                    Surname = "Doe"
                },
                new Person
                {
                    Forename = "Jane",
                    Surname = "Doe"
                },
                new Person
                {
                    Forename = "Xamarin",
                    Surname = "Monkey"
                }
            }
    };
    public RelativeSourceFindAncestorPage()
	{
		InitializeComponent();
	}
}