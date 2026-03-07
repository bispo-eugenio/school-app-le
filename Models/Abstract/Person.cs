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
    protected DateTime CreateData { get; set; }
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
        if (Time != FlagTime.Create && Time != FlagTime.Update)
                   throw new(""); // Colocar uma exceção;
        return Time == FlagTime.Create ? CreateData.ToString(format) : UpdateData.ToString(format);
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}
