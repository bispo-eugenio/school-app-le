using Student = schoolApp.Models.Student;
using Teacher = schoolApp.Models.Teacher;
using Stats = schoolApp.Types.Enums.Stats;
using Group = schoolApp.Types.Enums.Group;

namespace schoolApp.Types;

public interface IPersonFactory
{
    Student CreateStudent(string firstname,
    string lastname, DateTime birthday,
    string cpf, Stats stats,
    List<double>? grade = null, Group? group = null);
    Teacher CreateTeacher(string firstname,
    string lastname, DateTime birthday,
    string cpf, Stats stats, double? salary = null,
    List<Student>? classroom = null, Group? group = null);

}
