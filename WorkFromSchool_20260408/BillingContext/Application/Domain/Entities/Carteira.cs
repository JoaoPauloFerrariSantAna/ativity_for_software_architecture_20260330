namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

public class Carteira
{
    public Guid Id { get; set; }
    public decimal Saldo { get; set; }
    public static List<ContaBancaria> ContaBancarias { get; set; } = new List<ContaBancaria>();

    public Carteira(decimal saldo, ContaBancaria contaBancaria)
    {
        Id = Guid.NewGuid();
        Saldo = saldo;
        Attach(contaBancaria);
    }

    private void Attach(ContaBancaria contaBancaria)
    {
        ContaBancarias.Add(contaBancaria);
    }
}