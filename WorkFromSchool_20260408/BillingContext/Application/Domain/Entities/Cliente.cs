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
        Id = Guid.NewGuid();
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Carteira = carteira;
    }

    public void Deposit(decimal amount)
    {
        this.Carteira.Saldo += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.Carteira.Saldo -= amount;
    }
}