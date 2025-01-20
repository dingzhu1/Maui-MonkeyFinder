using UseSQLite.Data;

namespace UseSQLite.Views;

[QueryProperty("Item", "Item")]
public partial class TodoItemPage : ContentPage
{
	public TodoItemPage(TodoItemDatabase todoItemDatabase)
	{
		InitializeComponent();
        database= todoItemDatabase;

    }
    TodoItem item;
    public TodoItem Item
    {
        get => BindingContext as TodoItem;
        set => BindingContext = value;
    }

    TodoItemDatabase database;




    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    private async void CancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }
}