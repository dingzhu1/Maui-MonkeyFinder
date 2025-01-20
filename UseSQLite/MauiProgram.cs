using UseSQLite.Data;
using UseSQLite.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UseSQLite
{
    public static class MauiProgram
    {
        internal static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<TodoListPage>();
            builder.Services.AddTransient<TodoItemPage>();

            builder.Services.AddSingleton<TodoItemDatabase>();

            return builder.Build();
        }
    }
}
