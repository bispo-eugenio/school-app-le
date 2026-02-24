using ITeacherService = schoolApp.Types.ITeacherService;
using Teacher = schoolApp.Models.Teacher;
using Stats = schoolApp.Types.@Enums.Stats;
using Student = schoolApp.Models.Student;
using PersonFactory = schoolApp.Models.PersonFactory;
using Group = schoolApp.Types.@Enums.Group;
using LogicOperatorMode = schoolApp.Types.@Enums.LogicOperatorMode;

namespace schoolApp.Services;

public class TeacherService : ITeacherService
{
    private readonly List<Teacher> teachers = [];

    public void AddTeacher(string firstname, string lastname,
    DateTime birthday, string cpf, Stats stats,
    decimal? salary = null, List<Student>? classroom = null)
    {
        Teacher teacher = new PersonFactory().CreateTeacher(firstname, lastname,
        birthday, cpf, stats, salary, classroom);
        teachers.Add(teacher);
    }

    public IReadOnlyList<Teacher> GetAllTeacher()
    {
        return teachers;
    }

    public bool UpdateTeacherById(int id, Teacher data)
    {
        foreach (Teacher teacher in teachers)
        {
            if (teacher.TeacherRegister == id)
            {
                teacher.FirstNameIO = data.FirstNameIO;
                teacher.LastNameIO = data.LastNameIO;
                teacher.BirthdayIO = data.BirthdayIO;
                teacher.CpfIO = data.CpfIO;
                teacher.StatsIO = data.StatsIO;

                teacher.GroupIO = data.GroupIO;
                return true;
            }
        }
        return false;
    }

    public bool RemoveTeacherById(int id)
    {
        foreach (Teacher teacher in teachers)
        {
            if (teacher.TeacherRegister == id)
            {
                teachers.Remove(teacher);
                return true;
            }
        }
        return false;
    }

    public Teacher? GetRegisterById(int id)
    {
        foreach (Teacher teacher in teachers)
        {
            if (teacher.TeacherRegister == id)
            {
                return teacher;
            }
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
                throw new Exception("Operação inválida");
        }
    }


}
