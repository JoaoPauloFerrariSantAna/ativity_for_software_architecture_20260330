namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class CvvObject : BaseStringValueObject
{
    const int CvvMaxLength = 3;

    public string Cvv { get; private set; }

    public CvvObject(string cvv)
    {
        CheckForEmptiness(cvv);
        CheckLength(cvv, CvvMaxLength);

        Cvv = cvv;
    }
}
