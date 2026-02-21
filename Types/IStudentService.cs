using Stats = schoolApp.Types.Enums.Stats;
using Student = schoolApp.Models.Student;
using Group = schoolApp.Types.Enums.Group;
using GradeStats = schoolApp.Types.@Enums.GradeStats;
using LogicOperatorMode = schoolApp.Types.@Enums.LogicOperatorMode;

namespace schoolApp.Types;

public interface IStudentService
{
    void AddStudent(string firstname, string lastname,
    DateTime birthday, string cpf, Stats stats,
    List<double>? grade = null, Group? group = null);
    bool RemoveStudentById(int studentRegister);
    Student? GetRegisterById(int studentRegister);
    bool UpdateStudentById(int studentRegister, Student data);
    bool UpdateGradeById(int studentRegister, List<double> grade);
    IReadOnlyList<Student> GetAllStudent();
    IReadOnlyList<Student> GetStudentByGroup(Group group);
    IReadOnlyList<Student> GetStudentByStats(Stats stats);
    IReadOnlyList<Student> GetStudentsByAverange(double averange, LogicOperatorMode mode);
    IReadOnlyList<Student> GetStudentsGradeStats(GradeStats gradeStats);
}
