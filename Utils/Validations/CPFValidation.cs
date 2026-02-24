using CPFCNPJ;
using schoolApp.Types;

namespace schoolApp.Utils.@Validations;

public class CPFValidation : IValidator<string>
{
    private static readonly Main manager = new Main();

    public bool IsValid(string cpf)
    {
        return manager.IsValidCPFCNPJ(cpf);
    }

}
