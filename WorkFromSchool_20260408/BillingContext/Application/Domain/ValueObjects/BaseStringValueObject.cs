namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class BaseStringValueObject
{
    public void CheckForEmptiness(string value)
    {
        if (String.IsNullOrEmpty(value)) throw new Exception("Value is empty");
    }

    public void CheckLength(string value, int max)
    {
        if (value.Length < max || value.Length > max) throw new Exception("Field must have valid length");
    }
}
