namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class ChavePixObject : BaseStringValueObject
{
    private const int CpfMinLength = 9;

    public string ChavePix { get; set; } = string.Empty;

    public ChavePixObject(string chavePix)
    {
        CheckForEmptiness(chavePix);
        CheckLength(chavePix, CpfMinLength);

        ChavePix = chavePix;
    }
}
