namespace schoolApp.Models;

using Person = schoolApp.Models.@Abstract.Person;
using ITeacher = schoolApp.Types.ITeacher;
using Stats = schoolApp.Types.Enums.Stats;
using schoolApp.Types.Enums;

public class Teacher : Person, ITeacher
{
    private static int _id;
    private readonly List<Student> _classroom;
    private const double _salary = 1400;
    private double Salary { get; set; }
    private Group TeacherGroup { get; set; }
    public int TeacherRegister { get; init; }

    public Teacher(string firstName, string lastName,
    DateTime birthday, string cpf, Stats stats) : base(
    firstName, lastName, birthday, cpf, stats)
    {
        TeacherRegister = ++_id;
        Salary = _salary;
        _classroom = [];
    }

    public Teacher(string firstName, string lastName,
    DateTime birthday, string cpf, Stats stats, double? salary = null,
    List<Student>? classroom = null, Group? group = null) : this(firstName, lastName, birthday, cpf, stats)
    {
        TeacherGroup = group == null ? Group.A : group.Value;
        Salary = SalaryValidation(salary, _salary);
        _classroom = classroom ?? [];
    }

    static double SalaryValidation(double? salary, double _salary)
    {
        if (salary == null)
            return _salary;
        if (salary >= _salary)
            return salary.Value;
        return _salary;
    }

    public void SetClassroom(List<Student> classroom)
    {
        foreach (Student student in classroom)
        {
            _classroom.Add(student);
        }
    }

    public void AddStudent(Student student) => _classroom.Add(student);
    public void RemoveStudent(Student student) => _classroom.Remove(student);
    public IReadOnlyList<Student> GetStudents() => _classroom;

    public string FirstNameIO { get => FirstName; set => FirstName = value; }
    public string LastNameIO { get => LastName; set => LastName = value; }
    public DateTime BirthdayIO { get => Birthday; set => Birthday = value; }
    public string CpfIO { get => Cpf; set => Cpf = value; }
    public Stats StatsIO { get => Stats; set => Stats = value; }
    public Group GroupIO { get => TeacherGroup; set => TeacherGroup = value; }
    public double SalaryIO { get => Salary; set => Salary = value; }

}
