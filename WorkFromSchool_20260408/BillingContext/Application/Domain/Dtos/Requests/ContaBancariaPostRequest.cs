namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;

public class ContaBancariaPostRequest
{
    public string Agencia { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Banco { get; set; } = string.Empty;
}