namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;

public class PixPostRequest : BaseCarteiraRequest
{
    public PixPostRequest(Guid idContaBancaria, decimal saldo) : base(idContaBancaria, saldo)
    {
    }
}