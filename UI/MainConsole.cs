using Spectre.Console;
namespace schoolApp.UI;

public sealed class MainConsole
{
    private static MainConsole? _instance;
    private bool change = true;

    private StudentUI _studentUI = new();
    private TeacherUI _teacherUI = new();
    private ConsultUI _consultUI = new();
    private AdvancededConsultUI _advancededConsultUI = new();

    private MainConsole() { }

    ///<summary>
    /// Se _instance for null atribue e retorna _instance,
    /// caso não seja null, retorna _instance
    /// </summary>
    public static MainConsole GetMainConsole()
    {
        return _instance ??= new MainConsole();
    }

    public void Run()
    {
        while (change)
        {
            var menuPrompt = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[bold white]<------- Opções  ------->[/]")
            .AddChoices(
            "1 - Gerenciar aluno",
            "2 - Gerenciar professor",
            "3 - Consultar",
            "4 - Consulta avançada",
            "5 - Sair"
            ));
            switch (menuPrompt)
            {
                case "1 - Gerenciar aluno":
                    AnsiConsole.Clear();
                    _studentUI.Run();
                    break;
                case "2 - Gerenciar professor":
                    AnsiConsole.Clear();
                    _teacherUI.Run();
                    break;
                case "3 - Consultar":
                    AnsiConsole.Clear();
                    _consultUI.Run();
                    break;
                case "4 - Consulta avançada":
                    AnsiConsole.Clear();
                    _advancededConsultUI.Run();
                    break;
                case "5 - Sair":
                    AnsiConsole.Clear();
                    change = false;
                    break;
                default:
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine("[bold red]Valor Inválido![/]");
                    break;
            }
        }
    }
}
