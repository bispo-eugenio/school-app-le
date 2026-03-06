using schoolApp.Types.Enums;
using Spectre.Console;

namespace schoolApp.Models.@Abstract;

public abstract class AbcUI
{

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

    public Stats GetStats(string title)
    {
        while (true)
        {
            var statsResult = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title(title)
            .AddChoices("Ativo", "Desativado")
            );
            AnsiConsole.Clear();
            return statsResult == "Ativo" ?
            Stats.Enabled : Stats.Disabled;
        }
    }

    public Group GetGroup(string title)
    {
        while (true)
        {
            var groupResult = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title(title)
            .AddChoices(
            "1 - Turma A", "2 - Turma B",
            "3 - Turma C", "4 - Turma D",
            "5 - Turma E"
            ));

            Group group = groupResult switch
            {
                "1 - Turma A" => Group.A,
                "2 - Turma B" => Group.B,
                "3 - Turma C" => Group.C,
                "4 - Turma D" => Group.D,
                "5 - Turma E" => Group.E,
                _ => throw new NotImplementedException()
            };

            AnsiConsole.Clear();
            return group;
        }

    }
    public static void Table(List<Student> students, string messageInfo)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Firstname");
        table.AddColumn("Lastname");
        table.AddColumn("Birthday");
        table.AddColumn("CPF");
        table.AddColumn("Grade");
        table.AddColumn("Group");
        table.AddColumn("Stats");

        foreach (var student in students)
        {
            table.AddRow(
            Markup.Escape($"{student.StudentRegister}"),
            Markup.Escape(student.FirstNameIO),
            Markup.Escape(student.LastNameIO),
            Markup.Escape($"{student.BirthdayIO}"),
            Markup.Escape(student.CpfIO),
            Markup.Escape($"{student.ShowGrade()}"),
            Markup.Escape($"{student.GroupIO}"),
            Markup.Escape($"{student.StatsIO}")
            );
        }
        AnsiConsole.Clear();
        if (students.Count == 0)
            AnsiConsole.MarkupLine(messageInfo);
        else
            AnsiConsole.Write(table);
    }

    public static void Table(List<Teacher> teachers, string messageInfo)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Firstname");
        table.AddColumn("Lastname");
        table.AddColumn("Birthday");
        table.AddColumn("CPF");
        table.AddColumn("Salary");
        table.AddColumn("Stats");

        foreach (var teacher in teachers)
        {
            table.AddRow(
            Markup.Escape($"{teacher.TeacherRegister}"),
            Markup.Escape(teacher.FirstNameIO),
            Markup.Escape(teacher.LastNameIO),
            Markup.Escape($"{teacher.BirthdayIO}"),
            Markup.Escape(teacher.CpfIO),
            Markup.Escape($"{teacher.SalaryIO}"),
            Markup.Escape($"{teacher.StatsIO}")
            );
        }
        AnsiConsole.Clear();
        if (teachers.Count == 0)
            AnsiConsole.MarkupLine("[bold blue]<INFO>Não tem aluno cadastro no sistema.[/]");
        else
            AnsiConsole.Write(table);
    }

}
