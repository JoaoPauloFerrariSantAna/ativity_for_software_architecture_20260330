namespace Billing.Domain.ValueObjects;

public record NumeroCartao
{
    public string Numero { get; }

    public NumeroCartao(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero) || numero.Length < 13)
            throw new ArgumentException("Número do cartão inválido.");

        Numero = numero;
    }
}