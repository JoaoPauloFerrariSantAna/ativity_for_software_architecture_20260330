namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;

public class MetodoPagamentoObject : BaseObject
{
    public MetodoPagamento MetodoPagamento { get; set; }

    public MetodoPagamentoObject(MetodoPagamento metodoPagamento)
    {
        Validate();
    }

    public bool MethodIsValid(MetodoPagamento metodoPagamento)
    {
        if (!Enum.IsDefined<MetodoPagamento>(metodoPagamento))
        {
            return false;
        }

        return true;
    }

    public override void Validate()
    {
        if (!MethodIsValid(MetodoPagamento))
        {
            throw new Exception("Payment method is invalid");
        }
    }
}