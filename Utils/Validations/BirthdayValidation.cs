using System.Globalization;
using schoolApp.Types;

namespace schoolApp.Utils.@Validations;

public class BirthdayValidation : IValidator<string>
{

    private static readonly string _format = "dd/MM/yyyy";

    public bool IsValid(string datetime)
    {
        return DateTime.TryParseExact(datetime,
        _format, CultureInfo.GetCultureInfo("pt-BR"),
        DateTimeStyles.AdjustToUniversal, out DateTime data);
    }

}
