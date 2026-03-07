using Spectre.Console;
using schoolApp.Services;
using schoolApp.Models.Abstract;
using schoolApp.Models;

namespace schoolApp.UI;

public class ConsultUI : AbcUI
{
    private static TeacherService _teacherService = new();
    private static StudentService _studentService = new();

    private bool change;
    public void Run()
    {
        change = true;
        while (change)
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[bold white]<------- Opções  ------->[/]")
            .AddChoices(
            "1 - Consultar todos os estudantes",
            "2 - Consultar todos os professores",
            "3 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Consultar todos os estudantes":
                    StudentTable();
                    break;
                case "2 - Consultar todos os professores":
                    TeacherTable();
                    break;
                case "3 - Voltar ao Menu":
                    change = false;
                    AnsiConsole.Clear();
                    break;
            }
        }
    }

    public static void StudentTable()
    {
        List<Student> students = _studentService.GetAll();
        TableView(
        students,
        "[bold blue]<INFO>Não tem aluno cadastro no sistema.[/]");
    }

    public static void TeacherTable()
    {
        var teachers = _teacherService.GetAll();
        TableView(
        teachers,
        "[bold blue]<INFO>Não tem professor cadastro no sistema.[/]"
        );
    }

}
