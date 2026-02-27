using Spectre.Console;
using schoolApp.Services;

namespace schoolApp.UI;

public class TeacherAdvancedConsultUI
{

    private static TeacherService _teacherService = new TeacherService();
    private static StudentService _studentService = new StudentService();

    private bool change;
    public void Run()
    {
        change = true;
        while (change)
        {
            AnsiConsole.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[bold green]<------- Opções  ------->[/]")
            .AddChoices(
            "1 - Consultar por id",
            "2 - Consultar por turmar",
            "3 - Consultar por status",
            "4 - Consultar por salário",
            "5 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Consultar por id":
                    Console.WriteLine("0");
                    break;
                case "2 - Consultar por turmar":
                    Console.WriteLine("1");
                    break;
                case "3 - Consultar por status":
                    Console.WriteLine("1");
                    break;
                case "4 - Consultar por salário":
                    Console.WriteLine("1");
                    break;
                case "5 - Voltar ao Menu":
                    change = false;
                    break;
            }
        }
    }

}
