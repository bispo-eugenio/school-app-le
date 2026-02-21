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
        return new Student(firstname, lastname,
            birthday, cpf, stats, grade, group);
    }

    public Teacher CreateTeacher(string firstname,
    string lastname, DateTime birthday,
    string cpf, Stats stats, double? salary = null,
    List<Student>? classroom = null, Group? group = null)
    {
        return new Teacher(firstname, lastname,
        birthday, cpf, stats, salary, classroom, group);
    }

}
