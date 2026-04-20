namespace Billing.Domain.ValueObjects;

public record NumeroCartao
{
    const int NumeroMinLength = 13;

    public string Numero { get; private set; }

    public NumeroCartao(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero) || numero.Length < NumeroMinLength || numero.Length > NumeroMinLength)
            throw new ArgumentException("Número do cartão inválido.");

        Numero = numero;
    }
}