using schoolApp.Models;
using schoolApp.Types.Enums;

namespace schoolApp.Types;

public interface ITeacher
{
    int TeacherRegister { get; }
    DateTime BirthdayIO { get; set; }
    string FirstNameIO { get; set; }
    string LastNameIO { get; set; }
    string CpfIO { get; set; }
    Group GroupIO { get; set; }
    decimal SalaryIO { get; set; }

    IReadOnlyList<Student> GetStudents();
    void SetClassroom(List<Student> students);
    void AddStudent(Student student);
    void RemoveStudent(Student student);

}
