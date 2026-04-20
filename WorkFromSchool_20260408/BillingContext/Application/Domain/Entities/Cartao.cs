using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

public class Cartao : Carteira
{
    public TipoCartao Tipo { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    public string NomeTitular { get; set; } = string.Empty;
    public DateOnly Validade { get; set; }

    public Cartao(string numero, string cvv, string nomeTitular, decimal saldo,
        DateOnly validade, ContaBancaria conta) : base(saldo, conta)
    {
        Numero = numero;
        CVV = cvv;
        NomeTitular = nomeTitular;
        Validade = validade;
    }
}