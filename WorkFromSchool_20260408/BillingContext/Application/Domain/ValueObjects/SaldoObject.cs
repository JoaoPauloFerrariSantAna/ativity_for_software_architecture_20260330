namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class AmountObject
{
    public decimal Amount;

    public AmountObject(decimal amount)
    {
        if (amount < 0) throw new Exception("Amount must be positive!");
    }
}