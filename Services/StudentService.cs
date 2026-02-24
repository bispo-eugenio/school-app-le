using Student = schoolApp.Models.Student;
using IStudentService = schoolApp.Types.IStudentService;
using Group = schoolApp.Types.@Enums.Group;
using PersonFactory = schoolApp.Models.PersonFactory;
using Stats = schoolApp.Types.@Enums.Stats;
using GradeStats = schoolApp.Types.@Enums.GradeStats;
using LogicOperatorMode = schoolApp.Types.@Enums.LogicOperatorMode;

namespace schoolApp.Services;

public class StudentService : IStudentService
{
    private readonly List<Student> students = [];


    public void AddStudent(string firstname, string lastname,
    DateTime birthday, string cpf, Stats stats,
    List<decimal>? grade = null, Group? group = null)
    {
        Student student = new PersonFactory().CreateStudent(firstname,
        lastname, birthday, cpf, stats, grade, group);
        students.Add(student);
    }

    public IReadOnlyList<Student> GetAllStudent()
    {
        return students;
    }

    public bool UpdateStudentById(int id, Student data)
    {
        foreach (Student student in students)
        {
            if (student.StudentRegister == id)
            {
                student.FirstNameIO = data.FirstNameIO;
                student.LastNameIO = data.LastNameIO;
                student.BirthdayIO = data.BirthdayIO;
                student.CpfIO = data.CpfIO;
                student.StatsIO = data.StatsIO;
                student.SetGrade(data.Grade().ToList());
                student.GroupIO = data.GroupIO;
                return true;
            }
        }
        return false;
    }

    public bool RemoveStudentById(int id)
    {
        foreach (Student student in students)
        {
            if (student.StudentRegister == id)
            {
                students.Remove(student);
                return true;
            }
        }
        return false;
    }

    public bool UpdateGradeById(int id, List<decimal> grade)
    {
        foreach (Student student in students)
        {
            if (student.StudentRegister == id)
            {
                student.SetGrade(grade);
                return true;
            }
        }
        return false;
    }

    public Student? GetRegisterById(int id)
    {
        foreach (Student student in students)
        {
            if (student.StudentRegister == id)
            {
                return student;
            }
        }
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
                throw new Exception("Opção inválida");
        }
    }

}
