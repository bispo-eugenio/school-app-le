using Group = schoolApp.Types.@Enums.Group;

namespace schoolApp.Types;

public interface IStudent
{
    int StudentRegister { get; }
    DateTime BirthdayIO { get; set; }
    string FirstNameIO { get; set; }
    string LastNameIO { get; set; }
    string CpfIO { get; set; }
    Group GroupIO { get; set; }

    IReadOnlyList<double> Grade();
    void SetGrade(List<double> grade);
}
