using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

public interface IClienteRepository
{
    public Cliente GetCliente(int id);
    public List<Cliente> All();
    public void Post(Cliente cliente);
    public void Update(Cliente cliente);
    public void Delete(int id);
    public void Deposit(Cliente cliente, decimal amount);
    public bool IsInDatabase(int id);
}