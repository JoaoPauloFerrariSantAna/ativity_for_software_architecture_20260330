namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class EmailObject
{
    public string Email { get; set; } = string.Empty;

    public EmailObject(string email)
    {
        if (!string.IsNullOrEmpty(email)) throw new Exception("Email field must be filled");

        if (!email.Contains('@')) throw new Exception("Email is invalid");

        this.Email = email;
    }
}
