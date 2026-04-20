using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private static List<Cliente> _clientes = new List<Cliente>();

    public List<Cliente> All() { return _clientes; }

    public bool IsInDatabase(Guid id) { return (_clientes.Find(c => id == c.Id) != null); }
    
    public bool HasCarteira(Guid carteiraId) {
        return (_clientes.Find(c => carteiraId == c.Carteira.Id) != null);
    }

    public Cliente Get(Guid id) { return _clientes.Find(cl => id == cl.Id); }

    public void Post(Cliente cliente)
    {
        if (cliente == null)
            throw new Exception("Client data is empty");
        
        if (IsInDatabase(cliente.Id) && !IsCpfUnique(cliente.Cpf))
            throw new Exception("Cliente is in database already");
        
        _clientes.Add(cliente);
    }

    public void Update(Cliente cliente)
    {
        Cliente c = null;
        
        if (cliente == null)
            throw new Exception("Client data is empty");
        
        if(!IsInDatabase(cliente.Id))
            throw new Exception("Cliente does not exists");
        
        c = Get(cliente.Id);
        c = cliente;
    }

    public void Delete(Guid id)
    {
        if (!IsInDatabase(id))
            throw new Exception("Cliente does not exists");
        
        _clientes.Remove(Get(id));
    }

    public Carteira GetCarteira(Guid carteiraId)
    {
        if (!HasCarteira(carteiraId))
            throw new Exception("Cliente has no Carteira");
        
        return _clientes.Find(cliente => carteiraId == cliente.Carteira.Id).Carteira;
    }

    public bool IsCpfUnique(string cpf)
    {
        return (_clientes.Find(c => cpf == c.Cpf) == null);
    }
}