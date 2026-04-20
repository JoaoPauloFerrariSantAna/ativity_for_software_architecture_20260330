using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;

public class CartaoPostRequest : BaseCarteiraRequest
{
    public string Numero { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    public string NomeTitular { get; set; } = string.Empty;
    public TipoCartao Tipo { get; set; }
    public DateOnly Validade { get; set; }

    public CartaoPostRequest(string numero, string cvv, string nomeTitular, decimal saldo,
        TipoCartao tipo, DateOnly validade, Guid idContaBancaria) 
        : base(idContaBancaria, saldo)
    {
        Numero = numero;
        CVV = cvv;
        NomeTitular = nomeTitular;
        Tipo = tipo;
        Validade = validade;
    }
}