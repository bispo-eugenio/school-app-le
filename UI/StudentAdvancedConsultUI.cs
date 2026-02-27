using Spectre.Console;
using schoolApp.Services;
namespace schoolApp.UI;


public class StudentAdvancedConsultUI
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
            "2 - Consultar por turma",
            "3 - Consultar por status",
            "4 - Consultar por status de média",
            "5 - Consultar por média",
            "6 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Consultar por id":
                    Console.WriteLine("0");
                    break;
                case "2 - COnsultar por turma":
                    Console.WriteLine("1");
                    break;
                case "3 - Consultar por status":
                    Console.WriteLine("1");
                    break;
                case "4 - Consultar por status de média":
                    Console.WriteLine("1");
                    break;
                case "5 - Consultar por média":
                    Console.WriteLine("1");
                    break;
                case "6 - Voltar ao Menu":
                    change = false;
                    break;
            }
        }
    }

}
