using Spectre.Console;
using TeacherService = schoolApp.Services.TeacherService;
namespace schoolApp.UI;

public class TeacherUI
{
    private static TeacherService _teacherService = new TeacherService();
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
            "1 - Adiciona professor",
            "2 - Atualizar professor",
            "3 - Adicionar aluno na turma",
            "4 - Remover aluno da turma",
            "5 - Apagar professor",
            "6 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Adiciona professor":
                    Console.WriteLine("0");
                    break;
                case "2 - Atualizar professor":
                    Console.WriteLine("1");
                    break;
                case "3 - Adicionar aluno na turma":
                    Console.WriteLine("2");
                    break;
                case "4 - Remover aluno da turma":
                    Console.WriteLine("3");
                    break;
                case "5 - Apagar professor":
                    Console.WriteLine("3");
                    break;
                case "6 - Voltar ao Menu":
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
