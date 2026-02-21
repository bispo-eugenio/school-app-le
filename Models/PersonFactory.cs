using IPersonFactory = schoolApp.Types.IPersonFactory;
using Stats = schoolApp.Types.Enums.Stats;
using Group = schoolApp.Types.Enums.Group;

namespace schoolApp.Models;

public class PersonFactory : IPersonFactory
{

    public PersonFactory() { }

    public Student CreateStudent(string firstname,
    string lastname, DateTime birthday,
    string cpf, Stats stats,
    List<double>? grade = null, Group? group = null)
    {
        if (grade != null && group != null)
        {
            return new Student(firstname, lastname,
            birthday, cpf, stats, grade, group.Value);
        }
        else if (grade != null)
        {
            return new Student(firstname, lastname,
            birthday, cpf, stats, grade);
        }
        else if (group != null)
        {
            return new Student(firstname, lastname,
            birthday, cpf, stats, group.Value);
        }
        return new Student(firstname, lastname, birthday, cpf, stats);
    }

    public Teacher CreateTeacher(string firstname,
    string lastname, DateTime birthday,
    string cpf, Stats stats, double? salary = null,
    List<Student>? classroom = null)
    {
        if (salary != null && classroom != null)
        {
            return new Teacher(firstname, lastname,
            birthday, cpf, stats, salary.Value, classroom);
        }
        else if (salary != null)
        {
            return new Teacher(firstname, lastname, birthday, cpf, stats, salary.Value);
        }
        else if (classroom != null)
        {
            return new Teacher(firstname, lastname,
            birthday, cpf, stats, classroom);
        }
        return new Teacher(firstname, lastname, birthday, cpf, stats);
    }

}
