namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Carteira Carteira { get; set; }

    public Cliente(string nome, decimal amount, string cpf, string email, Carteira carteira)
    {
        Id = new Guid();
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Carteira = carteira;
    }

    public Cliente GetCliente(int id)
    {
        return null;
    }

    public void Deposit(decimal amount)
    {
        this.Carteira.Saldo += amount;
    }
}
