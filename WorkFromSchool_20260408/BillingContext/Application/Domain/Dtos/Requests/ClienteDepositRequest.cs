using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;

public class ClienteDepositRequest
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public MetodoPagamento Metodo { get; set; }

    public ClienteDepositRequest(int id, decimal amount, MetodoPagamento metodo)
    {
        this.Id = id;
        this.Amount = amount;
        this.Metodo = metodo;
    }
}