namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;

public class BoletoPostRequest : BaseCarteiraRequest
{

    public string CodigoBoleto { get; set; } = string.Empty;

    public BoletoPostRequest(Guid idContaBancaria, decimal saldo) : base(idContaBancaria, saldo)
    {
    }
}
