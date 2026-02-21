using Teacher = schoolApp.Models.Teacher;
using Student = schoolApp.Models.Student;
using Group = schoolApp.Types.@Enums.Group;
using Stats = schoolApp.Types.@Enums.Stats;
using LogicOperatorMode = schoolApp.Types.@Enums.LogicOperatorMode;

namespace schoolApp.Types;

public interface ITeacherService
{
    void AddTeacher(string firstname, string lastname,
    DateTime birthday, string cpf, Stats stats,
    double? salary = null, List<Student>? classroom = null);
    bool RemoveTeacherById(int teacherRegister);
    bool UpdateTeacherById(int teacherRegister, Teacher data);
    Teacher? GetRegisterById(int teacherRegister);
    IReadOnlyList<Teacher> GetAllTeacher();
    IReadOnlyList<Teacher> GetTeacherByGroup(Group group);
    IReadOnlyList<Teacher> GetTeacherByStats(Stats stats);
    IReadOnlyList<Teacher> GetTeacherBySalary(double value, LogicOperatorMode mode);
}
