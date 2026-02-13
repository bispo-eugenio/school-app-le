namespace schoolApp.Models.@abstract;

using Stats = schoolApp.Types.@Enums.Stats;
using FlagTime = schoolApp.Types.@Enums.FlagTimeDataType;

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
        if (Time == FlagTime.Create)
            return CreateData.ToString(format);
        else if (Time == FlagTime.Update)
            return UpdateData.ToString(format);
        return ""; // Colocar uma exceção no lugar da string falsy;

    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}
