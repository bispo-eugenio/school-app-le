namespace schoolApp.Models.@abstract;

public abstract class Person
{
    public abstract string FirstName { get; set; }
    public abstract string LastName { get; set; }
    public abstract DateTime Birthday { get; set; }
    public abstract string Cpf { get; set; }
    public abstract DateTime CreateData { get; set; }
    public abstract DateTime UpdateData { get; set; }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
    public abstract void SetCreateData();
    public abstract void SetUpdateData();
}
