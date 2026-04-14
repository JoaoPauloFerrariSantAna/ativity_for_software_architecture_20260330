namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class CpfObject
{
    private const int cpf_min_length = 9;
    
    public string Cpf = string.Empty;

    public CpfObject(string cpf)
    {
        if (cpf == string.Empty)
            throw new Exception("Cpf field must be filled");

        if (cpf.Length < cpf_min_length || cpf.Length > cpf_min_length)
            throw new Exception("Cpf field must have valid length of nine");

        // TODO: search for cpf in database (isCpfUnique)

        this.Cpf = cpf;
    }
}
