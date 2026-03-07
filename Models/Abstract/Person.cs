using Stats = schoolApp.Types.@Enums.Stats;
using FlagTime = schoolApp.Types.@Enums.FlagTimeDataType;

namespace schoolApp.Models.@Abstract;

public abstract class Person
{
    protected string FirstName { get; set; } = "";
    protected string LastName { get; set; } = "";
    protected DateTime Birthday { get; set; }
    protected string Cpf { get; set; } = "";
    protected Stats Stats { get; set; }
    protected DateTime CreateData { get; init; }
    protected DateTime UpdateData { get; set; }

    protected Person(string firstName, string lastName,
    DateTime birthday, string cpf, Stats stats)
    {
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        Cpf = cpf;
        Stats = stats;
    }

    public string StringTimeData(FlagTime Time, string format = "dd/MM/yyyy")
    {
        string stringDate = Time switch
        {
            FlagTime.Create => Birthday.ToString(format),
            FlagTime.Update => UpdateData.ToString(format),
            FlagTime.Birthday => Birthday.ToString(format),
            _ => throw new NotImplementedException()
        };
        return stringDate;
    }

    public void RefreshUpdateData()
    {
        UpdateData = DateTime.Now;
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}
