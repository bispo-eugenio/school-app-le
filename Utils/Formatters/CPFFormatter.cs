using schoolApp.Types;
using CPFCNPJ;
namespace schoolApp.Utils.@Formatters;

public class CPFFormatter : IFormatter<string>
{
    private static readonly Main _main = new();
    public string Format(string value)
    {
        return _main.FormatCPFCNPJ(value, CPFCNPJ.Enum.TypeString.CPF);
    }
}
