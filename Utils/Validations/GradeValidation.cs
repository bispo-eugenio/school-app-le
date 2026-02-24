using schoolApp.Types;

namespace schoolApp.Utils.@Validations;

public class GradeValidation : IValidator<List<double>>
{
    public bool IsValid(List<double> grade)
    {
        if (grade.Count != 2)
            return false;
        foreach (double index in grade)
        {
            if (index < 0 && index > 10)
                return false;
        }
        return true;
    }
}
