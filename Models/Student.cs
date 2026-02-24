namespace schoolApp.Models;


using Person = schoolApp.Models.Abstract.Person;
using Stats = schoolApp.Types.@Enums.Stats;
using Group = schoolApp.Types.@Enums.Group;
using IStudent = schoolApp.Types.IStudent;
using GradeStats = schoolApp.Types.@Enums.GradeStats;
using Constants = schoolApp.Utils.Constants;

public class Student : Person, IStudent
{
    private static int _id;
    private readonly List<decimal> _grade;
    private Group StudentGroup { get; set; }
    public int StudentRegister { get; init; }
    private static readonly Constants _constants = new Constants();
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
        StudentGroup = group == null ? Group.A : group.Value;
    }

    public void SetGrade(List<decimal> grade)
    {
        //Refatorar a lógica depois
        if (grade.Count != 2)
            throw new("");
        foreach (var item in grade)
        {
            if (item < 0 && item > 10)
                throw new("");
        }
        _grade.Clear();
        foreach (var item in grade)
        {
            _grade.Add(item);
        }
    }
    public IReadOnlyList<decimal> Grade() => _grade;

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
