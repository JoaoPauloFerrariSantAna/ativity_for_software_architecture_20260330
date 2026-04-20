using System.Diagnostics;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

public class ContaBancaria
{
    public Guid Id { get; set; }
    public string Agencia { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Banco { get; set; } = string.Empty;

    public ContaBancaria(string agencia, string numero, string banco)
    {
        Id = Guid.NewGuid();
        Agencia = agencia;
        Numero = numero;
        Banco = banco;
    }
}