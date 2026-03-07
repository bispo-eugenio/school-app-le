using schoolApp.Models;
using schoolApp.Models.Abstract;
using schoolApp.Services;
using schoolApp.Types.Enums;
using schoolApp.Utils;
using schoolApp.Utils.Validations;
using Spectre.Console;
namespace schoolApp.UI;

public class TeacherUI : AbcUI
{
    private static TeacherService _teacherService = new();
    private static StudentService _studentService = new();
    private NameValidation _nameValidation = new();
    private BirthdayValidation _birthdayValidation = new();
    private CPFValidation _cpfValidation = new();
    private SalaryValidation _salaryValidation = new();
    private ProjectConstants _constant = new();
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
            "1 - Adiciona professor",
            "2 - Consultar professor",
            "3 - Atualizar professor",
            "4 - Apagar professor",
            "5 - Adicionar aluno na turma",
            "6 - Remover aluno da turma",
            "7 - Voltar ao Menu"
            ));
            switch (option)
            {
                case "1 - Adiciona professor":
                    AnsiConsole.Clear();
                    Add();
                    break;
                case "2 - Consultar professor":
                    AnsiConsole.Clear();
                    ConsultTeacher();
                    break;
                case "3 - Atualizar professor":
                    AnsiConsole.Clear();
                    updTeacher();
                    break;
                case "4 - Apagar professor":
                    AnsiConsole.Clear();
                    RemoveTeacher();
                    break;
                case "5 - Adicionar aluno na turma":
                    AnsiConsole.Clear();
                    AddStudentToGroup();
                    break;
                case "6 - Remover aluno da turma":
                    AnsiConsole.Clear();
                    RemoveStudentToGroup();
                    break;
                case "7 - Voltar ao Menu":
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
            "Qual o [green]nome[/] do professor?",
            "[bold yellow]<WARNING>Nome inválidos.[/]\n"
            );
            string lastname = GetData(
            _nameValidation.IsValid,
            "Qual o [green]sobrenome[/] do professor?",
            "[bold yellow]<WARNING>Sobrenome inválidos.[/]\n"
            );
            DateTime birthday = DateTime.Parse(GetData(
            _birthdayValidation.IsValid,
            "Qual a [green]data de nascimento[/] do professor?",
            "[bold yellow]<WARNING>Data de nascimento é inválido.[/]\n"
            ));
            string cpf = GetData(
            _cpfValidation.IsValid,
            "Qual o [green]cpf[/] do professor?",
            "[bold yellow]<WARNING>CPF é inválido.[/]\n"
            );
            decimal salary = Decimal.Parse(GetData(
            _salaryValidation.IsValid,
            "Digite o valor do [bold green]salário[/] do professor?",
            $"[bold yellow]<WARNING>Salário abaixo de {_constant.GetSalary}"
            + " não são permitidos e/ou formato de dado inválido.[/]\n"
            ));

            Group group = GetGroup("Qual a turma do professor?");
            Stats stats = GetStats("O professor está ativo no sistema?");
            _teacherService.Add(firstname, lastname,
             birthday, cpf, stats, salary, null, group);
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]Cadastro realizado![/]");
            break;
        }
    }

    public void ConsultTeacher()
    {
        try
        {
            int id = int.Parse(AnsiConsole.Ask<string>("Digite o id do usuário: "));
            Teacher? teacher = _teacherService.GetRegister(id);
            AnsiConsole.Clear();
            if (teacher != null)
                AnsiConsole.MarkupLine(
                $"""
                [bold green]Status:[/] {teacher.StatsIO}
                [bold green]Nome Completo:[/] {teacher.GetFullName()}
                [bold green]CPF:[/] {teacher.CpfIO}
                [bold green]Data de Nascimento:[/] {teacher.StringTimeData(FlagTimeDataType.Birthday)}
                [bold green]Turma:[/] {teacher.GroupIO}
                [bold green]Salário:[/] {teacher.SalaryIO}
                [bold green]Data de Criação:[/] {teacher.StringTimeData(FlagTimeDataType.Create)}
                [bold green]Data de Atualização:[/] {teacher.StringTimeData(FlagTimeDataType.Update)}
                """
                );
            else
                AnsiConsole.MarkupLine("[bold blue]<INFO>Usuário não encontrando![/]");
        }
        catch (Exception)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold red]Entrada inválida.[/]");
        }


    }

    public void updTeacher()
    {
        try
        {
            int id = int.Parse(AnsiConsole.Ask<string>("Digite o id do usuário: "));
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .AddChoices(
                "1 - Firstame",
                "2 - Lastname",
                "3 - Birthday",
                "4 - Cpf",
                "5 - Stats",
                "6 - Salary"

            ));
            switch (choice)
            {
                case "1 - Firstame":
                    string firstname = GetData(
                    _nameValidation.IsValid,
                    "Qual o [green]nome[/] do professor?",
                    "[bold yellow]<WARNING>Nome inválidos e/ou formato " +
                    "incorreto.[/]\n"
                    );
                    _teacherService.Update(
                    id,
                    EntityProperties.FIRSTNAME,
                    firstname);
                    break;
                case "2 - Lastname":
                    string lastname = GetData(
                    _nameValidation.IsValid,
                    "Qual o [green]sobrenome[/] do professor?",
                    "[bold yellow]<WARNING>Sobrenome inválidos e/ou formato " +
                    "incorreto.[/]\n"
                    );
                    _teacherService.Update(
                    id,
                    EntityProperties.LASTNAME,
                    lastname);
                    break;
                case "3 - Birthday":
                    string birthday = GetData(
                    _birthdayValidation.IsValid,
                    "Qual a [green]data de nascimento[/] do professor?",
                    "[bold yellow]<WARNING>Data de nascimento é inválido e/ou" +
                    "formato incorreto.[/]\n"
                    );
                    _teacherService.Update(
                    id,
                    EntityProperties.BIRTHDAY,
                    birthday
                    );
                    break;
                case "4 - Cpf":
                    string cpf = GetData(
                    _cpfValidation.IsValid,
                    "Qual o [green]cpf[/] do professor?",
                    "[bold yellow]<WARNING>CPF é inválido e/ou" +
                    " formato incorreto.[/]\n"
                    );
                    _teacherService.Update(
                    id,
                    EntityProperties.CPF,
                    cpf
                    );
                    break;
                case "5 - Stats":
                    _teacherService.Update(
                    id,
                    EntityProperties.STATS
                    );
                    break;
                case "6 - Salary":
                    string salary = GetData(
                    _salaryValidation.IsValid,
                    "Digite a primeira [bold green]primeiro nota[/]?",
                    "[bold yellow]<WARNING>Salário abaixo de" +
                    $" {_constant.GetSalary} não são permitidos" +
                    " e/ou formato de dado inválido.[/]\n"
                    );
                    _teacherService.Update(
                    id,
                    EntityProperties.SALARY,
                    salary
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

    public void RemoveTeacher()
    {
        try
        {
            int id = int.Parse(AnsiConsole.Ask<string>("Digite o id do usuário: "));
            AnsiConsole.Clear();
            AnsiConsole.WriteLine(_teacherService.Remove(id));
            if (_teacherService.Remove(id))
                AnsiConsole.MarkupLine("[bold green]Usuário removido com sucesso![/]");
            else
                AnsiConsole.MarkupLine("[bold yellow]<WARNING>Usuário não foi " +
                "removido e/ou não foi encontrado.[/]");
        }
        catch (Exception)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold red]Entrada inválida.[/]");
        }

    }

    public void AddStudentToGroup()
    {
        try
        {
            int teacherId = int.Parse(
                AnsiConsole.Ask<string>("Digite o id do professor: "));
            int studentId = int.Parse(
                AnsiConsole.Ask<string>("Digite o id do estudante: "));
            AnsiConsole.Clear();
            Student? student = _studentService.GetRegister(studentId);
            Teacher? teacher = _teacherService.GetRegister(teacherId);
            if (teacher != null && student != null)
            {
                teacher.AddStudent(student);
                student.GroupIO = teacher.GroupIO;
                AnsiConsole.MarkupLine("[bold green]Estudante" +
                " foi matriculado na turma com sucesso![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold yellow]<WARNING>Usuário não foi " +
                "adicionado na turma e/ou não foi encontrado.[/]");
            }
        }
        catch (Exception)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold red]Entrada inválida.[/]");
        }
    }

    public void RemoveStudentToGroup()
    {
        try
        {
            int teacherId = int.Parse(
                AnsiConsole.Ask<string>("Digite o id do professor: "));
            int studentId = int.Parse(
                AnsiConsole.Ask<string>("Digite o id do estudante: "));
            AnsiConsole.Clear();
            Student? student = _studentService.GetRegister(studentId);
            Teacher? teacher = _teacherService.GetRegister(teacherId);
            if (teacher != null && student != null)
            {
                teacher.RemoveStudent(student);
                student.GroupIO = Group.SEMTURMA;
                AnsiConsole.MarkupLine("[bold green]Estudante foi" +
                " retirado da turma com sucesso![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold yellow]<WARNING>Usuário não foi " +
                "removido da turma e/ou não foi encontrado.[/]");
            }
        }
        catch (Exception)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold red]Entrada inválida.[/]");
        }
    }

}
