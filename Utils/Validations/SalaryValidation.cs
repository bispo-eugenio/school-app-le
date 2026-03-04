using schoolApp.Types;
using System.Globalization;
namespace schoolApp.Utils.@Validations;

public class SalaryValidation : IValidator<string>
{
    private static readonly ProjectConstants constants = new();
    public bool IsValid(string value)
    {
        if (value.Length == 0
        && String.IsNullOrWhiteSpace(value))
            return false;
        if (!Decimal.TryParse(
            value,
            NumberStyles.Number,
            CultureInfo.GetCultureInfo("pt-BR"),
            out decimal result))
            return false;
        return Decimal.Parse(value) >= constants.GetSalary;
    }
}
