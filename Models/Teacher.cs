using schoolApp.Models.@Abstract;
using schoolApp.Types.Enums;
using schoolApp.Utils;

namespace schoolApp.Models;

public class Teacher : Person
{
    private static int _id;
    private readonly List<Student> _classroom;
    private static readonly ProjectConstants _constants = new();
    private decimal Salary { get; set; }
    private Group TeacherGroup { get; set; }
    public int TeacherRegister { get; init; }

    public Teacher(string firstName, string lastName,
    DateTime birthday, string cpf, Stats stats) : base(
    firstName, lastName, birthday, cpf, stats)
    {
        TeacherRegister = ++_id;
        Salary = _constants.GetSalary;
        _classroom = [];
    }

    public Teacher(string firstName, string lastName,
    DateTime birthday, string cpf, Stats stats, decimal? salary = null,
    List<Student>? classroom = null, Group? group = null) : this(firstName, lastName, birthday, cpf, stats)
    {
        TeacherGroup = group == null ? Group.A : group.Value;
        Salary = SalaryValidation(salary, _constants.GetSalary);
        _classroom = classroom ?? [];
    }

    static decimal SalaryValidation(decimal? salary, decimal baseSalary)
    {
        if (salary == null)
            return baseSalary;
        if (salary >= baseSalary)
            return salary.Value;
        return baseSalary;
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
    public decimal SalaryIO { get => Salary; set => Salary = value; }

}
