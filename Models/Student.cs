using schoolApp.Models.Abstract;
using schoolApp.Types.@Enums;
using schoolApp.Utils;

namespace schoolApp.Models;

public class Student : Person
{
    private static int _id;
    private readonly List<decimal> _grade;
    private Group StudentGroup { get; set; }
    public int StudentRegister { get; init; }
    private static readonly ProjectConstants _constants = new();
    public Student(string firstName, string lastName,
    DateTime birthday,
    string cpf, Stats stats) : base(firstName,
    lastName, birthday, cpf, stats)
    {
        StudentRegister = ++_id;
        _grade = [];
    }

    public Student(string firstName, string lastName,
    DateTime birthday, string cpf, Stats stats,
    List<decimal>? grade = null, Group? group = null) : this(firstName,
    lastName, birthday, cpf, stats)
    {
        _grade = grade ?? [];
        StudentGroup = group == null ? Group.SEMTURMA : group.Value;
    }

    public void SetGrade(List<decimal> grade)
    {
        if (grade.Count != 2)
            throw new("Existe uma quantidade incomum de notas.");
        foreach (var item in grade)
        {
            if (item < 0 && item > 10)
                throw new("Existe nota(s) fora do padrão permitido.");
        }
        _grade.Clear();
        foreach (var item in grade)
        {
            _grade.Add(item);
        }
    }
    public IReadOnlyList<decimal> Grade() => _grade;
    public string ShowGrade() => $"Nota-1: {_grade[0]}\nNota-2: {_grade[1]}";

    public decimal Average()
    {
        decimal result = 0;
        foreach (decimal item in _grade)
        {
            result += item;
        }

        return result /= 2;
    }

    public GradeStats GetGradeStats()
    {
        decimal result = Average();

        return result >= _constants.GetAverange ? GradeStats.Passed : GradeStats.Failed;
    }

    public DateTime BirthdayIO { get => Birthday; set => Birthday = value; }
    public string FirstNameIO { get => FirstName; set => FirstName = value; }
    public string LastNameIO { get => LastName; set => LastName = value; }
    public string CpfIO { get => Cpf; set => Cpf = value; }
    public Stats StatsIO { get => Stats; set => Stats = value; }
    public Group GroupIO { get => StudentGroup; set => StudentGroup = value; }
}
