using Spectre.Console;
using schoolApp.Services;

namespace schoolApp.UI;

public class ConsultUI
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
            "1 - Consultar todos os estudantes",
            "2 - Consultar todos os professores",
            "3 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Adiciona estudante":
                    Console.WriteLine("0");
                    break;
                case "2 - Atualizar estudante":
                    Console.WriteLine("1");
                    break;
                case "3 - Voltar ao Menu":
                    change = false;
                    break;
            }
        }
    }

}
