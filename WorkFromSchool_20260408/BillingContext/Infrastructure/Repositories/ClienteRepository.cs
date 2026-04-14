using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;

using DatabaseEntities = List<Cliente>;

public class ClienteRepository : IClienteRepository
{
    private static DatabaseEntities _clienteList = new List<Cliente>();

    public void Deposit(Cliente cliente, decimal amount)
    {
        throw new NotImplementedException();
    }

    public DatabaseEntities All()
    {
        return _clienteList;
    }

    public void Post(Cliente cliente)
    {
        if (cliente == null) throw new Exception("Client data is empty");

        if (IsInDatabase(cliente.Id)) throw new Exception("It is in database already");

        // TODO: Add more fields tto validate

        _clienteList.Add(cliente);
    }
    public void Update(Cliente cliente)
    {
        // it is ok to just place this:
        // ClienteRepository::GetCliente returns an exception if the id is not found in DB
        // witch will go down in the callstack
        Cliente c = GetCliente(cliente.Id);
        c = cliente;
    }

    public void Delete(Guid id)
    {
        // it is ok to just place this:
        // ClienteRepository::GetCliente returns an exception if the id is not found in DB
        // witch will go down in the callstack
        _clienteList.Remove(GetCliente(id));
    }

    public Cliente GetCliente(Guid id)
    {
        if(!IsInDatabase(id)) throw new Exception("Cliente is not in database");
        return _clienteList.Find(cl => id == cl.Id);
    }

    public Carteira GetCarteira(Guid carteiraId)
    {
        Carteira ca = null;
        if (!HasCarteira(carteiraId)) throw new Exception("Cliente has no Carteira");
        foreach (Cliente c in _clienteList) if (carteiraId == c.Carteira.Id) ca = c.Carteira;
        return ca;
    }

    public bool IsInDatabase(Guid id)
    {
        foreach (Cliente c in _clienteList) if (id == c.Id) return true;
        return false;
    }

    public bool HasCarteira(Guid carteiraId)
    {
        foreach (Cliente c in _clienteList) if (carteiraId == c.Carteira.Id) return true;
        return false;
    }
}