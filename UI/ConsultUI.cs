using Spectre.Console;
using schoolApp.Services;
using schoolApp.Models;
using System.Formats.Asn1;

namespace schoolApp.UI;

public class ConsultUI
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
        var table = new Table();
        var students = _studentService.GetAll();
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
            AnsiConsole.MarkupLine("[bold blue]<INFO>Não tem aluno cadastro no sistema.[/]");
        else
            AnsiConsole.Write(table);
    }

    public static void TeacherTable()
    {
        var table = new Table();
        var teachers = _teacherService.GetAll();
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
