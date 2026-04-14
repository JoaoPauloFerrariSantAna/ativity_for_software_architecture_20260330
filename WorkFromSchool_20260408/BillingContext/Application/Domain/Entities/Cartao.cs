using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

public class Cartao : Carteira
{
    public TipoCartao Tipo { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    public string NomeTitular { get; set; } = string.Empty;
    public DateOnly Validade { get; set; }

}