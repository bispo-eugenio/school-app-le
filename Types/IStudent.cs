using schoolApp.Types.Enums;
using Group = schoolApp.Types.@Enums.Group;
using GradeStats = schoolApp.Types.@Enums.GradeStats;

namespace schoolApp.Types;

public interface IStudent
{
    int StudentRegister { get; }
    DateTime BirthdayIO { get; set; }
    string FirstNameIO { get; set; }
    string LastNameIO { get; set; }
    string CpfIO { get; set; }
    Group GroupIO { get; set; }
    Stats StatsIO { get; set; }

    IReadOnlyList<double> Grade();
    void SetGrade(List<double> grade);
    double Average();
    GradeStats GetGradeStats();
}
