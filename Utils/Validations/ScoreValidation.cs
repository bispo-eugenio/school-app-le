using schoolApp.Types;
using Spectre.Console;
using System.Globalization;
namespace schoolApp.Utils.@Validations;

public class ScoreValidation : IValidator<string>
{
    public bool IsValid(string value)
    {

        if (String.IsNullOrWhiteSpace(value))
            return false;
        if (!Decimal.TryParse(
            value,
            NumberStyles.Number,
            CultureInfo.GetCultureInfo("pt-BR"),
            out decimal result))
            return false;

        return result >= 0 && result <= 10;
    }
}
