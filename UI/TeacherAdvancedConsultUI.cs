using Spectre.Console;
using schoolApp.Services;
using schoolApp.Utils.Validations;
using schoolApp.Models.Abstract;
using schoolApp.Types.Enums;

namespace schoolApp.UI;

public class TeacherAdvancedConsultUI : AbcUI
{

    private TeacherService _teacherService = new();
    private SalaryValidation _salaryValidation = new();

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
            "3 - Consultar por salário",
            "4 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Consultar por turmar":
                    ConsultByGroup();
                    break;
                case "2 - Consultar por status":
                    ConsultByStats();
                    break;
                case "3 - Consultar por salário":
                    ConsultBySalary();
                    break;
                case "4 - Voltar ao Menu":
                    change = false;
                    break;
            }
        }
    }

    public void ConsultByGroup()
    {
        var group = GetGroup("Qual o [bold green]grupo[/] dos usuários?");
        var teachersByGroup =
        _teacherService.GetTeacherByGroup(group);
        TableView(teachersByGroup,
        "[bold blue]<INFO>Não conseguimos " +
        "realizar esse tipo de consulta.[/]");
    }

    public void ConsultByStats()
    {
        var stats = GetStats("Qual o [bold green]status[/] dos usuários?");
        var teachersByStats = _teacherService.GetTeacherByStats(stats);
        TableView(teachersByStats,
        "[bold blue]<INFO>Não conseguimos " +
        "realizar esse tipo de consulta.[/]");
    }

    public void ConsultBySalary()
    {
        decimal value = Decimal.Parse(GetData(
        _salaryValidation.IsValid,
        "Digite o valor da [bold green]salário[/]:",
        "[bold yellow]<WARNING>Valor de salário inválida para" +
        " consultar.[/]\n"
        ));
        string choice = AnsiConsole
        .Prompt(new SelectionPrompt<string>()
        .AddChoices(
        "1 - Igual ao salário",
        "2 - Maior que o salário",
        "3 - Menor que o salário"
        ));
        LogicOperatorMode mode = choice switch
        {
            "1 - Igual ao salário" => LogicOperatorMode.Equals,
            "2 - Maior que o salário" => LogicOperatorMode.Higher,
            "3 - Menor que o salário" => LogicOperatorMode.Lower,
            _ => throw new NotImplementedException()
        };
        var teachersBySalary = _teacherService.GetTeacherBySalary(value, mode);
        TableView(teachersBySalary,
        "[bold blue]<INFO>Não conseguimos " +
        "realizar esse tipo de consulta.[/]"
        );
    }
}
