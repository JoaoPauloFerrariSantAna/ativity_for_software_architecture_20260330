namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

public class Pix : Carteira
{
    public string ChavePix { get; set; } = string.Empty;

    public Pix(string chavePix, decimal saldo, ContaBancaria contaBancarias) : base(saldo, contaBancarias)
    {
        ChavePix = chavePix;
    }
}