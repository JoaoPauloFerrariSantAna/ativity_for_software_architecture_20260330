namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class AmountObject : BaseObject
{
    public decimal Amount;

    public AmountObject(decimal amount)
    {
        Validate();
    }

    public bool ValidateAmount(decimal amount)
    {
        if (amount < 0)
        {
            return false;
        }

        return true;
    }

    public override void Validate()
    {
        if (!ValidateAmount(Amount))
        {
            throw new Exception("amount must be positive");
        }
    }
}