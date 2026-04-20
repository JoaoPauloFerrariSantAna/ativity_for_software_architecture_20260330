namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class NomeBanco : BaseStringValueObject
{
    public string Banco { get; set; } = string.Empty;

    public NomeBanco(string banco)
    {
        CheckForEmptiness(banco);

        Banco = banco;
    }
}
