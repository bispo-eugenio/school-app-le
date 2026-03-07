using Spectre.Console;
using schoolApp.Services;
using schoolApp.Models;
using schoolApp.Models.Abstract;
using schoolApp.Utils.Validations;
using schoolApp.Types.Enums;
namespace schoolApp.UI;


public class StudentAdvancedConsultUI : AbcUI
{
    private static StudentService _studentService = new();
    private static ScoreValidation _scoreValidation = new();

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
            "1 - Consultar por turma",
            "2 - Consultar por status",
            "3 - Consultar por status de média",
            "4 - Consultar por média",
            "5 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Consultar por turma":
                    AnsiConsole.Clear();
                    ConsultGroup();
                    break;
                case "2 - Consultar por status":
                    AnsiConsole.Clear();
                    ConsultStats();
                    break;
                case "3 - Consultar por status de média":
                    AnsiConsole.Clear();
                    ConsultGradeStats();
                    break;
                case "4 - Consultar por média":
                    AnsiConsole.Clear();
                    ConsultAverange();
                    break;
                case "5 - Voltar ao Menu":
                    change = false;
                    break;
            }
        }
    }

    public void ConsultGroup()
    {
        var group = GetGroup("Qual o [bold green]grupo[/] dos usuários?");
        var studentsByGroup =
        _studentService.GetStudentByGroup(group);
        TableView(studentsByGroup,
        "[bold blue]<INFO>Não conseguimos " +
        "realizar esse tipo de consulta.[/]");
    }

    public void ConsultStats()
    {
        var stats = GetStats("Qual o [bold green]status[/] dos usuários?");
        var studentsByStats = _studentService.GetStudentByStats(stats);
        TableView(studentsByStats,
        "[bold blue]<INFO>Não conseguimos " +
        "realizar esse tipo de consulta.[/]");
    }

    public void ConsultGradeStats()
    {
        string choiceAverange = AnsiConsole
        .Prompt(new SelectionPrompt<string>()
       .AddChoices(
           "1 - Passou de acordo à [bold green]média[/]",
           "2 - Não passou de acordo à [bold green]média[/]"
       ));
        GradeStats result = choiceAverange
        == "1 - Passou de acordo à [bold green]média[/]"
        ? GradeStats.Passed : GradeStats.Failed;

        var studentByGradeStats = _studentService.GetStudentsGradeStats(result);
        TableView(studentByGradeStats,
        "[bold blue]<INFO>Não conseguimos " +
        "realizar esse tipo de consulta.[/]");
    }

    public void ConsultAverange()
    {
        decimal value = Decimal.Parse(GetData(
        _scoreValidation.IsValid,
        "Digite o valor da [bold green]média[/]:",
        "[bold yellow]<WARNING>Valor de média inválida para" +
        " consultar.[/]\n"
        ));
        string choice = AnsiConsole
        .Prompt(new SelectionPrompt<string>()
        .AddChoices(
        "1 - Igual à média",
        "2 - Maior que à média",
        "3 - Menor que á média"
        ));
        LogicOperatorMode mode = choice switch
        {
            "1 - Igual à média" => LogicOperatorMode.Equals,
            "2 - Maior que à média" => LogicOperatorMode.Higher,
            "3 - Menor que á média" => LogicOperatorMode.Lower,
            _ => throw new NotImplementedException()
        };
        var studentByAverange = _studentService.GetStudentsByAverange(value, mode);
        TableView(studentByAverange,
        "[bold blue]<INFO>Não conseguimos " +
        "realizar esse tipo de consulta.[/]"
        );
    }
}
