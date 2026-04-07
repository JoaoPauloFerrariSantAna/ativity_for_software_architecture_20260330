using Billing.Domain.Entities;
using Jwt.Interfaces;

namespace Jwt.Repositories;
{
    public class ClienteRepository : IClienteRepository
{
    private static List<Cliente> _clienteList = new List<Cliente>();

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
}
