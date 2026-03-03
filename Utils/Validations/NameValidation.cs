using schoolApp.Types;

namespace schoolApp.Utils.@Validations;

public class NameValidation : IValidator<string>
{

    public bool IsValid(string value)
    {
        if (value.Length == 0 || value.Length < 3
        || String.IsNullOrWhiteSpace(value)
        || !value.All(char.IsLetter))
            return false;
        return true;
    }

}
