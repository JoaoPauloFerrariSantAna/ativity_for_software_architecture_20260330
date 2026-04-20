namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class EmailObject : BaseStringValueObject
{
    public string Email { get; private set; }

    public EmailObject(string email)
    {
        CheckLength(email);
        
        if (!email.Contains('@')) throw new Exception("Email is invalid");

        Email = email;
    }
}