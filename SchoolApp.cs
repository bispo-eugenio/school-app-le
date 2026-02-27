namespace SchoolApp;

using MainConsole = schoolApp.UI.MainConsole;

class SchoolApp
{
    public static void Main()
    {
        var app = MainConsole.GetMainConsole();

        app.Run();
    }
}
