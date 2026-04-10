using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class NameObject
{
    private readonly IClienteRepository _clienteRepository;

    public string Name { get; private set; }

    public NameObject(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new Exception("Name field is empty");

        this.Name = name;
    }
}
