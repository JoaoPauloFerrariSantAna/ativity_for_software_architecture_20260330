using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class NomeObject : BaseStringValueObject
{
    public string Nome { get; private set; }

    public NomeObject(string nome)
    {
        CheckForEmptiness(nome);

        Nome = nome;
    }
}