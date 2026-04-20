namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class CpfObject : BaseStringValueObject
{
    private const int CpfMinLength = 9;
    
    public string Cpf { get; private set; } = string.Empty;

    public CpfObject(string cpf)
    {
        CheckForEmptiness(cpf);
        CheckLength(cpf, CpfMinLength);

        Cpf = cpf;
    }
}