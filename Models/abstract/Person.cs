namespace schoolApp.Models.@abstract;

using Stats = schoolApp.Types.@Enums.Stats;

public abstract class Person
{
    protected string FirstName { get; set; } = "";
    protected string LastName { get; set; } = "";
    protected DateTime Birthday { get; set; }
    protected string Cpf { get; set; } = "";
    protected Stats Stats { get; set; }


    public static DateTime CreateData
    {
        get => CreateData;
        set => CreateData = value;
    }

    public static DateTime UpdateData
    {
        get => UpdateData;
        set => UpdateData = value;
    }

    public string StringCreateData(string format = "dd/MM/YYYY")
    {
        return CreateData.ToString(format);
    }

    public string StringUpdateData(string format = "dd/MM/YYYY")
    {
        return UpdateData.ToString(format);
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}
