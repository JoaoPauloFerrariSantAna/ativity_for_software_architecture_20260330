using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
public interface IClienteRepository
{
    public Cliente GetCliente(Guid id);
    public Carteira GetCarteira(Guid carteiraId);
    public List<Cliente> All();
    public void Post(Cliente cliente);
    public void Update(Cliente cliente);
    public void Delete(Guid id);
    public void Deposit(Cliente cliente, decimal amount);
    public bool IsInDatabase(Guid id);
    public bool HasCarteira(Guid carteiraId);
}