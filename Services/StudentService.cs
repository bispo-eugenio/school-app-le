using schoolApp.Models;
using schoolApp.Types.@Enums;
using Spectre.Console;

namespace schoolApp.Services;

public class StudentService
{
    private static readonly List<Student> students = [];


    public void Add(string firstname, string lastname,
    DateTime birthday, string cpf, Stats stats,
    List<decimal>? grade = null, Group? group = null)
    {
        Student student = new PersonFactory().CreateStudent(firstname,
        lastname, birthday, cpf, stats, grade, group);
        students.Add(student);
    }

    public IReadOnlyList<Student> GetAll()
    {
        return students;
    }

    public bool Update(int id, EntityProprieties property, string? data = null)
    {
        Student? student = students.Find((x) => x.StudentRegister == id);
        if (student != null)
        {
            switch (property)
            {
                case EntityProprieties.FIRSTNAME:
                    student.FirstNameIO = data ??= student.FirstNameIO;
                    break;
                case EntityProprieties.LASTNAME:
                    student.LastNameIO = data ??= student.LastNameIO;
                    break;
                case EntityProprieties.BIRTHDAY:
                    student.BirthdayIO =
                    DateTime.TryParse(data, out DateTime _) ?
                    DateTime.Parse(data) : student.BirthdayIO;
                    break;
                case EntityProprieties.CPF:
                    student.CpfIO = data ??= student.FirstNameIO;
                    break;
                case EntityProprieties.STATS:
                    student.StatsIO = student.StatsIO == Stats.Enabled ?
                    Stats.Disabled : Stats.Enabled;
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
        Student? student = students.Find((x) => x.StudentRegister == id);
        if (student != null && student.StudentRegister == id)
        {
            students.Remove(student);
            return true;
        }
        return false;
    }

    public bool UpdateGradeById(int id, List<decimal> grade)
    {
        Student? student = students.Find((x) => x.StudentRegister == id);
        if (student != null && student.StudentRegister == id)
        {
            student.SetGrade(grade);
            return true;
        }
        return false;
    }

    public Student? GetRegister(int id)
    {
        Student? student = students.Find((x) => x.StudentRegister == id);
        if (student != null && student.StudentRegister == id)
            return student;
        return null;
    }

    public IReadOnlyList<Student> GetStudentByGroup(Group group)
    {
        IReadOnlyList<Student> studentsByGroup = students.Where(student =>
        student.GroupIO == group).ToList();
        return studentsByGroup;
    }

    public IReadOnlyList<Student> GetStudentByStats(Stats stats)
    {
        IReadOnlyList<Student> studentsByStats = students.Where(student =>
        student.StatsIO == stats).ToList();
        return studentsByStats;
    }

    public IReadOnlyList<Student> GetStudentsGradeStats(GradeStats gradeStats)
    {
        IReadOnlyList<Student> studentsByGradeStats = students.Where(student =>
         student.GetGradeStats() == gradeStats).ToList();
        return studentsByGradeStats;
    }

    public IReadOnlyList<Student> GetStudentsByAverange(decimal averange,
    LogicOperatorMode mode)
    {
        switch (mode)
        {
            case LogicOperatorMode.Equals:
                IReadOnlyList<Student> studentsByAverange = students.
                Where(student => student.Average() == averange).ToList();
                return studentsByAverange;
            case LogicOperatorMode.Higher:
                IReadOnlyList<Student> studentsByHighestAverange = students.
                Where(student => student.Average() > averange).ToList();
                return studentsByHighestAverange;
            case LogicOperatorMode.Lower:
                IReadOnlyList<Student> studentsByLowestAverange = students.
                Where(student => student.Average() < averange).ToList();
                return studentsByLowestAverange;
            default:
                throw new NotImplementedException();
        }
    }

}
