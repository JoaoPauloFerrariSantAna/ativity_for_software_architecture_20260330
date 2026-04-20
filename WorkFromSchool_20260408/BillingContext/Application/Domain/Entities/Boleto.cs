namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

public class Boleto : Carteira
{
    public Guid Id { get; set; }
    public string CodigoBoleto { get; set; } = string.Empty;

    public Boleto(string codigoBoleto, decimal saldo, ContaBancaria contaBancarias) : base(saldo, contaBancarias)
    {
        Id = Guid.NewGuid();
        CodigoBoleto = codigoBoleto;
    }
}
