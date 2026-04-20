namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;

public class BaseCarteiraRequest
{
    public Guid IdContaBancaria { get; set; }
    public decimal Saldo { get; set; }


    public BaseCarteiraRequest(Guid idContaBancaria, decimal saldo)
    {
        IdContaBancaria = idContaBancaria;
        Saldo = saldo;
    }
}
