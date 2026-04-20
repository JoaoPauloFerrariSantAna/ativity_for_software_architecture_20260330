namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class CodigoBoleto : BaseStringValueObject
{
    public string Codigo { get; private set; } = string.Empty;

    public CodigoBoleto(string codigo)
    {
        CheckForEmptiness(codigo);
        CheckLength(codigo, 48);

        Codigo = codigo;
    }
}