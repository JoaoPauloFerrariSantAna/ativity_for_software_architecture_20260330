using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;
public class ClienteRepository : IClienteRepository
{
    private static List<Cliente> clienteList = new List<Cliente>();

    public void Deposit(Cliente cliente, decimal amount)
    {
        throw new NotImplementedException();
    }

    public Cliente GetCliente(int id)
    {
        throw new NotImplementedException();
    }

    public bool IsInDatabase(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Cliente cliente)
    {
        throw new NotImplementedException();
    }
}