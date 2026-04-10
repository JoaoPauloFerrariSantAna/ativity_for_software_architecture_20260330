namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;

public class MetodoPagamentoObject
{
    public MetodoPagamento MetodoPagamento { get; private set; }

    public MetodoPagamentoObject(MetodoPagamento metodoPagamento)
    {
        if (!Enum.IsDefined<MetodoPagamento>(metodoPagamento)) throw new Exception("unknown payment method");

        this.MetodoPagamento = metodoPagamento;
    }
}