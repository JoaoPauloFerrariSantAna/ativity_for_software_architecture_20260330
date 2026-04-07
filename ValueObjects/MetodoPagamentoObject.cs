using ConsoleApp2.Enums;

namespace Jwt.ValueObjects;

public class MetodoPagamentoObject : BaseObject
{
    public MetodoPagamento MetodoPagamento { get; set; }

    public MetodoPagamentoObject(MetodoPagamento metodoPagamento)
    {
        Validate();
    }

    public override void Validate()
    {
        if (!MethodIsValid(MetodoPagamento))
        {
            throw new Exception("Payment method is invalid");
        }
    }

    public bool MethodIsValid(MetodoPagamento metodoPagamento)
    {
        if (!Enum.IsDefined<MetodoPagamento>(metodoPagamento))
        {
            return false;
        }

        return true;
    }
}
