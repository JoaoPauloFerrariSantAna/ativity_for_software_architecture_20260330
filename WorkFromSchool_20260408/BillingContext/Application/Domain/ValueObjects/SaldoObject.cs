namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class SaldoObject
{
    public decimal Saldo { get; private set; }

    public SaldoObject(decimal saldo)
    {
        if (saldo < 0) throw new Exception("Saldo must be positive!");

        Saldo = saldo;
    }
}