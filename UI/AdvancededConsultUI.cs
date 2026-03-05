using Spectre.Console;

namespace schoolApp.UI;

public class AdvancededConsultUI
{
    private static StudentAdvancedConsultUI _studentAdvancedCosnultUI = new();
    private static TeacherAdvancedConsultUI _teacherAdvancedCosnultUI = new();
    private bool change;
    public void Run()
    {
        change = true;
        while (change)
        {
            AnsiConsole.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[bold white]<------- Opções  ------->[/]")
            .AddChoices(
            "1 - Consultar estudantes",
            "2 - Consultar professores",
            "3 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Consultar estudantes":
                    _studentAdvancedCosnultUI.Run();
                    break;
                case "2 - Consultar professores":
                    _teacherAdvancedCosnultUI.Run();
                    break;
                case "3 - Voltar ao Menu":
                    change = false;
                    break;
            }
        }
    }

}
