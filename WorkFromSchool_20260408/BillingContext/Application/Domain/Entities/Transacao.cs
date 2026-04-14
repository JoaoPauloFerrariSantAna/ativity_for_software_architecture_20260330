using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

public class Transacao
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DestinatarioTipo Destinatario { get; set; }
    public MetodoPagamento? MetodoPagamento { get; set; }
    public ContaBancaria? ContaBancaria { get; set; }
    public bool Validacao { get; set; }
}