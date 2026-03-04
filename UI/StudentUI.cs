using Spectre.Console;
using schoolApp.Services;
using schoolApp.Models;
using schoolApp.Utils.@Validations;
using schoolApp.Types.@Enums;

namespace schoolApp.UI;

public class StudentUI
{
    private StudentService _studentService = new();
    private NameValidation _nameValidation = new();
    private BirthdayValidation _birthdayValidation = new();
    private CPFValidation _cpfValidation = new();
    private ScoreValidation _scoreValidation = new();
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
            "1 - Adiciona estudante",
            "2 - Consultar estudante por id",
            "3 - Atualizar estudante",
            "4 - Atualizar notas do estudante",
            "5 - Apagar estudante",
            "6 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Adiciona estudante":
                    AnsiConsole.Clear();
                    Add();
                    break;
                case "2 - Consultar estudante por id":
                    AnsiConsole.Clear();
                    ConsultStudent();
                    break;
                case "3 - Atualizar estudante":
                    AnsiConsole.Clear();
                    updStudent();
                    break;
                case "4 - Atualizar notas do estudante":
                    AnsiConsole.Clear();
                    UpdGrade();
                    break;
                case "5 - Apagar estudante":
                    AnsiConsole.Clear();
                    RemoveStudent();
                    break;
                case "6 - Voltar ao Menu":
                    AnsiConsole.Clear();
                    change = false;
                    break;
            }
        }
    }

    public void Add()
    {
        while (true)
        {
            string firstname = GetData(
            _nameValidation.IsValid,
            "Qual o [green]nome[/] do estudante?",
            "[bold yellow]<WARNING>Nome inválidos.[/]\n"
            );
            string lastname = GetData(
            _nameValidation.IsValid,
            "Qual o [green]sobrenome[/] do estudante?",
            "[bold yellow]<WARNING>Sobrenome inválidos.[/]\n"
            );
            DateTime birthday = DateTime.Parse(GetData(
            _birthdayValidation.IsValid,
            "Qual a [green]data de nascimento[/] do estudante?",
            "[bold yellow]<WARNING>Data de nascimento é inválido.[/]\n"
            ));
            string cpf = GetData(
            _cpfValidation.IsValid,
            "Qual o [green]cpf[/] do estudante?",
            "[bold yellow]<WARNING>CPF é inválido.[/]\n"
            );
            decimal oneValue = Decimal.Parse(GetData(
            _scoreValidation.IsValid,
            "Digite a primeira [bold green]primeiro nota[/]?",
            "[bold yellow]<WARNING>Nota inválida para" +
            " cadastrar o estudante.[/]\n"
            ));
            decimal twoValue = Decimal.Parse(GetData(
            _scoreValidation.IsValid,
            "Digite a [bold green]segunda nota[/]?",
            "[bold yellow]<WARNING>Nota inválida para" +
            " cadastrar o estudante.[/]\n"
            ));
            Stats stats = GetStats();
            _studentService.Add(firstname, lastname,
             birthday, cpf, stats, [oneValue, twoValue]);
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]Cadastro realizado![/]");
            break;
        }
    }

    public void updStudent()
    {
        try
        {
            int id = int.Parse(
            AnsiConsole.Ask<string>("Digite o id do usuário: "));
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(
                "1 - Firstame",
                "2 - Lastname",
                "3 - Birthday",
                "4 - Cpf",
                "5 - Stats"

            ));
            switch (choice)
            {
                case "1 - Firstame":
                    string firstname = GetData(
                    _nameValidation.IsValid,
                    "Qual o [green]nome[/] do estudante?",
                    "[bold yellow]<WARNING>Nome inválidos e/ou formato " +
                    "incorreto.[/]\n"
                    );
                    _studentService.Update(
                    id,
                    EntityProprieties.FIRSTNAME,
                    firstname);
                    break;
                case "2 - Lastname":
                    string lastname = GetData(
                    _nameValidation.IsValid,
                    "Qual o [green]sobrenome[/] do estudante?",
                    "[bold yellow]<WARNING>Sobrenome inválidos e/ou formato " +
                    "incorreto.[/]\n"
                    );
                    _studentService.Update(
                    id,
                    EntityProprieties.LASTNAME,
                    lastname);
                    break;
                case "3 - Birthday":
                    string birthday = GetData(
                    _birthdayValidation.IsValid,
                    "Qual a [green]data de nascimento[/] do estudante?",
                    "[bold yellow]<WARNING>Data de nascimento é inválido" +
                    " e/ou formato incorreto.[/]\n"
                    );
                    _studentService.Update(
                    id,
                    EntityProprieties.BIRTHDAY,
                    birthday
                    );
                    break;
                case "4 - Cpf":
                    string cpf = GetData(
                    _cpfValidation.IsValid,
                    "Qual o [green]cpf[/] do estudante?",
                    "[bold yellow]<WARNING>CPF é inválido e/ou" +
                    " formato incorreto.[/]\n"
                    );
                    _studentService.Update(
                    id,
                    EntityProprieties.CPF,
                    cpf
                    );
                    break;
                case "5 - Stats":
                    _studentService.Update(
                    id,
                    EntityProprieties.STATS
                    );
                    break;
                default:
                    throw new NotImplementedException();
            }

        }
        catch (Exception)
        {
            AnsiConsole.MarkupLine($"[bold red]Entrada inválida.[/]");
        }

    }
    public void UpdGrade()
    {
        try
        {
            int id = int.Parse(
            AnsiConsole.Ask<string>("Digite o id do usuário: "));
            decimal oneValue = Decimal.Parse(GetData(
            _scoreValidation.IsValid,
            "Digite a primeira [bold green]primeiro nota[/]?",
            "[bold yellow]<WARNING>Nota inválida" +
            " para cadastrar o estudante.[/]\n"
            ));
            decimal twoValue = Decimal.Parse(GetData(
            _scoreValidation.IsValid,
            "Digite a [bold green]segunda nota[/]?",
            "[bold yellow]<WARNING>Nota inválida" +
            " para cadastrar o estudante.[/]\n"
            ));
            if (_studentService.UpdateGradeById(id, [oneValue, twoValue]))
                AnsiConsole.MarkupLine("[bold green]As notas" +
                " do estudante foram atualizadas![/]");
            else
                AnsiConsole.MarkupLine("[bold yellow]<WARNING>" +
                "As notas do estudante não foram atualizadas![/]");
        }
        catch (Exception)
        {
            AnsiConsole.MarkupLine($"[bold red]Entrada inválida.[/]");
        }
    }
    public void ConsultStudent()
    {
        try
        {
            int id = int.Parse(
            AnsiConsole.Ask<string>("Digite o id do usuário: "));
            Student? student = _studentService.GetRegister(id);
            AnsiConsole.Clear();
            if (student != null)
                AnsiConsole.MarkupLine(
                $"""
                [bold green]Status:[/] {student.StatsIO}
                [bold green]Nome Completo:[/] {student.GetFullName()}
                [bold green]CPF:[/] {student.CpfIO}
                [bold green]Data de Nascimento:[/] {student.BirthdayIO}
                [bold green]Turma:[/] {student.GroupIO}
                [bold green]Média:[/] {student.Average()}
                [bold green]Status de Aprovação:[/] {student.GetGradeStats()}
                """
                );
            else
                AnsiConsole.MarkupLine("[bold blue]<INFO>" +
                "Usuário não encontrando![/]");
        }
        catch (Exception)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold red]Entrada inválida.[/]");
        }


    }
    public void RemoveStudent()
    {
        try
        {
            int id = int.Parse(
            AnsiConsole.Ask<string>("Digite o id do usuário: "));
            AnsiConsole.Clear();
            if (_studentService.Remove(id))
                AnsiConsole.MarkupLine("[bold green]" +
                "Usuário removido com sucesso![/]");
            else
                AnsiConsole.MarkupLine("[bold yellow]<WARNING>Usuário" +
                " não foi removido e/ou não foi encontrado[/]");

        }
        catch (Exception)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold red]Entrada inválida.[/]");
        }

    }

    public string GetData(Func<string, bool> validation,
    string message, string exceptionMessage)
    {
        while (true)
        {
            string data = AnsiConsole.Ask<string>(message);
            if (!validation(data))
            {
                AnsiConsole.Clear();
                AnsiConsole.Markup(exceptionMessage);
            }
            else
            {
                AnsiConsole.Clear();
                return data;
            }
        }
    }

    public Stats GetStats()
    {
        while (true)
        {
            var statsResult = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("O estudante está ativo no sistema?")
            .AddChoices("Ativo", "Desativado")
            );
            AnsiConsole.Clear();
            return statsResult == "Ativo" ?
            Stats.Enabled : Stats.Disabled;
        }
    }

}
