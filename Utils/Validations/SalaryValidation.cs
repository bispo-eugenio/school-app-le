using schoolApp.Types;
namespace schoolApp.Utils.@Validations;


public class SalaryValidation : IValidator<string>
{
    private static readonly Constants constants = new Constants();
    public bool IsValid(string value)
    {
        if (value.Length == 0 ||
        double.TryParse(value, out double type) ||
        String.IsNullOrWhiteSpace(value))
            return false;
        return true;
    }
}
