using Spectre.Console;
using StudentService = schoolApp.Services.StudentService;
namespace schoolApp.UI;

public class StudentUI
{
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
            "1 - Adiciona estudante",
            "2 - Atualizar estudante",
            "3 - Atualizar notas do estudante",
            "4 - Apagar estudante",
            "5 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Adiciona estudante":
                    Console.WriteLine("0");
                    break;
                case "2 - Atualizar estudante":
                    Console.WriteLine("1");
                    break;
                case "3 - Atualizar notas do estudante":
                    Console.WriteLine("2");
                    break;
                case "4 - Apagar estudante":
                    Console.WriteLine("3");
                    break;
                case "5 - Voltar ao Menu":
                    Console.WriteLine("4");
                    change = false;
                    break;
            }
        }
    }

    public static void Add()
    {

    }

    public static void Upd()
    {

    }

    public static void UpdGrade()
    {

    }

    public static void Del()
    {

    }
}
