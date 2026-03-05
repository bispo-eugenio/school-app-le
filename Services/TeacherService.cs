using schoolApp.Models;
using schoolApp.Types.@Enums;
using Spectre.Console;

namespace schoolApp.Services;

public class TeacherService
{
    private static List<Teacher> teachers = [];

    public void Add(string firstname, string lastname,
    DateTime birthday, string cpf, Stats stats,
    decimal? salary = null, List<Student>? classroom = null, Group? group = null)
    {
        Teacher teacher = new PersonFactory().CreateTeacher(firstname, lastname,
        birthday, cpf, stats, salary, classroom);
        teachers.Add(teacher);
    }

    public List<Teacher> GetAll()
    {
        return teachers;
    }

    public bool Update(int id, EntityProprieties property, string? data = null)
    {
        Teacher? teacher = teachers.Find((x) => x.TeacherRegister == id);
        if (teacher != null)
        {
            switch (property)
            {
                case EntityProprieties.FIRSTNAME:
                    teacher.FirstNameIO = data ??= teacher.FirstNameIO;
                    break;
                case EntityProprieties.LASTNAME:
                    teacher.LastNameIO = data ??= teacher.LastNameIO;
                    break;
                case EntityProprieties.BIRTHDAY:
                    teacher.BirthdayIO =
                    DateTime.TryParse(data, out DateTime _) ?
                    DateTime.Parse(data) : teacher.BirthdayIO;
                    break;
                case EntityProprieties.CPF:
                    teacher.CpfIO = data ??= teacher.FirstNameIO;
                    break;
                case EntityProprieties.STATS:
                    teacher.StatsIO = teacher.StatsIO == Stats.Enabled ?
                    Stats.Disabled : Stats.Enabled;
                    break;
                case EntityProprieties.SALARY:
                    teacher.SalaryIO = Decimal.TryParse(data, out decimal _) ?
                    Decimal.Parse(data) : teacher.SalaryIO;
                    break;
                default:
                    throw new NotImplementedException();
            }
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]<INFO>Usuário atualizado com sucesso![/]");
            return true;
        }
        AnsiConsole.MarkupLine("[bold yellow]<WARNING>Usuário" +
        " não foi atualizado e/ou não foi cadastrado no sistema![/]");
        return false;
    }

    public bool Remove(int id)
    {
        Teacher? teacher = teachers.Find((x) => x.TeacherRegister == id);
        if (teacher != null && teacher.TeacherRegister == id)
        {
            teachers.Remove(teacher);
            return true;
        }
        return false;
    }

    public Teacher? GetRegister(int id)
    {
        Teacher? teacher = teachers.Find((x) => x.TeacherRegister == id);
        if (teacher != null && teacher.TeacherRegister == id)
        {
            return teacher;
        }
        return null;
    }

    public IReadOnlyList<Teacher> GetTeacherByGroup(Group group)
    {
        IReadOnlyList<Teacher> teachersByGroup = teachers.Where(teacher => teacher.GroupIO == group).ToList();
        return teachersByGroup;
    }

    public IReadOnlyList<Teacher> GetTeacherByStats(Stats stats)
    {
        IReadOnlyList<Teacher> teachersByStats = teachers.Where(teacher => teacher.StatsIO == stats).ToList();
        return teachersByStats;
    }

    public IReadOnlyList<Teacher> GetTeacherBySalary(decimal value, LogicOperatorMode mode)
    {
        switch (mode)
        {
            case LogicOperatorMode.Equals:
                IReadOnlyList<Teacher> teachersByEqualsSalary = teachers.
                Where(teacher => teacher.SalaryIO == value).ToList();
                return teachersByEqualsSalary;
            case LogicOperatorMode.Higher:
                IReadOnlyList<Teacher> teachersByHighestSalary = teachers.
                Where(teacher => teacher.SalaryIO > value).ToList();
                return teachersByHighestSalary;
            case LogicOperatorMode.Lower:
                IReadOnlyList<Teacher> teacherByLowestSalary = teachers.
                Where(teacher => teacher.SalaryIO < value).ToList();
                return teacherByLowestSalary;
            default:
                throw new NotImplementedException();
        }
    }


}
