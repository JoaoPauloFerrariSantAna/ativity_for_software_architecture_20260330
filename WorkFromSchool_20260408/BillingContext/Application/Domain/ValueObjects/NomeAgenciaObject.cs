namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class NomeAgenciaObject : BaseStringValueObject
{
    public string Agencia { get; set; } = string.Empty;

    public NomeAgenciaObject(string agencia)
    {
        CheckForEmptiness(agencia);

        Agencia = agencia;
    }
}
